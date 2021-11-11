using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibrary
{
    interface IValidator<T>
    {
        string[] Validate(T obj);
    }
}
