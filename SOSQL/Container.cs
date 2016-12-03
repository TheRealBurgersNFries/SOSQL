using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SOSQL
{
    [Serializable]
    public class Container : Drawable3D
    {
        private int InternalWidth;
        private int InternalHeight;
        private int InternalDepth;
        private List<Bin> Bins;
        public List<Package> Packages;
        private float WeightLimit;
        public float Weight;

        public Container(int _InternalWidth, int _InternalHeight, int _InternalDepth,
            int _ExternalWidth, int _ExternalHeight, int _ExternalDepth, float _WeightLimit,
            float _Weight)
        {
            Red = 100;
            Green = 100;
            Blue = 120;
            X = -1;
            Y = -1;
            Z = -1;
            Transparency = 40;
            // Define the internal dimensions of the Container
            InternalWidth = _InternalWidth;
            InternalHeight = _InternalHeight;
            InternalDepth = _InternalDepth;
            
            // Define the external dimensions of the Container
            Width = _ExternalWidth + 2;
            Height = _ExternalHeight + 2;
            Depth = _ExternalDepth + 2;

            // Get the mass of the container and it's weight limit
            // Weight limit should never be an issue but should be kept in mind.
            // Requires balance is, I believe a competely worthless value. - Shayne Hemminger
            WeightLimit = _WeightLimit;
            Weight = _Weight;

            // These are for the packing Logic, there are going to be a lot of functions to deal with these.
            Bins = new List<Bin>();
            Bins.Add(new Bin(0, 0, 0, Width - 2, Height - 2, Depth - 2));
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

            Bins = Bins.OrderBy(b => b.Z).ToList();
            Bins = Bins.OrderBy(b => b.Y).ToList();
            Bins = Bins.OrderBy(b => b.X).ToList();
            
            
            foreach (Bin bin in Bins)
            {
                // Ensure that we start by assuming that it isn't colliding
                collision = false;
                // Move the box to the bin coordinates
                package._X = bin.X;
                package._Y = bin.Y;
                package._Z = bin.Z;

                Rect3D SupportChecker = new Rect3D(package.X, package.Y - 1, package.Z, package.Width, 1, package.Depth);
                int supported = 0;
                
                foreach (Package other in Packages)
                {
                    Rect3D intersect = Rect3D.Intersect(SupportChecker, other.ToRect());
                    collision = IsIntersect(intersect);
                    if (collision)
                    {
                        supported += (int)intersect.SizeX * (int)intersect.SizeY;
                    }
                }
                if (!(supported > (0.75 * (float)package._Width * (float)package._Width)) && Y > 0)
                    collision = true;

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

                package.Rotate(1, true);

                SupportChecker = new Rect3D(package.X, package.Y - 1, package.Z, package.Width, 1, package.Depth);
                supported = 0;
                foreach (Package other in Packages)
                {
                    Rect3D intersect = Rect3D.Intersect(SupportChecker, other.ToRect());
                    collision = IsIntersect(intersect);
                    if (collision)
                    {
                        supported += (int)intersect.SizeX * (int)intersect.SizeY;
                    }
                }
                if (!(supported > (0.75 * (float)package._Width * (float)package._Width)) && Y > 0)
                    collision = true;

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
                package.Rotate(2, true);

                SupportChecker = new Rect3D(package.X, package.Y - 1, package.Z, package.Width, 1, package.Depth);
                supported = 0;
                foreach (Package other in Packages)
                {
                    Rect3D intersect = Rect3D.Intersect(SupportChecker, other.ToRect());
                    collision = IsIntersect(intersect);
                    if (collision)
                    {
                        supported += (int)intersect.SizeX * (int)intersect.SizeY;
                    }
                }
                if (!(supported > (0.75 * (float)package._Width * (float)package._Width)) && Y > 0)
                    collision = true;

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
                package.Rotate(2, false);

                SupportChecker = new Rect3D(package.X, package.Y - 1, package.Z, package.Width, 1, package.Depth);
                supported = 0;
                foreach (Package other in Packages)
                {
                    Rect3D intersect = Rect3D.Intersect(SupportChecker, other.ToRect());
                    collision = IsIntersect(intersect);
                    if (collision)
                    {
                        supported += (int)intersect.SizeX * (int)intersect.SizeY;
                    }
                }
                if (!(supported > (0.75 * (float)package._Width * (float)package._Width)) && Y > 0)
                    collision = true;

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
                package.Rotate(3, true);

                SupportChecker = new Rect3D(package.X, package.Y - 1, package.Z, package.Width, 1, package.Depth);
                supported = 0;
                foreach (Package other in Packages)
                {
                    Rect3D intersect = Rect3D.Intersect(SupportChecker, other.ToRect());
                    collision = IsIntersect(intersect);
                    if (collision)
                    {
                        supported += (int)intersect.SizeX * (int)intersect.SizeY;
                    }
                }
                if (!(supported > (0.75 * (float)package._Width * (float)package._Width)) && Y > 0)
                    collision = true;

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
                package.Rotate(3, false);

                SupportChecker = new Rect3D(package.X, package.Y - 1, package.Z, package.Width, 1, package.Depth);
                supported = 0;
                foreach (Package other in Packages)
                {
                    Rect3D intersect = Rect3D.Intersect(SupportChecker, other.ToRect());
                    collision = IsIntersect(intersect);
                    if (collision)
                    {
                        supported += (int)intersect.SizeX * (int)intersect.SizeY;
                    }
                }
                if (!(supported > (0.75 * (float)package._Width * (float)package._Width)) && Y > 0)
                    collision = true;

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
                package.Rotate(1, false);

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
