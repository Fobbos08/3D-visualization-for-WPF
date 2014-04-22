using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace WPF3D
{
    class PointRotater
    {
        public Point3D Rotate(Point3D point, Point3D offset, float angleX, float angleY, float angleZ)
        {
            Point3D p = new Point3D();
            double[] coordinate = new double[3];
            coordinate[0] = point.X - offset.X;
            coordinate[1] = point.Y - offset.Y;
            coordinate[2] = point.Z - offset.Z;
            double[] angles = new double[3];
            angles[0] = angleX * Math.PI / 180;
            angles[1] = angleY * Math.PI / 180;
            angles[2] = angleZ * Math.PI / 180;
            coordinate = RotateX(coordinate, angles);
            coordinate = RotateY(coordinate, angles);
            coordinate = RotateZ(coordinate, angles);
            p.X = coordinate[0] + offset.X;
            p.Y = coordinate[1] + offset.Y;
            p.Z = coordinate[2] + offset.Z;
            return p;
        }

        public Vector3D Rotate(Vector3D point, Point3D offset, float angleX, float angleY, float angleZ)
        {
            Vector3D p = new Vector3D();
            double[] coordinate = new double[3];
            coordinate[0] = point.X - offset.X;
            coordinate[1] = point.Y - offset.Y;
            coordinate[2] = point.Z - offset.Z;
            double[] angles = new double[3];
            angles[0] = angleX * Math.PI / 180;
            angles[1] = angleY * Math.PI / 180;
            angles[2] = angleZ * Math.PI / 180;
            coordinate = RotateX(coordinate, angles);
            coordinate = RotateY(coordinate, angles);
            coordinate = RotateZ(coordinate, angles);
            p.X = coordinate[0] + offset.X;
            p.Y = coordinate[1] + offset.Y;
            p.Z = coordinate[2] + offset.Z;
            return p;
        }

        private double[] RotateX(double[] point, double[] angle)
        {
            double[] p = new double[3];
            p[1] = point[1];
            p[2] = point[2];
            point[1] = p[1] * Math.Cos(angle[0]) - p[2] * Math.Sin(angle[0]);
            point[2] = p[1] * Math.Sin(angle[0]) + p[2] * Math.Cos(angle[0]);
            return point; 
        }

        private double[] RotateY(double[] point, double[] angle)
        {
            double[] p = new double[3];
            p[0] = point[0];
            //p[1] = point[1];
            p[2] = point[2];
            point[0] = p[0] * Math.Cos(angle[1]) - p[2] * Math.Sin(angle[1]);
            point[2] = p[0] * Math.Sin(angle[1]) + p[2] * Math.Cos(angle[1]);
            return point; 
        }

        private double[] RotateZ(double[] point, double[] angle)
        {
            double[] p = new double[3];
            p[0] = point[0];
            p[1] = point[1];
            //p[2] = point[2];
            point[0] = p[0] * Math.Cos(angle[2]) - p[1] * Math.Sin(angle[2]);
            point[1] = p[0] * Math.Sin(angle[2]) + p[1] * Math.Cos(angle[2]);
            return point; 
        }
    }
}
