using CSharpBinairoSolver;
using CSharpBinairoSolver.ValidityCheckers;
using NUnit.Framework;

namespace SolverTests
{
    [TestFixture]
    public class PlayfieldValidatorTests
    {
        private PlayfieldValidator _validator;

        [Test]
        public void Setup()
        {
            _validator = new PlayfieldValidator();
        }

        [Test]
        public void TestIsValidReturnsFalseIfRowDoesntHaveEqualAmountOfBothColors()
        {
            var field = new[,]
            {
                {SlotStatus.One, SlotStatus.Empty},
                {SlotStatus.One, SlotStatus.Empty}
            };
            Assert.IsFalse(_validator.IsValid(new Playfield(field)), "Field should be invalid, because first column has only blue slots.");
        }
    }
}
