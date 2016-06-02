using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oils_well
{
    class EndGameScherm
    {
        private Game1 game;

        private int index;
        private string name = "NONAME";
        private int score = 0;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private MouseState currentMouseState;
        private MouseState previousMouseState;


        private Rectangle mainMenuButton;
        private Rectangle submitButton;

        private Texture2D mainMenuTexture;
        private Texture2D submitTexture;
        private Texture2D nameTexture;
        private Texture2D scoreText;
        private Texture2D yourScoreText;
        private Texture2D messageText;
        private Texture2D newHighscoreMessage;


        private Color mainMenuButtonColor;
        private Color submitButtonColor;
        
        public string message
        {
            get; set;
        }

        public EndGameScherm(Game1 game, Texture2D mainMenuTexture, Texture2D submitTexture)
        {
            this.game = game;
            this.mainMenuTexture = mainMenuTexture;
            this.submitTexture = submitTexture;

            mainMenuButton = new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - mainMenuTexture.Width / 2, 380, mainMenuTexture.Width, mainMenuTexture.Height);
            submitButton = new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - submitTexture.Width / 2, 300, submitTexture.Width, submitTexture.Height);
            mainMenuButtonColor = Color.White;
            submitButtonColor = Color.White;

            newHighscoreMessage = game.TextToTexture("New highscore! type a name and press enter to submit it", 12);
            yourScoreText = game.TextToTexture("Your score:", 20);
        }

        public void Initialize(int score, string message)
        {
            this.score = score;
            index = game.CheckHighScore(score);
            Console.WriteLine(score + " & " + index);
            this.message = message;
            messageText = game.TextToTexture(message, 24);
            nameTexture = game.TextToTexture(name, 20);
            scoreText = game.TextToTexture(score.ToString(), 20);
        }

        public void Update(GameTime gameTime)
        {
            previousKeyboardState = game.previousKeyboardState;
            currentKeyboardState = game.currentKeyboardState;
            previousMouseState = game.previousMouseState;
            currentMouseState = game.currentMouseState;
            if (index > -1)
            {
                foreach (Keys key in currentKeyboardState.GetPressedKeys())
                {
                    if (previousKeyboardState.IsKeyUp(key))
                    {
                        if (key == Keys.Back)
                        {
                            RemoveLetter();
                        }
                        else if (key.ToString().Length == 1)
                        {
                            AddLetter(key.ToString());
                        }
                    }
                }
            }

            if (previousMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mainMenuButton.Contains(currentMouseState.Position))
                {
                    game.SwitchCase(0);
                }
                if (submitButton.Contains(currentMouseState.Position))
                {
                    game.SaveHighScore(name, score);
                    game.SwitchCase(3);
                }
            }
        }

        public void AddLetter(string letter)
        {
            if (name.Length < 10)
            {
                name += letter;
                nameTexture = game.TextToTexture(name, 20);
            }
        }
        public void RemoveLetter()
        {
            if (name.Length > 0)
            {
                name = name.Remove(name.Length - 1);
                nameTexture = game.TextToTexture(name, 20);
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(messageText, new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - messageText.Width / 2, 55 - messageText.Height / 2, messageText.Width, messageText.Height), Color.White);
            if (index > -1)
            {
                spriteBatch.Draw(newHighscoreMessage, new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - newHighscoreMessage.Width / 2, 100 - newHighscoreMessage.Height / 2, newHighscoreMessage.Width, newHighscoreMessage.Height), Color.White);
                spriteBatch.Draw(nameTexture, new Rectangle(game.GraphicsDevice.Viewport.Width/2 - nameTexture.Width/2, 150, nameTexture.Width, nameTexture.Height), Color.White);
                spriteBatch.Draw(this.submitTexture, this.submitButton, null, submitButtonColor);
            }
            else
            {
                spriteBatch.Draw(yourScoreText, new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - yourScoreText.Width / 2, 150, yourScoreText.Width, yourScoreText.Height), Color.White);
            }
            spriteBatch.Draw(scoreText, new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - scoreText.Width / 2, 180, scoreText.Width, scoreText.Height), Color.White);

            spriteBatch.Draw(this.mainMenuTexture, this.mainMenuButton, null, mainMenuButtonColor);
        }
    }
}
