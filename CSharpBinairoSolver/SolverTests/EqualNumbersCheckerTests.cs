using CSharpBinairoSolver;
using CSharpBinairoSolver.ValidityCheckers;
using NUnit.Framework;

namespace SolverTests
{
    [TestFixture]
    public class EqualNumbersCheckerTests
    {
        private EqualNumbersChecker _checker;

        [SetUp]
        public void Setup()
        {
            _checker = new EqualNumbersChecker();
        }

        [Test]
        public void TestIsValidReturnsTrueWhenPlayfieldIsEmpty()
        {
            var field = new[,]
            {
                {SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsTrue(_checker.IsValid(new Playfield(field)));
        }

        [Test]
        public void TestIsValidReturnsTrueWhenPlayfieldHasCorrectSolution()
        {
            var field = new[,]
            {
                {SlotStatus.Zero, SlotStatus.One, SlotStatus.One, SlotStatus.Zero},
                {SlotStatus.One, SlotStatus.Zero, SlotStatus.Zero, SlotStatus.One},
                {SlotStatus.Zero, SlotStatus.Zero, SlotStatus.One, SlotStatus.One},
                {SlotStatus.One, SlotStatus.One, SlotStatus.Zero, SlotStatus.Zero}
            };
            Assert.IsTrue(_checker.IsValid(new Playfield(field)));
        }

        [Test]
        public void TestIsValidReturnsFalseWhenThereAreTooManyZeroValuesInRow()
        {
            var field = new[,]
            {
                {SlotStatus.Zero, SlotStatus.Zero},
                {SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsFalse(_checker.IsValid(new Playfield(field)), "First row had only zero values, it should have been false.");
            field = new[,]
            {
                {SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Zero, SlotStatus.Zero}
            };
            Assert.IsFalse(_checker.IsValid(new Playfield(field)), "Second row had only zer values, it should have been false.");
        }

        [Test]
        public void TestIsValidReturnsFalseWhenThereAreTooManyOneValuesInRow()
        {
            var field = new[,]
            {
                {SlotStatus.One, SlotStatus.One},
                {SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsFalse(_checker.IsValid(new Playfield(field)), "First row had only one values, it should have been false.");
            field = new[,]
            {
                {SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.One, SlotStatus.One}
            };
            Assert.IsFalse(_checker.IsValid(new Playfield(field)), "Second row had only one values, it should have been false.");
        }
    }
}
