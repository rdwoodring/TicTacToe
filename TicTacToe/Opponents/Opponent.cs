using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Opponents
{
    public abstract class Opponent
    {
        public Board Board { get; set; }

        public Opponent()
        { }

        public Opponent(Board _board)
        {
            this.Board = _board;
        }

        public abstract Point MakeMove();
    }
}
