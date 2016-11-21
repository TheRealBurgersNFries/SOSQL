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
        public int Width { get { return (int)Rect.SizeX; } set { Rect.SizeX = value; } }
        public int Depth { get { return (int)Rect.SizeZ; } set { Rect.SizeZ = value; } }
        public int Height { get { return (int)Rect.SizeY; } set { Rect.SizeY = value; } }

        public int X { get { return (int)Rect.X; } set { Rect.X = value; } }
        public int Y { get { return (int)Rect.Y; } set { Rect.Y = value; } }
        public int Z { get { return (int)Rect.Z; } set { Rect.Z = value; } }

        private int Transparency = 200;

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
