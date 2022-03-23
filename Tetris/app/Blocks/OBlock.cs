using System;

namespace Tetris
{
    public class OBlock : Block
    {
        private readonly Cell[][] _rotations = new Cell[][]
        {
            new Cell[] { new(0,0), new(0,1), new(1,0), new(1,1) },
        };

        public override int id => 4;
        public override ConsoleColor color => ConsoleColor.Yellow;
        protected override Cell startPoint => new Cell(0, 4);
        protected override Cell[][] rotations => _rotations;
    }
}