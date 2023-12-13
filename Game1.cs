using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Monogame_Parts_1_5_summative
{
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            Yoshiruns,
            losing

        }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D yoshirun1;
        Texture2D yoshirun2;
        Texture2D yoshijump;
        Texture2D yoshilose;
        Texture2D koopa1;
        Texture2D koopa2;
        Texture2D introscreen;
        Texture2D introscreenbg;
        SoundEffect intro;
        SoundEffect run;
        SoundEffect lose;
        Rectangle yoshirnj;
        Rectangle koopawalking;
        Vector2 yJump;
        Vector2 kMove;
        Screen screen;
        MouseState mouseState;
        private SpriteFont writing;
        private SpriteFont cts;
        int song1 = 1;
        int song2 = 1;
        int song3 = 1;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            if (screen == Screen.Intro)
            {
                _graphics.PreferredBackBufferWidth = 443;
                _graphics.PreferredBackBufferHeight = 563;
                _graphics.ApplyChanges();
            }
            else if (screen == Screen.Yoshiruns)
            {
                _graphics.PreferredBackBufferWidth = 800;
                _graphics.PreferredBackBufferHeight = 500;
                _graphics.ApplyChanges();
            }
            yoshirnj = new Rectangle(90, 300, 100, 100);
            koopawalking = new Rectangle(222, 300, 60, 90);
            yJump = new Vector2(4, 0);
            kMove = new Vector2(2, 0);
            screen = Screen.Intro;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            yoshirun1 = Content.Load<Texture2D>("yoshirun1");
            yoshirun2 = Content.Load<Texture2D>("yoshirun2");
            yoshijump = Content.Load<Texture2D>("yoshijump");
            yoshilose = Content.Load<Texture2D>("yoshilose");
            koopa1 = Content.Load<Texture2D>("koopatroopa1");
            koopa2 = Content.Load<Texture2D>("koopatroopa2");
            introscreen = Content.Load<Texture2D>("yoshiintro");
            introscreenbg = Content.Load<Texture2D>("introBG");
            intro = Content.Load<SoundEffect>("Yoshi Story");
            run = Content.Load<SoundEffect>("yoshirunning");
            lose = Content.Load<SoundEffect>("yoshiloses");
            writing = Content.Load<SpriteFont>("text");
            cts = Content.Load<SpriteFont>("cts");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Yoshiruns;

            }
            else if (screen == Screen.Yoshiruns)
            {
                yoshirnj.X += (int)yJump.X;
                yoshirnj.Y += (int)yJump.Y;
                if (yoshirnj.Left <= 0 || yoshirnj.Right >= _graphics.PreferredBackBufferWidth)
                {
                    yJump.X *= -1;
                }
                if (yoshirnj.Top <= 0 || yoshirnj.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    yJump.Y *= -1;
                }
                if (koopawalking.Left <= 0 || koopawalking.Right >= _graphics.PreferredBackBufferWidth)
                {
                    kMove.X *= -1;
                }
                if (koopawalking.Top <= 0 || koopawalking.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    kMove.Y *= -1;
                }
               
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Salmon);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                while (song1 == 1)
                {
                    intro.Play();
                    song1++;
                }
                _spriteBatch.Draw(introscreenbg, new Vector2(-300, 0), Color.White);
                _spriteBatch.Draw(introscreen, new Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(writing, "Yoshi Hop", new Vector2(37, 403), Color.Black);
                _spriteBatch.DrawString(writing, "Yoshi Hop", new Vector2(40, 400), Color.Blue);
                _spriteBatch.DrawString(cts, "click to start", new Vector2(89, 452), Color.Black);
                _spriteBatch.DrawString(cts, "click to start", new Vector2(90, 450), Color.Blue);
                if (screen == Screen.Yoshiruns)
                {
                    MediaPlayer.Stop();
                }
            }
            else if (screen == Screen.Yoshiruns)
            {
                MediaPlayer.Pause();
                while (song2 == 1)
                {
                    run.Play();
                    song2++;
                }
                _spriteBatch.Draw(introscreenbg, new Vector2(0, 0), Color.White);
                _spriteBatch.Draw(yoshirun1, yoshirnj, Color.White);
                _spriteBatch.Draw(koopa1, koopawalking, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}