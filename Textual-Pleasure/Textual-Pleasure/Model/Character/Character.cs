using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using Textual_Pleasure.Model.Character.Body;

namespace Textual_Pleasure.Model.Character
{
    public abstract class Character
    {
        protected Character(string name, Dictionary<string, Character> knownCharacters = null, Dictionary<string, BodyPart> bodyParts = null)
        {
            Name = name;
            KnownCharacters = knownCharacters;
            BodyParts = bodyParts;
            GenerateHash();
        }

        public string Name { get; set; }

        public Dictionary<string, Character> KnownCharacters { get; set; }

        public Dictionary<string, BodyPart> BodyParts { get; set; }
        
        public string Id { get; set; }
        
        public int Idnum { get; set; }
                
        #region Stats

        #region Body
        public double Strength { get; set; }
        public double Body { get; set; }
        public double Health { get; set; }
        #endregion

        #region Mental
        public double Mind { get; set; }
        public double Will { get; set; }
        public double Resolve { get; set; }
        #endregion
        
        #region Speed
        public double Agility { get; set; }
        public double Reflex { get; set; }
        public double Coordination { get; set; }
        #endregion

        #region Social
        public double Charisma { get; set; }
        public double Presence { get; set; }
        public double Influence { get; set; }
        #endregion

        
        #endregion

        #region BodyControl

        // TODO: Check for bodypart ID instead of just ToString
        public bool AddBodyPart(BodyPart part)
        {
            if (BodyParts.ContainsKey(part.ToString())) return false;
            
            BodyParts.Add(part.ToString(), part);
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
        private string GenerateID()
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

    }
}