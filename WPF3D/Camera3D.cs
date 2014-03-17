using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace WPF3D
{
    public class Camera3D
    {
        private PerspectiveCamera camera;
        private Point3D pos = new Point3D();
        private Vector3D direct = new Vector3D();
        private PointRotater rotater= new PointRotater();
        public Camera3D(Camera camera)
        {
            this.camera = camera as PerspectiveCamera;

        }

        public void MoveAbsolute(float x, float y, float z)
        {
            pos.X = x;
            pos.Y = y;
            pos.Z = z;
            camera.Position = pos;
        }
        public void MoveRelative(float x, float y, float z)
        {
            pos = camera.Position;
            pos.X+=x;
            pos.Y+=y;
            pos.Z+=z;
            camera.Position = pos;
        }
        public void MoveByDirection(float speed)
        {
            direct = camera.LookDirection;
            if (direct.X!=0)
                direct.X = direct.X / Math.Abs(direct.X);
            if (direct.Y != 0)
                direct.Y = direct.Y / Math.Abs(direct.Y);
            if (direct.Z != 0)
                direct.Z = direct.Z / Math.Abs(direct.Z);
            pos = camera.Position;
            pos.X += direct.X * speed;
            pos.Y += direct.Y * speed;
            pos.Z += direct.Z * speed;
            camera.Position = pos;
        }

        public void RotateRelative(float angleX, float angleY, float angleZ)
        {
           
            camera.LookDirection = rotater.Rotate(camera.LookDirection, camera.Position, angleX, angleY, angleZ); 
           // direct.
        }

    }
}
