using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeIterator
{   
    interface Iterator
    {
        bool hasNext();
        int Next();
    }
}