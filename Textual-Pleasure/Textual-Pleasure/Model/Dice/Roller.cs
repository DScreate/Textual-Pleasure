using System;
using System.Collections;
using System.Windows.Documents;

namespace Textual_Pleasure.Model.Dice
{
    public class Roller
    {
        private ArrayList _dice;

        public int DieSides { get; set; }

        public Random Prng { get; set; }

        public RollResults Res;

        public bool EnableCritHits { get; set; }

        public bool EnableCritFails { get; set; }

        public int HitThreshold { get; set; }

        public int CritThreshold { get; set; }

        public int CritFailThreshold { get; set; }
    
        public RollResults RollDiceAgainstThreshold()
        {
            Res.Reset();
            
            foreach (Die die in _dice)
            {
                int roll = die.Roll();
                if (roll >= HitThreshold)
                {
                    Res.Hits++;
                    if (EnableCritHits && roll >= CritThreshold)
                        Res.Crits++;
                }
                else
                {
                    Res.Fails++;
                    if (EnableCritFails && roll <= CritFailThreshold)
                        Res.Crits++;
                }

            }

            return Res;
        }

        // TODO: Double check this construtor to implement numDice
        public Roller(int numDice, Random prng, int sides = 6, bool critsOn = false, bool critFailsOn = false)
        {
            //_dice = _dice;
            this.Prng = prng;
            this.DieSides = sides;
            this.EnableCritHits = critsOn;
            this.EnableCritFails = critFailsOn;
            Res = new RollResults();
        }

        public void CreateDie()
        {
            string id = _dice.Count + "_" + DieSides;
            Die newDie = new Die(DieSides, id, Prng);
        }

        public void AddDie(Die die)
        {
            _dice.Add(die);
        }

        public void RemoveDie()
        {
            if (_dice.Count > 0)
                _dice.RemoveAt(_dice.Count);
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