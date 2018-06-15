using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Engine.Annotations;
using Engine.Command;

namespace Engine.ViewModel
{
    public abstract class AButtonContext : INotifyPropertyChanged
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

        private bool _buttonEnabled1;
        private bool _buttonEnabled2;
        private bool _buttonEnabled3;
        private bool _buttonEnabled4;
        private bool _buttonEnabled5;
        private bool _buttonEnabled6;
        private bool _buttonEnabled7;
        private bool _buttonEnabled8;
        private bool _buttonEnabled9;
        private bool _buttonEnabled10;

        public virtual bool ButtonEnabled1
        {
            get => _buttonEnabled1;
            set
            {
                _buttonEnabled1 = value;
                OnPropertyChanged(nameof(ButtonEnabled1));
            }
        }
        public virtual bool ButtonEnabled2
        {
            get => _buttonEnabled2;
            set
            {
                _buttonEnabled2 = value;
                OnPropertyChanged(nameof(ButtonEnabled2));
            }
        }
        public virtual bool ButtonEnabled3
        {
            get => _buttonEnabled3;
            set
            {
                _buttonEnabled3 = value;
                OnPropertyChanged(nameof(ButtonEnabled3));
            }
        }
        public virtual bool ButtonEnabled4
        {
            get => _buttonEnabled4;
            set
            {
                _buttonEnabled4 = value;
                OnPropertyChanged(nameof(ButtonEnabled4));
            }
        }
        public virtual bool ButtonEnabled5
        {
            get => _buttonEnabled5;
            set
            {
                _buttonEnabled5 = value;
                OnPropertyChanged(nameof(ButtonEnabled5));
            }
        }
        public virtual bool ButtonEnabled6
        {
            get => _buttonEnabled6;
            set
            {
                _buttonEnabled6 = value;
                OnPropertyChanged(nameof(ButtonEnabled6));
            }
        }
        public virtual bool ButtonEnabled7
        {
            get => _buttonEnabled7;
            set
            {
                _buttonEnabled7 = value;
                OnPropertyChanged(nameof(ButtonEnabled7));
            }
        }
        public virtual bool ButtonEnabled8
        {
            get => _buttonEnabled8;
            set
            {
                _buttonEnabled8 = value;
                OnPropertyChanged(nameof(ButtonEnabled8));
            }
        }
        public virtual bool ButtonEnabled9
        {
            get => _buttonEnabled9;
            set
            {
                _buttonEnabled9 = value;
                OnPropertyChanged(nameof(ButtonEnabled9));
            }
        }
        public virtual bool ButtonEnabled10
        {
            get => _buttonEnabled10;
            set
            {
                _buttonEnabled10 = value;
                OnPropertyChanged(nameof(ButtonEnabled10));
            }
        }



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

        public virtual void ButtonBehavior5()
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
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
