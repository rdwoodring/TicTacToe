using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Board : ICloneable
    {
        public List<Tile> Tiles {get; set;}

        /// <summary>
        /// Default constructor.  Creates a standard tic tac toe board with a 3x3 grid (9 tiles)
        /// </summary>
        public Board()
        {
            this.Tiles = new List<Tile>();

            for (int y = 0; y <=2; y++)
            {
                for (int x = 0; x <= 2; x++)
                {
                    this.Tiles.Add(new Tile(x, y));
                }
            }
        }

        public void DisplayBoard()
        {
            //TODO: update this method to display boards that are more than 3x3

            Console.Clear();

            StringBuilder sb = new StringBuilder();

            for (int y = 0; y <= 2; y++)
            {
                sb.AppendLine("   |   |   ");

                for (int x = 0; x <= 2; x++)
                {
                    Tile tile = (from t in this.Tiles
                                 where t.TileCoordinates.X == x && t.TileCoordinates.Y == y
                                 select t).FirstOrDefault();

                    string mark = (tile.OccupiedBy != null) ? tile.OccupiedBy.ToString() : " ";

                    sb.Append(" " + mark + " " + x.ToString());
                }


                sb.AppendLine("\r\n   |   |   \r\n___________");
            }

            //remove the placeholding indices and add pipes or empty strings to create board
            string printedboard = sb.ToString();
            printedboard = printedboard.Replace("0", "|");
            printedboard = printedboard.Replace("1", "|");
            printedboard = printedboard.Replace("2", string.Empty);

            //remove last 13 characters which are just consequence of the loop structure
            printedboard = printedboard.Remove(printedboard.Length - 13);

            Console.Write(printedboard);
        }

        public object Clone()
        {
            Board newBoard = (Board)this.MemberwiseClone();
            newBoard.Tiles = new List<Tile>();

            foreach(Tile tile in this.Tiles)
            {
                newBoard.Tiles.Add((Tile)tile.Clone());
            }
            newBoard.Tiles = new List<Tile>(this.Tiles);

            return newBoard;
        }

        public bool NoWinner(out char? winner)
        {
            bool result = true;
            winner = null;
            //TODO: adjust this to accomodate non-standard thiss
            if (this.Tiles[0].OccupiedBy != null && this.Tiles[0].OccupiedBy == this.Tiles[1].OccupiedBy && this.Tiles[1].OccupiedBy == this.Tiles[2].OccupiedBy)
            {
                winner = this.Tiles[0].OccupiedBy;
                result = false;
            }

            if (this.Tiles[3].OccupiedBy != null && this.Tiles[3].OccupiedBy == this.Tiles[4].OccupiedBy && this.Tiles[4].OccupiedBy == this.Tiles[5].OccupiedBy)
            {
                winner = this.Tiles[0].OccupiedBy;
                result = false;
            }

            if (this.Tiles[6].OccupiedBy != null && this.Tiles[6].OccupiedBy == this.Tiles[7].OccupiedBy && this.Tiles[7].OccupiedBy == this.Tiles[8].OccupiedBy)
            {
                winner = this.Tiles[0].OccupiedBy;
                result = false;
            }

            if (this.Tiles[0].OccupiedBy != null && this.Tiles[0].OccupiedBy == this.Tiles[3].OccupiedBy && this.Tiles[3].OccupiedBy == this.Tiles[6].OccupiedBy)
            {
                winner = this.Tiles[0].OccupiedBy;
                result = false;
            }

            if (this.Tiles[1].OccupiedBy != null && this.Tiles[1].OccupiedBy == this.Tiles[4].OccupiedBy && this.Tiles[4].OccupiedBy == this.Tiles[7].OccupiedBy)
            {
                winner = this.Tiles[0].OccupiedBy;
                result = false;
            }

            if (this.Tiles[2].OccupiedBy != null && this.Tiles[2].OccupiedBy == this.Tiles[5].OccupiedBy && this.Tiles[5].OccupiedBy == this.Tiles[8].OccupiedBy)
            {
                winner = this.Tiles[0].OccupiedBy;
                result = false;
            }

            if (this.Tiles[0].OccupiedBy != null && this.Tiles[0].OccupiedBy == this.Tiles[4].OccupiedBy && this.Tiles[4].OccupiedBy == this.Tiles[8].OccupiedBy)
            {
                winner = this.Tiles[0].OccupiedBy;
                result = false;
            }

            if (this.Tiles[2].OccupiedBy != null && this.Tiles[2].OccupiedBy == this.Tiles[4].OccupiedBy && this.Tiles[4].OccupiedBy == this.Tiles[6].OccupiedBy)
            {
                winner = this.Tiles[0].OccupiedBy;
                result = false;
            }

            return result;
        }
    }
}
