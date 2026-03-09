using System;

namespace Tdd_io2
{
    public class GPU
    {
        private readonly IClock _clock;
        private DateTime _startTime;
        private TimeSpan _accumulatedTime;

        public bool IsRunning { get; private set; }

        public GPU(IClock clock)
        {
            _clock = clock;
        }

        public void Start()
        {
            if (IsRunning)
                throw new InvalidOperationException("GPU already running.");

            _startTime = _clock.Now;
            IsRunning = true;
        }

        public void Stop()
        {
            if (!IsRunning)
                throw new InvalidOperationException("GPU is not running");

            _accumulatedTime += _clock.Now - _startTime;
            IsRunning = false;
        }

        public double TotalHours => _accumulatedTime.TotalHours;

        public double CalculateCost(double hourlyRate)
        {
            if (hourlyRate <= 0)
                throw new ArgumentException("Hourly rate must be greater than zero.");

            return hourlyRate * TotalHours;
        }
    }
}