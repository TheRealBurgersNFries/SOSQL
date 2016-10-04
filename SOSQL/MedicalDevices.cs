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
        private string DeviceType;
        private string Location;
        private string Donor;
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
        private string ShipDate;
        private string Notes;
        private string RestrictedMaterials;
        private string Image;
        private List<float> Dimensions;
        public float Volume;
        public List<Container> AttachedContainers;
        public float ContainerVolumes;
        private bool OrientableX;
        private bool OrientableY;
        private bool OrientableZ;
        private bool StackableX;
        private bool StackableY;
        private bool StackableZ;
        private List<MedicalDevice> RelatedObjects;
        private bool Confirmed;
        private string Query;

        public MedicalDevice(int _IdentifierNumber, string _TestStatus, string _DeviceType, string _Location,
            string _Donor, string _DonorGroup, float _DeviceWeight, string _DateReceived, string _Description,
            string _Manufacturer, string _ModelNumber, int _Quantity, float _Value, string _AssignedDestination,
            string _ShippingStatus, string _ShipDate, string _Notes,  string _RestrictedMaterials, 
            string _Image, List<float> _Dimenstions, List<Container> _AttachedContainers, bool _OrientableX, 
            bool _OrientableY, bool _OrientableZ, bool _StackableX, bool _StackableY, bool _StackableZ, 
            List<MedicalDevice> _RelatedObjects)
        {
            IdentifierNumber = _IdentifierNumber;
            TestStatus = _TestStatus;
            DeviceType = _DeviceType;
            Location = _Location;
            Donor = _Donor;
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
            Dimensions = _Dimenstions;
            Volume = Dimensions[0] * Dimensions[1] * Dimensions[2];
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
            Confirmed = false;

        }
    }
}
