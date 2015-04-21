namespace CSharpBinairoSolver.ValidityCheckers
{
    public class EqualNumbersChecker : IPlayfieldValidityChecker
    {
        public bool IsValid(Playfield currentField)
        {
            return HasRightAmountOfNumbers(currentField);
        }

        private static bool HasRightAmountOfNumbers(Playfield currentField)
        {
            for (var i = 0; i < currentField.Size; i++)
            {
                if (!RowHasRightAmountOfNumbers(currentField, i))
                    return false;
                if (!ColumnHasRightAmountOfNumbers(currentField, i))
                    return false;
            }
            return true;
        }

        private static bool RowHasRightAmountOfNumbers(Playfield currentField, int row)
        {
            var maxAMountOfSingleColor = currentField.Size / 2;
            var oneCount = 0;
            var zeroCount = 0;
            for (var column = 0; column < currentField.Size; column++)
            {
                if (currentField.Get(column, row) == SlotStatus.One)
                    zeroCount++;
                if (currentField.Get(column, row) == SlotStatus.Zero)
                    oneCount++;
            }
            return zeroCount <= maxAMountOfSingleColor && oneCount <= maxAMountOfSingleColor;
        }

        private static bool ColumnHasRightAmountOfNumbers(Playfield currentField, int column)
        {
            var maxAMountOfSingleColor = currentField.Size / 2;
            var oneCount = 0;
            var zeroCount = 0;
            for (var row = 0; row < currentField.Size; row++)
            {
                if (currentField.Get(column, row) == SlotStatus.One)
                    zeroCount++;
                if (currentField.Get(column, row) == SlotStatus.Zero)
                    oneCount++;
            }
            return zeroCount <= maxAMountOfSingleColor && oneCount <= maxAMountOfSingleColor;
        }
    }
}
