using System.Windows.Forms;
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
            BaseEquipable BE = new BaseEquipable(1, "BaseSword", 10);
            BE.EquipEffects.Add("Strength", 1);
            BE.TargetBodyParts.Add(new Arm());

            Session.CurrentPlayer.AddEquipment(BE);
        }

        public override void ButtonBehavior4()
        {
            Session.ReplaceDisplayText("Your current inventory:\n");
            foreach(BodyPart part in Session.CurrentPlayer.BodyParts.Values)
            {
                Session.AddToDisplayText("Your " + part.Name + " has equipped: ");
                foreach (BaseEquipable equipable in part.Equipables)
                {
                    Session.AddToDisplayText(equipable.Name);
                }
            }
        }
    }
}