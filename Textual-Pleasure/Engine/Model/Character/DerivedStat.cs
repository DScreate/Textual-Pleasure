using System;
using System.Collections.Generic;

namespace Engine.Model.Character
{
    public class DerivedStat : AbstractStat
    {
        public Dictionary<AbstractStat, double> StatFactorDictionary;

        public DerivedStat(string inName, Dictionary<AbstractStat, double> factorDictionary) : base (inName)
        {
            StatFactorDictionary = factorDictionary;
        }

        public new double Value
        {
            get
            {
                double temp = 0;
                foreach (KeyValuePair<AbstractStat, double> entry in StatFactorDictionary)
                {
                    AbstractStat stat = entry.Key;
                    temp += stat.Value * entry.Value;
                }

                return temp;
            }
        }

        // TODO: Update this to spit out text?
        public void AddBase(AbstractStat stat, double factor)
        {

            if (StatFactorDictionary.ContainsKey(stat))
            {
                // do something and spit out error
                StatFactorDictionary[stat] = factor;
                Console.WriteLine("Error in adding base to Derived stat:\nBase: " + stat.Name + ", Derived: " + Name);
            }
            else
            {
                StatFactorDictionary.Add(stat, factor);
            }
        }

    }
}