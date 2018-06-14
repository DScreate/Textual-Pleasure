using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Model.Character.Body;
using Engine.Model.Items.ConcreteItems;
using Engine.Model.LanguageDictionaries;

namespace Engine.Model.Factories
{
    public static class ItemFactory
    {
        private static List<BaseWeapon> Weapons = new List<BaseWeapon>();

        private static List<BaseEquipable> Equipables = new List<BaseEquipable>();

        private static List<BaseArmor> Armors = new List<BaseArmor>();

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
                foreach (string target in BW.EquipEffects.Keys.ToList())
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


            BE = new BaseEquipable(Equipables.Count + 1, name, 15 * level, level);
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


        public static BaseArmor CreateArmor(int level, BodyPart BodyPart, bool allowSpecial = false, bool forceSpecial = false)
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

            name = material + " " + BodyPart.Name + " Armor";

            BaseArmor BA = Armors.Find(x => x.Name == name);
            if (BA != null)
            {
                return BA;
            }


            BA = new BaseArmor(Armors.Count + 1, name, 15 * level, level);
            BA.Exclusive = true;

            BA.TargetBodyParts.Add(BodyPart);

            if (BodyPart.GetType() == typeof(Arm))
            {
                BA.EquipEffects.Add("Agility", 1 * level);
                BA.EquipEffects.Add("Toughness", 1 * level);
            } else if (BodyPart.GetType() == typeof(Leg))
            {
                BA.EquipEffects.Add("Willpower", 1 * level);
                BA.EquipEffects.Add("Toughness", 1 * level);
            } else if ((BodyPart.GetType() == typeof(Head)))
            {
                BA.EquipEffects.Add("Intelligence", 1 * level);
                BA.EquipEffects.Add("Toughness", (int)(.5 * level));
            }
            else
            {
                BA.EquipEffects.Add("Toughness", 1 * level);
                BA.EquipEffects.Add("Charisma", 1 * level);
            }

            if (forceSpecial)
            {
                BA.Price *= 2;
                foreach (string target in BA.EquipEffects.Keys.ToList())
                {
                    BA.EquipEffects[target] *= (float)1.5;
                }
            }

            Armors.Add(BA);
            return BA;
        }

    }
}