using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Oils_well
{
    class MainMenuScherm
    {
        private Game1 game;
        
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        private Rectangle startButton;
        private Rectangle highscoreButton;
        private Rectangle quitButton;
        private Texture2D startTexture;
        private Texture2D highscoreTexture;
        private Texture2D quitTexture;
        private Texture2D logoText;
        private Color startButtonColor;
        private Color highscoreButtonColor;
        private Color quitButtonColor;

        public Rectangle StartButton
        {
            get
            {
                return startButton;
            }
        }
        public Rectangle HighscoreButton
        {
            get
            {
                return highscoreButton;
            }
        }

        public Rectangle QuitButton
        {
            get
            {
                return quitButton;
            }
        }
        

        public Color StartButtonColor
        {
            get
            {
                return startButtonColor;
            }

            set
            {
                startButtonColor = value;
            }
        }

        public Color HighscoreButtonColor
        {
            get
            {
                return highscoreButtonColor;
            }

            set
            {
                highscoreButtonColor = value;
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


        public MainMenuScherm(Game1 game, Texture2D logoText, Texture2D startTexture,  Texture2D highscoreTexture, Texture2D quitTexture)
        {
            this.game = game;
            this.startTexture = startTexture;
            this.highscoreTexture = highscoreTexture;
            this.logoText = logoText;
            this.quitTexture = quitTexture;
            startButton = new Rectangle(372 - startTexture.Width/2, 200, startTexture.Width, startTexture.Height);
            highscoreButton = new Rectangle(372 - highscoreTexture.Width/2, 275, highscoreTexture.Width, highscoreTexture.Height);
            quitButton = new Rectangle(372 - quitTexture.Width/2, 350, quitTexture.Width, quitTexture.Height);
            startButtonColor = Color.White;
            highscoreButtonColor = Color.White;
            quitButtonColor = Color.White;
        }

        public void Update(GameTime gameTime)
        {

            previousKeyboardState = game.previousKeyboardState;
            currentKeyboardState = game.currentKeyboardState;
            previousMouseState = game.previousMouseState;
            currentMouseState = game.currentMouseState;
            if (previousMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (StartButton.Contains(currentMouseState.Position))
                {
                    game.SwitchCase(1);
                }
                if (HighscoreButton.Contains(currentMouseState.Position))
                {
                    game.SwitchCase(3);
                }
                if (QuitButton.Contains(currentMouseState.Position))
                {
                    game.Exit();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logoText, new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 230, 25, logoText.Width, logoText.Height), Color.White);
            spriteBatch.Draw(this.startTexture, this.startButton, null, startButtonColor);
            spriteBatch.Draw(this.highscoreTexture, this.highscoreButton, null, highscoreButtonColor);
            spriteBatch.Draw(this.quitTexture, this.quitButton, null, quitButtonColor);
        }
    }
}
