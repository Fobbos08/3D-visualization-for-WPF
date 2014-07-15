using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Parser.Parcers
{
    public class Parser : IParser
    {
        private IParser parser;
        //private IParcer 

        public Parser(IParser parser)
        {
            this.parser = parser;
        }

        public _3DModel[] Parse(List<List<string>> model)
        {
            return this.parser.Parse(model);
        }
    }
}
