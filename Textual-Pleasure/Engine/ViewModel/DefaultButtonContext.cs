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
    }
}