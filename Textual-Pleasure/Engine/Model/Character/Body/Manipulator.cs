using System;
using Engine.Model.Character.Body.ManipulateBehaviors;

namespace Engine.Model.Character.Body
{
    public class Manipulator
    {
        private IManipulate _manipulator;

        public String Name { get; set; }

        public Manipulator(String name, IManipulate behavior)
        {
            _manipulator = behavior;
            Name = name;
        }

        public void ChangeBehavior(IManipulate behavior)
        {
            _manipulator = behavior;
        }

        // TODO: How does this work?
        public void Manipulate()
        {
            _manipulator.Manipulate();
        }
    }
}