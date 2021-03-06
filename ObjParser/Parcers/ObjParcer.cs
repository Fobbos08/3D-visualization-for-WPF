﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Model;

namespace Parser.Parcers
{
    public class ObjParcer : IParser
    {
        private _3DModel[] models;
        private List<Point3D> points;
        private List<Point3D> texturePoints;
        private List<Vector3D> normals;
        
        public _3DModel[] Parse(List<List<string>> model)/////селать вызов mtl/ отличный от вызова из this, будет правильнее
        {
            int start;
            string[] buff = { "" };
            if (model[0].Count!=0)
            buff = model[0][0].Split(' ');
            if (buff[0] == "mtllib")
            {
                models = new _3DModel[model.Count - 1];
                start = 1;
            }
            else
            {
                models = new _3DModel[model.Count];
                start = 0;
            }
            int index = 0;
            for (int i = start; i < model.Count; i++ )
            {
                points = PointsParce(model[i]);
                normals = NormalsParce(model[i]);
                texturePoints = TexturePointsParce(model[i]);
                models[index] = new _3DModel();
                models[index].AddTriangles(TriangleParce(model[i]));
                models[index].AddPoints(points);
                index++;
            }

            return models;
        }

        private List<Point3D> PointsParce(List<string> model)
        {
            string[] str;
            points = new List<Point3D>();
            int index = 0;
            foreach (var s in model)
            {
                str = s.Split(' ');
                if (str[0] == "v")
                {
                    try
                    {
                        points.Add(new Point3D(float.Parse(str[2].Replace(".", ",")), float.Parse(str[3].Replace(".", ",")), float.Parse(str[4].Replace(".", ","))));
                      //  model.RemoveAt(index);
                    }
                    catch (Exception e)
                    {
                      //  model.RemoveAt(index);
                    }
                }
                else
                {
                    index++;
                }
            }
            return points;
        }

        private List<Vector3D> NormalsParce(List<string> model)
        {
            string[] str;
            normals = new List<Vector3D>();
            int index = 0;
            foreach (var s in model)
            {
                str = s.Split(' ');
                if (str[0] == "vn")
                {
                    try
                    {
                        normals.Add(new Vector3D(float.Parse(str[1].Replace(".", ",")), float.Parse(str[2].Replace(".", ",")), float.Parse(str[3].Replace(".", ","))));
                       // model.RemoveAt(index);
                    }
                    catch (Exception e)
                    {
                       // model.RemoveAt(index);
                    }
                }
                index++;
            }
            return normals;
        }

        private List<Point3D> TexturePointsParce(List<string> model)
        {
            string[] str;
            texturePoints = new List<Point3D>();
            int index = 0;
            foreach (var s in model)
            {
                str = s.Split(' ');
                if (str[0] == "vt")
                {
                    try
                    {
                        texturePoints.Add(new Point3D(float.Parse(str[1].Replace(".", ",")), float.Parse(str[2].Replace(".", ",")), float.Parse(str[3].Replace(".", ","))));
                        //  model.RemoveAt(index);
                    }
                    catch (Exception e)
                    {
                        int a = 0;
                        a++;
                        //  model.RemoveAt(index);
                    }
                }
                else
                {
                    index++;
                }
            }
            return texturePoints;
        }

        private List<Triangle> TriangleParce(List<string> model)
        {
            // f 1/1/1 2/2/1 3/3/1 
            string[] str;
            List<Triangle> triangles = new List<Triangle>();
            int index = 0;
            int[,] param = new int[3,3];
            string mtl = "";
            foreach (var s in model)
            {
                str = s.Split(' ');
                if (str[0] == "usemtl")
                {
                    mtl = str[1];
                }
                if (str[0] == "f")
                {
                    try
                    {
                        for (int i = 0; i < 3; i++)//пробит вариант на 3
                        {
                            string[] buff = str[i+1].Split('/');
                            if (buff.Length == 3)
                            {
                                param[i, 0] = int.Parse(buff[0]);
                                param[i, 1] = int.Parse(buff[1]);
                                param[i, 2] = int.Parse(buff[2]);
                            }
                        }
                        triangles.Add(new Triangle(points[param[0, 0]-1], points[param[1, 0]-1], points[param[2, 0]-1],
                            normals[param[0, 2]-1], normals[param[1, 2]-1], normals[param[2, 2]-1],
                            texturePoints[param[0, 1] - 1], texturePoints[param[1, 1] - 1], texturePoints[param[2, 1] - 1]));
                        triangles[triangles.Count - 1].Mtl = mtl;//!!!!!!!!!!!!!
                       // model.RemoveAt(index);
                    }
                    catch (Exception e)
                    {
                        int a = 0;
                        a++;
                        //model.RemoveAt(index);
                    }
                }
                index++;
            }
            return triangles;
        }
    }
}
