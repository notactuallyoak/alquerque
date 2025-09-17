using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alquerque
{
    internal class PVP
    {
        Game game = new Game();

        public void Start()
        {
            Console.Write("Enter maximum undo times allowed: ");
            if (int.TryParse(Console.ReadLine(), out int limit) && limit >= 0)
                game.SetUndoLimit(limit);
            else
                game.SetUndoLimit(0); // default no undo

            game.SetupGame();

            while (true)
            {
                game.DrawBoard();

                if (game.IsGameOver(out string winner))
                {
                    Console.WriteLine($"Game Over! {winner} wins!");
                    break;
                }

                Console.WriteLine("Enter your move (from to) e.g. b2 d3");
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input)) continue;

                if (input == "quit" || input == "q")
                {
                    if (game.IsPlayer1Turn())
                    {
                        Console.WriteLine("Player 1 gave up! Player 2 wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 gave up! Player 1 wins!");
                    }
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                if (input == "undo" || input == "z")
                {
                    if (!game.UndoMove())
                        Console.WriteLine("No moves to undo!");
                    else
                        Console.WriteLine("Move undone.");
                    Console.ReadKey();
                    continue;
                }

                // parse input
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input! Format: from to");
                    continue;
                }

                string from = parts[0];
                string to = parts[1];

                bool moved = game.Move(from, to);

                if (!moved)
                {
                    Console.WriteLine("Invalid move, try again!");
                    Console.ReadKey();
                }
            }
        }
    }
}
