using System.Windows;
using Engine.Common;
using Engine.Model.Battle;
using Engine.Model.Character;
using Engine.Model.Character.Body;
using Engine.Model.Factories;
using Engine.Model.Items.ConcreteItems;

namespace Engine.ViewModel
{
    public class ExploreButtonContext : AButtonContext
    {
        public ExploreButtonContext(GameSession session) : base(session)
        {
            ButtonContent1 = "Move North";
            ButtonContent2 = "Move South";
            ButtonContent3 = "Move East";
            ButtonContent4 = "Move West";
            ButtonContent5 = "Look Around";

            ButtonContent6 = "Equipment";
            ButtonContent7 = "Stats";
            ButtonContent8 = "Armor?";
            ButtonContent9 = "Weapon?";
            ButtonContent10 = "Fight!";


            ButtonEnabled1 = Session.HasLocationToNorth;
            ButtonEnabled2 = Session.HasLocationToSouth;
            ButtonEnabled3 = Session.HasLocationToEast;
            ButtonEnabled4 = Session.HasLocationToWest;

            ButtonEnabled5 = true;

            ButtonEnabled6 = true;
            ButtonEnabled7 = true;

            ButtonEnabled8 = true;
            ButtonEnabled9 = true;
            ButtonEnabled10 = true;
        }

        public override void ButtonBehavior1()
        {
            Session.MoveNorth();

        }

        public override void ButtonBehavior2()
        {
            Session.MoveSouth();

        }

        public override void ButtonBehavior3()
        {
            Session.MoveEast();
        }

        public override void ButtonBehavior4()
        {
           Session.MoveWest();
        }

        public override void ButtonBehavior5()
        {
            Session.DescribeLocation();
        }

        public override void ButtonBehavior6()
        {
            Session.ReplaceDisplayText("Your current inventory:\n");
            foreach (BodyPart part in Session.CurrentPlayer.BodyParts.Values)
            {
                Session.AddToDisplayText("Your " + part.Name + " has equipped: ");
                foreach (BaseEquipable equipable in part.Equipables)
                {
                    Session.AddToDisplayText(equipable.Name + " ");
                }
                Session.AddToDisplayText("\n");
            }
        }

        public override void ButtonBehavior7()
        {
            Session.ReplaceDisplayText("Your stats are:\n");
            Session.AddToDisplayText("Strength: " + Session.CurrentPlayer.myStats.Strength.Value + "\n");
            Session.AddToDisplayText("Toughness: " + Session.CurrentPlayer.myStats.Toughness.Value + "\n");
            Session.AddToDisplayText("Agility: " + Session.CurrentPlayer.myStats.Agility.Value + "\n");
            Session.AddToDisplayText("Perception: " + Session.CurrentPlayer.myStats.Perception.Value + "\n");
            Session.AddToDisplayText("Intelligence: " + Session.CurrentPlayer.myStats.Intelligence.Value + "\n");
            Session.AddToDisplayText("Willpower: " + Session.CurrentPlayer.myStats.Willpower.Value + "\n");
            Session.AddToDisplayText("Charisma: " + Session.CurrentPlayer.myStats.Charisma.Value + "\n");
            Session.AddToDisplayText("Corruption: " + Session.CurrentPlayer.myStats.Corruption.Value + "\n");
            Session.AddToDisplayText("Appeal: " + Session.CurrentPlayer.myStats.Appeal.Value + "\n");
            Session.AddToDisplayText("Health: " + Session.CurrentPlayer.myStats.Health.Value + "\n");
            Session.AddToDisplayText("Endurance: " + Session.CurrentPlayer.myStats.Endurance.Value + "\n");
            Session.AddToDisplayText("Power: " + Session.CurrentPlayer.myStats.StrengthMeleeDamage.Value + "\n");
            Session.AddToDisplayText("Skill: " + Session.CurrentPlayer.myStats.AgilityMeleeDamage.Value + "\n");
            Session.AddToDisplayText("Accuracy: " + Session.CurrentPlayer.myStats.RangedDamage.Value + "\n");
        }

        public override void ButtonBehavior8()
        {
            Session.ReplaceDisplayText("Searching around...");
            if (RandomNumberGenerator.NumberBetween(0, 5) > 1)
            {
                Session.AddToDisplayText("\n...you found nothing");
                return;
            } 


            Session.ReplaceDisplayText("You found a piece of armor!");

            BaseArmor BA;

            switch (RandomNumberGenerator.NumberBetween(0, 7))
            {
                case 1:
                    BA = ItemFactory.CreateArmor(Session.CurrentPlayer.Level, Arm.ArmFactory(false), true);
                    break;
                case 2:
                    BA = ItemFactory.CreateArmor(Session.CurrentPlayer.Level, Arm.ArmFactory(true), true);
                    break;
                case 3:
                    BA = ItemFactory.CreateArmor(Session.CurrentPlayer.Level, Leg.LegFactory(false), true);
                    break;
                case 4:
                    BA = ItemFactory.CreateArmor(Session.CurrentPlayer.Level, Leg.LegFactory(true), true);
                    break;
                case 5:
                    BA = ItemFactory.CreateArmor(Session.CurrentPlayer.Level, Torso.TorsoFactory(), true);
                    break;
                case 6:
                    BA = ItemFactory.CreateArmor(Session.CurrentPlayer.Level, Torso.TorsoFactory(), true);
                    break;
                default:
                    BA = ItemFactory.CreateArmor(Session.CurrentPlayer.Level, Head.HeadFactory(), true);
                    break;
            }
            Session.AddToDisplayText("\nYou found:\n" + BA.Name);
            Session.CurrentPlayer.AddEquipment(BA);


        }

        public override void ButtonBehavior9()
        {
            Session.ReplaceDisplayText("Searching around...");
            if (RandomNumberGenerator.NumberBetween(0, 5) > 1)
            {
                Session.AddToDisplayText("\n...you found nothing");
                return;
            }

            Session.ReplaceDisplayText("You found a weapon!");

            BaseWeapon BW = ItemFactory.CreateWeapon(Session.CurrentPlayer.Level, true);

            Session.AddToDisplayText("\nYou found:\n" + BW.Name);
            Session.CurrentPlayer.AddEquipment(BW);
        }


        public override void ButtonBehavior10()
        {
            if (Session.CurrentLocation.Characters.Count > 0)
            {
                while (Session.CurrentLocation.Characters.Count > 0)
                {
                    BattleInstance battle = new BattleInstance(Session, (PlayerCharacter)Session.CurrentPlayer, (BaseMonster)Session.CurrentLocation.Characters[Session.CurrentLocation.Characters.Count-1]);
                    Session.CurrentLocation.Characters.RemoveAt(Session.CurrentLocation.Characters.Count -1);
                }
            }
            else
            {
                Session.AddToDisplayText("\nThere is nobody to fight!");
            }
        }
    }
}