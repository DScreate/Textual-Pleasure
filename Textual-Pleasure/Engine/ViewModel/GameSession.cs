using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Engine.Annotations;
using Engine.Command;
using Engine.Common;
using Engine.Model.Character;
using Engine.Model.Factories;
using Engine.Model.Items.ConcreteItems;

namespace Engine.ViewModel
{
    public class GameSession : INotifyPropertyChanged
    {
        //private readonly RelayCommand _clickCommand;
        public ACharacter CurrentPlayer { get; set; }
        public AButtonContext ButtonContext { get; set; }

        private string _displayText;

        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;

                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public GameSession()
        {
            StartUpLogging();
            ButtonContext = new DefaultButtonContext(this);
            CurrentPlayer = new PlayerCharacter("Vanessa");
            CurrentPlayer.Experience = 0;
            CurrentPlayer.Level = 1;
            CurrentPlayer.Gold = 10;
        }

        public void AddToDisplayText(String textIn)
        {
            DisplayText += textIn;
        }

        public void ReplaceDisplayText(String textIn)
        {
            DisplayText = textIn;
        }

        public void ClearDisplayText()
        {
            DisplayText = "";
        }

        private void StartUpLogging()
        {            
            FileStream filestream = File.Open("..\\ErrorLog.log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);
        }


        /*
        public RelayCommand ButtonClickCommand
        {
            //get { return _clickCommand; }
        }

        private string _input;
        
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                _clickCommand.OnCanExecuteChanged();
            }
        }
        */
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}