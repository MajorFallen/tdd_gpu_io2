using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tdd_io2
{
    public class GPU
    {
        public TimeSpan RunningTime => DateTime.Now - _startTime;
        private DateTime _startTime;
        public bool IsRunning { get; private set; }

        public void Start()
        {
            if (IsRunning)
                throw new InvalidOperationException("GPU already running.");
            _startTime = DateTime.Now;
            IsRunning = true;
        }
        public void Stop()
        {
            if (!IsRunning)
                throw new InvalidOperationException("GPU is not running");
            IsRunning = false;
        }
    }
}
