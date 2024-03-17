using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; // Represents the game board
        static char currentPlayer = 'X'; // Represents the current player ('X' or 'O')
        static bool gameEnded = false; // Indicates whether the game has ended

        static void Main(string[] args)
        {
            InitializeBoard();
            PrintBoard();

            // Main game loop
            while (!gameEnded)
            {
                Console.WriteLine($"Player {currentPlayer}'s turn");
                int[] move = GetPlayerMove();

                if (IsValidMove(move))
                {
                    PlaceMove(move);
                    PrintBoard();
                    if (HasWinner(move))
                    {
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameEnded = true;
                    }
                    else if (IsBoardFull())
                    {
                        Console.WriteLine("It's a draw!");
                        gameEnded = true;
                    }
                    else
                    {
                        // Switch player for the next turn
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }
        }

        // Initializes the game board with empty spaces
        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        // Prints the current state of the game board
        static void PrintBoard()
        {
            Console.WriteLine("  1 2 3");
            for (int row = 0; row < 3; row++)
            {
                Console.Write($"{row + 1} "); //prints 1 2 3 as row numbers
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{board[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Gets the player's move (row and column)
        static int[] GetPlayerMove()
        {
            Console.Write("Enter row (1-3): ");
            int row = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Enter column (1-3): ");
            int col = int.Parse(Console.ReadLine()) - 1;
            return new int[] { row, col };
        }

        // Checks if the move is valid (within bounds and the cell is empty)
        static bool IsValidMove(int[] move)
        {
            int row = move[0];
            int col = move[1];
            return row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ';
        }

        // Places the player's move on the board
        static void PlaceMove(int[] move)
        {
            int row = move[0];
            int col = move[1];
            board[row, col] = currentPlayer;//writes on the board 'X' or 'O'
        }

        // Checks if the current player has won
        static bool HasWinner(int[] move)
        {
            int row = move[0];
            int col = move[1];
            char symbol = currentPlayer;

            // Check row
            if (board[row, 0] == symbol && board[row, 1] == symbol && board[row, 2] == symbol)
                return true;
            // Check column
            if (board[0, col] == symbol && board[1, col] == symbol && board[2, col] == symbol)
                return true;
            // Check diagonal (top-left to bottom-right)
            if (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol)
                return true;
            // Check diagonal (bottom-left to top-right)
            if (board[2, 0] == symbol && board[1, 1] == symbol && board[0, 2] == symbol)
                return true;

            return false;
        }

        // Checks if the board is full (i.e., a draw)
        static bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                        return false;
                }
            }
            return true;
        }
    }
}
