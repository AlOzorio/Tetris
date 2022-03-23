namespace Tetris
{
    public class Grid
    {
        private readonly int[,] grid;
        public int rows, columns;
        public int score = 0;

        public int this[int row, int col]
        {
            get => grid[row, col];
            set => grid[row, col] = value;
        }

        public Grid(int _rows, int _columns)
        {
            rows = _rows;
            columns = _columns;
            grid = new int[_rows, _columns];
        }

        public bool CheckBoundaries(int row, int col)
        {
            if (row >= 0 && row < rows && col >= 0 && col < columns)
            {
                return true;
            }

            return false;
        }

        public bool CheckEmptyCell(int row, int col)
        {
            if (CheckBoundaries(row, col) && grid[row, col] == 0)
            {
                return true;
            }

            return false;
        }

        public bool CheckFullRow(int row)
        {
            for (int i = 0; i < columns; i++)
            {
                if (grid[row, i] == 0)
                {
                    return false;
                }
            }

            score += 100;
            return true;
        }

        public bool CheckEmptyRow(int row)
        {
            for (int i = 0; i < columns; i++)
            {
                if (grid[row, i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void ClearRow(int row)
        {
            for (int i = 0; i < columns; i++)
            {
                grid[row, i] = 0;
            }
        }

        private void DropRow(int row, int qtd)
        {
            for (int i = 0; i < columns; i++)
            {
                grid[row + qtd, i] = grid[row, i];
                grid[row, i] = 0;
            }
        }

        public int ClearFullRows()
        {
            int qtd = 0;

            for (int i = rows - 1; i >= 0; i--)
            {
                if (CheckFullRow(i))
                {
                    ClearRow(i);
                    qtd++;
                }
                else if (qtd > 0)
                {
                    DropRow(i, qtd);
                }
            }

            return qtd;
        }
    }
}