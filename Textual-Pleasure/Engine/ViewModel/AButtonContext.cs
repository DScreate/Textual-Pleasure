using System.Windows.Input;
using Engine.Command;

namespace Engine.ViewModel
{
    public abstract class AButtonContext
    {

        private GameSession _session;

        public GameSession Session { get; set; }

        public ICommand ButtonCommand1 { get; set; }

        public ICommand ButtonCommand2 { get; set; }

        public ICommand ButtonCommand3 { get; set; }

        public ICommand ButtonCommand4 { get; set; }

        public ICommand ButtonCommand5 { get; set; }

        public ICommand ButtonCommand6 { get; set; }

        public ICommand ButtonCommand7 { get; set; }

        public ICommand ButtonCommand8 { get; set; }

        public ICommand ButtonCommand9 { get; set; }

        public ICommand ButtonCommand10 { get; set; }

        // What we want:

        public string ButtonContent1 { get; set; }
        public string ButtonContent2 { get; set; }
        public string ButtonContent3 { get; set; }
        public string ButtonContent4 { get; set; }
        public string ButtonContent5 { get; set; }
        public string ButtonContent6 { get; set; }
        public string ButtonContent7 { get; set; }
        public string ButtonContent8 { get; set; }
        public string ButtonContent9 { get; set; }
        public string ButtonContent10 { get; set; }


        // A holder class that contains methods to define behaviors for each button
        public virtual void ButtonBehavior1()
        {
            Session.AddToDisplayText("Button1 Pressed\n");
        }

        public virtual void ButtonBehavior2()
        {
            Session.AddToDisplayText("Button2 Pressed\n");
        }

        public virtual void ButtonBehavior3()
        {
            Session.AddToDisplayText("Button3 Pressed\n");
        }

        public virtual void ButtonBehavior4()
        {
            Session.AddToDisplayText("Button4 Pressed\n");
        }

        public void ButtonBehavior5()
        {
            Session.AddToDisplayText("Button5 Pressed\n");
        }

        public virtual void ButtonBehavior6()
        {
            Session.AddToDisplayText("Button6 Pressed\n");
        }

        public virtual void ButtonBehavior7()
        {
            Session.AddToDisplayText("Button7 Pressed\n");
        }

        public virtual void ButtonBehavior8()
        {
            Session.AddToDisplayText("Button8 Pressed\n");
        }

        public virtual void ButtonBehavior9()
        {
            Session.AddToDisplayText("Button9 Pressed\n");
        }

        public virtual void ButtonBehavior10()
        {
            Session.AddToDisplayText("Button10 Pressed\n");
        }

        // A property for each button that can be bound to in order to define whether or not that button
        // is active and visible
        protected AButtonContext(GameSession session)
        {

            Session = session;

            ButtonCommand1 = new RelayCommand(
                o =>
                    {
                        ButtonBehavior1();
                    }
            );

            ButtonCommand2 = new RelayCommand(
                o =>
                {
                    ButtonBehavior2();
                }
            );

            ButtonCommand3 = new RelayCommand(
                o =>
                {
                    ButtonBehavior3();
                }
            );

            ButtonCommand4 = new RelayCommand(
                o =>
                {
                    ButtonBehavior4();
                }
            );

            ButtonCommand5 = new RelayCommand(
                o =>
                {
                    ButtonBehavior5();
                }
            );

            ButtonCommand6 = new RelayCommand(
                o =>
                {
                    ButtonBehavior6();
                }
            );

            ButtonCommand7 = new RelayCommand(
                o =>
                {
                    ButtonBehavior7();
                }
            );

            ButtonCommand8 = new RelayCommand(
                o =>
                {
                    ButtonBehavior8();
                }
            );

            ButtonCommand9 = new RelayCommand(
                o =>
                {
                    ButtonBehavior9();
                }
            );

            ButtonCommand10 = new RelayCommand(
                o =>
                {
                    ButtonBehavior10();
                }
            );
        }
        // Some kind of additional functionality for having certain actions have their own button?
    }
}
