using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SOSQL
{
    public class Bin
    {
        private Rect3D Rect;

        public int Width { get { return (int)Rect.SizeX; } set { Rect.SizeX = value; } }
        public int Height { get { return (int)Rect.SizeY; } set { Rect.SizeY = value; } }
        public int Depth { get { return (int)Rect.SizeZ; } set { Rect.SizeZ = value; } }

        public int X { get { return (int)Rect.X; } set { Rect.X = value; } }
        public int Y { get { return (int)Rect.Y; } set { Rect.Y = value; } }
        public int Z { get { return (int)Rect.Z; } set { Rect.Z = value; } }

        public Bin(Rect3D rect)
        {
            Rect = rect;
        }

        public Bin(int x, int y, int z, int idth, int height, int depth)
        {
            Rect3D rect = new Rect3D(x, y, z, Width, height, depth);
            Rect = rect;
        }

        public static Bin Create(int left, int right, int top, int bottom, int front, int back)
        {
            try
            {
                Rect3D rect = new Rect3D();
                rect.X = left;
                rect.SizeX = right - left;
                rect.Y = bottom;
                rect.SizeY = top - bottom;
                rect.Z = front;
                rect.SizeZ = back - front;
                return new Bin(rect);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new Bin(0, 0, 0, 0, 0, 0);
            }
        }
        public Rect3D ToRect()
        {
            return Rect;
        }

        public int Volume()
        {
            int volume = (int)Rect.SizeX * (int)Rect.SizeY * (int)Rect.SizeZ;
            return volume;
        }

        public bool IsIntersect(Rect3D intersect)
        {
            if (intersect == Rect3D.Empty) return false;
            if (intersect.SizeX == 0 || intersect.SizeY == 0 || intersect.SizeZ == 0) return false;
            return true;
        }

        public List<Bin> Subtract(Rect3D sub)
        {
            Rect3D op = Rect;
            List<Bin> result = new List<Bin>();
            Rect3D intersect = Rect3D.Intersect(op, sub);
            if (!IsIntersect(intersect))
            {
                result.Add(new SOSQL.Bin(op));
            }
            else
            {
                int a = Math.Min((int)op.X, (int)intersect.X);
                int b = Math.Max((int)op.X, (int)intersect.X);
                int c = Math.Min((int)op.X + (int)op.SizeX, (int)intersect.X + (int)intersect.SizeX);
                int d = Math.Max((int)op.X + (int)op.SizeX, (int)intersect.X + (int)intersect.SizeX);

                int e = Math.Min((int)op.Y, (int)intersect.Y);
                int f = Math.Max((int)op.Y, (int)intersect.Y);
                int g = Math.Min((int)op.Y + (int)op.SizeY, (int)intersect.Y + (int)intersect.SizeY);
                int h = Math.Max((int)op.Y + (int)op.SizeY, (int)intersect.Y + (int)intersect.SizeY);

                int i = Math.Min((int)op.Z, (int)intersect.Z);
                int j = Math.Max((int)op.Z, (int)intersect.Z);
                int k = Math.Min((int)op.Z + (int)op.SizeZ, (int)intersect.Z + (int)intersect.SizeZ);
                int l = Math.Max((int)op.Z + (int)op.SizeZ, (int)intersect.Z + (int)intersect.SizeZ);

                /*          _   _   _   l
                 *        /   /   /   /
                 *       / _ / _ / _ / k
                 *      /   /   /   /
                 *     / _ / _ / _ / j
                 *    /   /   /   /
                 * h +___+___+___+ i
                 * . |   |   |   |
                 * g +___+___+___+
                 * . |   |   |   |
                 * f +___+___+___+
                 * . |   |   |   |
                 * e +___+___+___+
                 *   a   b   c   d
                 * 
                 * 
                 */

                Bin bin;
                // Generate all of the Bins on the front face
                bin = Create(a, b, f, e, i, j); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(b, c, f, e, i, j); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(c, d, f, e, i, j); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(a, b, g, f, i, j); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(b, c, g, f, i, j); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(c, d, g, f, i, j); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(a, b, h, g, i, j); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(b, c, h, g, i, j); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(c, d, h, g, i, j); if (bin.Volume() > 0) result.Add(bin);
                
                // Generate all but the center bin in the center section
                bin = Create(a, b, f, e, j, k); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(b, c, f, e, j, k); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(c, d, f, e, j, k); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(a, b, g, f, j, k); if (bin.Volume() > 0) result.Add(bin);
                // This one can't be a case
                bin = Create(c, d, g, f, j, k); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(a, b, h, g, j, k); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(b, c, h, g, j, k); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(c, d, h, g, j, k); if (bin.Volume() > 0) result.Add(bin);

                //Generate all of the Bins on the back Face.
                bin = Create(a, b, f, e, k, l); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(b, c, f, e, k, l); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(c, d, f, e, k, l); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(a, b, g, f, k, l); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(b, c, g, f, k, l); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(c, d, g, f, k, l); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(a, b, h, g, k, l); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(b, c, h, g, k, l); if (bin.Volume() > 0) result.Add(bin);
                bin = Create(c, d, h, g, k, l); if (bin.Volume() > 0) result.Add(bin);
            }
            return result;
        }

    }
}
