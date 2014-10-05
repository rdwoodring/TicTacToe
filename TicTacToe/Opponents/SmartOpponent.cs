using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Opponents
{
    public class SmartOpponent : Opponent
    {
        public SmartOpponent()
            : base()
        { }

        public SmartOpponent(Board _board)
            : base(_board)
        { }


        public override Point MakeMove()
        {
            List<Tile> openTiles = (from t in this.Board.Tiles
                                    where t.OccupiedBy == null
                                    select t).ToList();

            foreach (Tile tile in openTiles)
            {

            }

            throw new NotImplementedException();
        }
    }
}
