using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

using Model;
using Parser;
using System.Windows.Controls;
using System.Numerics;

namespace WPF3D//так же сделать манипулируемый источник света
{
    public class Object3D
    {
        private _3DModel[] arrayModel;
        public Point3D Center{ get; private set; }
        private MeshGeometry3D[] mesh;
        private ModelUIElement3D[] model;
        private PointRotater rotater = new PointRotater();
        private Color color = Colors.Chocolate;

        private float angleX = 0;
        private float angleY = 0;
        private float angleZ = 0;

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler MouseDownEvent;
        public event EventHandler MouseUpEvent;

        protected virtual void MouseDownEventFunction(object sender, EventArgs e)
        {
            EventHandler handler = MouseDownEvent;
            if (MouseDownEvent != null) handler(this, e);
        }

        protected virtual void MouseUpEventFunction(object sender, EventArgs e)
        {
            EventHandler handler = MouseUpEvent;
            if (MouseUpEvent != null) handler(this, e);
        }

        public Object3D(string path)//продумать на принятие готового объекта
        {
            Parcer parcer = new Parcer();
            arrayModel = parcer.Parce(path);
            mesh = new MeshGeometry3D[arrayModel.Length];
            model = new ModelUIElement3D[arrayModel.Length];
            double x=0;
            double y=0;
            double z=0;
            int count = 0;
            for (int i = 0; i < arrayModel.Length; i++)
            {
                foreach (var a in arrayModel[i].Triangles)
                {
                    x += a.GetPoint(0).X;
                    y += a.GetPoint(0).Y;
                    z += a.GetPoint(0).Z;
                    x += a.GetPoint(1).X;
                    y += a.GetPoint(1).Y;
                    z += a.GetPoint(1).Z;
                    x += a.GetPoint(2).X;
                    y += a.GetPoint(2).Y;
                    z += a.GetPoint(2).Z;
                    count += 3;
                }
            }
            Center = new Point3D(x/count, y/count, z/count);
        }//конструктор

        public Object3D(Object3D oldObject)
        {
            oldObject.Clone(this);
            double x = 0;
            double y = 0;
            double z = 0;
            int count = 0;
            for (int i = 0; i < arrayModel.Length; i++)
            {
                foreach (var a in arrayModel[i].Triangles)
                {
                    x += a.GetPoint(0).X;
                    y += a.GetPoint(0).Y;
                    z += a.GetPoint(0).Z;
                    x += a.GetPoint(1).X;
                    y += a.GetPoint(1).Y;
                    z += a.GetPoint(1).Z;
                    x += a.GetPoint(2).X;
                    y += a.GetPoint(2).Y;
                    z += a.GetPoint(2).Z;
                    count += 3;
                }
            }
            Center = new Point3D(x / count, y / count, z / count);
        }

        public void Draw(Viewport3D viewport)//доработать на предмет отмены отображения и модификации
        {//кроме отрисовки так же и назначает events
            int count = 0;
            if (arrayModel != null)
            {
                for(int i=0; i<mesh.Length; i++)
                {
                    mesh[i] = new MeshGeometry3D();
                    Vector3D vv = new Vector3D(-1,-1,-1);
                    foreach (var t in arrayModel[i].Triangles)
                    {
                        mesh[i].Positions.Add(t.GetPoint(0));
                        mesh[i].Positions.Add(t.GetPoint(1));
                        mesh[i].Positions.Add(t.GetPoint(2));

                        mesh[i].Normals.Add(t.GetNormal(0));
                        mesh[i].Normals.Add(t.GetNormal(1));
                        mesh[i].Normals.Add(t.GetNormal(2));

                        mesh[i].TriangleIndices.Add(0 + count);
                        mesh[i].TriangleIndices.Add(1 + count);
                        mesh[i].TriangleIndices.Add(2 + count);
                        
                        count += 3;
                    }

                    SolidColorBrush brush = new SolidColorBrush();
                    brush.Color = color;
                    Material material = new DiffuseMaterial(brush);

                    GeometryModel3D geometry = new GeometryModel3D(mesh[i], material);
                    model[i] = new ModelUIElement3D();
                    model[i].Model = geometry;
                    SetEvents(model[i]);

                    viewport.Children.Add(model[i]);
                }
            }
            
        }

        public void Hide(Viewport3D viewport)
        {
            foreach (var a in model)
            {
                viewport.Children.Remove(a);
            }
        }

        private void SetEvents(ModelUIElement3D m)
        {
            m.MouseDown += MouseDownEventFunction;
            m.MouseUp += MouseUpEventFunction;
        }

