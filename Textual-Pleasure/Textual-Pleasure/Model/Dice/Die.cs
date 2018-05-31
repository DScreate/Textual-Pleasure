﻿using System;

namespace Textual_Pleasure.Model.Dice
{
    public class Die
    {
        public string Id { get; set; }

        public int Sides { get; set; }
        
        public Random prng { get; set; }

        public Die(int sides, string newId, Random prng)
        {
            Sides = sides;
            this.Id = newId;
            this.prng = prng;
        }

        public int Roll()
        {
            return prng.Next(0, Sides);
        }

        public override string ToString()
        {
            return "Die " + Id + " Sides: " + Sides;
        }
    }
}