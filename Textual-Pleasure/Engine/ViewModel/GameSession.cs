using Engine.Common;

namespace Engine.ViewModel
{
    public class GameSession
    {
        private readonly RelayCommand _clickCommand;

        public GameSession()
        {
            _clickCommand = new RelayCommand(
                (s) => { /* perform some action */ }, //Execute
                (s) => { return !string.IsNullOrEmpty(_input); } //CanExecute
            );
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

    }
}