using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    public class Supply
    {
        private string Name;
        private int Box;
        private float Weight;
        private int Count;
        private float Value;
        private float TotalValue;
        private string Pallet;
        private string BoxType;
    
        public Supply (string _Name, int _Box, float _Weight, int _Count, float _Value, string _Pallet,
            string _BoxType)
        {
            Name = _Name;
            Box = _Box;
            Weight = _Weight;
            Count = _Count;
            Value = _Value;
            TotalValue = Count * Value;
            Pallet = _Pallet;
            BoxType = _BoxType;
        }
    }
}
