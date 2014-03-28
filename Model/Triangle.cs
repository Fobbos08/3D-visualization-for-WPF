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
            normalePoints[0] = normalP0;
            normalePoints[1] = normalP1;
            normalePoints[2] = normalP2;
        }

        public Point3D GetPoint(int index)
        {
            if (index >= 0 && index <= 2)
                return trianglePoints[index];
            throw new System.ArgumentException("Accept value 0,1,2");
        }

        public Vector3D GetNormal(int index)
        {
            if (index >= 0 && index <= 2)
                return normalePoints[index];
            throw new System.ArgumentException("Accept value 0,1,2");
        }


        public void Move(Vector3D v)
        {
            trianglePoints[0] += v;
            trianglePoints[1] += v;
            trianglePoints[2] += v;
        }
        
    }
}
