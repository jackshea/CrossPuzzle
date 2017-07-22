namespace CrossPuzzleCore
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public enum PieceDirection
    {
        Up,
        Right,
        Down,
        Left
    }

    public static class Utils
    {
        public static PieceDirection GetNextDirection(this PieceDirection dir)
        {
            PieceDirection nextDir = dir;

            if (nextDir == PieceDirection.Left)
            {
                nextDir = PieceDirection.Up;
            }
            else
            {
                nextDir++;
            }
            return nextDir;
        }
    }
}