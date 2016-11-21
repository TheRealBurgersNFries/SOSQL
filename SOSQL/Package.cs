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
        public int _Width { get { return (int)Rect.SizeX; } set { Rect.SizeX = value; Width = value; } }
        public int _Depth { get { return (int)Rect.SizeZ; } set { Rect.SizeZ = value; Depth = value; } }
        public int _Height { get { return (int)Rect.SizeY; } set { Rect.SizeY = value; Height = value; } }

        public int _X { get { return (int)Rect.X; } set { Rect.X = value; X = value; } }
        public int _Y { get { return (int)Rect.Y; } set { Rect.Y = value; Y = value; } }
        public int _Z { get { return (int)Rect.Z; } set { Rect.Z = value; Z = value; } }

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
    }
}
