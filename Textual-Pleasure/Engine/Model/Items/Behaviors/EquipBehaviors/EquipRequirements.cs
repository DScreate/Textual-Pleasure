using System.Collections.Generic;
using Engine.Model.Character;
using Engine.Model.Character.Body;

namespace Engine.Model.Items.Behaviors.EquipBehaviors
{
    public class EquipRequirements
    {
        public List<BodyPart> NeededParts { get; set; }

        public List<BaseStat> MinBaseStats { get; set; }

        public List<DerivedStat> MinDerivedStats { get; set; }

        public EquipRequirements(List<BodyPart> parts, List<BaseStat> neededBases = null,
            List<DerivedStat> neededDeriveds = null)
        {
            NeededParts = parts;
            MinBaseStats = neededBases;
            MinDerivedStats = neededDeriveds;
        }

        public bool CanIEquip(ACharacter character)
        {
            foreach (BodyPart part in NeededParts)
            {
                if (!character.BodyParts.ContainsValue(part))
                    return false;
            }
            foreach (BaseStat baseStat in MinBaseStats)
            {
                if (character.GetBaseStat(baseStat).Value < baseStat.Value)
                    return false;
            }
            foreach (DerivedStat derivedStat in MinDerivedStats)
            {
                if (character.GetDerivedStat(derivedStat).Value < derivedStat.Value)
                    return false;
            }

            return true;
        }
    
    }
}