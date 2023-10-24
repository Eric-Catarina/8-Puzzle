using System;

public class PuzzleGame
{
    private int[,] board;
    private int emptyRow, emptyCol;

    public PuzzleGame()
    {
        board = new int[3, 3];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        int value = 1;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = value;
                value++;
            }
        }
        emptyRow = 2;
        emptyCol = 2;
        board[emptyRow, emptyCol] = 0;
        ShuffleBoard();
    }

    private void ShuffleBoard()
    {
        Random random = new Random();
        for (int i = 0; i < 1000; i++)
        {
            int move = random.Next(4);
            PerformMove(move);
        }
    }

    private void PerformMove(int move)
    {
        int newRow = emptyRow;
        int newCol = emptyCol;

        if (move == 0 && emptyRow > 0)
        {
            newRow--;
        }
        else if (move == 1 && emptyRow < 2)
        {
            newRow++;
        }
        else if (move == 2 && emptyCol > 0)
        {
            newCol--;
        }
        else if (move == 3 && emptyCol < 2)
        {
            newCol++;
        }
        else
        {
            return;
        }

        board[emptyRow, emptyCol] = board[newRow, newCol];
        board[newRow, newCol] = 0;
        emptyRow = newRow;
        emptyCol = newCol;
    }

    public void PrintBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == 0)
                {
                    Console.Write("   ");
                }
                else
                {
                    Console.Write(board[row, col].ToString("D2") + " ");
                }
            }
            Console.WriteLine();
        }
    }

    private bool IsSolved()
    {
        int value = 1;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] != value)
                {
                    return false;
                }
                value = (value + 1) % 9;
            }
        }
        return true;
    }


    public static void Main()
    {
        PuzzleGame game = new PuzzleGame();
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            game.PrintBoard();
            Console.WriteLine("Digite W (cima), A (esquerda), S (baixo), D (direita) ou Q para sair:");

            string move = Console.ReadLine().Trim();

            if (move == "q" || move == "Q")
            {
                gameOver = true;
            }
            else if (move.Length == 1)
            {
                char direction = move[0];
                if (direction == 'w' || direction == 'W')
                {
                    game.PerformMove(0);
                }
                else if (direction == 's' || direction == 'S')
                {
                    game.PerformMove(1);
                }
                else if (direction == 'a' || direction == 'A')
                {
                    game.PerformMove(2);
                }
                else if (direction == 'd' || direction == 'D')
                {
                    game.PerformMove(3);
                }

                if (game.IsSolved())
                {
                    Console.Clear();
                    game.PrintBoard();
                    Console.WriteLine("Parabéns! Você resolveu o quebra-cabeça!");
                    gameOver = true;
                }
            }
        }
    }
}

