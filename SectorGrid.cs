using System;

namespace SpaceSectorMapping
{
    public class SectorGrid
    {
        public int Width { get; }
        public int Height { get; }
        private readonly SectorNode[,] grid;

        public SectorGrid(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new SectorNode[width, height];
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    grid[x, y] = new SectorNode(x, y, SectorType.Empty);
                }
            }
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public SectorNode GetNode(int x, int y)
        {
            if (!IsInBounds(x, y)) return null;
            return grid[x, y];
        }

        public void SetSectorType(int x, int y, SectorType type)
        {
            if (IsInBounds(x, y))
            {
                grid[x, y].Type = type;
            }
        }
    }
}
