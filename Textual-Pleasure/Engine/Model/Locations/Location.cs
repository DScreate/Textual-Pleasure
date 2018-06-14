using System;
using System.Collections.Generic;
using Engine.Common;
using Engine.Model.Items;
using Engine.Model.Character;

namespace Engine.Model.Locations
{
    public class Location : IDescribable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public string Id { get; set; }

        public List<Path> Paths;

        public List<ACharacter> Characters { get; set; }

        public List<AItem> Items { get; set; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Characters = new List<ACharacter>();
            Items = new List<AItem>();
        }

        // TODO: Implement error checking?
        public void AddPath(Path newPath)
        {
            if (Paths.Contains(newPath))
            {
                // do something?
                Console.WriteLine("Trying to add already existing path " + newPath + " to " + Name);
            }
            else
            {
                Paths.Add(newPath);
            }
        }

        public bool HasCharacters()
        {
            return Characters.Count == 0;
        }

        public void AddCharacter(ACharacter newChar, bool allowDuplicates = false)
        {
            if (Characters.Contains(newChar) && !allowDuplicates)
            {
                Console.WriteLine("Duplicate Character in " + Name + " when trying to add " + newChar);
            }
            else
            {
                Characters.Add(newChar);
            }
        }

        public void RemoveCharacter(ACharacter character)
        {
            if (Characters.Contains(character))
            {
                Console.WriteLine("Attempted to remove nonexistance character in " + Name + ", they were " + character);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}