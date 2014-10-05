namespace TicTacToe
{
    public struct Point
    {
        public int X {get; set;}
        public int Y { get; set; }

        public Point(int _x, int _y) : this()
        {
            this.X = _x;
            this.Y = _y;
        }

        public override string ToString()
        {
            return this.X.ToString() + ", " + this.Y.ToString();
        }
    }
}
