using System.Collections.Generic;
using Engine.Common;
using Engine.Model.Character;
using Engine.Model.Character.Body;
using Engine.Model.Items.ConcreteItems;
using Engine.Model.LanguageDictionaries;

namespace Engine.Model.Factories
{
    public static class MonsterFactory
    {
        private static List<BaseMonster> Monsters = new List<BaseMonster>();

        public static BaseMonster CreateBaseMonster(int level, bool allowSpecial = false, bool forceSpecial = false)
        {
            string name = MonstersByLevel.RandomMonsterName(RandomNumberGenerator.NumberBetween(0, 20));
            string monsterName = "";

            if ((allowSpecial && RandomNumberGenerator.NumberBetween(0, 10) <= 2) || forceSpecial)
            {
                monsterName = MonstersByLevel.GetNextSpecialMonster(level);
                forceSpecial = true;
            }
            else
            {
                monsterName = MonstersByLevel.GetNextMonster(level);
            }

            name = name + ", the " + monsterName;

            BaseMonster BM = Monsters.Find(x => x.Name == name);
            if (BM != null)
            {
                return BM;
            }

            BM = new BaseMonster(name);

            BM.RewardGold = 6 * (level + 1);
            BM.RewardExperiencePoints = 4 * (level + 1);

            if (forceSpecial)
            {
                int num = RandomNumberGenerator.NumberBetween(0, 6);
                BM.RewardExperiencePoints = (int)(BM.RewardExperiencePoints * 1.25);
                BM.RewardGold = (int)(BM.RewardGold * 1.25);
                while (num > 0)
                {
                    int num2 = RandomNumberGenerator.NumberBetween(0, 8);
                    switch (num2)
                    {
                        case 1:
                            BM.AddEquipment(ItemFactory.CreateWeapon(level, true, true));
                            break;
                        case 2:
                            BM.AddEquipment(ItemFactory.CreateArmor(level, Torso.TorsoFactory(), true, true));
                            break;
                        case 3:
                            BM.AddEquipment(ItemFactory.CreateArmor(level, Arm.ArmFactory(true), true, true));
                            break;
                        case 4:
                            BM.AddEquipment(ItemFactory.CreateArmor(level, Arm.ArmFactory(false), true, true));
                            break;
                        case 5:
                            // TODO THis was the error point
                            BM.AddEquipment(ItemFactory.CreateArmor(level, Leg.LegFactory(false), true, true));
                            break;
                        case 6:
                            BM.AddEquipment(ItemFactory.CreateArmor(level, Head.HeadFactory(), true, true));
                            break;
                        case 7:
                            BM.myStats.Strength.Value *= 1.2;
                            break;
                        case 8:
                            BM.myStats.Toughness.Value *= 1.2;
                            break;
                        default:
                            break;
                    }
                }
            }

            Monsters.Add(BM);
            return BM;
        }
    }
}