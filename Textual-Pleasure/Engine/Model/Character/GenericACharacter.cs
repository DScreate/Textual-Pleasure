using Engine.Model.Character.Body;

namespace Engine.Model.Character
{
    public class GenericACharacter : ACharacter
    {
        private GenericACharacter(string name) : base(name)
        {
            AddBodyPart(Arm.ArmFactory(true));
            AddBodyPart(Arm.ArmFactory(false));
            AddBodyPart(Leg.LegFactory(true));
            AddBodyPart(Leg.LegFactory(false));
            AddBodyPart(Torso.TorsoFactory());
            AddBodyPart(Head.HeadFactory());
        }

        public static GenericACharacter GCFactory()
        {
            return new GenericACharacter("Vanessa");
        }
    }
}