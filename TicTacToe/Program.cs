using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TicTacToe.Opponents;

namespace TicTacToe
{
    class Program
    {
        static Board board;
        static Opponent cpu;
        static char? winner;

        static void Main(string[] args)
        {
            board = new Board();

            string line;
            int choice;

            //menu
            do
            {
                Console.WriteLine("TIC TAC TOE");
                Console.WriteLine("1.  Play against an opponent who moves randomly");
                Console.WriteLine("2.  Play against a smart opponent");
                Console.WriteLine("3.  Quit");

                line = Console.ReadLine();
                choice = Convert.ToInt32(line);
            } while (choice != 1 && choice != 2 && choice != 3);

            Console.Clear();

            Random rand = new Random();
            bool playerFirst;

            if (rand.Next(0,2) == 0)
            {
                //computer goes first
                playerFirst = false;
                Console.WriteLine("The CPU is going first this time.  Press any key to start the game");
            }
            else
            {
                //player goes first
                playerFirst = true;
                Console.WriteLine("You are going first this time.  Press any key to start the game");
            }

            Console.ReadKey();
            Console.Clear();

            cpu = null;

            switch (choice)
            {
                case 1:
                    cpu = new RandomOpponent(board);
                    break;
                case 2:
                    cpu = new SmartOpponent(board);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }

            int movesCount = 0;

            while (movesCount <= board.Tiles.Count && NoWinner())
            {
                if (playerFirst)
                {
                    if (movesCount % 2 == 0)
                    {
                        PlayerMove();
                    }
                    else
                    {
                        CPUMove();
                    }
                }
                else
                {
                    if (movesCount % 2 == 0)
                    {
                        CPUMove();
                    }
                    else
                    {
                        PlayerMove();
                    }
                }

                movesCount++;

                //board.DisplayBoard();
            }

            board.DisplayBoard();

            if (winner == 'P')
            {
                Console.WriteLine("Nice!  You won!");
            }
            else if (winner == 'C')
            {
                Console.WriteLine("Bummer!  You lost!");
            }
            else
            {
                Console.WriteLine("Cat got it!");
            }

            Console.ReadKey();
        }

        private static bool NoWinner()
        {
            bool result = true;
            //TODO: adjust this to accomodate non-standard boards
            if (board.Tiles[0].OccupiedBy != null && board.Tiles[0].OccupiedBy == board.Tiles[1].OccupiedBy && board.Tiles[1].OccupiedBy == board.Tiles[2].OccupiedBy)
            {
                winner = board.Tiles[0].OccupiedBy;
                result = false;
            }

            if (board.Tiles[3].OccupiedBy != null && board.Tiles[3].OccupiedBy == board.Tiles[4].OccupiedBy && board.Tiles[4].OccupiedBy == board.Tiles[5].OccupiedBy)
            {
                winner = board.Tiles[0].OccupiedBy;
                result = false;
            }

            if (board.Tiles[6].OccupiedBy != null && board.Tiles[6].OccupiedBy == board.Tiles[7].OccupiedBy && board.Tiles[7].OccupiedBy == board.Tiles[8].OccupiedBy)
            {
                winner = board.Tiles[0].OccupiedBy;
                result = false;
            }

            if (board.Tiles[0].OccupiedBy != null && board.Tiles[0].OccupiedBy == board.Tiles[3].OccupiedBy && board.Tiles[3].OccupiedBy == board.Tiles[6].OccupiedBy)
            {
                winner = board.Tiles[0].OccupiedBy;
                result = false;
            }

            if (board.Tiles[1].OccupiedBy != null && board.Tiles[1].OccupiedBy == board.Tiles[4].OccupiedBy && board.Tiles[4].OccupiedBy == board.Tiles[7].OccupiedBy)
            {
                winner = board.Tiles[0].OccupiedBy;
                result = false;
            }

            if (board.Tiles[2].OccupiedBy != null && board.Tiles[2].OccupiedBy == board.Tiles[5].OccupiedBy && board.Tiles[5].OccupiedBy == board.Tiles[8].OccupiedBy)
            {
                winner = board.Tiles[0].OccupiedBy;
                result = false;
            }

            if (board.Tiles[0].OccupiedBy != null && board.Tiles[0].OccupiedBy == board.Tiles[4].OccupiedBy && board.Tiles[4].OccupiedBy == board.Tiles[8].OccupiedBy)
            {
                winner = board.Tiles[0].OccupiedBy;
                result = false;
            }

            if (board.Tiles[2].OccupiedBy != null && board.Tiles[2].OccupiedBy == board.Tiles[4].OccupiedBy && board.Tiles[4].OccupiedBy == board.Tiles[6].OccupiedBy)
            {
                winner = board.Tiles[0].OccupiedBy;
                result = false;
            }

            return result;
        }

        private static void CPUMove()
        {
            Console.WriteLine("It's CPU's turn!");
            board.DisplayBoard();
            Point move = cpu.MakeMove();
            Console.WriteLine("CPU moved to {0}", move.ToString());

            Tile tile = (from t in board.Tiles
                         where t.TileCoordinates.X == move.X && t.TileCoordinates.Y == move.Y
                         select t).FirstOrDefault();

            int index = board.Tiles.IndexOf(tile);
            board.Tiles[index].OccupiedBy = 'C';

            cpu.Board = board;

            Console.ReadKey();
        }

        private static void PlayerMove()
        {
            Console.WriteLine("It's your turn!");
            board.DisplayBoard();
            Console.WriteLine("Enter the x,y coordinates of the square you would like to take, separated by a comma... ");
            string enteredmove = Console.ReadLine();

            while (enteredmove.Length != 3)
            {
                Console.WriteLine("Invalid.  Enter a valid move");
                enteredmove = Console.ReadLine();
            }

            Tile tile;

            do
            {
                string[] coords = enteredmove.Split(',');
                Point move = new Point(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]));

                tile = (from t in board.Tiles
                        where t.TileCoordinates.X == move.X && t.TileCoordinates.Y == move.Y
                        select t).FirstOrDefault();
            } while (tile.OccupiedBy != null);
            

            int index = board.Tiles.IndexOf(tile);
            board.Tiles[index].OccupiedBy = 'P';

            cpu.Board = board;
        }
    }
}
