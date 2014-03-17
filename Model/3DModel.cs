using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;


namespace Model
{
    public class _3DModel
    {
        private List<Triangle> triangles = new List<Triangle>();

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

        public void draw(Viewport3D viewport)
        {
            foreach (var a in triangles)
                a.Draw(viewport);
        }
    }
}
