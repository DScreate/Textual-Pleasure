using System;
using System.Collections;
using System.Windows.Documents;

namespace Textual_Pleasure.Model.Dice
{
    public class Roller
    {
        private ArrayList dice;

        public Random prng { get; set; }

        
        // TODO: Implement crits
        public int RollDiceAgainstThreshold(int threshold)
        {
            int successes = 0;
            
            foreach (Die die in dice)
            {
                if (die.Roll() > threshold)
                    successes++;

            }

            return successes;
        }

        public Roller(ArrayList dice, Random prng)
        {
            this.dice = dice;
            this.prng = prng;
        }

        public void AddDie(Die die)
        {
            dice.Add(die);
        }

        public void RemoveDie()
        {
            if (dice.Count > 0)
                dice.RemoveAt(dice.Count);
        }
    }
}