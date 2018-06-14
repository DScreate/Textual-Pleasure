using System.Collections.Generic;
using Engine.Model.Character;
using Engine.Model.Character.Body;
using Engine.Model.Items.Behaviors;

namespace Engine.Model.Items.ConcreteItems
{
    public class BaseEquipable : AItem, IEquipable
    {
        public bool RequiresManip;

        public bool Exclusive;

        public List<BodyPart> TargetBodyParts;

        public EquipRequirements eReqs { get; set; }

        public Dictionary<string, float> EquipEffects;

        public BaseEquipable(int Id, string name, int price, int level = 1, Dictionary<string, float> equipEffects = null, List<BodyPart> targets = null) : 
            base(Id, name, price, level)
        {
            EquipEffects = equipEffects;
            if(EquipEffects == null)
                EquipEffects = new Dictionary<string, float>();
            TargetBodyParts = targets;
            if(TargetBodyParts == null)
                TargetBodyParts = new List<BodyPart>();

        }

        public void OnEquip(ACharacter character)
        {
            foreach (string targetStat in EquipEffects.Keys)
            {
                ((AbstractStat) character.myStats[targetStat]).Value += EquipEffects[targetStat];
            }
        }

        public void OnUnEquip(ACharacter character)
        {
            foreach (string targetStat in EquipEffects.Keys)
            {
                ((AbstractStat)character.myStats[targetStat]).Value -= EquipEffects[targetStat];
            }
        }

        public virtual bool CanEquip(ACharacter character)
        {
            return eReqs.CanIEquip(character);
        }

        public virtual bool CanUnequip(ACharacter character)
        {
            // TODO Implement Curses? For now, return true

            return true;
        }
    }
}