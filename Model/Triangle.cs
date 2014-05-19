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
        private Point3D[] texturePoints = new Point3D[3];
        public string Mtl{get;set;}
        public MyMaterial MyMtl { get; set; }

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

        public Triangle(Point3D p0, Point3D p1, Point3D p2, Vector3D normalP0, Vector3D normalP1, Vector3D normalP2, Point3D tp0, Point3D tp1, Point3D tp2)
        {
            trianglePoints[0] = p0;
            trianglePoints[1] = p1;
            trianglePoints[2] = p2;
            normalePoints[0] = normalP0;
            normalePoints[1] = normalP1;
            normalePoints[2] = normalP2;
            texturePoints[0] = tp0;
            texturePoints[1] = tp1;
            texturePoints[2] = tp2;
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

        public Point3D GetTexturePoint(int index)
        {
            if (index >= 0 && index <= 2)
                return texturePoints[index];
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
