using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Opponents
{
    public class RandomOpponent : Opponent
    {
        public RandomOpponent()
            : base()
        { }

        public RandomOpponent(Board _board)
            : base(_board)
        {
        }

        public override Point MakeMove()
        {
            List<Tile> openTiles = (from t in this.Board.Tiles
                                    where t.OccupiedBy == null
                                    select t).ToList();

            Random rand = new Random();

            int number = rand.Next(0, openTiles.Count - 1);

            return openTiles[number].TileCoordinates;

            //return this.Board;

            //return openTiles[choice].TileCoordinates;
        }
    }
}
