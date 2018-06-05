using System;

namespace Engine.Model.Character.Body
{
    public abstract class BodyPart
    {
        public string Name { get; set; }
        public double Weight { get; set; }


        public int ControversialLevel { get; set; }

        public Manipulator Manip { get; set; }
    

        public BodyPart(String name, double weight, int conLevel, Manipulator inMan = null)
        {
            Name = name;
            Weight = weight;
            ControversialLevel = conLevel;
            Manip = inMan;
        }


        // TODO FIX THIS
        public bool AddManipulator(Manipulator inMan)
        {
            if (Manip == null)
                Manip = inMan;
            return true;
        }

    }
}