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
        private int BoxNumber;
        private float Weight;
        private float Value;
        private float TotalValue;
        private int Count;
        private string Pallet;
        private string BoxType;
    
        public Supply (string _Name, int _BoxNumber, float _Weight, float _Value, int _Count,
            string _Pallet, string _BoxType)
        {
            Name = _Name;
            BoxNumber = _BoxNumber;
            Weight = _Weight;
            Value = _Value;
            Count = _Count;
            TotalValue = Count * Value;
            Pallet = _Pallet;
            BoxType = _BoxType;
        }
    }
}
