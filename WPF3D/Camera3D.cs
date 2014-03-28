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
            direct.X = camera.LookDirection.X;
            direct.Y = camera.LookDirection.Y;
            direct.Z = camera.LookDirection.Z;
            direct.Normalize();
            pos = camera.Position;
            pos.X += direct.X * speed;
            pos.Y += direct.Y * speed;
            pos.Z += direct.Z * speed;
            /*
            Vector3D d = new Vector3D();
            d.X = camera.LookDirection.X + direct.X * speed;
            d.Y = camera.LookDirection.Y + direct.Y * speed;
            d.Z = camera.LookDirection.Z + direct.Z * speed;
            camera.LookDirection = d;*/
            camera.Position = pos;
        }
        public void RotateRelative(float angleX, float angleY, float angleZ)
        {

            camera.LookDirection = rotater.Rotate(camera.LookDirection, camera.Position, angleX, angleY, angleZ);

        }

    }
}
