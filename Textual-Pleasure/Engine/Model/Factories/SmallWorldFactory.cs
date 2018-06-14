using System.Runtime.InteropServices.ComTypes;
using Engine.Common;
using Engine.Model.Locations;

namespace Engine.Model.Factories
{
    public class SmallWorldFactory
    {



        internal SmallWorld CreateWorld()
        {
            int y = RandomNumberGenerator.NumberBetween(0, 5);
            int x = RandomNumberGenerator.NumberBetween(0, 5);

            x = 10;
            y = 10;
            SmallWorld newWorld = new SmallWorld();

            for (int i = 0; i <= y; i++)
            {
                for (int j = 0; j <= x; j++)
                {
                    newWorld.CreateLocationAtPoint(i,j, i > j ? i/2 : j/2);
                }
            }

            return newWorld;
        }
    }
}