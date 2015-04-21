using CSharpBinairoSolver;
using NUnit.Framework;

namespace SolverTests
{
    [TestFixture]
    public class SolverTests
    {
        private Solver _solver;

        [SetUp]
        public void Setup()
        {
            _solver = new Solver();
        }

        [Test]
        public void TestSolveReturnsCorrectAnswerWhenSingleSlotIsEmpty()
        {
            var field = new[,]
            {
                {SlotStatus.Zero, SlotStatus.Zero,SlotStatus.One, SlotStatus.One},
                {SlotStatus.One, SlotStatus.Zero,SlotStatus.Zero, SlotStatus.One},
                {SlotStatus.One, SlotStatus.One,SlotStatus.Zero, SlotStatus.Empty},
                {SlotStatus.Zero, SlotStatus.One,SlotStatus.One, SlotStatus.Zero}
            };
            var result = _solver.Solve(new Playfield(field));
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(SlotStatus.Zero, result.Value.Get(2,3));
        }

        [Test]
        public void TestSolveReturnsCorrectAnswerWhenTwoSlotsAreEmpty()
        {
            var field = new[,]
            {
                {SlotStatus.Zero, SlotStatus.Zero,SlotStatus.One, SlotStatus.One},
                {SlotStatus.One, SlotStatus.Zero,SlotStatus.Zero, SlotStatus.One},
                {SlotStatus.One, SlotStatus.One,SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Zero, SlotStatus.One,SlotStatus.One, SlotStatus.Zero}
            };
            var result = _solver.Solve(new Playfield(field));
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(SlotStatus.Zero, result.Value.Get(2, 3));
            Assert.AreEqual(SlotStatus.Zero, result.Value.Get(2, 2));
        }

        [Test]
        public void TestSolveReturnsCorrectAnswerWhenFieldsIsEmpty()
        {
            var field = new[,]
            {
                {SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty}
            };
            var result = _solver.Solve(new Playfield(field));
            Assert.IsTrue(result.HasValue);

            for (var x = 0; x < field.GetLength(0); x++)
            {
                for (var y = 0; y < field.GetLength(1); y++)
                {
                    Assert.IsTrue(result.Value.Get(x,y) != SlotStatus.Empty, string.Format("Slot ({0},{1}) was empty", x, y));
                }
            }
        }

        [Test]
        public void TestSolveReturnsCorrectAnswerForSizeSix()
        {
            var field = new[,]
            {
                {SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Zero,SlotStatus.Empty, SlotStatus.Zero,SlotStatus.Empty, SlotStatus.Zero},
                {SlotStatus.Zero, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.One,SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.Empty, SlotStatus.Empty,SlotStatus.Zero, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.Empty},
                {SlotStatus.One, SlotStatus.Empty,SlotStatus.Empty, SlotStatus.One,SlotStatus.One, SlotStatus.Empty}
            };
            var result = _solver.Solve(new Playfield(field));
            Assert.IsTrue(result.HasValue);

            for (var x = 0; x < field.GetLength(0); x++)
            {
                for (var y = 0; y < field.GetLength(1); y++)
                {
                    Assert.IsTrue(result.Value.Get(x, y) != SlotStatus.Empty, string.Format("Slot ({0},{1}) was empty", x, y));
                }
            }
        }
    }
}
