using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    public class Container
    {
        private List<float> InternalDimensions;
        private List<float> ExternalDimensions;
        private float WeightLimit;
        private float Weight;
        private bool RequiresBalance;

        public Container(List<float> _InternalDimensions, List<float> _ExternalDimensions, float _WeightLimit,
            float _Weight, bool _RequiresBalance)
        {
            InternalDimensions = _InternalDimensions;
            ExternalDimensions = _ExternalDimensions;
            WeightLimit = _WeightLimit;
            Weight = _Weight;
            RequiresBalance = _RequiresBalance;
        }
    }
}
