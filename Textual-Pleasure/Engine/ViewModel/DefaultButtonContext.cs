using System.Windows.Forms;

namespace Engine.ViewModel
{
    public class DefaultButtonContext : AButtonContext
    {
        public DefaultButtonContext(GameSession session) : base(session)
        {
            
        }

        public override void ButtonBehavior1()
        {
            Session.AddToDisplayText("Default Context: Button1 Pressed\n");
            //MessageBox.Show("Responding to button click event...");

        }
    }
}