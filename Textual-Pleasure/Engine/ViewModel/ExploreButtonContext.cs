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
            ButtonContent8 = "???";
            ButtonContent9 = "???";
            ButtonContent10 = "???";


            ButtonEnabled1 = Session.HasLocationToNorth;
            ButtonEnabled2 = Session.HasLocationToSouth;
            ButtonEnabled3 = Session.HasLocationToEast;
            ButtonEnabled4 = Session.HasLocationToWest;

            ButtonEnabled5 = true;

            ButtonEnabled6 = true;
            ButtonEnabled7 = true;

            ButtonEnabled8 = false;
            ButtonEnabled9 = false;
            ButtonEnabled10 = false;
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
           


        }

        public override void ButtonBehavior9()
        {

        }
    }
}