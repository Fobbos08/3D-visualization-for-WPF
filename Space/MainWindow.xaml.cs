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

namespace Space
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpaceAnimator s;
        public MainWindow()
        {
            InitializeComponent();
            //this.Background = new ImageBrush(new BitmapImage(new Uri("kosmos-fon-6.png")));
            //s = new SpaceAnimator(mainViewport);
            //ImageBrush myBrush = new ImageBrush();
            //Image image = new Image();
            //image.Source = new BitmapImage(
            //    new Uri(
            //       "kosmos-fon-6.jpg", UriKind.Relative));
            //myBrush.ImageSource = image.Source;
            //Grid grid = new Grid();
            //grid.Background = myBrush;
            //this.AddChild(grid);


        }
    }
}
