using System.Windows.Forms;
using Engine.Model.Character;
using Engine.Model.Character.Body;
using Engine.Model.Factories;
using Engine.Model.Items.Behaviors;
using Engine.Model.Items.ConcreteItems;

namespace Engine.ViewModel
{
    public class DefaultButtonContext : AButtonContext
    {
        public DefaultButtonContext(GameSession session) : base(session)
        {
            ButtonContent1 = "Test Add Test";
            ButtonContent2 = "Test Add Weapon";
            ButtonContent3 = "Other Test";
        }

        public override void ButtonBehavior1()
        {
            Session.AddToDisplayText("Default Context: Button1 Pressed\n");
            //MessageBox.Show("Responding to button click event...");

        }

        public override void ButtonBehavior2()
        {
            Session.ReplaceDisplayText("You found a weapon!");
            Session.CurrentPlayer.AddEquipment(ItemFactory.CreateWeapon(15, false, false));
        }

        public override void ButtonBehavior3()
        {
            Session.ReplaceDisplayText("You found a basic weapon!");
            Session.CurrentPlayer.AddEquipment(ItemFactory.CreateWeapon(1, false, false));
        }

        public override void ButtonBehavior4()
        {
            Session.ReplaceDisplayText("Your current inventory:\n");
            foreach(BodyPart part in Session.CurrentPlayer.BodyParts.Values)
            {
                Session.AddToDisplayText("Your " + part.Name + " has equipped: ");
                foreach (BaseEquipable equipable in part.Equipables)
                {
                    Session.AddToDisplayText(equipable.Name + " ");
                }
                Session.AddToDisplayText("\n");
            }
        }

        public override void ButtonBehavior5()
        {
            Session.ReplaceDisplayText("Your current power:\n");
            Session.AddToDisplayText(Session.CurrentPlayer.myStats.StrengthMeleeDamage.Value.ToString());
        }

        public override void ButtonBehavior6()
        {
            Session.ReplaceDisplayText("You took 1 damage");
            Session.CurrentPlayer.CurrentHealth--;
        }

        public override void ButtonBehavior7()
        {
            Session.ReplaceDisplayText("You healed 1 damage");
            Session.CurrentPlayer.CurrentHealth++;
        }

        public override void ButtonBehavior8()
        {
            Session.ReplaceDisplayText("Now giving you armor!");

            Session.CurrentPlayer.AddEquipment(ItemFactory.CreateArmor(1, Arm.ArmFactory(false)));
            Session.CurrentPlayer.AddEquipment(ItemFactory.CreateArmor(1, Arm.ArmFactory(true)));
            Session.CurrentPlayer.AddEquipment(ItemFactory.CreateArmor(1, Leg.LegFactory(false)));
            Session.CurrentPlayer.AddEquipment(ItemFactory.CreateArmor(1, Leg.LegFactory(true)));

            Session.CurrentPlayer.AddEquipment(ItemFactory.CreateArmor(1, Torso.TorsoFactory()));
            Session.CurrentPlayer.AddEquipment(ItemFactory.CreateArmor(1, Head.HeadFactory()));


        }

        public override void ButtonBehavior9()
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
    
    }
}