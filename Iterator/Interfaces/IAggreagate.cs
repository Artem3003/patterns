using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patterns.Iterator;

public interface IAggreagate<T>
{
    IIterator<T> CreateIterator();
}