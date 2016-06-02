using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Oils_well
{
    class GridSystem
    {
        private List<Level> levelList = new List<Level>();
        public static float spaceDimensions;
        public int gridWidth;
        public int gridHeight;
        private Vector2 startPosition;
        private InGameScherm game;

        public Vector2 StartPosition
        {
            get
            {
                return startPosition;
            }
        }

        public void Initialize(InGameScherm game, List<Level> levelList)
        {
            this.game = game;
            this.levelList = levelList;

            spaceDimensions = 24.0f;

            gridWidth = 31;
            gridHeight = 19;
            

        }
        public void LoadLevel(int levelIndex)
        {
            Level loadedLevel = levelList[levelIndex-1];
            List<string> level = loadedLevel.Grid;
            int levelHeight = loadedLevel.LevelHeight;
            int levelWidth = loadedLevel.LevelWidth;

            for (int x = 0; x < levelWidth; x++)
            {
                for (int y = 0; y < levelHeight; y++)
                {
                    Vector2 gridVector = new Vector2(x * spaceDimensions + spaceDimensions / 2, y * spaceDimensions + spaceDimensions / 2);
                    if (level[y].ToCharArray()[x] == "s".ToCharArray()[0])// Start point
                    {
                        this.startPosition = gridVector;
                    }
                    if (level[y].ToCharArray()[x] == "1".ToCharArray()[0]) // wall object
                    { 
                        game.AddWall(gridVector);
                    }
                    if (level[y].ToCharArray()[x] == "2".ToCharArray()[0]) // Score object
                    {
                        game.AddCandy(100, gridVector);
                    }
                    if (level[y].ToCharArray()[x] == "3".ToCharArray()[0]) // TimeOut object
                    {
                        game.AddCandy(0, gridVector);
                    }

                }
            }
        }
        
    }
}
