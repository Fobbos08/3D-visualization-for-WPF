using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Parser.Parcers
{
    public class MtlParser
    {
        public MyMaterial[] Parce(List<List<string>> model)
        {
            MyMaterial[] mtl = new MyMaterial[model.Count-1];


            for (int i = 0; i < model.Count-1; i++)
            {
                mtl[i] = new MyMaterial();
                string[] buff;
                foreach (string a in model[i+1])
                {
                    buff = a.Split(' ');
        //            public String Name { get; set; }
        //public Point3D Ka = new Point3D(1,1,1);// Цвет окружающего освещения (желтый)
        //public Point3D Kd = new Point3D(1,1,1);// Диффузный цвет (белый)
        ////# Параметры отражения
        //public Point3D Ks = new Point3D(0,0,0);// Цвет зеркального отражения (0;0;0 - выключен)
        //public float Ns = 10;//                   # Коэффициент зеркального отражения (от 0 до 1000)
        ////# Параметры прозрачности
        //public float D = 0.9f;//                        # Прозрачность указывается с помощью директивы D
        //public float Tr = 0.9f;//                     #   или в других реализациях формата с помощью Tr
        //public string Path = "";
        //public Point3D Tilling = new Point3D(0, 0, 0);
                    switch (buff[0])
                    {
                        case "newmtl": { mtl[i].Name = buff[1]; break; }
                        case "\tKa": { mtl[i].Ka = new System.Windows.Media.Media3D.Point3D(double.Parse(buff[1].Replace(".", ",")), double.Parse(buff[2].Replace(".", ",")), double.Parse(buff[3].Replace(".", ","))); break; }
                        case "\tKd": { mtl[i].Kd = new System.Windows.Media.Media3D.Point3D(double.Parse(buff[1].Replace(".", ",")), double.Parse(buff[2].Replace(".", ",")), double.Parse(buff[3].Replace(".", ","))); break; }
                        case "\tKs": { mtl[i].Ks = new System.Windows.Media.Media3D.Point3D(double.Parse(buff[1].Replace(".", ",")), double.Parse(buff[2].Replace(".", ",")), double.Parse(buff[3].Replace(".", ","))); break; }
                        case "\tNs": { mtl[i].Ns = float.Parse(buff[1].Replace(".", ",")); break; }
                        case "\tD": { mtl[i].D = float.Parse(buff[1].Replace(".", ",")); break; }
                        case "\tTr": { mtl[i].Tr = float.Parse(buff[1].Replace(".", ",")); break; }
                        case "\tmap_Ka":
                            {
                                if (buff.Length > 2)
                                {
                                    mtl[i].Path = buff[5];
                                    mtl[i].Tilling = new System.Windows.Media.Media3D.Point3D(double.Parse(buff[2].Replace(".", ",")), double.Parse(buff[3].Replace(".", ",")), double.Parse(buff[4].Replace(".", ",")));
                                }
                                else
                                {
                                    mtl[i].Path = buff[1];
                                    mtl[i].Tilling = new System.Windows.Media.Media3D.Point3D(1,1,1);
                                }
                                break;
                            }
                        default: break;
                    }
                }
                
            }
            return mtl;
        }
    }
}
