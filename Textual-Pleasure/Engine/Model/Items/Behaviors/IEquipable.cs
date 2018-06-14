using System.Collections.Generic;
using System.Security.AccessControl;
using Engine.Model.Character;
using Engine.Model.Character.Body;

namespace Engine.Model.Items.Behaviors
{
    public interface IEquipable
    { 
        bool CanEquip(ACharacter character);

        bool CanUnequip(ACharacter character);
    }
}