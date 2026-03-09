using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdd_io2
{
    public class FakeClock : IClock
    {
        public DateTime Now { get; set; }
    }
}
