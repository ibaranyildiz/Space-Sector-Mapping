using System.Collections.Generic;

namespace SpaceSectorMapping
{
    public class Pathfinder
    {
        private readonly SectorGrid grid;

        // 4 Yönlü Hareket: Yukarı, Aşağı, Sol, Sağ
        private readonly (int dx, int dy)[] directions = new[]
        {
            (0, 1),  // Yukarı
            (0, -1), // Aşağı
            (-1, 0), // Sol
            (1, 0)   // Sağ
        };

        public Pathfinder(SectorGrid grid)
        {
            this.grid = grid;
        }

        /// <summary>
        /// BFS kullanarak başlangıçtan hedefe en kısa yolu bulur.
        /// </summary>
        public List<SectorNode> FindShortestPath(int startX, int startY, int targetX, int targetY)
        {
            SectorNode startNode = grid.GetNode(startX, startY);
            SectorNode targetNode = grid.GetNode(targetX, targetY);

            if (startNode == null || targetNode == null || !targetNode.IsWalkable)
            {
                return new List<SectorNode>(); // Geçersiz hedef veya engel
            }

            Queue<SectorNode> queue = new Queue<SectorNode>();
            Dictionary<SectorNode, SectorNode> cameFrom = new Dictionary<SectorNode, SectorNode>();
            HashSet<SectorNode> visited = new HashSet<SectorNode>();

            queue.Enqueue(startNode);
            visited.Add(startNode);

            bool found = false;

            while (queue.Count > 0)
            {
                SectorNode current = queue.Dequeue();

                if (current.X == targetX && current.Y == targetY)
                {
                    found = true;
                    break;
                }

                foreach (var dir in directions)
                {
                    int neighborX = current.X + dir.dx;
                    int neighborY = current.Y + dir.dy;

                    SectorNode neighbor = grid.GetNode(neighborX, neighborY);

                    // Sınır kontrolü, engel kontrolü ve daha önce ziyaret edilip edilmediği kontrolü
                    if (neighbor != null && neighbor.IsWalkable && !visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        cameFrom[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            if (!found) return new List<SectorNode>(); // Yol bulunamadı

            // Hedef düğümden geriye doğru yolu yeniden inşa etme
            return RetracePath(startNode, targetNode, cameFrom);
        }

        private List<SectorNode> RetracePath(SectorNode startNode, SectorNode targetNode, Dictionary<SectorNode, SectorNode> cameFrom)
        {
            List<SectorNode> path = new List<SectorNode>();
            SectorNode current = targetNode;

            while (current != startNode)
            {
                path.Add(current);
                current = cameFrom[current];
            }

            path.Add(startNode);
            path.Reverse(); // Yolu başlangıçtan hedefe sırala
            return path;
        }
    }
}
