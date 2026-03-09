using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdd_io2
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
