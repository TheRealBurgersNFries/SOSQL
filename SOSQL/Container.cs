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
        public float InternalVolume;
        private List<float> ExternalDimensions;
        public float ExternalVolume;
        private float WeightLimit;
        public float Weight;
        private bool RequiresBalance;

        public Container(List<float> _InternalDimensions, List<float> _ExternalDimensions, float _WeightLimit,
            float _Weight, bool _RequiresBalance)
        {
            InternalDimensions = _InternalDimensions;
            InternalVolume = InternalDimensions[0] * InternalDimensions[1] * InternalDimensions[2];
            ExternalDimensions = _ExternalDimensions;
            ExternalVolume = ExternalDimensions[0] * ExternalDimensions[1] * ExternalDimensions[2];
            WeightLimit = _WeightLimit;
            Weight = _Weight;
            RequiresBalance = _RequiresBalance;
        }
    }
}
