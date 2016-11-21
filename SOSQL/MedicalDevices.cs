using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    public class MedicalDevice : Package
    {
        public int IdentifierNumber { get; set; }
        public string TestStatus { get; set; }
        public string TestedBy { get; set; }
        public DateTime TestedDate { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string DonorName { get; set; }
        public string DonorGroup { get; set; }
        public float DeviceWeight { get; set; }
        public DateTime DateReceived { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }
        public int Quantity { get; set; }
        public float Value { get; set; }
        public string AssignedDestination { get; set; }
        public string ShippingStatus { get; set; }
        public DateTime ShipDate { get; set; }
        public string Notes { get; set; }
        public string RestrictedMaterials { get; set; } //still needed? need to insert column in database if so
        public string Image { get; set; }
        public string ReceivedBy { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int DimensionZ { get; set; }
        public float Volume;
        public List<Bin> AttachedContainers; //also if this is needed to be stored in database, will need to insert column
        public float ContainerVolumes;
        public bool OrientableX { get; set; }
        public bool OrientableY { get; set; }
        public bool OrientableZ { get; set; }
        public bool StackableX { get; set; }
        public bool StackableY { get; set; }
        public bool StackableZ { get; set; }
        public List<MedicalDevice> RelatedObjects { get; set; }
        public bool Approved { get; set; } //assuming this is for equipment approval
        public string Query { get; set; }

        public MedicalDevice(int _IdentifierNumber, string _TestStatus, string _TestedBy, DateTime _TestedDate, string _Category, string _Location,
            string _DonorName, string _DonorGroup, float _DeviceWeight, DateTime _DateReceived, string _Description,
            string _Manufacturer, string _ModelNumber, int _Quantity, float _Value, string _AssignedDestination,
            string _ShippingStatus, DateTime _ShipDate, string _Notes,  string _RestrictedMaterials, 
            string _Image, string _ReceivedBy, int _DimensionX, int _DimensionY, int _DimensionZ, List<Bin> _AttachedContainers, bool _OrientableX, 
            bool _OrientableY, bool _OrientableZ, bool _StackableX, bool _StackableY, bool _StackableZ, 
            List<MedicalDevice> _RelatedObjects)
        {
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
            Description = _Description;
            Manufacturer = _Manufacturer;
            ModelNumber = _ModelNumber;
            Quantity = _Quantity;
            Value = _Value;
            AssignedDestination = _AssignedDestination;
            ShippingStatus = _ShippingStatus;
            ShipDate = _ShipDate;
            Notes = _Notes;
            RestrictedMaterials = _RestrictedMaterials;
            Image = _Image;
            ReceivedBy = _ReceivedBy;
            DimensionX = _DimensionX;
            DimensionY = _DimensionY;
            DimensionZ = _DimensionZ;
            Volume = DimensionX * DimensionY * DimensionZ;
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
        public override List<Bin> GetBins()
        {
            return AttachedContainers;
        }
    }
}
