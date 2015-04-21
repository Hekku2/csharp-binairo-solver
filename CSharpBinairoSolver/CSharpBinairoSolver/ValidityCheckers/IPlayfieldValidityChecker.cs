namespace CSharpBinairoSolver.ValidityCheckers
{
    public interface IPlayfieldValidityChecker
    {
        bool IsValid(Playfield currentField);
    }
}
