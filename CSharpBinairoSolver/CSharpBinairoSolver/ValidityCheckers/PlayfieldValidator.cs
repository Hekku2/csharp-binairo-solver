namespace CSharpBinairoSolver.ValidityCheckers
{
    public class PlayfieldValidator : IPlayfieldValidityChecker
    {
        private readonly IPlayfieldValidityChecker[] _validityCheckers =
        {
            new DuplicatesChecker(),
            new EqualNumbersChecker(),
            new OnlyTwoSameNumbersChecker()
        };

        public bool IsValid(Playfield currentField)
        {
            foreach (var validityChecker in _validityCheckers)
            {
                if (!validityChecker.IsValid(currentField))
                    return false;
            }

            return true;
        }
    }
}
