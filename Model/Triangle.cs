using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Model
{
    public class Triangle
    {
        private Point3D[] trianglePoints = new Point3D[3];
        private Vector3D[] normalePoints = new Vector3D[3];

        public Triangle(Point3D p0, Point3D p1, Point3D p2)
        {
            trianglePoints[0] = p0;
            trianglePoints[1] = p1;
            trianglePoints[2] = p2;
        }

        public Triangle(Point3D p0, Point3D p1, Point3D p2, Vector3D normalP0, Vector3D normalP1, Vector3D normalP2)
        {
            trianglePoints[0] = p0;
            trianglePoints[1] = p1;
            trianglePoints[2] = p2;
        }

        public Point3D GetPoint(int index)
        {
            if (index >= 0 && index <= 2)
                return trianglePoints[index];
            throw new System.ArgumentException("Accept value 0,1,2");
        }

        public void Draw(Viewport3D viewport)//доработать на предмет отмены отображения и модификации
        {
            MeshGeometry3D mesh = new MeshGeometry3D();
            mesh.Positions.Add(trianglePoints[0]);
            mesh.Positions.Add(trianglePoints[1]);
            mesh.Positions.Add(trianglePoints[2]);
           
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Chocolate;
            Material material = new DiffuseMaterial(brush);

            GeometryModel3D geometry = new GeometryModel3D(mesh, material);
            ModelUIElement3D model = new ModelUIElement3D();
            model.Model = geometry;

            viewport.Children.Add(model);
        }
    }
}
