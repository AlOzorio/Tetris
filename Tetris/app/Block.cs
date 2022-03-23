using System.Collections.Generic;
using System;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Cell[][] rotations { get; }
        protected abstract Cell startPoint { get; }
        public abstract ConsoleColor color { get; }
        public abstract int id { get; }
        private int currentRotation;
        public Cell position;

        public Block()
        {
            position = new Cell(startPoint.rowIndex, startPoint.columnIndex);
        }

        public IEnumerable<Cell> RotationPositions()
        {
            foreach (Cell c in rotations[currentRotation])
            {
                yield return new Cell(c.rowIndex + position.rowIndex, c.columnIndex + position.columnIndex);
            }
        }

        public void Rotate()
        {
            currentRotation = (currentRotation + 1) % rotations.Length;
        }

        public void UndoRotation()
        {
            if (currentRotation == 0)
            {
                currentRotation = rotations.Length - 1;
            }
            else
            {
                currentRotation--;
            }
        }

        public void Move(int rows, int columns)
        {
            position.rowIndex += rows;
            position.columnIndex += columns;
        }

        public void Reset()
        {
            currentRotation = 0;
            position.rowIndex = startPoint.rowIndex;
            position.columnIndex = startPoint.columnIndex;
        }
    }
}