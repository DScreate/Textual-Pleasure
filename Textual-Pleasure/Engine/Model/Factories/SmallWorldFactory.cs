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

        internal SmallWorld CreateWorld(int x, int y)
        {
            SmallWorld newWorld = new SmallWorld();

            newWorld.CreateLocationAtPoint(x, y, 0, true);
            ExpandWorld(newWorld, x, y);

            return newWorld;
        }

        internal void ExpandWorld(SmallWorld world, int x, int y)
        {
            int i = x;
            int j = y;

            i = x - 1;
            world.CreateLocationAtPoint(i, j, i > j ? i / 2 : j / 2);


            i = x + 1;
            world.CreateLocationAtPoint(i, j, i > j ? i / 2 : j / 2);


            i = x;
            j = y - 1;
            world.CreateLocationAtPoint(i, j, i > j ? i / 2 : j / 2);

            j = y + 1;
            world.CreateLocationAtPoint(i, j, i > j ? i / 2 : j / 2);
        }
    }
}