using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Parser.Readers
{
    public class ObjReader : IReader
    {
        public List<List<string>> Read(string path)
        {
            List<List<string>> list = new List<List<string>>();
            StreamReader sr = new StreamReader(path);
            //так же учитывать что может присутствовать mtlib
            int i = 0;
            string buff;
            list.Add(new List<string>());
            while(!sr.EndOfStream)
            {
                buff = sr.ReadLine();
                string[] split = buff.Split(' ');
                if (split.Length > 1)
                {
                    if (split[1] == "object")
                    {
                        i++;
                        list.Add(new List<string>());
                    }
                }
                if (buff.Length > 0 && buff[0] != '#')
                {
                    list[i].Add(buff);
                }
                
            }
            return list;
        }
    }
}
