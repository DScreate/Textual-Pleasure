using System;

namespace Engine.Model.Character
{
    public class BaseStat : AbstractStat, IEquatable<BaseStat>
    {
        public BaseStat(double inValue, string inName) : base(inValue, inName)
        { 

        }

        public bool NameEquals(BaseStat other)
        {
            return Name == other.Name;
        }

        public bool Equals(BaseStat other)
        {
            return other != null && (Name == other.Name && Math.Abs(Value - other.Value) < 0.05);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BaseStat) obj);
        }
        

        // TODO : Implement this
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(BaseStat left, BaseStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseStat left, BaseStat right)
        {
            return !Equals(left, right);
        }
    }
}