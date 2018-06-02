using Engine.Model.Character.Body.ManipulateBehaviors;

namespace Engine.Model.Character.Body
{
    public class Manipulator
    {
        private IManipulate _manipulator;

        
        // TODO: How does this work?
        public void Manipulate()
        {
            _manipulator.Manipulate();
        }
    }
}