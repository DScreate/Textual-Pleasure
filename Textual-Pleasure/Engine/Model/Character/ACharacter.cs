using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Engine.Annotations;
using Engine.Model.Character.Body;
using Engine.Model.Items.ConcreteItems;
using Engine.Model.Locations;

namespace Engine.Model.Character
{
    public abstract class ACharacter : INotifyPropertyChanged
    {
        protected ACharacter(string name, Dictionary<string, ACharacter> knownCharacters = null, Dictionary<string, BodyPart> bodyParts = null)
        {
            Name = name;
            KnownCharacters = knownCharacters;
            if(KnownCharacters == null)
                KnownCharacters = new Dictionary<string, ACharacter>();
            BodyParts = bodyParts;
            if(BodyParts == null)
                BodyParts = new Dictionary<string, BodyPart>();
            myStats = Stats.StatsFactory();

            CurrentHealth = MaxHealth;
            CurrentEndurance = MaxEndurance;
            GenerateHash();
        }

        private Location _curLocation;

        public Location CurrentLocation
        {
            get => _curLocation;
            set
            {
                _curLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public void PlaceAtLocation(Location loc)
        {
            CurrentLocation = loc;
        }

        private int _curHealth;
        public int CurrentHealth
        {
            get => _curHealth;
            set
            {
                _curHealth = value > MaxHealth ? MaxHealth : value;
                OnPropertyChanged(nameof(CurrentHealth));
            }
        }

        private int _curEndurance;
        public int CurrentEndurance
        {
            get => _curEndurance;
            set
            {
                _curEndurance = value > MaxEndurance ? MaxEndurance : value;
                OnPropertyChanged(nameof(CurrentEndurance));
            }
        }

        public int MaxHealth => (int)myStats.Health.Value;

        public int MaxEndurance => (int)myStats.Endurance.Value;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        private int _experience;
        public int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnPropertyChanged(nameof(Experience));
            }
        }

        private int _gold;

        public int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public double StrengthAttackPower
        {
            get => (int)myStats.StrengthMeleeDamage.Value;
        }

        public double AgilityAttackPower
        {
            get => (int) myStats.AgilityMeleeDamage.Value;
        }

        public Dictionary<string, ACharacter> KnownCharacters { get; set; }

        public Dictionary<string, BodyPart> BodyParts { get; set; }

        public Stats myStats { get; set; }

        public virtual bool AddEquipment(BaseEquipable equipable)
        {
            bool sameItem = false;

            foreach (BodyPart part in equipable.TargetBodyParts)
            {
                if (equipable.Exclusive)
                {
                    
                    foreach (BaseEquipable subEquipable in BodyParts[part.Name].Equipables.ToList())
                    {
                        if (!subEquipable.CanUnequip(this))
                        {
                            return false;
                        }

                        if (subEquipable.ItemID == equipable.ItemID)
                        {
                            // this means we're trying to add the same item
                            sameItem = true;
                        } else
                        {
                            BodyParts[part.Name].Equipables.Remove(subEquipable);
                            subEquipable.OnUnEquip(this);
                        }
                    }
                }

                if (!sameItem)
                {
                    BodyParts[part.Name].Equipables.Add(equipable);
                    equipable.OnEquip(this);
                }
            }

            return true;
        }

        public virtual bool RemoveEquipment(BaseEquipable equipable)
        {
            foreach (BodyPart part in equipable.TargetBodyParts)
            { 
                part.Equipables.Remove(equipable);
                equipable.OnUnEquip(this);
            }

            return true;
        }
        
        // TODO: Fix Id checking! Why is there Idnum AND Id?
        public string Id { get; set; }
        
        public int Idnum { get; set; }

        public override bool Equals(object that)
        {
            // Check for null values and compare run-time types.
            if (that == null || GetType() != GetType())
                return false;

            return (Name == ((ACharacter)that).Name) && (Id == ((ACharacter)that).Id);
        }
        public override int GetHashCode()
        {
            return Idnum;
        }

        //add this code to class ThreeDPoint as defined previously
        //
        public static bool operator ==(ACharacter a, ACharacter b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (a.Name == b.Name) && (a.Id == b.Id);
        }

        public static bool operator !=(ACharacter a, ACharacter b)
        {
            return !(a == b);
        }

        #region Stats

        // TODO : Possible error state if stat does not exit in basestats?
        public BaseStat GetBaseStat(BaseStat stat)
        {
            return (BaseStat)myStats.GetType().GetProperty(stat.Name).GetValue(myStats, null);
        }

        public BaseStat GetBaseStat(string statName)
        {
            return (BaseStat)myStats.GetType().GetProperty(statName).GetValue(myStats, null);
        }

        public DerivedStat GetDerivedStat(DerivedStat stat)
        {
            return (DerivedStat)myStats.GetType().GetProperty(stat.Name).GetValue(myStats, null);
        }

        public DerivedStat GetDerivedStat(string statName)
        {
            return (DerivedStat)myStats.GetType().GetProperty(statName).GetValue(myStats, null);
        }




        #endregion

        #region BodyControl

        // TODO: Check for bodypart ID instead of just ToString
        public bool AddBodyPart(BodyPart part)
        {
            if (BodyParts.ContainsKey(part.ToString())) return false;
            
            BodyParts.Add(part.Name, part);
            return true;
        }
        
        // TODO: Should this accept string or body part?
        public bool RemoveBodyPart(BodyPart part)
        {
            if (!BodyParts.ContainsKey(part.ToString())) return false;
            
            BodyParts.Remove(part.ToString());
            return true;
        }
        
        #endregion
        
        #region ID
        private string HashCode { get; set; }

        // TODO: Implement a more robust ID system -> perhaps checking character dictionary? Might be bad coupling
        private string GenerateId()
        {
            return Name + Idnum;
        }
        
        private void GenerateHash()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, Name);
                HashCode = hash;
            }            
        }

        private static string GetMd5Hash(HashAlgorithm md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}