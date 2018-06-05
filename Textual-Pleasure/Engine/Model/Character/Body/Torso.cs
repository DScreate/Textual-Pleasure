namespace Engine.Model.Character.Body
{
    public class Torso : BodyPart
    {
        private Torso() : base("Torso", 35.0, 0)
        {

        }

        public static Torso TorsoFactory()
        {
            Torso temp = new Torso();

            return temp;
        }
    }
}