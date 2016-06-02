using System;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;


namespace Oils_well
{
    class Player
    {
        private Texture2D texture;
        private Texture2D testTexture;
        private Rectangle hitbox;
        private Vector2 position;
        private bool active;
        private float moveSpeed;
        private InGameScherm game;
        private Rectangle sourceRectangle;
        private int timer;
        public int lastDirection {
            get;  set; }
        private double rotation;
        private bool isMoving;

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Player(InGameScherm game, Texture2D texture, Vector2 position, Texture2D testTexture)
        {
            lastDirection = 4;
            this.game = game;
            this.texture = texture;
            this.testTexture = testTexture;
            this.position = position;
            this.hitbox = new Rectangle((int)position.X - (int)GridSystem.spaceDimensions / 2, (int)position.Y - (int)GridSystem.spaceDimensions / 2, (int)GridSystem.spaceDimensions, (int)GridSystem.spaceDimensions);
            this.sourceRectangle = new Rectangle(24,0,(int)GridSystem.spaceDimensions, (int)GridSystem.spaceDimensions);
            this.active = true;

            this.moveSpeed =    12.0f;
        }
        public void Update()
        {
            if (timer <= 0)
            {
                if (isMoving)
                {
                    timer = 10;
                    if (sourceRectangle.X == 0)
                    {
                        sourceRectangle.X = 24;
                    }
                    else
                    {
                        sourceRectangle.X = 0;
                    }
                }

                else
                {
                    sourceRectangle.X = 24;
                }
            }
            else
            {
                timer -= 1;
            }
            isMoving = false;
        }
        public void MoveRight()
        {
            if (this.active)
            {
                if (lastDirection == 1)
                {
                    game.AddTube(this.position, (float)Math.PI * 1.5f);
                }
                if (lastDirection == 3)
                {
                    game.AddCornerTube(this.position, 0);
                }
                if (lastDirection == 4)
                {
                    game.AddCornerTube(this.position, (float)Math.PI * 1.5f);
                }
                this.position.X += moveSpeed;
                hitbox.Location = new Point((int)position.X - (int)GridSystem.spaceDimensions / 2, (int)position.Y - (int)GridSystem.spaceDimensions / 2);
                this.rotation = Math.PI * 3 / 2;
                isMoving = true;
                lastDirection = 1;
            }
        }

        public void MoveLeft()
        {
            if (this.active)
            {
                if (lastDirection == 2)
                {
                    game.AddTube(this.position, (float)Math.PI * 0.5f);
                }
                if (lastDirection == 3)
                {
                    game.AddCornerTube(this.position, (float)Math.PI * 0.5f);
                }
                if (lastDirection == 4)
                {
                    game.AddCornerTube(this.position, (float)Math.PI);
                }
                this.position.X -= moveSpeed;
                hitbox.Location = new Point((int)position.X - (int)GridSystem.spaceDimensions / 2, (int)position.Y - (int)GridSystem.spaceDimensions / 2);
                this.rotation = Math.PI/2;
                isMoving = true;
                lastDirection = 2;
            }
        }

        public void MoveUp()
        {
            if (this.active)
            {
                if (lastDirection == 1)
                {
                    game.AddCornerTube(this.position, (float)Math.PI);
                }
                if (lastDirection == 2)
                {
                    game.AddCornerTube(this.position, (float)Math.PI * 1.5f);
                }
                if (lastDirection == 3)
                {
                    game.AddTube(this.position, (float)Math.PI);
                }
                this.position.Y -= moveSpeed;
                hitbox.Location = new Point((int)position.X - (int)GridSystem.spaceDimensions / 2, (int)position.Y - (int)GridSystem.spaceDimensions / 2);
                this.rotation = Math.PI;
                isMoving = true;
                lastDirection = 3;
            }
        }

        public void MoveDown()
        {
            if (this.active)
            {
                if (lastDirection == 1)
                {
                    game.AddCornerTube(this.position, (float)Math.PI * 0.5f);
                }
                if (lastDirection == 2)
                {
                    game.AddCornerTube(this.position, 0);
                }
                if (lastDirection == 4)
                {
                    game.AddTube(this.position, 0);
                }
                this.position.Y += moveSpeed;
                hitbox.Location = new Point((int)position.X - (int)GridSystem.spaceDimensions / 2, (int)position.Y - (int)GridSystem.spaceDimensions / 2);
                this.rotation = 0;
                isMoving = true;
                lastDirection = 4;
            }
        }
        
