using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Reuslts
{
    public interface IResult
    {
        bool Succeded { get; }
        string Message { get; }
    }
}
