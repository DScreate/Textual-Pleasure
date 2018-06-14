using Engine.Model.Character;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Windows.UnitTests
{
    [TestClass]
    public class CharacterTests
    { 
        [TestMethod]
        public void TestCreateCharacter()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            Assert.IsInstanceOfType(GC, typeof(ACharacter));
        }

        [TestMethod]
        public void TestCreateCharacterName()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            Assert.AreEqual("Vanessa", GC.Name);
        }

        [TestMethod]
        public void TestGCharacterHasStats()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            Stats myStats = GC.myStats;

            Assert.IsInstanceOfType(myStats, typeof(Stats));
        }

        [TestMethod]
        public void TestGCharacterHasStrength()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            BaseStat testStat = GC.GetBaseStat("Strength");

            Assert.IsInstanceOfType(testStat, typeof(BaseStat));
        }

        [TestMethod]
        public void TestACharacterStrengthIsThree()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            BaseStat testStat = GC.GetBaseStat("Strength");

            Assert.AreEqual(3, testStat.Value);
        }

        [TestMethod]
        public void TestGCharacterHasAgility()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            BaseStat testStat = GC.GetBaseStat("Agility");

            Assert.IsInstanceOfType(testStat, typeof(BaseStat));
        }

        [TestMethod]
        public void TestACharacterAgilityIsThree()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            BaseStat testStat = GC.GetBaseStat("Agility");

            Assert.AreEqual(3, testStat.Value);
        }

        [TestMethod]
        public void TestACharacterAgilityIsFourAfterIncrement()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            GC.myStats.Agility.Value++;
            BaseStat testStat = GC.GetBaseStat("Agility");

            Assert.AreEqual(4,  testStat.Value);
        }

        [TestMethod]
        public void TestGCharacterHasDerivedStats()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            DerivedStat testStat = GC.GetDerivedStat("Health");

            Assert.IsInstanceOfType(testStat, typeof(DerivedStat));
        }

        // TODO: Implement tests for equality and comparing stats
    }
}
