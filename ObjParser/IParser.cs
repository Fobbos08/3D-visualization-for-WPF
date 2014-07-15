using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Parser
{
    public interface IParser
    {
        _3DModel[] Parse(List<List<string>> model);
    }
}
