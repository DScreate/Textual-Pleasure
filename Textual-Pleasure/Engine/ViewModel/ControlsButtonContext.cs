using System.Windows.Forms;
using Engine.Model.Character;
using Engine.Model.Factories;

namespace Engine.ViewModel
{
    public class ControlsButtonContext : AButtonContext
    {
        public ControlsButtonContext(GameSession session) : base(session)
        {
            ButtonContent1 = "Spawn Enemy";
            ButtonContent2 = "Help";

            ButtonEnabled1 = true;
            ButtonEnabled2 = true;
        }

        public override void ButtonBehavior1()
        {

            BaseMonster BM = MonsterFactory.CreateBaseMonster(Session.CurrentPlayer.Level, true);

            Session.CurrentLocation.AddCharacter(BM);

            Session.ReplaceDisplayText(BM.Name + " has appeared!");

            
        }

        public override void ButtonBehavior2()
        {
            MessageBox.Show("Basic text game by Derek Sams. Look forward to more in the future!\nHaving trouble? Try spam clicking the Armor/Weapon Buttons for some free gear!",
                "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}