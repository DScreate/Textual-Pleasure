using System;
using System.Collections.Generic;
using Engine.Model.Items.ConcreteItems;
using Engine.Model.LanguageDictionaries;

namespace Engine.Model.Factories
{
    public static class ItemFactory
    {
        private static List<BaseWeapon> Weapons = new List<BaseWeapon>();

        private static List<BaseEquipable> Equipables = new List<BaseEquipable>();

        private static Random prng = new Random();

        // TODO: Add Implementation for basically everything else
        public static BaseWeapon CreateWeapon(int level, bool allowSpecial = false, bool forceSpecial = false)
        {

            string name = "";
            string material = "";

            if ((allowSpecial && prng.Next(10) <= 2) || forceSpecial)
            {
                material = MaterialsByLevel.GetNextSpecialMaterial(level);
                forceSpecial = true;
            }
            else
            {
                material = MaterialsByLevel.GetNextMaterial(level);
            }

            name = material + " Sword";

            BaseWeapon BW = Weapons.Find(x => x.Name == name);
            if (BW != null)
            {
                return BW;
            }


            BW = new BaseWeapon(Weapons.Count + 1, name, 15 * level, level);
            BW.Exclusive = true;

            if (forceSpecial)
            {
                BW.Price *= 2;
                foreach (string target in BW.EquipEffects.Keys)
                {
                    BW.EquipEffects[target] *= (float)1.5;
                }
            }

            Weapons.Add(BW);
            return BW;
        }
        // TODO : Need to be Changed to BaseArmor? Implement this more fully
        public static BaseEquipable CreateEquipable(int level, bool allowSpecial = false, bool forceSpecial = false)
        {
            string name = "";
            string material = "";

            if ((allowSpecial && prng.Next(10) <= 2) || forceSpecial)
            {
                material = MaterialsByLevel.GetNextSpecialMaterial(level);
                forceSpecial = true;
            }
            else
            {
                material = MaterialsByLevel.GetNextMaterial(level);
            }

            name = material + " Armor";

            BaseEquipable BE = Equipables.Find(x => x.Name == name);
            if (BE != null)
            {
                return BE;
            }


            BE = new BaseEquipable(Weapons.Count + 1, name, 15 * level, level);
            BE.Exclusive = true;

            if (forceSpecial)
            {
                BE.Price *= 2;
                foreach (string target in BE.EquipEffects.Keys)
                {
                    BE.EquipEffects[target] *= (float)1.5;
                }
            }

            Equipables.Add(BE);
            return BE;
        }


    }
}