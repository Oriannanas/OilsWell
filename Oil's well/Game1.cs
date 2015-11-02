using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Oils_well
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private MainMenuScherm mainMenuScherm;
        private HighscoreScherm highScoreScherm;
        private InGameScherm inGameScherm;
        private EndGameScherm endGameScherm;
        public readonly string HighScoresFilename = "highscores.lst";

        public Texture2D testText { get; private set; }

        private int currentState;
        
        public List<Texture2D> playerTexts { get; private set; } = new List<Texture2D>();
        public List<Texture2D> tubeTexts { get; private set; } = new List<Texture2D>();
        public List<Texture2D> wallTexts { get; private set; } = new List<Texture2D>();
        public List<Texture2D> candyTexts { get; private set; } = new List<Texture2D>();
        public List<Texture2D> enemyTexts { get; private set; } = new List<Texture2D>();
        public List<Texture2D> levelTexts { get; private set; } = new List<Texture2D>();
        public List<Texture2D> uiTexts { get; private set; } = new List<Texture2D>();

        public List<List<Texture2D>> textureLists { get; private set; } = new List<List<Texture2D>>();


        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public KeyboardState currentKeyboardState
        {
            get; private set;
        }
        public KeyboardState previousKeyboardState
        {
            get; private set;
        }
        public MouseState currentMouseState
        {
            get; private set;
        }
        public MouseState previousMouseState
        {
            get; private set;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currentState = 0;
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 744;
            graphics.PreferredBackBufferHeight = 456;
            graphics.ApplyChanges();

            if (!File.Exists(HighScoresFilename))
            {
                //If the file doesn't exist, make a fake one...
                // Create the data to save
                HighScore data = new HighScore(10);
                data.PlayerName[0] = "MARIJN";
                data.Score[0] = 15000;

                data.PlayerName[1] = "SHAWN";
                data.Score[1] = 12000;

                data.PlayerName[2] = "CARL";
                data.Score[2] = 10000;

                data.PlayerName[3] = "CARL";
                data.Score[3] = 9000;

                data.PlayerName[4] = "LISA";
                data.Score[4] = 8000;

                data.PlayerName[5] = "NEIL";
                data.Score[5] = 7000;

                data.PlayerName[6] = "SHAWN";
                data.Score[6] = 6000;

                data.PlayerName[7] = "PETER";
                data.Score[7] = 5000;

                data.PlayerName[8] = "LISA";
                data.Score[8] = 4000;

                data.PlayerName[9] = "SAM";
                data.Score[9] = 3000;

                HighScore.SaveHighScores(data, HighScoresFilename);
            }


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //player content
            inGameScherm = new InGameScherm(this);
            endGameScherm = new EndGameScherm(this, Content.Load<Texture2D>("mainmenubutton"), Content.Load<Texture2D>("submitButton"));
            mainMenuScherm = new MainMenuScherm(this, Content.Load<Texture2D>("Logo"), Content.Load<Texture2D>("startbutton"), Content.Load<Texture2D>("highscorebutton"), Content.Load<Texture2D>("quitbutton"));
            highScoreScherm = new HighscoreScherm(this, Content.Load<Texture2D>("mainmenubutton"), Content.Load<Texture2D>("quitbutton"));

            textureLists.Add(playerTexts);
            textureLists.Add(tubeTexts);
            textureLists.Add(wallTexts);
            textureLists.Add(candyTexts);
            textureLists.Add(enemyTexts);
            textureLists.Add(levelTexts);
            textureLists.Add(uiTexts);

            //verdander de testText naar een texture om de hitboxes te zien
            testText = null;

            textureLists[0].Add(Content.Load<Texture2D>("player")); // player
            textureLists[1].Add(Content.Load<Texture2D>("tube")); // tube
            textureLists[1].Add(Content.Load<Texture2D>("cornerTube")); // hoek van de pijp
            textureLists[2].Add(Content.Load<Texture2D>("wall")); // wall
            textureLists[3].Add(Content.Load<Texture2D>("candy1")); // score
            textureLists[3].Add(Content.Load<Texture2D>("enemy_time")); // tijd stop object texture
            textureLists[4].Add(Content.Load<Texture2D>("enemy1")); // enemy
            textureLists[4].Add(Content.Load<Texture2D>("enemy2")); // enemy
            textureLists[4].Add(Content.Load<Texture2D>("enemy3")); // enemy
            textureLists[5].Add(Content.Load<Texture2D>("levelxbg")); // level x achtergrond
            textureLists[5].Add(Content.Load<Texture2D>("level1bg")); // level 1 achtergrond
            textureLists[5].Add(Content.Load<Texture2D>("level2bg")); // level 2 achtergrond
            textureLists[6].Add(Content.Load<Texture2D>("scorebg"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                previousKeyboardState = currentKeyboardState;
                currentKeyboardState = Keyboard.GetState();
                previousMouseState = currentMouseState;
                currentMouseState = Mouse.GetState();

                // TODO: Add your update logic here
                switch (currentState)
                {
                    case 0:
                        mainMenuScherm.Update(gameTime);
                        break;
                    case 1:
                        inGameScherm.Update(gameTime);
                        break;
                    case 2:
                    endGameScherm.Update(gameTime);
                        break;
                    case 3:
                        highScoreScherm.Update(gameTime);
                        break;
                }
            base.Update(gameTime);
        }

        //defining the methods used to add objects to various lists in the game.
        public void SwitchToEndGame(int score, string message)
        {
            endGameScherm.Initialize(score, message);
            currentState = 2;
        }

        public void SwitchCase(int caseId)
        {
            currentState = caseId;
            switch (caseId)
            {
                case 1:
                    inGameScherm.Initialize();
                    break;
                case 3:
                    highScoreScherm.Initialize();
                    break;
                default:
                    break;
            }
        }

        public int CheckHighScore(int score)
        {
            // Create the data to save
            HighScore data = HighScore.LoadHighScores(HighScoresFilename);

            int scoreIndex = -1;
            for (int i = 0; i < data.Count; i++)
            {
                if (score > data.Score[i])
                {
                    scoreIndex = i;
                    break;
                }
            }
            return scoreIndex;
        }

        public void SaveHighScore(string name, int score) {

            HighScore data = HighScore.LoadHighScores(HighScoresFilename);
            int scoreIndex = -1;
            for (int i = 0; i < data.Count; i++)
            {
                if (score > data.Score[i])
                {
                    scoreIndex = i;
                    break;
                }
            }

            if (scoreIndex > -1)
            {
                //New high score found ... do swaps
                for (int i = data.Count - 1; i > scoreIndex; i--)
                {
                    data.PlayerName[i] = data.PlayerName[i - 1];
                    data.Score[i] = data.Score[i - 1];
                }

                data.PlayerName[scoreIndex] = name; //Retrieve User Name Here
                data.Score[scoreIndex] = score;

                HighScore.SaveHighScores(data, HighScoresFilename);
            }
        }

        //definining the methods used to convert a string of text to an image.
        private Bitmap CreateBitmapImage(string sImageText, int fontSize)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;

            // Create the Font object for the image text drawing.
            Font objFont = new Font("Arial", fontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            // Create a graphics object to measure the text's width and height.
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            // This is where the bitmap size is determined.
            intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Height;

            // Create the bmpImage again with the correct size for the text and font.
            if (intWidth > 0 && intHeight > 0)
            {
                objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));
            }
            else
            {
                objBmpImage = new Bitmap(objBmpImage, new Size(1,1));
            }

            // Add the colors to the new bitmap.
            objGraphics = Graphics.FromImage(objBmpImage);

            // Set Background color
            objGraphics.Clear(System.Drawing.Color.Transparent);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(sImageText, objFont, new SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255)), 0, 0);
            objGraphics.Flush();
            return (objBmpImage);
        }

        private byte[] GetBytes(Bitmap bitmap)
        {
            var data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // calculate the byte size: for PixelFormat.Format32bppArgb (standard for GDI bitmaps) it's the hight * stride
            int bufferSize = data.Height * data.Stride; // stride already incorporates 4 bytes per pixel

            // create buffer
            byte[] bytes = new byte[bufferSize];

            // copy bitmap data into buffer
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);

            // unlock the bitmap data
            bitmap.UnlockBits(data);

            return bytes;
        }

        public Texture2D TextToTexture(string text, int fontSize)
        {
            Bitmap textBmp = CreateBitmapImage(text, fontSize);

            Texture2D textTexture = new Texture2D(graphics.GraphicsDevice, textBmp.Width, textBmp.Height);

            textTexture.SetData<byte>(GetBytes(textBmp));

            return textTexture;

        } 

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (currentState)
            {
                case 0:
                    mainMenuScherm.Draw(spriteBatch);
                    break;
                case 1:
                    inGameScherm.Draw(spriteBatch);
                    break;
                case 2:
                    endGameScherm.Draw(spriteBatch);
                    break;
                case 3:
                    highScoreScherm.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }

}
