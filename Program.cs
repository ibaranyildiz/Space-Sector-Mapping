using System;
using System.Collections.Generic;

namespace SpaceSectorMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Space Sector Mapping & Pathfinding Engine ===");

            int width = 10;
            int height = 10;
            SectorGrid grid = new SectorGrid(width, height);

            // Engeller (Asteroit Kuşağı)
            grid.SetSectorType(3, 1, SectorType.Asteroid);
            grid.SetSectorType(3, 2, SectorType.Asteroid);
            grid.SetSectorType(3, 3, SectorType.Asteroid);
            grid.SetSectorType(3, 4, SectorType.Asteroid);
            grid.SetSectorType(3, 5, SectorType.Asteroid);

            // Başlangıç ve Hedef Noktaları
            int startX = 1, startY = 3;
            int targetX = 6, targetY = 3;

            grid.SetSectorType(targetX, targetY, SectorType.SpaceStation);

            Pathfinder pathfinder = new Pathfinder(grid);
            List<SectorNode> path = pathfinder.FindShortestPath(startX, startY, targetX, targetY);

            Console.WriteLine($"\nRota Aranıyor: ({startX}, {startY}) -> ({targetX}, {targetY})");

            if (path.Count > 0)
            {
                Console.WriteLine($"En kisa rota bulundu! Adim sayisi: {path.Count - 1}\n");
                HashSet<SectorNode> pathSet = new HashSet<SectorNode>(path);

                // Izgarayı Ekrana Çizme
                for (int y = height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < width; x++)
                    {
                        SectorNode node = grid.GetNode(x, y);

                        if (x == startX && y == startY)
                            Console.Write("S "); // Başlangıç
                        else if (x == targetX && y == targetY)
                            Console.Write("E "); // Hedef (End)
                        else if (pathSet.Contains(node))
                            Console.Write(". "); // Rota İzi
                        else if (node.Type == SectorType.Asteroid)
                            Console.Write("# "); // Engel (Asteroit)
                        else
                            Console.Write("- "); // Boş Alan
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Hedefe ulasan gecerli bir rota bulunamadi.");
            }
        }
    }
}
