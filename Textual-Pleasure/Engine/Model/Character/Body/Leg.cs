using Engine.Model.Character.Body.ManipulateBehaviors;

namespace Engine.Model.Character.Body
{
    public class Leg : BodyPart
    {
        
            // TODO : Implement Left vs Right Arm
            private Leg() : base("Leg", 35.0, 0, new Manipulator("Foot", new BluntManipulator()))
            {

            }

            public static Leg LegFactory(bool isLeft)
            {
                Leg temp = new Leg();
                if (isLeft)
                {
                    temp.Manip.Name = "Left Leg";
                    temp.Manip.Name = "Left Leg";
                }
                else
                {
                    temp.Manip.Name = "Right Leg";
                    temp.Manip.Name = "Right Leg";
                }

                return temp;
            }
        
    }
}