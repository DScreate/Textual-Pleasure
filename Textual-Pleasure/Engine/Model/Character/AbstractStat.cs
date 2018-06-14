using System.ComponentModel;
using System.Runtime.CompilerServices;
using Engine.Annotations;

namespace Engine.Model.Character
{
    public abstract class AbstractStat : INotifyPropertyChanged
    {
        private double _value;
        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public AbstractStat(string inName)
        {
            Name = inName;
        }

        public AbstractStat(double inValue, string inName)
        {
            Value = inValue;
            Name = inName;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}