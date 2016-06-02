using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

namespace Oils_well
{
    public class Tube
    {
        private Vector2 position;
        private float rotation;
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

        public Tube(Vector2 position, float rotation, Texture2D texture, Texture2D testTexture)
        {
            this.rotation = rotation;
            this.position = position;
            this.texture = texture;
            this.testTexture = testTexture;
            this.hitbox = new Rectangle(((int)position.X - texture.Width / 2)+1, ((int)position.Y - texture.Width / 2)+1, texture.Width-2, texture.Height-2);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
            if (testTexture != null)
            {
                spriteBatch.Draw(testTexture, hitbox, Color.White);
            }
        }
    }
}
