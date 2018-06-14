using System.Collections.Generic;
using System.Collections.ObjectModel;
using Engine.Model.Character.Body;
using Engine.Model.Items;
using Engine.Model.Items.ConcreteItems;
using Engine.Model.Locations;

namespace Engine.Model.Character
{
    public class BaseMonster : ACharacter
    {



        public BaseMonster(string name, Dictionary<string, ACharacter> knownCharacters = null,
            Dictionary<string, BodyPart> bodyParts = null) : base(name, knownCharacters, bodyParts)
        {
            AddBodyPart(Arm.ArmFactory(true));
            AddBodyPart(Arm.ArmFactory(false));
            AddBodyPart(Leg.LegFactory(true));
            AddBodyPart(Leg.LegFactory(false));
            AddBodyPart(Torso.TorsoFactory());
            AddBodyPart(Head.HeadFactory());
            Inventory = new ObservableCollection<AItem>();
            
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

        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }

        // TODO : Fix what this returns
        public new bool AddEquipment(BaseEquipable equipable)
        {
            base.AddEquipment(equipable);
            Inventory.Add(equipable);

            return true;
        }

        public new bool RemoveEquipment(BaseEquipable equipable)
        {
            base.RemoveEquipment(equipable);
            Inventory.Remove(equipable);

            return true;
        }


        public ObservableCollection<AItem> Inventory { get; set; }
    }
}