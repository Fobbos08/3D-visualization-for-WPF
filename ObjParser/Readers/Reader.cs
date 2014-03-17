using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Readers
{
    public class Reader : IReader
    {
        private IReader reader;

        public Reader(IReader reader)
        {
            this.reader = reader;
        }

        public List<List<string>> Read(string path)
        {
            return this.reader.Read(path);
        }
    }
}
