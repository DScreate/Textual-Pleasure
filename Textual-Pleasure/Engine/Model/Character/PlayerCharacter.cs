using System.Collections.Generic;
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
    }
}