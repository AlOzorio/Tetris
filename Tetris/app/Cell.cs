namespace Tetris
{
    public class Cell
    {
        public int rowIndex { get; set; }
        public int columnIndex { get; set; }

        public Cell(int row, int col)
        {
            rowIndex = row;
            columnIndex = col;
        }
    }
}