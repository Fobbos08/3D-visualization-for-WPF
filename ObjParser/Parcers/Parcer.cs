using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Parser.Parcers
{
    public class Parcer : IParcer
    {
        private IParcer parcer;
        //private IParcer 

        public Parcer(IParcer parcer)
        {
            this.parcer = parcer;
        }

        public _3DModel[] Parce(List<List<string>> model)
        {
            return this.parcer.Parce(model);
        }
    }
}
