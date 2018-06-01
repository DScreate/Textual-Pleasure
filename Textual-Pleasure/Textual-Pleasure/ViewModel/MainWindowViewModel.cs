using Textual_Pleasure.Common;

namespace Textual_Pleasure.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly RelayCommand _clickCommand;

        public MainWindowViewModel()
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