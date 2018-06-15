using System;
using Engine.Model.Dice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Windows.UnitTests
{
    [TestClass]
    public class DiceRollTests
    {
        [TestMethod]
        public void TestCreateRoller()
        {
            Roller roller = new Roller();

            Assert.IsInstanceOfType(roller, typeof(Roller));
        }

        [TestMethod]
        public void TestCreateDie()
        {
            Die die = new Die(6, "1", new Random());

            Assert.IsInstanceOfType(die, typeof(Die));
        }

        [TestMethod]
        public void TestGiveRoller3Dice()
        {
            Roller roller = new Roller();
            
            roller.ReplaceDice(3);

            Assert.AreEqual(3, roller.Dice.Count);
        }

        [TestMethod]
        public void TestRollerCreatesRollResults()
        {
            Roller roller = new Roller();

            roller.ReplaceDice(3);

            Assert.IsInstanceOfType(roller.RollDiceAgainstThreshold(), typeof(RollResults));
        }

        [TestMethod]
        public void TestRollerSystematicRolling()
        {
            Roller roller = new Roller(3);

            roller.ReplaceDice(5);

            Assert.AreEqual(roller.RollDiceAgainstThreshold(5), roller.RollDiceAgainstThreshold(5));
        }
    }
}