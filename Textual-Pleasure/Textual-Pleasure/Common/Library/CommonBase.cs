using System.ComponentModel;
using System.Runtime.CompilerServices;
using Textual_Pleasure.Annotations;

namespace Textual_Pleasure.Library
{
    public class CommonBase : INotifyPropertyChanged
    {
        #region  INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                
                // Raise the PropertyChanged event
                handler(this, args);
            }
        }
        #endregion
    }
}