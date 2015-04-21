using CSharpBinairoSolver;
using CSharpBinairoSolver.ValidityCheckers;
using NUnit.Framework;

namespace SolverTests
{
    [TestFixture]
    public class OnlyTwoSameNumbersCheckerTests
    {
        private OnlyTwoSameNumbersChecker _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new OnlyTwoSameNumbersChecker();
        }

        [Test]
        public void TestIsValidReturnsFalseIfThereAreThreeAdjacentZeroSlots()
        {
            var field = new[,]
            {
                {SlotStatus.Zero, SlotStatus.Zero, SlotStatus.Zero, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)));
        }

        [Test]
        public void TestIsValidReturnsFalseIfThereAreThreeAdjacentOneSlots()
        {
            var field = new[,]
            {
                {SlotStatus.One, SlotStatus.One, SlotStatus.One, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)));
        }

        [Test]
        public void TestIsValidReturnsTrueIfFieldIsEmpty()
        {
            var field = new[,]
            {
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsTrue(_validator.IsValid(new Playfield(field)));
        }

        [Test]
        public void TestIsValidReturnsFalseIfColumnHasThreeAdjacentZeroSlots()
        {
            var field = new[,]
            {
                {SlotStatus.Zero, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Zero, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Zero, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)));
        }

        [Test]
        public void TestIsValidReturnsFalseIfColumnHasThreeAdjacentOneSlots()
        {
            var field = new[,]
            {
                {SlotStatus.Zero, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.One, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Zero, SlotStatus.Empty, SlotStatus.One, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.One, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)));
        }
    }
}
