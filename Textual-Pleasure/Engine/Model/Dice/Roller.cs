using System;
using System.Collections;

namespace Engine.Model.Dice
{
    public class Roller
    {
        public ArrayList Dice { get; set; }

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
            
            foreach (Die die in Dice)
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

        public RollResults RollDiceAgainstThreshold(int numDice)
        {
            ReplaceDice(numDice);

            Res.Reset();

            foreach (Die die in Dice)
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

        public void ReplaceDice(int numDice)
        {
            Dice.Clear();
            for (int i = 0; i < numDice; i++)
            {
                AddDie(CreateDie());
            }
        }

        // TODO: Double check this construtor to implement numDice
        public Roller(int seed = 0, int sides = 6, bool critsOn = false, bool critFailsOn = false)
        {
            Dice = new ArrayList();
            this.Prng = new Random(seed);
            this.DieSides = sides;
            this.EnableCritHits = critsOn;
            this.EnableCritFails = critFailsOn;
            Res = new RollResults();
        }

        public Die CreateDie()
        {
            string id = Dice.Count + "_" + DieSides;
            return new Die(DieSides, id, Prng);
        }

        public void AddDie(Die die)
        {
            Dice.Add(die);
        }

        public void RemoveDie()
        {
            if (Dice.Count > 0)
                Dice.RemoveAt(Dice.Count);
        }
    }

    public class RollResults : IEquatable<RollResults>
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

        public bool Equals(RollResults other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Hits == other.Hits && Crits == other.Crits && Fails == other.Fails && CritFails == other.CritFails;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RollResults) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Hits;
                hashCode = (hashCode * 397) ^ Crits;
                hashCode = (hashCode * 397) ^ Fails;
                hashCode = (hashCode * 397) ^ CritFails;
                return hashCode;
            }
        }
    }
}