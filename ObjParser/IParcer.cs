using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Parser
{
    public interface IParcer
    {
        _3DModel[] Parce(List<List<string>> model);
    }
}