        public void SetPosition(Vector2 position)
        {
            this.position = position;
            hitbox.Location = new Point((int)position.X - (int)GridSystem.spaceDimensions / 2, (int)position.Y - (int)GridSystem.spaceDimensions / 2);
        }
        public void ScoreCollision()
        {
            foreach (Candy candy in game.candyList)
            {
                    if (candy.Hitbox.Intersects(this.hitbox))
                    {
                        if(candy.Score > 0)
                        {
                            game.score += candy.Score;
                        }
                        else
                        {
                            game.PauseEnemies();
                        }
                        game.candyList.Remove(candy);
                        break;
                    }

                
            }
            foreach (Tube tube in game.tubeList)
            {

                foreach (Candy candy in game.candyList)
                {
                    if (candy.Hitbox.Intersects(tube.Hitbox))
                    {
                        if (candy.Score > 0)
                        {
                            game.score += candy.Score;
                        }
                        else
                        {
                            game.PauseEnemies();
                        }
                        game.candyList.Remove(candy);
                        break;
                    }
                }
            }
        }
        public void EnemyCollision()
        {
            foreach (Enemy enemy in game.enemyList)
            {
                    if (enemy.Hitbox.Intersects((this.hitbox)))
                {
                    game.enemyList.Remove(enemy);
                    break;
                }
            }
        }
        public bool WallCollision(Vector2 direction)
        {
            foreach (Wall wall in game.wallList)
            {
                    if (direction == new Vector2(0,-1))
                    {
                        if (wall.Hitbox.Contains(new Point(hitbox.Left+2,hitbox.Top-2)) ||
                            wall.Hitbox.Contains(new Point(hitbox.Right - 2, hitbox.Top - 1)))
                        {
                            return true;
                        }
                    }
                    if (direction == new Vector2(0, 1))
                    {
                        if (wall.Hitbox.Contains(new Point(hitbox.Left + 2, hitbox.Bottom + 2)) ||
                            wall.Hitbox.Contains(new Point(hitbox.Right - 2, hitbox.Bottom + 2)))
                        {
                            return true;
                        }
                    }
                    if (direction == new Vector2(-1, 0))
                    {
                        if (wall.Hitbox.Contains(new Point(hitbox.Left - 2, hitbox.Top + 2))||
                            wall.Hitbox.Contains(new Point(hitbox.Left - 2, hitbox.Bottom - 2)))
                        {
                            return true;
                        }
                    }
                    if (direction == new Vector2(1, 0))
                    {
                        if (wall.Hitbox.Contains(new Point(hitbox.Right + 2, hitbox.Top + 2))||
                            wall.Hitbox.Contains(new Point(hitbox.Right + 2, hitbox.Bottom - 2)))
                        {
                            return true;
                        }
                    }
            }
            foreach (Tube tube in game.tubeList)
            {
                    if (direction == new Vector2(0,-1))
                    {
                        if (tube.Hitbox.Contains(new Point(hitbox.Left+2,hitbox.Top-2)) ||
                            tube.Hitbox.Contains(new Point(hitbox.Right - 2, hitbox.Top - 2)))
                        {
                            return true;
                        }
                    }
                    if (direction == new Vector2(0, 1))
                    {
                        if (tube.Hitbox.Contains(new Point(hitbox.Left + 2, hitbox.Bottom + 2)) ||
                            tube.Hitbox.Contains(new Point(hitbox.Right - 2, hitbox.Bottom + 2)))
                        {
                            return true;
                        }
                    }
                    if (direction == new Vector2(-1, 0))
                    {
                        if (tube.Hitbox.Contains(new Point(hitbox.Left - 2, hitbox.Top + 2))||
                            tube.Hitbox.Contains(new Point(hitbox.Left - 2, hitbox.Bottom - 2)))
                        {
                            return true;
                        }
                    }
                    if (direction == new Vector2(1, 0))
                    {
                        if (tube.Hitbox.Contains(new Point(hitbox.Right + 2, hitbox.Top + 2))||
                            tube.Hitbox.Contains(new Point(hitbox.Right + 2, hitbox.Bottom - 2)))
                        {
                            return true;
                        }
                    }
            }
            return false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, sourceRectangle, Color.White, (float)this.rotation, new Vector2((int)GridSystem.spaceDimensions / 2, (int)GridSystem.spaceDimensions / 2), 1f, SpriteEffects.None, 0f);
            if (testTexture != null)
            {
                spriteBatch.Draw(testTexture, hitbox, Color.Yellow);
            }
        }
    }
}
