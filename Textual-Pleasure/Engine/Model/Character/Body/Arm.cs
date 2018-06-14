using System;
using System.Runtime.CompilerServices;
using Engine.Model.Character.Body.ManipulateBehaviors;

namespace Engine.Model.Character.Body
{
    public class Arm : BodyPart, IAppendage
    {
        // TODO : Implement Left vs Right Arm
        public Arm() : base("Arm", 8.0, 0, new Manipulator("Hand", new FineManipulator()))
        {

        }

        public static Arm ArmFactory(bool isLeft)
        {
            Arm temp = new Arm();
            if (isLeft)
            {
                temp.Manip.Name = "Left Hand";
                temp.Name = "Left Arm";
            }
            else
            {
                temp.Manip.Name = "Right Hand";
                temp.Name = "Right Arm";
            }

            return temp;
        }
    }
}