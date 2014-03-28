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
        Object3D o;
        Camera3D c;
        public MainWindow()
        {
            InitializeComponent();
            draw();
        }

        public void draw()
        {
            o = new Object3D("33.obj");
            c = new Camera3D(mainViewport.Camera);

            o.Draw(mainViewport);
                
               // timer.Tick += new EventHandler(timerTick);
               // timer.Interval = new TimeSpan(0, 0, 0, 0, 40);
               // timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            c.RotateRelative(1, 1, 1);
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
