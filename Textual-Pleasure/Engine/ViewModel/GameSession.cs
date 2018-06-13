using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Engine.Annotations;
using Engine.Command;
using Engine.Common;

namespace Engine.ViewModel
{
    public class GameSession : INotifyPropertyChanged
    {
        //private readonly RelayCommand _clickCommand;
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

        public GameSession(AButtonContext newButtonContext = null)
        {
            if(newButtonContext == null)
                ButtonContext = new DefaultButtonContext(this);
            else
                ButtonContext = newButtonContext;
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