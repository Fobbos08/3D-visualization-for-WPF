using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF3D;

namespace Spheres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game g;
        public MainWindow()
        {
            InitializeComponent();
            g = new Game(mainViewport);
            g.RefreshScore += RefreshScore;
            g.Start();
            
        }

        private void RefreshScore(object sender, EventArgs e)
        {
            Score.Content = (sender as Game).GameScore;
        }

         
    }
}
