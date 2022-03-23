using System;

namespace Tetris
{
    public class GameManager
    {
        private Block currentBlock;
        public Block _currentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        public Grid grid { get; }
        public BlockGeneration blockGeneration { get; }
        public bool gameOver { get; private set; }

        public GameManager()
        {
            grid = new Grid(22, 10);
            blockGeneration = new BlockGeneration();
            currentBlock = blockGeneration.GetBlock();
        }

        private bool CheckBlock()
        {
            foreach (Cell c in currentBlock.RotationPositions())
            {
                if (!grid.CheckEmptyCell(c.rowIndex, c.columnIndex))
                {
                    return false;
                }
            }

            return true;
        }

        public void RotateBlockH()
        {
            currentBlock.Rotate();

            if (!CheckBlock())
            {
                currentBlock.UndoRotation();
            }
        }

        public void RotateBlockAH()
        {
            currentBlock.UndoRotation();

            if (!CheckBlock())
            {
                currentBlock.Rotate();
            }
        }

        public void MoveLeft()
        {
            currentBlock.Move(0, -1);

            if (!CheckBlock())
            {
                currentBlock.Move(0, 1);
            }
        }

        public void MoveRight()
        {
            currentBlock.Move(0, 1);

            if (!CheckBlock())
            {
                currentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            if (!(grid.CheckEmptyRow(0) && grid.CheckEmptyRow(1)))
            {
                return true;
            }
            return false;
        }

        private void DropBlock()
        {
            foreach (Cell c in currentBlock.RotationPositions())
            {
                grid[c.rowIndex, c.columnIndex] = currentBlock.id;
            }

            grid.ClearFullRows();

            if (IsGameOver())
            {
                gameOver = true;
            }
            else
            {
                currentBlock = blockGeneration.GetBlock();
            }
        }

        public void MoveDown()
        {
            currentBlock.Move(1, 0);

            if (!CheckBlock())
            {
                currentBlock.Move(-1, 0);
                DropBlock();
            }
        }

        public void CheckUserInput()
        {
            ConsoleKey k;

            if (Console.KeyAvailable)
            {
                k = Console.ReadKey().Key;

                switch (k)
                {
                    case ConsoleKey.LeftArrow:
                        MoveLeft();
                        MoveDown();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight();
                        MoveDown();
                        break;
                    case ConsoleKey.Q:
                        RotateBlockAH();
                        MoveDown();
                        break;
                    case ConsoleKey.W:
                        RotateBlockH();
                        MoveDown();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        break;
                    default:
                        MoveDown();
                        break;
                }

                Draw();
            }
        }

        public void Draw()
        {
            Console.Clear();
            DrawBorders();
            DrawGrid();
            DrawBlock();
        }

        public void DrawBorders()
        {
            string s = "╔";
            string space = "";
            for (int i = 0; i < grid.columns; i++)
            {
                space += " ";
                s += "═";
            }

            s += "╗" + $"        Score: {grid.score}" + "\n";
            s += "║" + space + "║" + "\n";
            s += "║" + space + "║" + "\n";
            s += "║" + space + "║" + "\n";
            s += "║" + space + "║" + "        Mover para a direita: seta direita" + "\n";
            s += "║" + space + "║" + "        Mover para a esquerda: seta esquerda" + "\n";
            s += "║" + space + "║" + "        Mover para baixo: seta para baixo" + "\n";
            s += "║" + space + "║" + "        Rodar no sentido horário: W" + "\n";
            s += "║" + space + "║" + "        Rodar no sentido anti horário: Q" + "\n";


            for (int j = 8; j < grid.rows - 1; j++)
            {
                s += "║" + space + "║" + "\n";
            }

            s += "╚";
            for (int k = 0; k < grid.columns; k++)
            {
                s += "═";
            }

            s += "╝" + "\n";

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.Write(s);
            Console.ResetColor();
        }

        public void DrawBlock()
        {
            foreach (Cell c in currentBlock.RotationPositions())
            {
                Console.SetCursorPosition(c.columnIndex, c.rowIndex);
                Console.ForegroundColor = currentBlock.color;
                Console.Write("#");
            }
        }
        public void DrawGrid()
        {
            for (int i = 0; i < grid.rows; i++)
            {
                for (int j = 0; j < grid.columns; j++)
                {
                    if (grid[i, j] != 0)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write('#');
                    }
                }
            }
        }

        public void EndGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Score: {0}", grid.score);
            return;
        }

        public void StartGame()
        {
            Draw();
            while (!IsGameOver())
            {
                CheckUserInput();
            }
            EndGame();
        }
    }
}