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


        public _3DModel[] Parce(string path)
        {
            reader = new Readers.Reader(new Readers.ObjReader());
            parcer = new Parcers.Parcer(new Parcers.ObjParcer());
            return parcer.Parce(reader.Read(path));
        }
    }
}
