using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Model
{
    public class MyMaterial
    {
        public String Name = "";
        public Point3D Ka = new Point3D(1,1,1);// Цвет окружающего освещения (желтый)
        public Point3D Kd = new Point3D(1,1,1);// Диффузный цвет (белый)
        //# Параметры отражения
        public Point3D Ks = new Point3D(0,0,0);// Цвет зеркального отражения (0;0;0 - выключен)
        public float Ns = 10;//                   # Коэффициент зеркального отражения (от 0 до 1000)
        //# Параметры прозрачности
        public float D = 0.9f;//                        # Прозрачность указывается с помощью директивы D
        public float Tr = 0.9f;//                     #   или в других реализациях формата с помощью Tr
        public string Path = "";
        public Point3D Tilling = new Point3D(0, 0, 0);
    }
}
