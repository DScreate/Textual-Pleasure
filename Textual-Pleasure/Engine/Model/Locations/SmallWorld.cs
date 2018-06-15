using System.Collections.Generic;
using System.Linq;
using Engine.Model.Factories;

namespace Engine.Model.Locations
{
    public class SmallWorld
    {
        private List<Location> _locations = new List<Location>();

        //Location[,] _locations = new Location[100,100];

        internal void CreateLocationAtPoint(int XCoord, int YCoord, int dangerLevel, bool forceSpawn = false)
        {
            Location loc = LocationAt(XCoord, YCoord);

            if (loc != null)
                return;


            loc = LocationFactory.CreateLocation(dangerLevel, forceSpawn);
            loc.XCoordinate = XCoord;
            loc.YCoordinate = YCoord;
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