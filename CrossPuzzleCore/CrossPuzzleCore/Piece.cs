namespace CrossPuzzleCore
{
    public class Piece
    {
        public Vector Position { get; set; }
        public PieceDirection PieceDir { get; set; }
        public int? Value { get; set; }

        public void Turn()
        {
            PieceDir = PieceDir.GetNextDirection();
        }

        public string ToArrowString()
        {
            switch (PieceDir)
            {
            case PieceDirection.Up:
                return "↑";
            case PieceDirection.Right:
                return "→";
            case PieceDirection.Down:
                return "↓";
            case PieceDirection.Left:
                return "←";
            }

            return " ";
        }

        public string ToValueString()
        {
            if (Value == null)
            {
                return "   ";
            }
            else
            {
                return string.Format("{0,3}", Value.Value);
            }
        }
    }


}