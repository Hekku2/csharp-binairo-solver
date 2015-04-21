using CSharpBinairoSolver;
using CSharpBinairoSolver.ValidityCheckers;
using NUnit.Framework;

namespace SolverTests
{
    [TestFixture]
    public class DuplicatesCheckerTests
    {
        private DuplicatesChecker _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new DuplicatesChecker();
        }

        [Test]
        public void TestIsValidFalseIfThereAreDuplicateRows()
        {
            var field = new[,]
            {
                {SlotStatus.One, SlotStatus.Zero},
                {SlotStatus.One, SlotStatus.Zero}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)), "Field with duplicate rows should be invalid.");
            field = new[,]
            {
                {SlotStatus.One, SlotStatus.Zero, SlotStatus.One, SlotStatus.Zero},
                {SlotStatus.One, SlotStatus.Zero, SlotStatus.One, SlotStatus.Zero},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)), "Field with duplicate rows should be invalid.");
        }

        [Test]
        public void TestIsValidReturnsFalseIfThereAreDuplicateColumns()
        {
            var field = new[,]
            {
                {SlotStatus.One, SlotStatus.One},
                {SlotStatus.Zero, SlotStatus.Zero}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)), "Field with duplicate columns should be invalid.");
            field = new[,]
            {
                {SlotStatus.One, SlotStatus.One, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.One, SlotStatus.One, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Zero, SlotStatus.Zero, SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Zero, SlotStatus.Zero, SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)), "Field with duplicate rows should be invalid.");
        }

        [Test]
        public void TestIsValidDoesntCountEmptyRowsOrColumnsAsDuplicates()
        {
            var field = new[,]
            {
                {SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty}
            };
            Assert.IsTrue(_validator.IsValid(new Playfield(field)), "Field should have some solution");
        }
    }
}
