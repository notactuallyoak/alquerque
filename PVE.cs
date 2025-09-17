using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alquerque
{
    internal class PVE
    {
        Game game = new Game();
        Random random = new Random((int)DateTime.Now.Ticks);

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

                if (game.IsPlayer1Turn())
                {
                    HumanTurn();
                }
                else
                {
                    BotTurn();
                }

                // check again after each turn
                if (game.IsGameOver(out string winnerAfterMove))
                {
                    game.DrawBoard();
                    Console.WriteLine($"Game Over! {winnerAfterMove} wins!");
                    break;
                }
            }
        }

        private void HumanTurn()
        {
            Console.WriteLine("Enter your move (from to) e.g. b2 d3");
            Console.Write("> ");
            string input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(input)) return;

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
            }

            // parse input
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid input! Format: from to");
                return;
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

        private void BotTurn()
        {
            Console.WriteLine("Bot is thinking...");
            Thread.Sleep(random.Next(100,1500));

            var legalMoves = game.GetAllLegalMovesForCurrentPlayer().ToList();

            if (legalMoves.Count == 0)
            {
                Console.WriteLine("Bot has no moves left!");
                return;
            }

            // pick random legal move
            var move = legalMoves[random.Next(legalMoves.Count)];
            bool moved = game.Move(move.from, move.to);

            if (moved)
            {
                Console.WriteLine($"Bot picked {move.from} to {move.to}");
                Thread.Sleep(2000); // small pause, so player can see the update
            }
        }
    }
}
