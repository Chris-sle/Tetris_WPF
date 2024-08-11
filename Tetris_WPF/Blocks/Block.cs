namespace Tetris_WPF.Blocks
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffSet { get; }
        public abstract int Id { get; }

        private int _rotationState;
        private Position _offset;

        public Block()
        {
            _offset = new Position(StartOffSet.Row, StartOffSet.Column);
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[_rotationState])
            {
                yield return new Position(p.Row + _offset.Row, p.Column + _offset.Column);
            }
        }

        public void RotateCW()
        {
            _rotationState = (_rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW()
        {
            _rotationState = (_rotationState - 1 + Tiles.Length) % Tiles.Length;
        }

        public void Move(int rows, int columns)
        {
            _offset.Row += rows;
            _offset.Column += columns;
        }

        public void Reset()
        {
            _rotationState = 0;
            _offset.Row = StartOffSet.Row;
            _offset.Column = StartOffSet.Column;
        }
    }
}
