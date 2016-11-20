using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SOSQL
{
    public abstract class Package : Drawable3D
    {
        private Rect3D Rect;
        public new int Width { get { return (int)Rect.SizeX; } set { Rect.SizeX = value; } }
        public new int Depth { get { return (int)Rect.SizeZ; } set { Rect.SizeZ = value; } }
        public new int Height { get { return (int)Rect.SizeY; } set { Rect.SizeY = value; } }

        public new int X { get { return (int)Rect.X; } set { Rect.X = value; } }
        public new int Y { get { return (int)Rect.Y; } set { Rect.Y = value; } }
        public new int Z { get { return (int)Rect.Z; } set { Rect.Z = value; } }

        

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
    }
}
