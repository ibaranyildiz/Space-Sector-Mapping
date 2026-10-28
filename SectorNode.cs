namespace SpaceSectorMapping
{
    public class SectorNode
    {
        public int X { get; }
        public int Y { get; }
        public SectorType Type { get; set; }
        public bool IsExplored { get; set; }

        public SectorNode(int x, int y, SectorType type)
        {
            X = x;
            Y = y;
            Type = type;
            IsExplored = false;
        }

        public bool IsWalkable => Type != SectorType.Asteroid;
    }
}
