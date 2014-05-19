using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Parser
{
    public class Parcer
    {
        private IParcer parcer;
        private IReader reader;

        private IReader mtlReader;
        private Parcers.MtlParser mtlParser;


        public _3DModel[] Parce(string path)
        {
            reader = new Readers.Reader(new Readers.ObjReader());
            parcer = new Parcers.Parcer(new Parcers.ObjParcer());
            List<List<string>> r = reader.Read(path);
            mtlParser = new Parcers.MtlParser();
            mtlReader = new Readers.Reader(new Readers.MtlReader());
            string[] buff = new string[2];
            Model._3DModel[] models = parcer.Parce(r);
            if (r[0].Count != 0)
                buff = r[0][0].Split(' ');
            if (buff[0] == "mtllib")
            {
            MyMaterial[] mt = mtlParser.Parce(mtlReader.Read(buff[1]));

            for (int i = 0; i < models.Length; i++)
            {
                foreach (var t in models[i].Triangles)
                {
                    foreach (var u in mt)
                    {
                        if (t.Mtl == u.Name)
                        {
                            t.MyMtl = u;
                        }
                    }
                }
            }

            }
            
            //string[] buff = { " " };
            
            //{
            //    mtlReader = new Readers.Reader(new Readers.MtlReader());
            //    mtlParser = new Parcers.Parcer(new Parcers.MtlParser());

            //    List<List<string>> t = mtlReader.Read(buff[1]);
            //    //написать конструктор для закидывания текстур

            //}

            return models;
        }
    }
}
