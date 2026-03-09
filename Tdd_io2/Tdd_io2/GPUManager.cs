using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdd_io2
{
    public class GPUManager
    {
        private readonly double _maxCost;

        public GPUManager(double maxCost)
        {
            _maxCost = maxCost;
        }

        public double CalculateCost(GPU gpu, double hourlyRate)
        {
            double cost = hourlyRate * gpu.TotalHours;
            if (cost > _maxCost)
                return _maxCost;
            return cost;
        }
    }
}
