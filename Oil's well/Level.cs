using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oils_well
{
    class Level
    {
        private int levelHeight;
        private int levelWidth;
        private List<string> grid = new List<string>();

        public int LevelHeight
        {
            get
            {
                return levelHeight;
            }
        }
        public int LevelWidth
        {
            get
            {
                return levelWidth;
            }
        }

        public List<string> Grid
        {
            get
            {
                return grid;
            }
        }

        public Level(List<string> grid)
        {
            this.grid = grid;
            this.levelWidth = grid[0].ToCharArray().Length;
            this.levelHeight = grid.Count;
        }
    }
}
