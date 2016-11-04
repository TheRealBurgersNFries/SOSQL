using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSQL
{
    public class MedicalDevice
    {
        private int IdentifierNumber;
        private string TestStatus;
        private string Category;
        private string Location;
        private string DonorName;
        private string DonorGroup;
        private float DeviceWeight;
        private string DateReceived;
        private string Description;
        private string Manufacturer;
        private string ModelNumber;
        private int Quantity;
        private float Value;
        private string AssignedDestination;
        private string ShippingStatus;
        private DateTime ShipDate;
        private string Notes;
        private string RestrictedMaterials; //still needed? need to insert column in database if so
        private string Image;
        private string ReceivedBy;
        private int DimensionX;
        private int DimensionY;
        private int DimensionZ;
        public float Volume;
        public List<Container> AttachedContainers; //also if this is needed to be stored in database, will need to insert column
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

        public MedicalDevice(int _IdentifierNumber, string _TestStatus, string _Category, string _Location,
            string _DonorName, string _DonorGroup, float _DeviceWeight, string _DateReceived, string _Description,
            string _Manufacturer, string _ModelNumber, int _Quantity, float _Value, string _AssignedDestination,
            string _ShippingStatus, DateTime _ShipDate, string _Notes,  string _RestrictedMaterials, 
            string _Image, string _ReceivedBy, int _DimensionX, int _DimensionY, int _DimensionZ, List<Container> _AttachedContainers, bool _OrientableX, 
            bool _OrientableY, bool _OrientableZ, bool _StackableX, bool _StackableY, bool _StackableZ, 
            List<MedicalDevice> _RelatedObjects)
        {
            IdentifierNumber = _IdentifierNumber;
            TestStatus = _TestStatus;
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
            ContainerVolumes = 0;
            foreach(Container _Container in AttachedContainers)
            {
                ContainerVolumes += _Container.InternalVolume;
            }
            OrientableX = _OrientableX;
            OrientableY = _OrientableY;
            OrientableZ = _OrientableY;
            StackableX = _StackableX;
            StackableY = _StackableY;
            StackableZ = _StackableZ;
            RelatedObjects = _RelatedObjects;
            Approved = false;

        }
    }
}