        public void Move(Vector3D v)
        {
            Center += v;
            for (int i=0; i<arrayModel.Length; i++)
            {
                int pos=0;
                foreach (var a in arrayModel[i].Triangles)
                {
                    mesh[i].Positions[pos] += v;
                    mesh[i].Positions[pos + 1] += v;
                    mesh[i].Positions[pos + 2] += v;
                    pos += 3;
                }
            }
        }

        private void SetPosition(Point3D point) { }///!!!

        public void RotateRelative(float angleX, float angleY, float angleZ)
        {
            this.angleX = angleX;
            this.angleY = angleY;
            this.angleZ = angleZ;

            Rotate();
        }

        //public void RotateAbsolyte(float angleX, float angleY, float angleZ)
        //{
        //    this.angleX = angleX;
        //    this.angleY = angleY;
        //    this.angleZ = angleZ;

        //    Rotate();        
        //}

        private void Rotate()
        {
            List<Point3D> points2 = new List<Point3D>();
            List<Vector3D> normals2 = new List<Vector3D>();//замедляет работу!!! продумать отключение
            Point3D p0 = new Point3D(0, 0, 0);
           
            for (int i = 0; i < arrayModel.Length; i++)
            {
                int pos = 0;
                foreach (var a in arrayModel[i].Triangles)
                {

                    //продумывать изменение напрямую для ускорения
                    mesh[i].Positions[pos] = rotater.Rotate(mesh[i].Positions[pos], Center, this.angleX, this.angleY, this.angleZ);
                    mesh[i].Positions[pos+1] = rotater.Rotate(mesh[i].Positions[pos+1], Center, this.angleX, this.angleY, this.angleZ);
                    mesh[i].Positions[pos+2] = rotater.Rotate(mesh[i].Positions[pos+2], Center, this.angleX, this.angleY, this.angleZ);
                    mesh[i].Normals[pos] = rotater.Rotate(mesh[i].Normals[pos], p0, this.angleX, this.angleY, this.angleZ);
                    mesh[i].Normals[pos+1] = rotater.Rotate(mesh[i].Normals[pos+1], p0, this.angleX, this.angleY, this.angleZ);
                    mesh[i].Normals[pos+2] = rotater.Rotate(mesh[i].Normals[pos+2], p0, this.angleX, this.angleY, this.angleZ);
                    //points2.Add(rotater.Rotate(a.GetPoint(0), Center, this.angleX, this.angleY, this.angleZ));
                    //points2.Add(rotater.Rotate(a.GetPoint(1), Center, this.angleX, this.angleY, this.angleZ));
                    //points2.Add(rotater.Rotate(a.GetPoint(2), Center, this.angleX, this.angleY, this.angleZ));
                    //normals2.Add(rotater.Rotate(a.GetNormal(0), p0, this.angleX, this.angleY, this.angleZ));
                    //normals2.Add(rotater.Rotate(a.GetNormal(1), p0, this.angleX, this.angleY, this.angleZ));
                    //normals2.Add(rotater.Rotate(a.GetNormal(2), p0, this.angleX, this.angleY, this.angleZ));
                    pos += 3;
                }
                //Point3DCollection p = new Point3DCollection(points2);
                //Vector3DCollection v = new Vector3DCollection(normals2);
                
               // mesh[i].Positions = p;
               // mesh[i].Normals = v;
            }
            
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void Clone(Object3D newObject)
        {
            newObject.mesh = new MeshGeometry3D[arrayModel.Length];
            newObject.model = new ModelUIElement3D[arrayModel.Length];
            newObject.arrayModel = new _3DModel[arrayModel.Length];
            for (int i = 0; i < arrayModel.Length; i++)
            {
                newObject.arrayModel[i] = new _3DModel();
                foreach (var a in arrayModel[i].Triangles)
                {
                    Point3D a1 = new Point3D(a.GetPoint(0).X, a.GetPoint(0).Y, a.GetPoint(0).Z);
                    Point3D a2 = new Point3D(a.GetPoint(1).X, a.GetPoint(1).Y, a.GetPoint(1).Z);
                    Point3D a3 = new Point3D(a.GetPoint(2).X, a.GetPoint(2).Y, a.GetPoint(2).Z);
                    Vector3D v1 = new Vector3D(a.GetNormal(0).X, a.GetNormal(0).Y, a.GetNormal(0).Z);
                    Vector3D v2 = new Vector3D(a.GetNormal(1).X, a.GetNormal(1).Y, a.GetNormal(1).Z);
                    Vector3D v3 = new Vector3D(a.GetNormal(2).X, a.GetNormal(2).Y, a.GetNormal(2).Z);
                    Triangle t = new Triangle(a1,a2,a3,v1,v2,v3);
                    newObject.arrayModel[i].AddTriangle(t);
                }
            }
        }
    }
}
