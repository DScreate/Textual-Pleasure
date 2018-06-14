using System.Collections.Generic;
using Engine.Model.Character.Body;
using Engine.Model.Items.Behaviors;

namespace Engine.Model.Items.ConcreteItems
{
    public class BaseWeapon : BaseEquipable
    {
        public BaseWeapon(int Id, string name, int price, int level = 1, Dictionary<string, float> equipEffects = null, List<BodyPart> targets = null) : base(Id, name, price, level, equipEffects, targets)
        {
        }
    }
}