using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Engine.Annotations;
using Engine.Common;

namespace Engine.ViewModel
{
    public class GameSession : INotifyPropertyChanged
    {
        private readonly RelayCommand _clickCommand;

        private string _displayText;

        public string DisplayText
        {
            get => _displayText;
            set
            {
                OnPropertyChanged(nameof(DisplayText));
                _displayText = value;
            }
        }

        public GameSession()
        {
            _clickCommand = new RelayCommand(
                (s) => { /* perform some action */ }, //Execute
                (s) => { return !string.IsNullOrEmpty(_input); } //CanExecute
            );
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

        public RelayCommand ButtonClickCommand
        {
            get { return _clickCommand; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}