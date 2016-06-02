using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

namespace Oils_well
{
    class Wall
    {
        private Vector2 position;
        private Texture2D texture;
        private Texture2D testTexture;
        private Rectangle hitbox;

        public Wall(Vector2 position, Texture2D texture, Texture2D testTexture)
        {
            this.position = position;
            this.texture = texture;
            this.testTexture = testTexture;
            this.hitbox = new Rectangle((int)this.position.X - texture.Width / 2, (int)this.position.Y - texture.Height / 2, texture.Width, texture.Height);
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
            if (testTexture != null)
            {
                spriteBatch.Draw(testTexture, hitbox, Color.Red);
            }
        }
    }
}
