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

namespace WPF3D
{
    public class Object3D
    {
        private _3DModel[] arrayModel;
        private Point3D center;
        private MeshGeometry3D[] mesh;
        private ModelUIElement3D[] model;
        private PointRotater rotater = new PointRotater();

        private float angleX = 0;
        private float angleY = 0;
        private float angleZ = 0;

        public Object3D(string path)
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
            center = new Point3D(x/count, y/count, z/count);
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
                    brush.Color = Colors.Chocolate;
                    Material material = new DiffuseMaterial(brush);

                    GeometryModel3D geometry = new GeometryModel3D(mesh[i], material);
                    model[i] = new ModelUIElement3D();
                    model[i].Model = geometry;

                    viewport.Children.Add(model[i]);
                }
            }
            
        }

        public void Move(Vector3D v)
        {
            center += v;
            List<Point3D> points2 = new List<Point3D>();
            for (int i=0; i<arrayModel.Length; i++)
            {
                foreach (var a in arrayModel[i].Triangles)
                {
                    points2.Add(a.GetPoint(0) + v);//поменять местами
                    points2.Add(a.GetPoint(1) + v);
                    points2.Add(a.GetPoint(2) + v);
                    a.Move(v);
                }
                Point3DCollection p = new Point3DCollection(points2);
                mesh[i].Positions = p;
            }
        }

        public void RotateRelative(float angleX, float angleY, float angleZ)
        {
            this.angleX += angleX;
            this.angleY += angleY;
            this.angleZ += angleZ;

            List<Point3D> points2 = new List<Point3D>();
            for (int i = 0; i < arrayModel.Length; i++)
            {
                foreach (var a in arrayModel[i].Triangles)
                {
                    points2.Add(rotater.Rotate(a.GetPoint(0), center, this.angleX, this.angleY, this.angleZ));
                    points2.Add(rotater.Rotate(a.GetPoint(1), center, this.angleX, this.angleY, this.angleZ));
                    points2.Add(rotater.Rotate(a.GetPoint(2), center, this.angleX, this.angleY, this.angleZ));
                }
                Point3DCollection p = new Point3DCollection(points2);
                mesh[i].Positions = p;
            }
        }

    }
}
