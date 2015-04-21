using System;
using CSharpBinairoSolver;
using NUnit.Framework;

namespace SolverTests
{
    [TestFixture]
    public class PlayfieldTests
    {
        [Test]
        public void TestIsValidReturnFalseIfFieldSizeIsZero()
        {
            Assert.Throws<ArgumentException>(() => new Playfield(new SlotStatus[0, 0]));
        }

        [Test]
        public void TestIsValidReturnFalseIfOneSideLengthIsNotSameAsOther()
        {
            for (var i = 1; i < 20; i = i + 2)
            {
                Assert.Throws<ArgumentException>(() => new Playfield(new SlotStatus[i, 20 - 1]), "Field with uneven sides should be invalid.");
            }
        }

        [Test]
        public void TestIsValidReturnsFalseIfSideLengthIsUneven()
        {
            for (var i = 1; i < 20; i = i + 2)
            {
                Assert.Throws<ArgumentException>(() => new Playfield(new SlotStatus[i, i]), "Field with uneven size should be invalid.");
            }
        }
    }
}
