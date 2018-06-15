using Engine.Common;
using Engine.Model.Battle;
using Engine.Model.Character.Body;
using Engine.Model.Factories;
using Engine.Model.Items.ConcreteItems;

namespace Engine.ViewModel
{
    public class BattleButtonContext : AButtonContext
    {
        public BattleInstance Battle { get; set; }
        public BattleButtonContext(GameSession session, BattleInstance battle) : base(session)
        {

            Battle = battle;

            ButtonContent1 = "Attack!";
            ButtonContent2 = "Guard";

            ButtonContent3 = "Move East";
            ButtonContent4 = "Move West";
            ButtonContent5 = "Look Around";

            ButtonContent6 = "Equipment";
            ButtonContent7 = "Stats";
            ButtonContent8 = "Armor?";
            ButtonContent9 = "Weapon?";
            ButtonContent10 = "Fight!";


            ButtonEnabled1 = true;
            ButtonEnabled2 = true;
            ButtonEnabled3 = false;
            ButtonEnabled4 = false;

            ButtonEnabled5 = false;

            ButtonEnabled6 = true;
            ButtonEnabled7 = true;

            ButtonEnabled8 = false;
            ButtonEnabled9 = false;
            ButtonEnabled10 = false;
        }

        public override void ButtonBehavior1()
        {
            Battle.AttackCurrentMonster();

        }

        public override void ButtonBehavior2()
        {
            Battle.Guard();
        }

        public override void ButtonBehavior3()
        {
        }

        public override void ButtonBehavior4()
        {
        }

        public override void ButtonBehavior5()
        {
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

        public override void ButtonBehavior10()
        {
            base.ButtonBehavior10();
        }
    }
}