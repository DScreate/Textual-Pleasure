using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Engine.Model.LanguageDictionaries
{
    public struct MonstersByLevel
    {
        public static SortedList<int, string> MonsterDictionary = new SortedList<int, string>()
        {
            {1, "Bandit"},
            {3, "Skeleton" },
            {5, "Orc" },
            {7, "Ogre" },
            {10, "Fallen Knight" },
            {15, "Skeleton Lord" }
        };

        public static SortedList<int, string> SpecialMonsterDictionary = new SortedList<int, string>()
        {
            {1, "Crimelord"},
            {3, "Revenant" },
            {5, "Orc Boss" },
            {7, "Troll" },
            {10, "Dark Paladin" },
            {15, "Vampire" }
        };

        // Todo: Oh lord please fix this
        public static string RandomMonsterName(int seed)
        {
            switch (seed)
            {
                case 1:
                    return "Lokthrop";
                    
                case 2:
                    return "Zemlum";
                    
                case 3:
                    return "Harold";
                    
                case 4:
                    return "Adani";
                    
                case 5:
                    return "Lizzy";
                    
                case 6:
                    return "Ziggle";
                    
                case 7:
                    return "Hector von Berstenstein";
                    
                case 8:
                    return "Hamza Garthside";
                    
                case 9:
                    return "Bendix Dawson";
                    
                case 10:
                    return "Mustafa Whiteley";
                    
                case 11:
                    return "Wladisla Burlingame";
                    
                case 12:
                    return "Hamelin Clare";
                    
                case 13:
                    return "Jakob Blythe";
                    
                case 14:
                    return "Carrington Newbery";
                case 15:
                    return "Donatien Whitney";
                case 16:
                    return "Giuseppe Kent";
                case 17:
                    return "Holden Churchill";
                case 18:
                    return "Kinnard Shurman";
                case 19:
                    return "Moor Keats";
                default:
                    return "Andrew";
            }
                
        }

        //int k = GetK(); // or whatever

        public static string GetNextMonster(int k)
        {
            while (!MonsterDictionary.ContainsKey(k))
            {

                if (k > MonsterDictionary.Keys.Max())
                {
                    return MonsterDictionary[MonsterDictionary.Keys.Count];
                }

                k++;
            }

            return MonsterDictionary[k];
        }

        public static string GetNextSpecialMonster(int k)
        {
            while (!SpecialMonsterDictionary.ContainsKey(k))
            {

                if (k > SpecialMonsterDictionary.Keys.Max())
                {
                    return SpecialMonsterDictionary[SpecialMonsterDictionary.Keys.Count];
                }

                k++;
            }

            return SpecialMonsterDictionary[k];
        }
    }
}