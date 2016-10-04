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
        public Container Box;
    
        public Supply (string _Name, int _BoxNumber, float _Weight, float _Value, int _Count,
            string _Pallet, Container _Box)
        {
            Name = _Name;
            BoxNumber = _BoxNumber;
            Weight = _Weight;
            Value = _Value;
            Count = _Count;
            TotalValue = Count * Value;
            Pallet = _Pallet;
            Box = _Box;
        }
    }
}
