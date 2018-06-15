using System.Collections.Generic;
using Engine.Common;
using Engine.Model.Locations;

namespace Engine.Model.Factories
{
    public static class LocationFactory
    {
        public static List<Location> Locations = new List<Location>();

        public static Location CreateLocation(int dangerLevel, bool forceSpawn = false)
        {
            string name = GetRandomLocationName(RandomNumberGenerator.NumberBetween(0, 20));
            string id = name + "_" + dangerLevel;

            Location loc = Locations.Find(x => x.Name == name);
            if (loc != null)
            {
                return loc;
            }


            loc = new Location(name, "Somewhere out in the world...");
            if((RandomNumberGenerator.NumberBetween(0, 20) < dangerLevel) || forceSpawn)
                loc.AddCharacter(MonsterFactory.CreateBaseMonster(dangerLevel, true));

            Locations.Add(loc);
            return loc;
        }

        // TODO: Dear god fix this
        public static string GetRandomLocationName(int seed)
        { 
            switch (seed)
            {
                case 1:
                    return "Grassy Field";
                case 2:
                    return "Quiet Forest";
                case 3:
                    return "Rolling Hills";
                case 4:
                    return "Quiet Plains";
                case 5:
                    return "Thick Forest";
                case 6:
                    return "Shrub Steppe";
                case 7:
                    return "Dry Plains";
                case 8:
                    return "Rumbling Mountain";
                case 9:
                    return "Snow-Capped Mountain";
                case 10:
                    return "Abandoned Castle";
                case 11:
                    return "Ancient Fort";
                case 12:
                    return "Dark Cave";
                case 13:
                    return "Deep Forest";
                case 14:
                    return "Sandy Beach";
                case 15:
                    return "Ancient Dunes";
                case 16:
                    return "Whispering Woods";
                case 17:
                    return "Haunted Forest";
                case 18:
                    return "Pleasant Plains";
                case 19:
                    return "Old Campsite";
                default:
                    return "Tall Mountain";
            }
        
        }
    }
}