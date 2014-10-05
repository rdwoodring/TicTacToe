using System;

namespace TicTacToe
{
    public class Tile : ICloneable
    {
        public Point TileCoordinates { get; set; }
        public char? OccupiedBy { get; set; }
        
        public Tile(int x, int y)
        {
            this.TileCoordinates  = new Point(x, y);

            this.OccupiedBy = null;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
