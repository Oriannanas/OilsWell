using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oils_well
{
    class InGameScherm
    {
        private Game1 game;
        private int currentLevel;
        public int score;
        public int lives;

        private Player player;

        private List<Level> levelList = new List<Level>();
        public List<Candy> candyList { get; private set; } = new List<Candy>();
        public List<Wall> wallList { get; private set; } = new List<Wall>();
        public List<Tube> tubeList { get; private set; } = new List<Tube>();
        public List<Enemy> enemyList { get; private set; } = new List<Enemy>();
        private List<Vector2> enemySpawnList = new List<Vector2>();

        private int viewportWidth;
        private int viewportHeight;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        private Texture2D livesText;

        private GridSystem grid;

        private int timer;
        private int moveTimer;
        private int enemyTimeOut;
        private Random random = new Random();


        public InGameScherm(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            viewportWidth = game.GraphicsDevice.Viewport.Width;
            viewportHeight = game.GraphicsDevice.Viewport.Height;
            this.lives = 3;
            this.score = 0;

            grid = new GridSystem();
            enemySpawnList.Add(new Vector2(0, 132));
            enemySpawnList.Add(new Vector2(0, 180));
            enemySpawnList.Add(new Vector2(0, 228));
            enemySpawnList.Add(new Vector2(0, 276));
            enemySpawnList.Add(new Vector2(0, 324));
            enemySpawnList.Add(new Vector2(0, 372));
            enemySpawnList.Add(new Vector2(0, 420));
            enemySpawnList.Add(new Vector2(viewportWidth - 24, 132));
            enemySpawnList.Add(new Vector2(viewportWidth - 24, 180));
            enemySpawnList.Add(new Vector2(viewportWidth - 24, 228));
            enemySpawnList.Add(new Vector2(viewportWidth - 24, 276));
            enemySpawnList.Add(new Vector2(viewportWidth - 24, 324));
            enemySpawnList.Add(new Vector2(viewportWidth - 24, 372));
            enemySpawnList.Add(new Vector2(viewportWidth - 24, 420));

            this.levelList.Add(new Level(new List<string>() {   "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "111111111111111s111111111111111",
                                                                "222222222222222x222222222222222",
                                                                "11111x11111111111111111111x1111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11x111111111111x1111111x1111111",
                                                                "2x2x2x2x2x2x2x2x2x2x2x2x2x2x2x2",
                                                                "111111x111111111111111x11111111",
                                                                "2222222222222222222222222222222",
                                                                "11111111x1111111111111111111x11",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11111x1111111111x111111111x1111",
                                                                "2x2x2x2x2x2x2x232x2x2x2x2x2x2x2",
                                                                "111111x11111111111111x111111111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "1111111111111111111111111111111" }));

            this.levelList.Add(new Level(new List<string>() {   "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "111111111111111s111111111111111",
                                                                "222222222222222x222222222222222",
                                                                "11111x11111111111111111111x1111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11x111111111111x1111111x1111111",
                                                                "2x2x2x2x2x2x2xxx2x2x2x2x2x2x2x2",
                                                                "111111x111111111111111x11111111",
                                                                "2222222222222222222222222222222",
                                                                "11111111x1111111111111111111x11",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11111x1111111111x111111111x1111",
                                                                "2x2x2x3x2x2x2xxx2x2x2x2x3x2x2x2",
                                                                "111111x11111111111111x111111111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "1111111111111111111111111111111" }));

            this.levelList.Add(new Level(new List<string>() {   "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "111111111111111s111111111111111",
                                                                "222222222222222x222222222222222",
                                                                "11111x11111111111111111111x1111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11x111111111111x1111111x1111111",
                                                                "2x2x2x2x2x2x2xxx2x2x2x2x2x2x2x2",
                                                                "111111x111111111111111x11111111",
                                                                "2222222222222223222222222222222",
                                                                "11111111x1111111111111111111x11",
                                                                "22x22x22x22x22xxx22x22x22x22x22",
                                                                "11111x1111111111x111111111x1111",
                                                                "2x2x232x2x2x2xxx2x2x2x2x232x2x2",
                                                                "111111x11111111111111x111111111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "1111111111111111111111111111111" }));

            this.levelList.Add(new Level(new List<string>() {   "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "111111111111111s111111111111111",
                                                                "222222222222222x222222222222222",
                                                                "11111x11111111111111111111x1111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11x111111111111x1111111x1111111",
                                                                "2x2x2x2x2x2x2xxx2x2x2x2x2x2x2x2",
                                                                "111111x111111111111111x11111111",
                                                                "2222222222222222222222222222222",
                                                                "11111111x1111111111111111111x11",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11111x1111111111x111111111x1111",
                                                                "2x2x2x2x2x2x2xxx2x2x2x2x2x2x2x2",
                                                                "111111x11111111111111x111111111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "1111111111111111111111111111111" }));

            this.levelList.Add(new Level(new List<string>() {   "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                                                                "111111111111111s111111111111111",
                                                                "222222222222222x222222222222222",
                                                                "11111x11111111111111111111x1111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11x111111111111x1111111x1111111",
                                                                "2x2x2x2x2x2x2xxx2x2x2x2x2x2x2x2",
                                                                "111111x111111111111111x11111111",
                                                                "2222222222222222222222222222222",
                                                                "11111111x1111111111111111111x11",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "11111x1111111111x111111111x1111",
                                                                "2x2x2x2x2x2x2xxx2x2x2x2x2x2x2x2",
                                                                "111111x11111111111111x111111111",
                                                                "22x22x22x22x22x2x22x22x22x22x22",
                                                                "1111111111111111111111111111111" }));

            currentLevel = 1;
            LoadLevel(currentLevel);
        }

        public void LoadLevel(int levelIndex)
        {
            if (levelList.Count > levelIndex - 1)
            {
                grid.Initialize(this, this.levelList);
                grid.LoadLevel(levelIndex);
                enemyTimeOut = 0;

                player = new Player(this, game.textureLists[0][0], grid.StartPosition, game.testText);
            }
            else
            {
                game.SwitchToEndGame(score, "You won, congratiulations!");
                UnloadLevel();
            }
        }

        public void UnloadLevel()
        {
            enemyList.Clear();
            wallList.Clear();
            candyList.Clear();
            tubeList.Clear();
            player = null;
        }
        public void Update(GameTime gameTime)
        {
            previousKeyboardState = game.previousKeyboardState;
            currentKeyboardState = game.currentKeyboardState;
            previousMouseState = game.previousMouseState;
            currentMouseState = game.currentMouseState;

            UpdatePlayer(gameTime);
            if (candyList.Count <= 0)
            {
                UnloadLevel();
                LoadLevel(currentLevel + 1);
                currentLevel += 1;
            }
            if (enemyTimeOut <= 0)
            {

                if (timer <= 0)
                {
                    foreach (Vector2 enemySpawn in enemySpawnList)
                    {
                        if (random.Next(100 - 20 * (currentLevel - 1)) < 2)
                        {
                            int direction;
                            if (enemySpawn.X < viewportWidth / 2)
                            {
                                direction = 1;
                            }
                            else
                            {
                                direction = -1;
                            }
                            int enemyRandomize = random.Next(3);
                            if (enemyRandomize == 0)
                            {
                                enemyList.Add(new Enemy(game.textureLists[4][0], direction, enemySpawn, game.testText, currentLevel));
                            }
                            else if (enemyRandomize == 1)
                            {
                                enemyList.Add(new Enemy(game.textureLists[4][1], direction, enemySpawn, game.testText, currentLevel));
                            }
                            else
                            {
                                enemyList.Add(new Enemy(game.textureLists[4][2], direction, enemySpawn, game.testText, currentLevel));
                            }
                        }
                    }
                    timer = 60;
                }
                else
                {
                    timer -= 1;
                }


                for (int i = 0; i < enemyList.Count; i++)
                {
                    if (enemyList[i].Position.X >= 0 && enemyList[i].Position.X <= (viewportWidth - GridSystem.spaceDimensions))
                    {
                        enemyList[i].Move();
                        foreach (Tube tube in tubeList)
                        {
                            if (tube.Hitbox.Intersects(enemyList[i].Hitbox))
                            {
                                IDied();
                                break;
                            }
                        }
                    }
                    else
                    {
                        enemyList.RemoveAt(i);
                    }
                }
            }
            else
            {
                enemyTimeOut -= 1;
            }

        }
        private void UpdatePlayer(GameTime gameTime)
        {
            player.Update();
            if (moveTimer <= 0)
            {
                moveTimer = 2;
                if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
                {
                    if (!player.WallCollision(new Vector2(0, -1)) && player.Position.Y > 4 * GridSystem.spaceDimensions + GridSystem.spaceDimensions / 2)
                    {
                        player.MoveUp();
                        player.ScoreCollision();
                    }
                }
                if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
                {
                    if (!player.WallCollision(new Vector2(0, 1)) && player.Position.Y < (viewportHeight - GridSystem.spaceDimensions / 2))
                    {
                        player.MoveDown();
                        player.ScoreCollision();
                    }
                }

                if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
                {
                    if (!player.WallCollision(new Vector2(-1, 0)) && player.Position.X > 0 + GridSystem.spaceDimensions / 2)
                    {
                        player.MoveLeft();
                        player.ScoreCollision();
                    }
                }
                if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
                {
                    if (!player.WallCollision(new Vector2(1, 0)) && player.Position.X < (viewportWidth - GridSystem.spaceDimensions / 2))
                    {
                        player.MoveRight();
                        player.ScoreCollision();
                    }
                }
                if (currentKeyboardState.IsKeyDown(Keys.Space))
                {
                    if (tubeList.Count > 2)
                    {
                        player.SetPosition(tubeList[tubeList.Count - 1].Position);
                        tubeList.RemoveAt(tubeList.Count - 1);

                        if (tubeList[tubeList.Count - 1].Position.Y > player.Position.Y)
                        {
                            player.lastDirection = 3;
                        }
                        if (tubeList[tubeList.Count - 1].Position.Y < player.Position.Y)
                        {
                            player.lastDirection = 4;
                        }

                        if (tubeList[tubeList.Count - 1].Position.X > player.Position.X)
                        {
                            player.lastDirection = 2;
                        }

                        if (tubeList[tubeList.Count - 1].Position.X < player.Position.X)
                        {
                            player.lastDirection = 1;
                        }
                        if (tubeList.Count > 2)
                        {
                            player.SetPosition(tubeList[tubeList.Count - 1].Position);
                            tubeList.RemoveAt(tubeList.Count - 1);

                            if (tubeList[tubeList.Count - 1].Position.Y > player.Position.Y)
                            {
                                player.lastDirection = 3;
                            }
                            if (tubeList[tubeList.Count - 1].Position.Y < player.Position.Y)
                            {
                                player.lastDirection = 4;
                            }

                            if (tubeList[tubeList.Count - 1].Position.X > player.Position.X)
                            {
                                player.lastDirection = 2;
                            }

                            if (tubeList[tubeList.Count - 1].Position.X < player.Position.X)
                            {
                                player.lastDirection = 1;
                            }

                        }
                        else
                        {
                            player.lastDirection = 4;
                        }
                    }
                    else
                    {
                        player.lastDirection = 4;
                    }
                }
            }
            else
            {
                moveTimer -= 1;
            }

            player.ScoreCollision();
            player.EnemyCollision();
        }
        public void IDied()
        {
            if (lives > 1)
            {
                lives -= 1;
                if (tubeList.Count > 0)
                {
                    for (int i = tubeList.Count - 1; i >= 1; i--)
                    {
                        player.SetPosition(tubeList[i].Position);
                        tubeList.RemoveAt(i);
                    }
                    player.lastDirection = 4;
                }
                enemyList.Clear();
            }
            else
            {
                game.SwitchToEndGame(score, "Uh - oh, you died: (");
                UnloadLevel();
            }
        }

        public void AddEnemySpawn(Vector2 position)
        {
            enemySpawnList.Add(position);
        }
        public void AddCandy(int score, Vector2 position)
        {
            if (score > 0)
            {
                candyList.Add(new Candy(score, position, game.textureLists[3][0], game.testText));
            }
            else
            {
                candyList.Add(new Candy(score, position, game.textureLists[3][1], game.testText));
            }
        }
        public void AddWall(Vector2 position)
        {
            wallList.Add(new Wall(position, game.textureLists[2][0], game.testText));
        }

        public void AddTube(Vector2 position, float rotation)
        {
            tubeList.Add(new Tube(position, rotation, game.textureLists[1][0], game.testText));
        }

        public void AddCornerTube(Vector2 position, float rotation)
        {
            tubeList.Add(new Tube(position, rotation, game.textureLists[1][1], game.testText));
        }

        public void PauseEnemies()
        {
            enemyTimeOut = 500;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (Tube tube in tubeList)
            {
                tube.Draw(spriteBatch);
            }
            foreach (Candy candy in candyList)
            {
                candy.Draw(spriteBatch);
            }
            foreach (Wall wall in wallList)
            {
                wall.Draw(spriteBatch);
            }
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
            if (game.textureLists[5].Count >= currentLevel)
            {
                spriteBatch.Draw(game.textureLists[5][this.currentLevel - 1], new Microsoft.Xna.Framework.Rectangle(viewportWidth / 2 - game.textureLists[5][this.currentLevel - 1].Width / 2, 0, game.textureLists[5][this.currentLevel - 1].Width, game.textureLists[5][this.currentLevel - 1].Height), Microsoft.Xna.Framework.Color.White);
            }
            spriteBatch.Draw(game.TextToTexture(score.ToString(), 20), new Vector2(20, 20), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            livesText = game.TextToTexture(lives.ToString(), 20);
            spriteBatch.Draw(livesText, new Vector2(viewportWidth - 20 - livesText.Width, 20), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
