using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patterns.Iterator;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}