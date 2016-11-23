using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    public class Supply : Package
    {
        public string Description { get; set; }
        public int BoxNumber { get; set; }
        public float Weight { get; set; }
        public int Count { get; set; }
        public float Value { get; set; }
        public float TotalValue { get; set; }
        public DateTime Expiration { get; set; }
        public string Pallet { get; set; }
        public string PalletLocation { get; set; }
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
