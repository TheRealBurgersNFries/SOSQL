using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    public class Donation
    {
        private string DonorGroup;
        private string DonorName;
        private DateTime DonationDate;
        private float Weight;
    
        public Donation (string _DonorGroup, string _DonorName, DateTime _DonationDate, float _Weight)
        {
            DonorGroup = _DonorGroup;
            DonorName = _DonorName;
            DonationDate = _DonationDate;
            Weight = _Weight;
        }
    }
}
