using System;

namespace Engine.Model.Dice
{
    public class Die
    {
        public string Id { get; set; }

        public int Sides { get; set; }
        
        public Random Prng { get; set; }

        public Die(int sides, string newId, Random prng)
        {
            Sides = sides;
            this.Id = newId;
            this.Prng = prng;
        }

        public int Roll()
        {
            return Prng.Next(0, Sides);
        }

        public override string ToString()
        {
            return "Die " + Id + " Sides: " + Sides;
        }
    }
}