using Engine.Model.Character.Body;

namespace Engine.Model.Character
{
    public class GenericCharacter : Character
    {
        private GenericCharacter(string name) : base(name)
        {
            AddBodyPart(Arm.ArmFactory(true));
            AddBodyPart(Arm.ArmFactory(false));
            AddBodyPart(Leg.LegFactory(true));
            AddBodyPart(Leg.LegFactory(false));
            AddBodyPart(Torso.TorsoFactory());
            AddBodyPart(Head.HeadFactory());
        }

        public static GenericCharacter GCFactory()
        {
            return new GenericCharacter("Vanessa");
        }
    }
}