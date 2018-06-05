using System;
using Engine.Model.Character.Body.ManipulateBehaviors;

namespace Engine.Model.Character.Body
{
    public class Arm : BodyPart, IAppendage
    {
        // TODO : Implement Left vs Right Arm
        private Arm() : base("Arm", 8.0, 0, new Manipulator("Hand", new FineManipulator()))
        {

        }

        public static Arm ArmFactory(bool isLeft)
        {
            Arm temp = new Arm();
            if (isLeft)
            {
                temp.Manip.Name = "Left Hand";
                temp.Manip.Name = "Left Arm";
            }
            else
            {
                temp.Manip.Name = "Right Hand";
                temp.Manip.Name = "Right Arm";
            }

            return temp;
        }
    }
}