using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    public class Supply : Package
    {
        private string Description;
        private int BoxNumber;
        private float Weight;
        private int Count;
        private float Value;
        private float TotalValue;
        private DateTime Expiration;
        private string Pallet;
        private string PalletLocation;
        public Container Box;
    
        public Supply (string _Description, int _BoxNumber, float _Weight, int _Count, float _Value, DateTime _Expiration,
            string _Pallet, string _PalletLocation, Container _Box)
        {
            Description = _Description;
            BoxNumber = _BoxNumber;
            Weight = _Weight;
            Count = _Count;
            Value = _Value;
            TotalValue = Count * Value;
            Expiration = _Expiration;
            Pallet = _Pallet;
            PalletLocation = _PalletLocation;
            Box = _Box;
            Transparency = 200;
        }
        public override List<Bin> GetBins()
        {
            return new List<Bin>();
        }
    }
}
