using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;


namespace Model
{
    public class _3DModel
    {
        private List<Triangle> triangles = new List<Triangle>();
        private List<Point3D> points = new List<Point3D>();

        public IEnumerable<Triangle> Triangles { get { return triangles; } }

        public void AddTriangle(Triangle triangle)
        {
            triangles.Add(triangle);
        }

        public void AddTriangles(List<Triangle> triangles)
        {
            foreach (var a in triangles)
            {
                this.triangles.Add(a);
            }
        }

        public void AddPoint(Point3D point)
        {
            points.Add(point);
        }

        public void AddPoints(List<Point3D> points)
        {
            foreach (var a in points)
            {
                this.points.Add(a);
            }
        }

        
        /*
        private void move(object sender, MouseButtonEventArgs e)
        {
            Vector3D v = new Vector3D(1,1,1);
            List<Point3D> l = new List<Point3D>();
            List<Point3D> points2 = new List<Point3D>();
            foreach (var a in triangles)
            {
                points2.Add(a.GetPoint(0)+v);
                points2.Add(a.GetPoint(1) + v);
                points2.Add(a.GetPoint(2) + v);

            }
            Point3DCollection p = new Point3DCollection(points2);
            mesh.Positions= p;
            
            foreach (var a in triangles)
                a.Move(v);

        }*/
    }
}
