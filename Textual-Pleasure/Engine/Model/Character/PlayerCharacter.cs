using System.Collections.Generic;
using Engine.Model.Character.Body;

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
    }
}