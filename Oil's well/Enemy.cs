using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

namespace Oils_well
{
    public class Enemy
    {
        private float moveSpeed;
        private int direction;

        private Vector2 position;
        private Texture2D texture;
        private Texture2D testTexture;
        private Rectangle hitbox;

        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Enemy(Texture2D texture, int direction, Vector2 position, Texture2D testTexture, int difficulty)
        {
            this.moveSpeed = 0.6f+ 0.3f*(difficulty-1);
            this.texture = texture;
            this.testTexture = testTexture;
            this.direction = direction;
            this.position = position;
            this.hitbox = new Rectangle((int)position.X - texture.Width / 2, (int)position.Y - texture.Width / 2, texture.Width, texture.Width);
        }

        public void Move()
        {
            this.position.X += moveSpeed * direction;
            hitbox.X = (int)position.X- texture.Width/2;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Width / 2), 1f, SpriteEffects.None, 0f); if (testTexture != null)
            {
                spriteBatch.Draw(testTexture, hitbox, Color.Blue);
            }
        }
    }
}
