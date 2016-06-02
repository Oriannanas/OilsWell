using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Oils_well
{
    class HighscoreScherm
    {
        private List<Texture2D> nameTextures = new List<Texture2D>();
        private List<Texture2D> valueTextures = new List<Texture2D>();
        private Game1 game;
        private Rectangle mainMenuButton;
        private Rectangle quitButton;
        private Texture2D mainMenuTexture;
        private Texture2D quitTexture;
        private Texture2D messageText;
        private Color mainMenuButtonColor;
        private Color quitButtonColor;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        public string Message
        {
            get; set;
        }

        public Rectangle QuitButton
        {
            get
            {
                return quitButton;
            }
        }
        

        public Color QuitButtonColor
        {
            get
            {
                return quitButtonColor;
            }

            set
            {
                quitButtonColor = value;
            }
        }

        public Rectangle MainMenuButton
        {
            get
            {
                return mainMenuButton;
            }
        }

        public Color MainMenuButtonColor
        {
            get
            {
                return mainMenuButtonColor;
            }

            set
            {
                mainMenuButtonColor = value;
            }
        }
        

        public HighscoreScherm(Game1 game, Texture2D mainMenuTexture, Texture2D quitTexture)
        {
            this.mainMenuTexture = mainMenuTexture;
            this.quitTexture = quitTexture;
            mainMenuButton = new Rectangle(247 - mainMenuTexture.Width / 2, 380, mainMenuTexture.Width, mainMenuTexture.Height);
            quitButton = new Rectangle(501 - quitTexture.Width / 2, 380, quitTexture.Width, quitTexture.Height);
            mainMenuButtonColor = Color.White;
            quitButtonColor = Color.White;
            this.game = game;
        }
        
        public void Initialize()
        {
            HighScore data = HighScore.LoadHighScores(game.HighScoresFilename);
            nameTextures.Clear();
            valueTextures.Clear();
            this.messageText = game.TextToTexture("HighScore", 48);
            for (int i = 0; i < data.Count; i++)
            {
                this.nameTextures.Add(game.TextToTexture(data.PlayerName[i], 20));
                this.valueTextures.Add(game.TextToTexture(data.Score[i].ToString(), 20));
            }
        }

        public void Update(GameTime gameTime)
        {
            previousKeyboardState = game.previousKeyboardState;
            currentKeyboardState = game.currentKeyboardState;
            previousMouseState = game.previousMouseState;
            currentMouseState = game.currentMouseState;
            

            if (previousMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (MainMenuButton.Contains(currentMouseState.Position))
                {
                    game.SwitchCase(0);
                }
                if (QuitButton.Contains(currentMouseState.Position))
                {
                    game.Exit();
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(messageText, new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - messageText.Width / 2, 55 - messageText.Height / 2, messageText.Width, messageText.Height), Color.White);

            for (int i = 0; i < 10; i++)
            {
                spriteBatch.Draw(nameTextures[i], new Rectangle(230, 115 + 25 * i, nameTextures[i].Width, nameTextures[i].Height), Color.White);
                spriteBatch.Draw(valueTextures[i], new Rectangle(515, 115 + 25 * i, valueTextures[i].Width, valueTextures[i].Height), null, Color.White, 0, new Vector2(valueTextures[i].Width, 0), SpriteEffects.None, 0);
            }
            spriteBatch.Draw(this.mainMenuTexture, this.mainMenuButton, null, mainMenuButtonColor);
            spriteBatch.Draw(this.quitTexture, this.quitButton, null, quitButtonColor);
        }
    }
}
