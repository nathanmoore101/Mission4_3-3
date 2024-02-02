using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission4TicTacToe
{
    internal class tools
    {
        private char[,] board;

        public tools()
        {
            // Initialize the game board with empty spaces
            board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        }

        public void PrintBoard()
        {
            // Print the current state of the game board
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
        }


        public bool CheckForWinner()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == 'X' && board[i, 1] == 'X' && board[i, 2] == 'X')
                {
                    return true;
                }
                else if (board[i, 0] == 'O' && board[i, 1] == 'O' && board[i, 2] == 'O')
                {
                    return true;
                }
            }

            // Check columns
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == 'X' && board[1, j] == 'X' && board[2, j] == 'X')
                {
                    return true;
                }
                else if (board[0, j] == 'O' && board[1, j] == 'O' && board[2, j] == 'O')
                {
                    return true;
                }
            }

            // Check diagonals
            if ((board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == 'X') ||
                (board[0, 2] == 'X' && board[1, 1] == 'X' && board[2, 0] == 'X'))
            {
                return true;
            }
            else if ((board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O') ||
                     (board[0, 2] == 'O' && board[1, 1] == 'O' && board[2, 0] == 'O'))
            {
                return true;
            }

            return false;
        }

        public void UpdateBoard(int row, int col, char player)
        {
            // Keep prompting the player for a valid move until they make one
            while (true)
            {
                // Check if the chosen position is already occupied
                if (board[row, col] == ' ')
                {
                    // Update the game board with the player's move
                    board[row, col] = player;
                    break; // Exit the loop after a valid move
                }
                else
                {
                    // Inform the player that the chosen position is already occupied
                    Console.WriteLine("Invalid move! The chosen position is already occupied. Try again.");

                    PrintBoard();

                    // Prompt the player to enter a new position
                    Console.Write($"Player {player}, enter your move (row): ");
                    // Validate user input for row
                    while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row >= 3)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid row (0, 1, or 2): ");
                    }

                    Console.Write($"Player {player}, enter your move (column): ");
                    // Validate user input for column
                    while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col >= 3)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid column (0, 1, or 2): ");
                    }
                }
            }
        }
    }
}
