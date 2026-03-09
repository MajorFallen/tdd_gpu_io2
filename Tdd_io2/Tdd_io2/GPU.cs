using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdd_io2
{
    public class GPU
    {
        public bool IsRunning { get; private set; }

        public void Start()
        {
            IsRunning = true;
        }
    }
}
