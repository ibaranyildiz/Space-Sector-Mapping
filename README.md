# Space Sector Mapping & Pathfinding Engine

A modular, high-performance 2D grid simulation and pathfinding engine developed in C#. The project models celestial sectors, dynamically places spatial obstacles (asteroids), and calculates optimal navigation trajectories using graph-traversal algorithms.

## Features
- **Grid-Based Spatial Representation:** Coordinate-based matrix modeling with customizable grid bounds and sector metadata.
- **Dynamic Obstacle Handling:** Distinct sector classifications (\`Empty\`, \`Asteroid\`, \`SpaceStation\`, \`Resource\`) with traversal validation.
- **Shortest Path Computation:** Implementation of Breadth-First Search (BFS) to guarantee the shortest unweighted path across active sectors.
- **Memory-Efficient Graph Traversal:** Node validation with hash-set lookups to minimize time complexity and prevent redundant traversals.
- **CLI Visualizer:** Real-time ASCII map rendering illustrating sector states, obstacles, and the calculated optimal trajectory.

## Architecture & Data Structures
- **Logical Grid:** Represented via a contiguous 2D array (\`SectorNode[,]\`), offering O(1) random-access performance per coordinate.
- **Pathfinding Queue & Lookup:**
  - \`Queue<SectorNode>\`: Manages the frontier for breadth-first exploration.
  - \`HashSet<SectorNode>\`: Maintains visited node states in O(1) lookup time.
  - \`Dictionary<SectorNode, SectorNode>\`: Tracks reverse node links (\`cameFrom\`) for backtracking the computed trajectory.

## Algorithmic Complexity
- **Time Complexity:** O(V + E), where V is the total number of sectors (W x H) and E is the set of orthogonal adjacent connections (edges).
- **Space Complexity:** O(V), required to store node traversal states, distance maps, and queue items.

## How to Run

Ensure [.NET 8.0 SDK](https://dotnet.microsoft.com/) is installed on your environment.

\`\`\`bash
# Clone the repository
git clone https://github.com/ibaranyildiz/-Space-Sector-Mapping.git

# Navigate to project directory
cd ./-Space-Sector-Mapping

# Build and run
dotnet run
\`\`\`

## Sample Output
\`\`\`text
=== Space Sector Mapping & Pathfinding Engine ===

Rota Araniyor: (1, 3) -> (6, 3)
En kisa rota bulundu! Adim sayisi: 9

- - - - - - - - - - 
- - - - - - - - - - 
- - - - - - - - - - 
- - - - - - - - - - 
- . . . - - - - - - 
- S - . # - E - - - 
- - - . # . . - - - 
- - - . # . - - - - 
- - - . . . - - - - 
- - - - - - - - - - 
\`\`\`
