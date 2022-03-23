using System;

namespace Tetris
{
    public class BlockGeneration
    {
        private readonly Random random = new Random();

        public Block nextBlock { get; private set; }

        public BlockGeneration()
        {
            nextBlock = GenerateBlock();
        }

        private Block GenerateBlock()
        {
            int rand = random.Next(0, 7);
            switch (rand)
            {
                case 0:
                    return new IBlock();
                case 1:
                    return new JBlock();
                case 2:
                    return new LBlock();
                case 3:
                    return new OBlock();
                case 4:
                    return new SBlock();
                case 5:
                    return new TBlock();
                case 6:
                    return new ZBlock();
            }
            return null;
        }

        public Block GetBlock()
        {
            Block block = nextBlock;

            do
            {
                nextBlock = GenerateBlock();
            }
            while (block.id == nextBlock.id);

            return block;
        }
    }
}