using System;
using System.Collections.Generic;
using System.Net.Mail;
using Engine.Model.Items.Behaviors;

namespace Engine.Model.Character.Body
{
    public abstract class BodyPart : IEquatable<BodyPart>
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public List<IEquipable> Equipables;


        public int ControversialLevel { get; set; }

        public Manipulator Manip { get; set; }
    

        public BodyPart(String name, double weight, int conLevel, Manipulator inMan = null)
        {
            Name = name;
            Weight = weight;
            ControversialLevel = conLevel;
            Manip = inMan;
            Equipables = new List<IEquipable>();
        }

        /*
        public bool AddEquipment(IEquipable equipable)
        {
            if (equipable.Exclusive)
            {
                foreach (IEquipable equipment in Equipables)
                {

                }
            }

            if (equipable.RequiresManip && Manip != null)
            {
                Equipables.Add(equipable);
                return true;
            }

            return false;
        }
        */


        // TODO FIX THIS
        public bool AddManipulator(Manipulator inMan)
        {
            if (Manip == null)
            {
                Manip = inMan;

            }
            return true;
        }

        public bool Equals(BodyPart other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Weight.Equals(other.Weight) && ControversialLevel == other.ControversialLevel && Equals(Manip, other.Manip);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BodyPart) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Weight.GetHashCode();
                hashCode = (hashCode * 397) ^ ControversialLevel;
                hashCode = (hashCode * 397) ^ (Manip != null ? Manip.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}