namespace CSharpBinairoSolver.ValidityCheckers
{
    public class DuplicatesChecker : IPlayfieldValidityChecker
    {
        public bool IsValid(Playfield currentField)
        {
            return !HasDuplicateRows(currentField) && !HasDuplicateColumns(currentField);
        }

        private static bool HasDuplicateRows(Playfield currentField)
        {
            for (var row = 0; row < currentField.Size; row++)
            {
                for (var compared = row + 1; compared < currentField.Size; compared++)
                {
                    if (RowsAreSame(currentField, row, compared))
                        return true;
                }
            }
            return false;
        }

        private static bool RowsAreSame(Playfield currentField, int row1, int row2)
        {
            for (var column = 0; column < currentField.Size; column++)
            {
                if (currentField.Get(row1, column) != currentField.Get(row2, column) || currentField.Get(row1, column) == SlotStatus.Empty)
                    return false;
            }
            return true;
        }

        private static bool HasDuplicateColumns(Playfield currentField)
        {
            for (var column = 0; column < currentField.Size; column++)
            {
                for (var compared = column + 1; compared < currentField.Size; compared++)
                {
                    if (ColumnsAreSame(currentField, column, compared))
                        return true;
                }
            }
            return false;
        }

        private static bool ColumnsAreSame(Playfield currentField, int column1, int column2)
        {
            for (var row = 0; row < currentField.Size; row++)
            {
                if (currentField.Get(row, column1) != currentField.Get(row, column2) || currentField.Get(row, column1) == SlotStatus.Empty)
                    return false;
            }
            return true;
        }
    }
}
