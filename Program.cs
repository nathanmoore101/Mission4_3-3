using Mission4TicTacToe;
using System;

class Driver
{
    static void Main(string[] args)
    {
        //Welcome the user to the game
        Console.WriteLine("Welcome to Tic-Tac-Toe");
        tools tools = new tools(); //instantiation of tools.cs
        char currentPlayer = 'X';
        bool gameWon = false;

        while (!gameWon)
        {
            Console.Clear();
            Console.WriteLine("Current board:");

            tools.PrintBoard();
            Console.WriteLine($"Player {currentPlayer}, make your move (row,col) (ex: 1,2 )): ");
            //Create a game board array to store the players’ choices
            string[] inputs = Console.ReadLine().Split(',');
            int row = int.Parse(inputs[0]);
            int col = int.Parse(inputs[1]); //save row and column of player input

            //Ask each player in turn for their choice and update the game board array
            tools.UpdateBoard(row, col, currentPlayer);

            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            //Check for a winner by calling the method in the supporting class
            gameWon = tools.CheckForWinner();

            if (gameWon)
            {
                Console.Clear();
                tools.PrintBoard();
                //notify the players when a win has occurred and which player won the game
                Console.WriteLine($"Player {currentPlayer} wins!");
                break;
            }
            else
            {
                Console.WriteLine(" Click Enter to save your move!");
                Console.ReadKey();
            }
   
        }


    }
}
