namespace CrossPuzzleCore
{
    public class Piece
    {
        public Vector Position { get; set; } // 在游戏盘上的坐标
        public PieceDirection PieceDir { get; set; } // 方向
        public PieceDirection CalcDir { get; set; } // 用于估值的方向
        public int? Value { get; set; } // 估值

        // 顺时针旋转
        public void Turn()
        {
            PieceDir = PieceDir.GetNextDirection();
        }

        // 用箭头表示方向
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

        // 格式化显示估值
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

        // 重置估值方向
        public void ResetCalcDir()
        {
            CalcDir = PieceDir;
        }
    }


}