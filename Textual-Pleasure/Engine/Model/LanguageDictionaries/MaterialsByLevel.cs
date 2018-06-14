using System.Collections.Generic;
using System.Linq;

namespace Engine.Model.LanguageDictionaries
{
    public struct MaterialsByLevel
    {
        public static SortedList<int, string> MaterialDictionary = new SortedList<int, string>()
        {
            {1, "Wood"},
            {3, "Iron" },
            {5, "Steel" },
            {7, "Truesteel" },
            {10, "Obsidian" },
            {15, "Adamantine" }
        };

        public static SortedList<int, string> SpecialMaterialDictionary = new SortedList<int, string>()
        {
            {1, "Elderwood"},
            {3, "Ghost Iron" },
            {5, "Stainless Steel" },
            {7, "Silver" },
            {10, "Star Iron" },
            {15, "Mythril" }
        };

        //int k = GetK(); // or whatever

        public static string GetNextMaterial(int k)
        {
            while (!MaterialDictionary.ContainsKey(k))
            {

                if (k > MaterialDictionary.Keys.Max())
                {
                    return MaterialDictionary[MaterialDictionary.Keys.Count];
                }

                k++; 
            }

            return MaterialDictionary[k];
        }

        public static string GetNextSpecialMaterial(int k)
        {
            while (!SpecialMaterialDictionary.ContainsKey(k))
            {

                if (k > SpecialMaterialDictionary.Keys.Max())
                {
                    return SpecialMaterialDictionary[SpecialMaterialDictionary.Keys.Count];
                }

                k++;
            }

            return SpecialMaterialDictionary[k];
        }


    }
}