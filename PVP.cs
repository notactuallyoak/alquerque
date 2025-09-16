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
            game.SetupGame();

            while (true)
            {

                game.DrawBoard();

                Console.WriteLine("Enter your move (from to) e.g. b2 d3");
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input)) continue;

                // allow quit
                if (input == "quit" || input == "q")
                    Environment.Exit(0);

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
