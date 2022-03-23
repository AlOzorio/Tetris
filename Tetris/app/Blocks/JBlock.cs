using System;

namespace Tetris
{
    public class JBlock : Block
    {
        private readonly Cell[][] _rotations = new Cell[][]
        {
            new Cell[] { new(0,0), new(1,0), new(1,1), new(1,2) },
            new Cell[] { new(0,1), new(0,2), new(1,1), new(2,1) },
            new Cell[] { new(1,0), new(1,1), new(1,2), new(2,2) },
            new Cell[] { new(0,1), new(1,1), new(2,1), new(2,0) }
        };

        public override int id => 2;
        public override ConsoleColor color => ConsoleColor.DarkBlue;
        protected override Cell startPoint => new Cell(0, 3);
        protected override Cell[][] rotations => _rotations;
    }
}