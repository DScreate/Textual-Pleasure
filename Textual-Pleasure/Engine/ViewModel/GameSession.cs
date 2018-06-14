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
using Engine.Model.Locations;

namespace Engine.ViewModel
{
    public class GameSession : INotifyPropertyChanged
    {
        //private readonly RelayCommand _clickCommand;
        public ACharacter CurrentPlayer { get; set; }
        public AButtonContext ButtonContext { get; set; }
        public SmallWorld CurrentWorld { get; set; }

        private Location _currentLocation;

        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));


                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToSouth));
            }
        }

        private SmallWorldFactory factory;

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

            factory = new SmallWorldFactory();
            CurrentWorld = factory.CreateWorld(0, 0);

            CurrentLocation = CurrentWorld.LocationAt(0, 0);
            //factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);


            ButtonContext = new ExploreButtonContext(this);
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


        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);
        }

        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);

        }

        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);

        }

        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);

        }

        public bool HasLocationToNorth
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
            }
        }

        public bool HasLocationToEast
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public bool HasLocationToSouth
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
            }
        }

        public bool HasLocationToWest
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public void DescribeLocation()
        {
            Location loc = CurrentLocation;
            AddToDisplayText("Looking at the " + loc.Name + ", you can see that ");
            foreach (ACharacter character in loc.Characters)
            {
                AddToDisplayText(character.Name + " is here\n");
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