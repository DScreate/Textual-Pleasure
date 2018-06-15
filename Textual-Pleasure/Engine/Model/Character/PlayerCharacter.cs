using System.Collections.Generic;
using Engine.Common;
using Engine.Model.Character.Body;
using Engine.Model.Locations;

namespace Engine.Model.Character
{
    public class PlayerCharacter : ACharacter
    {
        public PlayerCharacter(string name, Dictionary<string, ACharacter> knownCharacters = null, Dictionary<string, BodyPart> bodyParts = null) : base(name, knownCharacters, bodyParts)
        {
            AddBodyPart(Arm.ArmFactory(true));
            AddBodyPart(Arm.ArmFactory(false));
            AddBodyPart(Leg.LegFactory(true));
            AddBodyPart(Leg.LegFactory(false));
            AddBodyPart(Torso.TorsoFactory());
            AddBodyPart(Head.HeadFactory());
        }

        private Location _home;
        public Location Home
        {
            get => _home;
            set
            {
                _home = value;
                OnPropertyChanged(nameof(Home));
            }
        }

        public void ReturnToHome()
        {
            CurrentLocation = Home;
        }

        public void ReturnToHomeAndHeal()
        {
            CurrentHealth = MaxHealth;
            CurrentEndurance = MaxEndurance;
        }

        private int _experience;
        public new int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnPropertyChanged(nameof(Experience));
                if(Experience > (5 * Level))
                    LevelUp();
            }
        }

        private int _gold;

        public new int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        private void LevelUp()
        {
            Level++;
            Experience = 0;
            myStats.Strength.Value += RandomNumberGenerator.NumberBetween(0, 1);
            myStats.Toughness.Value += RandomNumberGenerator.NumberBetween(0, 1);
            myStats.Agility.Value += RandomNumberGenerator.NumberBetween(0, 1);
            myStats.Perception.Value += RandomNumberGenerator.NumberBetween(0, 1);
            myStats.Intelligence.Value += RandomNumberGenerator.NumberBetween(0, 1);
            myStats.Willpower.Value += RandomNumberGenerator.NumberBetween(0, 1);
            myStats.Charisma.Value += RandomNumberGenerator.NumberBetween(0, 1);
            //myStats.Corruption = new BaseStat(0, "Corruption");
            //myStats.Appeal = new BaseStat(RandomNumberGenerator.NumberBetween(2, 5), "Appeal");
        }
    }
}