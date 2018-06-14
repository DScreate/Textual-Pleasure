using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Engine.Annotations;

namespace Engine.Model.Character
{
    public class Stats : INotifyPropertyChanged
    {
        public BaseStat Strength { get; set; }

        public BaseStat Toughness { get; set; }

        public BaseStat Agility { get; set; }

        public BaseStat Perception { get; set; }

        public BaseStat Intelligence { get; set; }

        public BaseStat Willpower { get; set; }

        public BaseStat Charisma { get; set; }

        public BaseStat Corruption { get; set; }

        public BaseStat Appeal { get; set; }

        public DerivedStat Health { get; set; }

        public DerivedStat Endurance { get; set; }

        //public DerivedStat Dexterity { get; set; }

        //public DerivedStat Mind { get; set; }

        //public DerivedStat Awareness { get; set; }

        //public DerivedStat Influence { get; set; }
        private DerivedStat _strMeleeDamage;
        public DerivedStat StrengthMeleeDamage
        {
            get => _strMeleeDamage;
            set
            {
                _strMeleeDamage = value;
                OnPropertyChanged(nameof(StrengthMeleeDamage));
            }
        }

        private DerivedStat _agiMeleeDamage;
        public DerivedStat AgilityMeleeDamage
        {
            get => _agiMeleeDamage;
            set
            {
                _agiMeleeDamage = value;
                OnPropertyChanged(nameof(AgilityMeleeDamage));
            }
        }

        private DerivedStat _rangedDamage;
        public DerivedStat RangedDamage
        {
            get => _rangedDamage;
            set
            {
                _rangedDamage = value;
                OnPropertyChanged(nameof(RangedDamage));
            }
        }

        /*
        public void ModifyStat(string statName, double amount)
        {
            GetType().GetProperty(statName).GetValue(this, null);
        }
        */

        // A cool, php-esque way of getting properties
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        private Stats()
        {
            SetupBaseStats();
            SetupDerivedStats();
        }

        public static Stats StatsFactory()
        {

            return new Stats();
        }

        private void SetupBaseStats()
        {
            Strength = new BaseStat(3, "Strength");
            Toughness = new BaseStat(3, "Toughness");
            Agility = new BaseStat(3, "Agility");
            Perception = new BaseStat(3, "Perception");
            Intelligence = new BaseStat(3, "Intelligence");
            Willpower = new BaseStat(3, "Willpower");
            Charisma = new BaseStat(3, "Charisma");
            Corruption = new BaseStat(0, "Corruption");
            Appeal = new BaseStat(3, "Appeal");
        }

        private void SetupDerivedStats()
        {
            Health = new DerivedStat("Health", new Dictionary<AbstractStat, double>());
            Health.AddBase(Toughness, 0.7);
            Health.AddBase(Strength, 0.3);

            Endurance = new DerivedStat("Endurance", new Dictionary<AbstractStat, double>());
            Endurance.AddBase(Toughness, 0.6);
            Endurance.AddBase(Willpower, 0.4);

            StrengthMeleeDamage = new DerivedStat("StrengthMeleeDamage", new Dictionary<AbstractStat, double>());
            StrengthMeleeDamage.AddBase(Strength, 1);
            StrengthMeleeDamage.AddBase(Perception, 0.2);

            AgilityMeleeDamage = new DerivedStat("AgilityMeleeDamage", new Dictionary<AbstractStat, double>());
            AgilityMeleeDamage.AddBase(Agility, 1);
            AgilityMeleeDamage.AddBase(Perception, 0.2);

            RangedDamage = new DerivedStat("RangedDamage", new Dictionary<AbstractStat, double>());
            RangedDamage.AddBase(Perception, 0.8);
            RangedDamage.AddBase(Agility, 0.2);
            RangedDamage.AddBase(Strength, 0.2);


            /*

            Dexterity = new DerivedStat("Dexterity", new Dictionary<AbstractStat, double>());
            Dexterity.AddBase(Agility, 0.75);
            Dexterity.AddBase(Perception, 0.25);

            Mind = new DerivedStat("Mind", new Dictionary<AbstractStat, double>());
            Mind.AddBase(Intelligence, 0.55);
            Mind.AddBase(Willpower, 0.55);

            Awareness = new DerivedStat("Awareness", new Dictionary<AbstractStat, double>());
            Awareness.AddBase(Perception, 0.7);
            Awareness.AddBase(Intelligence, 0.3);

            Influence = new DerivedStat("Influence", new Dictionary<AbstractStat, double>());
            Influence.AddBase(Appeal, 0.8);
            Influence.AddBase(Charisma, 0.8);
            */

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}