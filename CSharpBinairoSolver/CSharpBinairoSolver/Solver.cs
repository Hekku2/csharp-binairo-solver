using CSharpBinairoSolver.ValidityCheckers;
using Functional.Maybe;

namespace CSharpBinairoSolver
{
    public class Solver
    {
        private readonly IPlayfieldValidityChecker _rulesChecker = new PlayfieldValidator();

        public Maybe<Playfield> Solve(Playfield field)
        {
            if (!_rulesChecker.IsValid(field))
                return Maybe<Playfield>.Nothing;

            for (var x = 0; x < field.Size; x++)
            {
                for (var y = 0; y < field.Size; y++)
                {
                    var slot = field.Get(x, y);
                    if (slot != SlotStatus.Empty)
                        continue;

                    var solution = TestSolution(field, x, y, SlotStatus.Zero);
                    if (solution.HasValue)
                        return solution;
                    solution = TestSolution(field, x, y, SlotStatus.One);
                    if (solution.HasValue)
                        return solution;

                    return Maybe<Playfield>.Nothing;
                }
            }

            return field.ToMaybe();
        }

        private Maybe<Playfield> TestSolution(Playfield currentField, int x, int y, SlotStatus color)
        {
            var copied = currentField.Copy();
            copied.Set(x, y, color);
            return Solve(copied);
        }
    }
}
