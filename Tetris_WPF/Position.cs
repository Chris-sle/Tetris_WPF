﻿namespace Tetris_WPF
{
    public class Position(int row, int column)
    {
        public int Row { get; set; } = row;
        public int Column { get; set; } = column;
    }
}
