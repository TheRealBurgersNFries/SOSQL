using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    [Serializable]
    public class MedicalDevice : Package
    {
        private int IdentifierNumber;
        private string TestStatus;
        private string TestedBy;
        private DateTime TestedDate;
        private string Category;
        private string Location;
        private string DonorName;
        private string DonorGroup;
        private float DeviceWeight;
        private DateTime DateReceived;
        private string Description;
        private string Manufacturer;
        private string ModelNumber;
        private int Quantity;
        private float Value;
        private string AssignedDestination;
        private string ShippingStatus;
        private DateTime ShipDate;
        private string Notes;
        private string Image;
        private string ReceivedBy;
        public List<Bin> AttachedContainers; //also if this is needed to be stored in database, will need to insert column
        public float ContainerVolumes;
        private bool OrientableX;
        private bool OrientableY;
        private bool OrientableZ;
        private bool StackableX;
        private bool StackableY;
        private bool StackableZ;
        private List<MedicalDevice> RelatedObjects;
        private bool Approved; //assuming this is for equipment approval
        private string Query;

        public MedicalDevice(int _IdentifierNumber, string _TestStatus, string _TestedBy, DateTime _TestedDate, string _Category, string _Location,
            string _DonorName, string _DonorGroup, float _DeviceWeight, DateTime _DateReceived, string _Description,
            string _Manufacturer, string _ModelNumber, int _Quantity, float _Value, string _AssignedDestination,
            string _ShippingStatus, DateTime _ShipDate, string _Notes, string _Image, string _ReceivedBy, 
            int _DimensionX, int _DimensionY, int _DimensionZ, List<Bin> _AttachedContainers, bool _OrientableX, 
            bool _OrientableY, bool _OrientableZ, bool _StackableX, bool _StackableY, bool _StackableZ, 
            List<MedicalDevice> _RelatedObjects)
        {
            Transparency = 200;
            IdentifierNumber = _IdentifierNumber;
            TestStatus = _TestStatus;
            TestedBy = _TestedBy;
            TestedDate = _TestedDate;
            Category = _Category;
            Location = _Location;
            DonorName = _DonorName;
            DonorGroup = _DonorGroup;
            DeviceWeight = _DeviceWeight;
            DateReceived = _DateReceived;
            Name = _Description;
            Manufacturer = _Manufacturer;
            ModelNumber = _ModelNumber;
            Quantity = _Quantity;
            Value = _Value;
            AssignedDestination = _AssignedDestination;
            ShippingStatus = _ShippingStatus;
            ShipDate = _ShipDate;
            Notes = _Notes;
            Image = _Image;
            ReceivedBy = _ReceivedBy;
            _Width = _DimensionX;
            _Height = _DimensionY;
            _Depth = _DimensionZ;
            AttachedContainers = _AttachedContainers;
            OrientableX = _OrientableX;
            OrientableY = _OrientableY;
            OrientableZ = _OrientableY;
            StackableX = _StackableX;
            StackableY = _StackableY;
            StackableZ = _StackableZ;
            RelatedObjects = _RelatedObjects;
            Approved = false;
        }
		public MedicalDevice(string _Name, int width, int height, int depth, bool orientx, bool orienty, bool orientz, bool stackx, bool stacky, bool stackz)
        {
            Transparency = 200;
            Description = _Name;
            Width = width;
            Height = height;
            Depth = depth;
            OrientableX = orientx;
            OrientableY = orienty;
            OrientableZ = orientz;
            StackableX = stackx;
            StackableY = stacky;
            StackableZ = stackz;
        }

        public MedicalDevice(int _DimensionX, int _DimensionY, int _DimensionZ)
        {
            Transparency = 200;
            _Width = _DimensionX;
            _Height = _DimensionY;
            _Depth = _DimensionZ;
            _X = 0;
            _Y = 0;
            _Z = 0;
            OrientableZ = true;
            OrientableY = false;
            OrientableX = false;
            StackableZ = true;
            StackableY = false;
            StackableX = false;
            Name = "TestPackage";
        }

        public override List<Bin> GetBins()
        {
            return AttachedContainers;
        }
    }
}
