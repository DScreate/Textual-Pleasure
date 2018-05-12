using System;

namespace Textual_Pleasure.Model.Dice
{
    public class Die
    {
        public int Sides { get; set; }
        
        public Random prng { get; set; }

        public Die(int sides, Random prng = null)
        {
            Sides = sides;
            this.prng = prng;
        }

        public int Roll()
        {
            return prng.Next(0, Sides);
        }
    }
}