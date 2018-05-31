using System;
using System.Collections;
using System.Windows.Documents;

namespace Textual_Pleasure.Model.Dice
{
    public class Roller
    {
        private ArrayList dice;

        public int DieSides { get; set; }

        public Random prng { get; set; }

        public RollResults res;

        public bool EnableCritHits { get; set; }

        public bool EnableCritFails { get; set; }

        public int HitThreshold { get; set; }

        public int CritThreshold { get; set; }

        public int CritFailThreshold { get; set; }
    
    
        // TODO: Implement crits
        public RollResults RollDiceAgainstThreshold()
        {
            res.Reset();
            
            foreach (Die die in dice)
            {
                int roll = die.Roll();
                if (roll >= HitThreshold)
                {
                    res.Hits++;
                    if (EnableCritHits && roll >= CritThreshold)
                        res.Crits++;
                }
                else
                {
                    res.Fails++;
                    if (EnableCritFails && roll <= CritFailThreshold)
                        res.Crits++;
                }

            }

            return res;
        }

        public Roller(int numDice, Random prng, int sides = 6, bool CritsOn = false, bool CritFailsOn = false)
        {
            dice = dice;
            this.prng = prng;
            this.DieSides = sides;
            this.EnableCritHits = CritsOn;
            this.EnableCritFails = CritFailsOn;
            res = new RollResults();
        }

        public void CreateDie()
        {
            string ID = dice.Count + "_" + DieSides;
            Die newDie = new Die(DieSides, ID, prng);
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

    public class RollResults
    {
        public int Hits { get; set; }
        public int Crits { get; set; }
        public int Fails { get; set; }
        public int CritFails { get; set; }

        public RollResults()
        {
            Hits = 0;
            Crits = 0;
            Fails = 0;
            CritFails = 0;
        }

        public void Reset()
        {
            Hits = 0;
            Crits = 0;
            Fails = 0;
            CritFails = 0;
        }

        public override string ToString()
        {
            return "Hits: " + Hits + ", Crits: " + Crits + ", Fails: " + Fails + ", CritFails: " + CritFails;
        }
    }
}