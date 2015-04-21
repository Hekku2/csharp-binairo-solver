namespace CSharpBinairoSolver.ValidityCheckers
{
    public class OnlyTwoSameNumbersChecker : IPlayfieldValidityChecker
    {
        public bool IsValid(Playfield currentField)
        {
            for (var rowOrColumn = 0; rowOrColumn < currentField.Size; rowOrColumn++)
            {
                if (RowHasThreeOrMoreSameColorSlotsNextToEachOther(currentField, rowOrColumn))
                    return false;
                if (ColumnHasThreeOrMoreSameColorSlotsNextToEachOther(currentField, rowOrColumn))
                    return false;
            }
            return true;
        }

        private static bool RowHasThreeOrMoreSameColorSlotsNextToEachOther(Playfield currentField, int row)
        {
            var count = 0;
            var color = SlotStatus.Empty;
            for (var column = 0; column < currentField.Size; column++)
            {
                var next = currentField.Get(column, row);
                if (next == SlotStatus.Empty)
                    count = 0;
                else if (next == color)
                    count++;
                else
                    count = 1;
                color = next;

                if (count >= 3)
                    return true;
            }
            return false;
        }

        private static bool ColumnHasThreeOrMoreSameColorSlotsNextToEachOther(Playfield currentField, int column)
        {
            var count = 0;
            var color = SlotStatus.Empty;
            for (var row = 0; row < currentField.Size; row++)
            {
                var next = currentField.Get(column, row);
                if (next == SlotStatus.Empty)
                    count = 0;
                else if (next == color)
                    count++;
                else
                    count = 1;
                color = next;

                if (count >= 3)
                    return true;
            }
            return false;
        }
    }
}
