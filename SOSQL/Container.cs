using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SOSQL
{
    public class Container : Drawable3D
    {
        private int InternalWidth;
        private int InternalHeight;
        private int InternalDepth;
        private List<Bin> Bins;
        private List<Package> Packages;
        private float WeightLimit;
        public float Weight;
        private bool RequiresBalance;

        public Container(int _InternalWidth, int _InternalHeight, int _InternalDepth,
            int _ExternalWidth, int _ExternalHeight, int _ExternalDepth, float _WeightLimit,
            float _Weight, bool _RequiresBalance)
        {
            X = 0;
            Y = 0;
            Z = 0;
            Transparency = 20;
            // Define the internal dimensions of the Container
            InternalWidth = _InternalWidth;
            InternalHeight = _InternalHeight;
            InternalDepth = _InternalDepth;
            
            // Define the external dimensions of the Container
            Width = _ExternalWidth;
            Height = _ExternalHeight;
            Depth = _ExternalDepth;

            // Get the mass of the container and it's weight limit
            // Weight limit should never be an issue but should be kept in mind.
            // Requires balance is, I believe a competely worthless value. - Shayne Hemminger
            WeightLimit = _WeightLimit;
            Weight = _Weight;
            RequiresBalance = _RequiresBalance;

            // These are for the packing Logic, there are going to be a lot of functions to deal with these.
            Bins = new List<Bin>();
            Packages = new List<Package>();
        }

        public bool IsIntersect(Rect3D intersect)
        {
            if (intersect == Rect3D.Empty) return false;
            if (intersect.SizeX == 0 || intersect.SizeY == 0 || intersect.SizeZ == 0) return false;
            return true;
        }

        public bool AddBox(Package package)
        {
            bool collision = false;
            if (Bins.Count == 0) return false;
            foreach (Bin bin in Bins)
            {
                // Ensure that we start by assuming that it isn't colliding
                collision = false;
                // Move the box to the bin coordinates
                package.X = bin.X;
                package.Y = bin.Y;
                package.Z = bin.Z;
                // Does it fit?
                if (((Width - package.X) >= package.Width) && ((Height - package.Y) >= package.Height) && ((Depth - package.Z) >= package.Depth))
                {
                    //Does it collide?
                    foreach (Package other in Packages)
                    {
                        Rect3D intersect = Rect3D.Intersect(package.ToRect(), other.ToRect());
                        collision = IsIntersect(intersect);
                        if (collision) break;
                    }
                    if (!collision) break;
                }
                collision = true;
            }
            // if it won't fit in the container GTFO
            if (collision) return false;
            Packages.Add(package);
            // Now we break apart the bins
            foreach (Bin bin in Bins.ToArray())
            {
                Bins.Remove(bin);
                Bins.AddRange(bin.Subtract(package.ToRect()));
            }
            return true;
        }
    }
}
