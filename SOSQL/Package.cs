using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SOSQL
{
    [Serializable]
    public abstract class Package : Drawable3D
    {
        private Rect3D Rect;
        public int _Width { get { return (int)Rect.SizeX; } set { Rect.SizeX = value; Width = value; } }
        public int _Depth { get { return (int)Rect.SizeZ; } set { Rect.SizeZ = value; Depth = value; } }
        public int _Height { get { return (int)Rect.SizeY; } set { Rect.SizeY = value; Height = value; } }

        public int _X { get { return (int)Rect.X; } set { Rect.X = value; X = value; } }
        public int _Y { get { return (int)Rect.Y; } set { Rect.Y = value; Y = value; } }
        public int _Z { get { return (int)Rect.Z; } set { Rect.Z = value; Z = value; } }

        public int sizeX;
        public int sizeY;
        public int sizeZ;

        public bool OrientableX;
        public bool OrientableY;
        public bool OrientableZ;
        public bool StackableX;
        public bool StackableY;
        public bool StackableZ;


        public string Name;

        public Rect3D ToRect()
        {
            return Rect;
        }

        public int Volume()
        {
            int volume = (int)Rect.SizeX * (int)Rect.SizeY * (int)Rect.SizeZ;
            return volume;
        }

        public abstract List<Bin> GetBins();

        public void Rotate(int dimension, bool orientation)
        { 
            switch (dimension)
            {
                default:
                    if (OrientableZ)
                    {
                        if (orientation)
                        {
                            _Width = sizeZ;
                            _Depth = sizeX;
                        }
                        else
                        {
                            _Width = sizeX;
                            _Depth = sizeZ;
                        }
                    }
                    return;
            case 2:
                if (OrientableY)
                {
                    if (orientation)
                    {
                        _Height = sizeX;
                        _Width = sizeY;
                    }
                    else
                    {
                        _Height = sizeX;
                        _Depth = sizeY;
                        _Width = sizeZ;
                    }
                }
                return;
            case 3:
            if (OrientableZ)
                {
                    if (orientation)
                    {
                        _Height = sizeZ;
                        _Depth = sizeY;
                    }
                    else
                    {
                        _Height = sizeZ;
                        _Depth = sizeX;
                        _Width = sizeY;
                    }
                }
                return;
            }

        }
    }
}
