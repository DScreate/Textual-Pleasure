using System.Collections.Generic;

namespace Engine.Model.Character
{
    public class DerivedStat : AbstractStat
    {
        public Dictionary<BaseStat, double> BaseFactorDictionary;

        public DerivedStat(string inName, BaseStat baseStat, double factor) : base (inName)
        {
            BaseFactorDictionary.Add(baseStat, factor);
        }

        public new double Value
        {
            get
            {
                double temp = 0;
                foreach (KeyValuePair<BaseStat, double> entry in BaseFactorDictionary)
                {
                    BaseStat stat = entry.Key;
                    temp += stat.Value * entry.Value;
                }

                return temp;
            }
        }

        // TODO: Update this to spit out text?
        public void AddBase(BaseStat stat, double factor)
        {

            if (BaseFactorDictionary.ContainsKey(stat))
            {
                // do something and spit out error
                BaseFactorDictionary[stat] = factor;
            }
            else
            {
                BaseFactorDictionary.Add(stat, factor);
            }
        }

    }
}