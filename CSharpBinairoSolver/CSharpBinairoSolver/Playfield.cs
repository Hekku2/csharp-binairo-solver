using System;

namespace CSharpBinairoSolver
{
    public class Playfield
    {
        private readonly SlotStatus[,] _field;

        private Playfield(int size)
        {
            _field = new SlotStatus[size,size];
        }

        public Playfield(SlotStatus[,] field)
        {
            if (!PlayfieldSizeIsValid(field))
                throw new ArgumentException("Field size is not valid.");
            _field = field;
        }

        public int Size
        {
            get { return _field.GetLength(0); }
        }

        public SlotStatus Get(int x, int y)
        {
            return _field[x, y];
        }

        public void Set(int x, int y, SlotStatus status)
        {
            _field[x, y] = status;
        }

        public Playfield Copy()
        {
            var field = new Playfield(Size);
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    field.Set(x, y, Get(x, y));
                }
            }
            return field;
        }

        private static bool PlayfieldSizeIsValid(SlotStatus[,] currentField)
        {
            const int row = 0;
            const int column = 1;
            if (currentField.GetLength(row) == 0 || currentField.GetLength(column) == 0)
                return false;
            if (currentField.GetLength(row) != currentField.GetLength(column))
                return false;

            return currentField.GetLength(row) % 2 == 0;
        }
    }
}
