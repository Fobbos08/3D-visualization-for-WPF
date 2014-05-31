using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using WPF3D;

namespace Space
{
    public class SpaceAnimator
    {
        private Viewport3D viewport;
        private List<Object3D> objects = new List<Object3D>();
        public SpaceAnimator(Viewport3D v)
        {
            this.viewport = v;
            objects.Add(new Object3D("sun.obj"));

            foreach (var a in objects)
            {
                
                a.Draw(viewport);
                a.Move(new Vector3D(viewport.ActualWidth, 0, 0));
            }
        }
    }
}
