using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using Parser;
using System.Windows.Controls;

namespace WPF3D
{
    public class Object3D
    {
        private _3DModel[] model;

        public Object3D(string path)
        {
            Parcer parcer = new Parcer();
            model = parcer.Parce(path);
        }

        public Object3D(Object3D object3D)
        {
 
        }

        public void Draw(Viewport3D viewport)
        {
            if (model != null)
            {
                foreach (var a in model)
                {
                    a.draw(viewport);
                }
            }
        }
    }
}
