using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alquerque
{
    internal class Game
    {
        MatrixGraph graph = new MatrixGraph();

        private Dictionary<string, string> positions = new Dictionary<string, string>(); // " " = empty, 1 = player1, 2 = player2
        private bool isPlayer1Turn = true; // X, O

        public void SetupGame()
        {
            // random turn
            Random random = new Random((int)DateTime.Now.Ticks);
            isPlayer1Turn = random.Next(0, 2) == 0;

            // add all vertices
            string[] vertices = {
                "a1", "a2",
                "b1", "b2", "b3", "b4", "b5",
                "c1", "c2",
                "d1", "d2", "d3", "d4", "d5", "d6", "d7",
                "e1", "e2",
                "f1", "f2", "f3", "f4", "f5", "f6", "f7",
                "g1",
                "h1", "h2", "h3", "h4", "h5", "h6", "h7",
                "i1", "i2",
                "j1", "j2", "j3", "j4", "j5", "j6", "j7",
                "k1", "k2",
                "l1", "l2", "l3", "l4", "l5", "l6", "l7",
                "m1", "m2"
            };
            foreach (var v in vertices)
                graph.AddVertex(v);

            // do connnections
            graph.AddEdge("a1", "b1"); graph.AddEdge("a1", "b2");
            graph.AddEdge("a2", "b4"); graph.AddEdge("a2", "b5");
            graph.AddEdge("b1", "a1"); graph.AddEdge("b1", "b2"); graph.AddEdge("b1", "c1"); graph.AddEdge("b1", "d1"); graph.AddEdge("b1", "d2");
            graph.AddEdge("b2", "a1"); graph.AddEdge("b2", "b1"); graph.AddEdge("b2", "c1"); graph.AddEdge("b2", "d3");
            graph.AddEdge("b3", "d3"); graph.AddEdge("b3", "d4"); graph.AddEdge("b3", "d5");
            graph.AddEdge("b4", "a2"); graph.AddEdge("b4", "b5"); graph.AddEdge("b4", "c2"); graph.AddEdge("b4", "d5");
            graph.AddEdge("b5", "a2"); graph.AddEdge("b5", "b4"); graph.AddEdge("b5", "c2"); graph.AddEdge("b5", "d6"); graph.AddEdge("b5", "d7");
            graph.AddEdge("c1", "b1"); graph.AddEdge("c1", "b2"); graph.AddEdge("c1", "d2"); graph.AddEdge("c1", "d3");
            graph.AddEdge("c2", "b4"); graph.AddEdge("c2", "b5"); graph.AddEdge("c2", "d5"); graph.AddEdge("c2", "d6");
            graph.AddEdge("d1", "b1"); graph.AddEdge("d1", "d2"); graph.AddEdge("d1", "e1");
            graph.AddEdge("d2", "b1"); graph.AddEdge("d2", "c1"); graph.AddEdge("d2", "d1"); graph.AddEdge("d2", "d3"); graph.AddEdge("d2", "e1"); graph.AddEdge("d2", "f2"); graph.AddEdge("d2", "f3");
            graph.AddEdge("d3", "b2"); graph.AddEdge("d3", "b3"); graph.AddEdge("d3", "c1"); graph.AddEdge("d3", "d2"); graph.AddEdge("d3", "f3");
            graph.AddEdge("d4", "b3"); graph.AddEdge("d4", "f3"); graph.AddEdge("d4", "f4"); graph.AddEdge("d4", "f5");
            graph.AddEdge("d5", "b3"); graph.AddEdge("d5", "b4"); graph.AddEdge("d5", "c2"); graph.AddEdge("d5", "d6");
            graph.AddEdge("d6", "b5"); graph.AddEdge("d6", "c2"); graph.AddEdge("d6", "d5"); graph.AddEdge("d6", "d7"); graph.AddEdge("d6", "e2"); graph.AddEdge("d6", "f5"); graph.AddEdge("d6", "f6");
            graph.AddEdge("d7", "b5"); graph.AddEdge("d7", "d6"); graph.AddEdge("d7", "e2");
            graph.AddEdge("e1", "d1"); graph.AddEdge("e1", "d2"); graph.AddEdge("e1", "f1"); graph.AddEdge("e1", "f2");
            graph.AddEdge("e2", "d6"); graph.AddEdge("e2", "d7"); graph.AddEdge("e2", "f6"); graph.AddEdge("e2", "f7");
            graph.AddEdge("f1", "e1"); graph.AddEdge("f1", "f2");
            graph.AddEdge("f2", "d2"); graph.AddEdge("f2", "e1"); graph.AddEdge("f2", "f1"); graph.AddEdge("f2", "f3"); graph.AddEdge("f2", "h2");
            graph.AddEdge("f3", "d2"); graph.AddEdge("f3", "d3"); graph.AddEdge("f3", "d4"); graph.AddEdge("f3", "f2"); graph.AddEdge("f3", "f4"); graph.AddEdge("f3", "g1");
            graph.AddEdge("f4", "d4"); graph.AddEdge("f4", "f3"); graph.AddEdge("f4", "f5"); graph.AddEdge("f4", "g1");
            graph.AddEdge("f5", "d4"); graph.AddEdge("f5", "d5"); graph.AddEdge("f5", "d6"); graph.AddEdge("f5", "f4"); graph.AddEdge("f5", "f6"); graph.AddEdge("f5", "g1");
            graph.AddEdge("f6", "d6"); graph.AddEdge("f6", "e2"); graph.AddEdge("f6", "f5"); graph.AddEdge("f6", "f7"); graph.AddEdge("f6", "h6");
            graph.AddEdge("f7", "e2"); graph.AddEdge("f7", "f6");
            graph.AddEdge("g1", "f3"); graph.AddEdge("g1", "f4"); graph.AddEdge("g1", "f5"); graph.AddEdge("g1", "h3"); graph.AddEdge("g1", "h4"); graph.AddEdge("g1", "h5");
            graph.AddEdge("h1", "h2"); graph.AddEdge("h1", "i1");
            graph.AddEdge("h2", "h1"); graph.AddEdge("h2", "h3"); graph.AddEdge("h2", "i1"); graph.AddEdge("h2", "j2");
            graph.AddEdge("h3", "g1"); graph.AddEdge("h3", "h2"); graph.AddEdge("h3", "h4"); graph.AddEdge("h3", "j2"); graph.AddEdge("h3", "j3"); graph.AddEdge("h3", "j4");
            graph.AddEdge("h4", "g1"); graph.AddEdge("h4", "h3"); graph.AddEdge("h4", "h5");
            graph.AddEdge("h5", "g1"); graph.AddEdge("h5", "h4"); graph.AddEdge("h5", "h6"); graph.AddEdge("h5", "j4"); graph.AddEdge("h5", "j5"); graph.AddEdge("h5", "j6");
            graph.AddEdge("h6", "h5"); graph.AddEdge("h6", "h7"); graph.AddEdge("h6", "i2"); graph.AddEdge("h6", "j6");
            graph.AddEdge("h7", "h6"); graph.AddEdge("h7", "i2");
            graph.AddEdge("i1", "h1"); graph.AddEdge("i1", "h2"); graph.AddEdge("i1", "j1"); graph.AddEdge("i1", "j2");
            graph.AddEdge("i2", "h6"); graph.AddEdge("i2", "h7"); graph.AddEdge("i2", "j6"); graph.AddEdge("i2", "j7");
            graph.AddEdge("j1", "i1"); graph.AddEdge("j1", "j2"); graph.AddEdge("j1", "l1");
            graph.AddEdge("j2", "i1"); graph.AddEdge("j2", "j1"); graph.AddEdge("j2", "j3");
            graph.AddEdge("j3", "h3"); graph.AddEdge("j3", "j2"); graph.AddEdge("j3", "k1"); graph.AddEdge("j3", "l2"); graph.AddEdge("j3", "l3");
            graph.AddEdge("j4", "h3"); graph.AddEdge("j4", "h5"); graph.AddEdge("j4", "l3");
            graph.AddEdge("j5", "h5"); graph.AddEdge("j5", "j6"); graph.AddEdge("j5", "k2"); graph.AddEdge("j5", "l3"); graph.AddEdge("j5", "l4");
            graph.AddEdge("j6", "h5"); graph.AddEdge("j6", "h6"); graph.AddEdge("j6", "i2"); graph.AddEdge("j6", "j5"); graph.AddEdge("j6", "j7"); graph.AddEdge("j6", "k2"); graph.AddEdge("j6", "l5");
            graph.AddEdge("j7", "i2"); graph.AddEdge("j7", "j6"); graph.AddEdge("j7", "l5");
            graph.AddEdge("k1", "j2"); graph.AddEdge("k1", "j3"); graph.AddEdge("k1", "l1"); graph.AddEdge("k1", "l2");
            graph.AddEdge("k2", "j5"); graph.AddEdge("k2", "j6"); graph.AddEdge("k2", "l4"); graph.AddEdge("k2", "l5");
            graph.AddEdge("l1", "j1"); graph.AddEdge("l1", "j2"); graph.AddEdge("l1", "k1"); graph.AddEdge("l1", "l2"); graph.AddEdge("l1", "m1");
            graph.AddEdge("l2", "j3"); graph.AddEdge("l2", "k1"); graph.AddEdge("l2", "l1"); graph.AddEdge("l2", "m1");
            graph.AddEdge("l3", "j3"); graph.AddEdge("l3", "j4"); graph.AddEdge("l3", "j5");
            graph.AddEdge("l4", "j5"); graph.AddEdge("l4", "k2"); graph.AddEdge("l4", "l5"); graph.AddEdge("l4", "m2");
            graph.AddEdge("l5", "j6"); graph.AddEdge("l5", "j7"); graph.AddEdge("l5", "k2"); graph.AddEdge("l5", "l4"); graph.AddEdge("l5", "m2");
            graph.AddEdge("m1", "l1"); graph.AddEdge("m1", "l2");
            graph.AddEdge("m2", "l4"); graph.AddEdge("m2", "l5");

                // initialize positions
                int count = 0;
            foreach (var node in graph.Vertices)
            {
                if (count < 25)
                    positions[node] = "X";
                else if (count == 25)
                    positions[node] = " ";
                else
                    positions[node] = "O";

                count++;
            }
        }

        public void Menu()
        {
            Console.WriteLine("-- Select Gamemodes --");
            Console.WriteLine("    1.PvP (local)");
            Console.WriteLine("    2.PvE (bot)");
            Console.WriteLine("    3.Quit");
            Console.WriteLine();

            Console.Write("> ");
            var input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "1":
                    PVP pvp = new PVP();
                    pvp.Start();
                    break;
                case "2":
                    // soon
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }

        public void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine($"                    {GetNode("a1")}              {GetNode("a2")}");
            Console.WriteLine($"                   /   |               |   \\");
            Console.WriteLine($"                 /     |               |     \\");
            Console.WriteLine($"               /       |               |       \\");
            Console.WriteLine($"           {GetNode("b1")}-----{GetNode("b2")}     {GetNode("b3")}     {GetNode("b4")}-----{GetNode("b5")}");
            Console.WriteLine($"          / |  \\    /  |    / |  \\     |  \\    /  | \\");
            Console.WriteLine($"        /   |   {GetNode("c1")}   |  /   |    \\   |   {GetNode("c2")}   |   \\");
            Console.WriteLine($"      /     |  /    \\  |/     |      \\ |  /    \\  |     \\");
            Console.WriteLine($"  {GetNode("d1")}-----{GetNode("d2")}-----{GetNode("d3")}     {GetNode("d4")}     {GetNode("d5")}-----{GetNode("d6")}-----{GetNode("d7")}");
            Console.WriteLine($"     \\    / |  \\       |    / |  \\     |      /   |\\    /");
            Console.WriteLine($"      {GetNode("e1")}  |    \\     |  /   |    \\   |    /     | {GetNode("e2")}");
            Console.WriteLine($"     /    \\ |      \\   |/     |      \\ |  /       |/    \\");
            Console.WriteLine($"  {GetNode("f1")}-----{GetNode("f2")}-----{GetNode("f3")}-----{GetNode("f4")}-----{GetNode("f5")}-----{GetNode("f6")}-----{GetNode("f7")}");
            Console.WriteLine($"            |           \\     |      /            |");
            Console.WriteLine($"            |              \\  |   /               |");
            Console.WriteLine($"            |                {GetNode("g1")}                 |");
            Console.WriteLine($"            |              /  |   \\               |");
            Console.WriteLine($"            |           /     |      \\            |");
            Console.WriteLine($"  {GetNode("h1")}-----{GetNode("h2")}-----{GetNode("h3")}-----{GetNode("h4")}-----{GetNode("h5")}-----{GetNode("h6")}-----{GetNode("h7")}");
            Console.WriteLine($"      \\  /  |     /    | \\          /  |   \\      | \\  / ");
            Console.WriteLine($"      {GetNode("i1")}  |    /     |  \\        /   |    \\     | {GetNode("i2")}");
            Console.WriteLine($"      /  \\  |   /      |   \\      /    |     \\    | /  \\ ");
            Console.WriteLine($"  {GetNode("j1")}-----{GetNode("j2")}-----{GetNode("j3")}     {GetNode("j4")}     {GetNode("j5")}-----{GetNode("j6")}-----{GetNode("j7")}");
            Console.WriteLine($"       \\    |   \\  /   | \\     |    /  |   \\  /   |    / ");
            Console.WriteLine($"        \\   |   {GetNode("k1")}   |  \\    |   /   |  {GetNode("k2")}    |   /");
            Console.WriteLine($"         \\  |   /  \\   |   \\   |  /    |   /  \\   |  /");
            Console.WriteLine($"           {GetNode("l1")}-----{GetNode("l2")}     {GetNode("l3")}     {GetNode("l4")}-----{GetNode("l5")}");
            Console.WriteLine($"               \\       |               |       /");
            Console.WriteLine($"                 \\     |               |     /");
            Console.WriteLine($"                   \\   |               |   /");
            Console.WriteLine($"                    {GetNode("m1")}              {GetNode("m2")}");
            Console.WriteLine();
            Console.WriteLine($"Player {(isPlayer1Turn ? 1 : 2)}'s Turn ({(isPlayer1Turn ? "X" : "O")}) (type q or quit to give up)");
        }

        public bool Move(string from, string to)
        {
            if (!positions.ContainsKey(from) || !positions.ContainsKey(to)) return false;
            string currentPlayer = isPlayer1Turn ? "X" : "O";

            if (positions[from] != currentPlayer) return false;

            // capture
            foreach (var enemy in graph.GetNeighbors(from))
            {
                foreach (var landing in graph.GetNeighbors(enemy))
                {
                    if (CanCapture(from, enemy, landing) && landing == to)
                    {
                        positions[enemy] = " ";
                        positions[to] = currentPlayer;
                        positions[from] = " ";

                        // multiple capture check
                        if (!HasCaptureAvailable(to, currentPlayer))
                            isPlayer1Turn = !isPlayer1Turn;

                        return true;
                    }
                }
            }

            // normal move
            if (CanMove(from, to))
            {
                positions[to] = currentPlayer;
                positions[from] = " ";
                isPlayer1Turn = !isPlayer1Turn;
                return true;
            }

            return false;
        }

        private bool CanCapture(string from, string enemy, string landing)
        {
            if (!positions.ContainsKey(from) || !positions.ContainsKey(enemy) || !positions.ContainsKey(landing))
                return false;

            string currentPlayer = positions[from];

            if (positions[enemy] == " " || positions[enemy] == currentPlayer) return false;
            if (positions[landing] != " ") return false;
            if (!graph.HasEdge(from, enemy) || !graph.HasEdge(enemy, landing)) return false;

            var neighbors = graph.GetNeighbors(from);
            if (!neighbors.Contains(enemy)) return false;

            // no diagonal capture
            if (graph.HasEdge(from, landing)) return false;

            return true;
        }

        private bool HasCaptureAvailable(string currentNode, string currentPlayer)
        {
            foreach (var enemy in graph.GetNeighbors(currentNode))
            {
                foreach (var landing in graph.GetNeighbors(enemy))
                {
                    if (CanCapture(currentNode, enemy, landing))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CanMove(string from, string to)
        {
            return positions.ContainsKey(from) &&
                   positions.ContainsKey(to) &&
                   positions[to] == " " &&
                   graph.HasEdge(from, to);
        }

        private string GetNode(string name)
        {
            return $"{name}:{positions[name]}";
        }
    }
}
