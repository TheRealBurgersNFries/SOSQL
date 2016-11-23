using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    public class Supply : Package
    {
        private string Description { get; set; }
        private int BoxNumber { get; set; }
        private float Weight { get; set; }
        private int Count { get; set; }
        private float Value { get; set; }
        private float TotalValue { get; set; }
        private DateTime Expiration { get; set; }
        private string Pallet { get; set; }
        private string PalletLocation { get; set; }
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
        }
        public override List<Bin> GetBins()
        {
            return new List<Bin>();
        }
    }
}
