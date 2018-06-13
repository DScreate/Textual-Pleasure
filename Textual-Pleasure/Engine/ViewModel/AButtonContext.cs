using System.Windows.Input;
using Engine.Command;

namespace Engine.ViewModel
{
    public abstract class AButtonContext
    {

        private GameSession _session;

        public GameSession Session { get; set; }

        public ICommand ButtonCommand1
        {
            get => _buttonCommand1;
            set => _buttonCommand1 = value;
        }

        public ICommand ButtonCommand2
        {
            get => _buttonCommand2;
            set => _buttonCommand2 = value;
        }

        public ICommand ButtonCommand3
        {
            get => _buttonCommand3;
            set => _buttonCommand3 = value;
        }

        public ICommand ButtonCommand4
        {
            get => _buttonCommand4;
            set => _buttonCommand4 = value;
        }

        public ICommand ButtonCommand5
        {
            get => _buttonCommand5;
            set => _buttonCommand5 = value;
        }

        public ICommand ButtonCommand6
        {
            get => _buttonCommand6;
            set => _buttonCommand6 = value;
        }

        public ICommand ButtonCommand7
        {
            get => _buttonCommand7;
            set => _buttonCommand7 = value;
        }

        public ICommand ButtonCommand8
        {
            get => _buttonCommand8;
            set => _buttonCommand8 = value;
        }

        public ICommand ButtonCommand9
        {
            get => _buttonCommand9;
            set => _buttonCommand9 = value;
        }

        public ICommand ButtonCommand10
        {
            get => _buttonCommand10;
            set => _buttonCommand10 = value;
        }

        private ICommand _buttonCommand1;
        private ICommand _buttonCommand2;
        private ICommand _buttonCommand3;
        private ICommand _buttonCommand4;
        private ICommand _buttonCommand5;
        private ICommand _buttonCommand6;
        private ICommand _buttonCommand7;
        private ICommand _buttonCommand8;
        private ICommand _buttonCommand9;
        private ICommand _buttonCommand10;

        // What we want:

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

            /*
            ButtonCommand2 = new RelayCommand(x =>
            {
                ButtonBehavior2();
            },
                ButtonCommand2.CanExecute
            );

            ButtonCommand3 = new RelayCommand(x =>
            {
                ButtonBehavior3();
            },
                ButtonCommand3.CanExecute
            );

            ButtonCommand4 = new RelayCommand(x =>
            {
                ButtonBehavior4();
            },
                ButtonCommand4.CanExecute
            );

            ButtonCommand5 = new RelayCommand(x =>
            {
                ButtonBehavior5();
            },
                ButtonCommand5.CanExecute
            );

            ButtonCommand6 = new RelayCommand(x =>
            {
                ButtonBehavior6();
            },
                ButtonCommand6.CanExecute
            );

            ButtonCommand7 = new RelayCommand(x =>
            {
                ButtonBehavior7();
            },
                ButtonCommand7.CanExecute
            );

            ButtonCommand8 = new RelayCommand(x =>
            {
                ButtonBehavior8();
            },
                ButtonCommand8.CanExecute
            );

            ButtonCommand9 = new RelayCommand(x =>
            {
                ButtonBehavior9();
            },
                ButtonCommand9.CanExecute
            );

            ButtonCommand10 = new RelayCommand(x =>
            {
                ButtonBehavior10();
            },
                ButtonCommand10.CanExecute
            );
            */
        }
        // Some kind of additional functionality for having certain actions have their own button?
    }
}
