using System.Collections.Generic;
using System.Linq;
using Engine.Model.Factories;

namespace Engine.Model.Locations
{
    public class SmallWorld
    {
        private List<Location> _locations = new List<Location>();

        internal void CreateLocationAtPoint(int XCoord, int yCoord, int dangerLevel)
        {
            Location loc = LocationFactory.CreateLocation(dangerLevel);
            _locations.Add(loc);
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach (Location loc in _locations.ToList())
            {
                if (loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate)
                {
                    return loc;
                }
            }

            return null;
        }
    }
}