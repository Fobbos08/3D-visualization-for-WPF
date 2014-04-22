using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF3D;

namespace Demonstration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerFPS = new DispatcherTimer();
        Object3D o;
        Object3D oo;
        Camera3D c;

        int fps = 0;
        public MainWindow()
        {
            InitializeComponent();
            draw();
        }

        public void draw()
        {
            o = new Object3D("sphere.obj");
            oo = new Object3D("1.obj");
            o.MouseDownEvent += Rotate;
            
            c = new Camera3D(mainViewport.Camera);

            o.Draw(mainViewport);
            oo.Draw(mainViewport);
            Vector3D v = new Vector3D();
            v.X = 10;
           // oo.Move(v);
            timerFPS.Tick += new EventHandler(timerTickFPS);
            timerFPS.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timerFPS.Start();
                timer.Tick += new EventHandler(timerTick);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 40);
                timer.Start();
        }

        private void timerTickFPS(object sender, EventArgs e)
        {
            FPSLabel.Content = fps;
            fps = 0;
            //
        }

        private void timerTick(object sender, EventArgs e)
        {
            o.RotateRelative(1, 1, 1);
            oo.RotateRelative(5, 5, 5);
            fps++;
            //
        }

        private void Rotate(object sender, EventArgs e) 
        {

            (sender as Object3D).RotateRelative(10, 10, 10);
            //(sender as Object3D).Hide(mainViewport);
        }


        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "W") { c.RotateRelative(1, 0, 0); }
            if (e.Key.ToString() == "S") { c.RotateRelative(-1, 0, 0); }
            if (e.Key.ToString() == "A") { c.RotateRelative(0, -1, 0); }
            if (e.Key.ToString() == "D") { c.RotateRelative(0, 1, 0); }
            if (e.Key.ToString() == "Z") { c.MoveByDirection(-1); }
            if (e.Key.ToString() == "X") { c.MoveByDirection(1); }
            if (e.Key.ToString() == "Q") { o.RotateRelative(1, 0, 0); }
            if (e.Key.ToString() == "E") { o.RotateRelative(0, 1, 0); }
            if (e.Key.ToString() == "R") { o.RotateRelative(0, 0, 1); }
        }

    }
}
