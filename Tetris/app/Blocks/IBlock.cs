using System;

namespace Tetris
{
    public class IBlock : Block
    {
        private readonly Cell[][] _rotations = new Cell[][]
        {
            new Cell[] { new(1,0), new(1,1), new(1,2), new(1,3) },
            new Cell[] { new(0,2), new(1,2), new(2,2), new(3,2) },
            new Cell[] { new(2,0), new(2,1), new(2,2), new(2,3) },
            new Cell[] { new(0,1), new(1,1), new(2,1), new(3,1) }
        };

        public override int id => 1;
        public override ConsoleColor color => ConsoleColor.Cyan;
        protected override Cell startPoint => new Cell(-1, 3);
        protected override Cell[][] rotations => _rotations;
    }
}