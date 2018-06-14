using System.Collections.Generic;
using Engine.Model.Character;
using Engine.Model.Character.Body;
using Engine.Model.Items.ConcreteItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Windows.UnitTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestCreateBaseEquippable()
        {
            BaseEquipable BE = new BaseEquipable(1, "BaseSword", 10);
            BE.EquipEffects.Add("Strength", 1);

            Assert.IsInstanceOfType(BE, typeof(BaseEquipable));

        }

        [TestMethod]
        public void TestCreateBaseEquippableWithStrength1()
        {
            BaseEquipable BE = new BaseEquipable(1, "BaseSword", 10);
            BE.EquipEffects.Add("Strength", 1);

            Assert.AreEqual(1, BE.EquipEffects["Strength"]);

        }

        [TestMethod]
        public void TestAddBaseEquippableToCharacter()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();
            
            BaseEquipable BE = new BaseEquipable(1, "BaseSword", 10);
            BE.EquipEffects.Add("Strength", 1);
            BE.TargetBodyParts.Add(new Arm());

            Assert.IsTrue(GC.AddEquipment(BE));
        }

        [TestMethod]
        public void TestAddBaseEquippableToCharacterAndTestStrength()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();

            BaseEquipable BE = new BaseEquipable(1, "BaseSword", 10);
            BE.EquipEffects.Add("Strength", 1);
            BE.TargetBodyParts.Add(new Arm());

            GC.AddEquipment(BE);

            Assert.AreEqual(4, GC.myStats.Strength.Value);
        }

        [TestMethod]
        public void TestAddAndRemoveBaseEquippableToCharacterAndTestStrength()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();

            BaseEquipable BE = new BaseEquipable(1, "BaseSword", 10);
            BE.EquipEffects.Add("Strength", 1);
            BE.TargetBodyParts.Add(new Arm());

            GC.AddEquipment(BE);

            GC.RemoveEquipment(BE);

            Assert.AreEqual(3, GC.myStats.Strength.Value);
        }

        [TestMethod]
        public void TestAddBaseEquippableToCharacterAndTestStrengthDualWeild()
        {
            GenericCharacter GC = GenericCharacter.GCFactory();

            BaseEquipable BE = new BaseEquipable(1, "BaseSword", 10);
            BE.EquipEffects.Add("Strength", 1);
            BE.TargetBodyParts.Add(new Arm());

            GC.AddEquipment(BE);

            BaseEquipable BE2 = new BaseEquipable(2, "BaseSword", 10);
            BE2.EquipEffects.Add("Strength", 1);
            BE2.TargetBodyParts.Add(new Arm());

            GC.AddEquipment(BE2);

            Assert.AreEqual(5, GC.myStats.Strength.Value);
        }
    }
}