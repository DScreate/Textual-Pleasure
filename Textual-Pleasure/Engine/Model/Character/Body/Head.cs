namespace Engine.Model.Character.Body
{
    public class Head : BodyPart
    {
        private Head() : base("Head", 10.0, 0)
        {

        }

        public static Head HeadFactory()
        {
            Head temp = new Head();

            return temp;
        }
    }
}