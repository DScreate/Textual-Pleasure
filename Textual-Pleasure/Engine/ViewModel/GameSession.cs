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
        private AButtonContext _buttonContext;
        public AButtonContext ButtonContext
        {
            get => _buttonContext;
            set
            {
                _buttonContext = value;
                OnPropertyChanged(nameof(ButtonContext));

            }
        }

        private ControlsButtonContext _controlsButtonContext;

        public ControlsButtonContext ControlsButtonContext
        {
            get => _controlsButtonContext;
            set
            {
                _controlsButtonContext = value;
                OnPropertyChanged(nameof(ControlsButtonContext));
            }
        }

        public SmallWorld CurrentWorld { get; set; }

        private Location _currentLocation;

        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;

                RandomArmor = RandomNumberGenerator.NumberBetween(0, 5) <= 1;
                RandomWeapon = RandomNumberGenerator.NumberBetween(0, 5) <= 1;

                OnPropertyChanged(nameof(CurrentLocation));


                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToSouth));

                OnPropertyChanged(nameof(ButtonContext.ButtonEnabled1));
                OnPropertyChanged(nameof(ButtonContext.ButtonEnabled2));
                OnPropertyChanged(nameof(ButtonContext.ButtonEnabled3));
                OnPropertyChanged(nameof(ButtonContext.ButtonEnabled4));

                OnPropertyChanged(nameof(CanBattle));
            }
        }

        private bool _randomArmor;

        public bool RandomArmor
        {
            get => _randomArmor;
            set
            {
                _randomArmor = value;
                OnPropertyChanged(nameof(RandomArmor));
            }
        }

        private bool _randomWeapon;

        public bool RandomWeapon
        {
            get => _randomWeapon;
            set
            {
                _randomWeapon = value;
                OnPropertyChanged(nameof(RandomWeapon));
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
            RecalculatePossibleMoves();
            //factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);


            ButtonContext = new ExploreButtonContext(this);
            ControlsButtonContext = new ControlsButtonContext(this);
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

        public void RecalculatePossibleMoves()
        {
            HasLocationToNorth = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
            HasLocationToWest = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
            HasLocationToEast = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
            HasLocationToSouth = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        }

        public void MoveNorth()
        {
            if (HasLocationToNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
                factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);

                RecalculatePossibleMoves();
            }
            else
            {
                AddToDisplayText("\nThere is nothing in that direction!");

            }


        }

        public void MoveEast()
        {
            if(HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
                factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);

                RecalculatePossibleMoves();
            }
            else
            {
                AddToDisplayText("\nThere is nothing in that direction!");
            }



        }

        public void MoveSouth()
        {
            if (HasLocationToSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
                factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);

                RecalculatePossibleMoves();
            }
            else
            {
                AddToDisplayText("\nThere is nothing in that direction!");
            }


        }

        public bool CanBattle
        {
            get => CurrentLocation.Characters.Count > 0;
        }

        public void MoveWest()
        {
            if (HasLocationToWest)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
                factory.ExpandWorld(CurrentWorld, CurrentLocation.XCoordinate, CurrentLocation.YCoordinate);

                RecalculatePossibleMoves();
            }
            else
            {
                AddToDisplayText("\nThere is nothing in that direction!");
            }


        }

        private bool _hasLocationToNorth;
        public bool HasLocationToNorth
        {
            get => _hasLocationToNorth;
            set
            {
                _hasLocationToNorth = value;
                OnPropertyChanged(nameof(HasLocationToNorth));
            }


        }

        private bool _hasLocationToEast;
        public bool HasLocationToEast
        {
            get => _hasLocationToEast;
            set
            {
                _hasLocationToEast = value;
                OnPropertyChanged(nameof(HasLocationToEast));
            }

        }

        private bool _hasLocationToSouth;
        public bool HasLocationToSouth
        {
            get => _hasLocationToSouth;
            set
            {
                _hasLocationToSouth = value;
                OnPropertyChanged(nameof(HasLocationToSouth));
            }
        }

        public bool _hasLocationToWest;
        public bool HasLocationToWest
        {
            get => _hasLocationToWest;
            set
            {
                _hasLocationToWest = value;
                OnPropertyChanged(nameof(HasLocationToWest));
            }
        }

        public void DescribeLocation()
        {
            Location loc = CurrentLocation;
            AddToDisplayText("\nLooking at the " + loc.Name + ", you can see that ");
            if (loc.Characters.Count > 0)
            {
                foreach (ACharacter character in loc.Characters)
                {
                    AddToDisplayText(character.Name + " is here\n");
                }
            }
            else
            {
                AddToDisplayText("you are alone save for a few stray animals");
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