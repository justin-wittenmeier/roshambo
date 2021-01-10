using System;

namespace csharp_roshambo
{
    class Game
    {
        private string[] Moves { get; set; }
        private int BotMove { get; set; }
        private int PlayerMove { get; set; }

        public Game()
        { Moves = new string[] {"rock","paper","scissors"}; }

        private int PlayerInput()
        {
            ConsoleKeyInfo input;
            int move = -1;
            bool onOff = true;
            while (onOff)
            {
                Console.Write("Inputs:\nR = Rock\nP = Paper\nS = Scissors\nSelect Move: ");
                input = Console.ReadKey();
                Console.Write("\n\n");
                foreach (string i in Moves)
                {
                    if (Char.ToLower(input.KeyChar) == i[0])
                    {
                        onOff = false;
                        move = Array.IndexOf(Moves, i);
                    }
                }
                if (onOff)
                { Console.WriteLine("\nError please select 'r, p or s'...\n\n"); }
            }
            return move;
        }

        private int BotInput()
        {
            Random rng = new Random();
            int bot = rng.Next(Moves.Length);
            return bot;
        }

        private void WinCheck()
        {
            int[,] checks = {{0, 2},{1, 0},{2, 1}};
            if (PlayerMove == BotMove)
                { Console.WriteLine("\n*******\n*Draw!*\n*******"); }
            else
            {
                for (int i = 0; i < checks.Length; i++)
                {
                    if (PlayerMove == checks[i, 0])
                    {
                        if (BotMove == checks[i, 1])
                        {
                            Console.WriteLine("\n**************\n*Player Wins!*\n**************");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n***********\n*Bot Wins!*\n***********");
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("\n");
        }

        public void RunGame()
        {
            PlayerMove = PlayerInput();
            BotMove = BotInput();
            WinCheck();
        }
    }
}
