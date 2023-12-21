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
        Texture2D ground;
        Texture2D transparent;
        SoundEffect intro;
        SoundEffect run;
        SoundEffect lose;
        SoundEffect koopa;
        SoundEffect yoshi;
        Rectangle yoshirnj;
        Rectangle koopawalking;
        Rectangle koopacollision;
        Rectangle theground;
        Rectangle thesky;
        Vector2 yJump;
        Vector2 kMove;
        Screen screen;
        MouseState mouseState;
        KeyboardState buttons;
        private SpriteFont writing;
        private SpriteFont cts;
        int song1 = 1;
        int song2 = 1;
        int song3 = 1;
        int yruns = 1;
        int kruns = 1;
        int ksound = 0;
        int ysound = 0;
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
            yoshirnj = new Rectangle(90, 339, 90, 85);
            koopawalking = new Rectangle(432, 354, 60, 90);
            koopacollision = new Rectangle(452, 390, 10, 10);
            theground = new Rectangle(0, 443, 800, 60);
            thesky = new Rectangle(0, 170, 800, 60);
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
            ground = Content.Load<Texture2D>("ground");
            transparent = Content.Load<Texture2D>("yoshiintro(wtbkrnd)");
            intro = Content.Load<SoundEffect>("Yoshi Story");
            run = Content.Load<SoundEffect>("yoshirunning");
            lose = Content.Load<SoundEffect>("failure");
            koopa = Content.Load<SoundEffect>("koopanoise");
            yoshi = Content.Load<SoundEffect>("yoshinoise");
            writing = Content.Load<SpriteFont>("text");
            cts = Content.Load<SpriteFont>("cts");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            buttons = Keyboard.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    intro.Dispose();
                    screen = Screen.Yoshiruns;
                }
            }
            else if (screen == Screen.Yoshiruns)
            {
                _graphics.PreferredBackBufferWidth = 800;
                _graphics.PreferredBackBufferHeight = 500;
                _graphics.ApplyChanges();
                yoshirnj.X += (int)yJump.X;
                yoshirnj.Y += (int)yJump.Y;
                koopawalking.X += (int)kMove.X;
                koopawalking.Y += (int)kMove.Y;
                koopacollision.X += (int)kMove.X;
                koopacollision.Y += (int)kMove.Y;
                if (yoshirnj.Left <= 0 || yoshirnj.Right >= _graphics.PreferredBackBufferWidth)
                {
                    yJump.X *= -1;
                    ysound++;
                    if (ysound == 5)
                    {
                        yoshi.Play();
                        ysound = 0;
                    }
                }
                if (yoshirnj.Top <= 0 || yoshirnj.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    yJump.Y *= -1;
                }
                if (buttons.IsKeyDown(Keys.W) && !yoshirnj.Intersects(thesky))
                {
                    yoshirnj.Y += -5;
                    if (yoshirnj.Intersects(thesky) && buttons.IsKeyDown(Keys.W) && !yoshirnj.Intersects(theground))
                    {
                        yoshirnj.Y += 15;
                    }
                }
                else if (buttons.IsKeyDown(Keys.W) && yoshirnj.Intersects(thesky) && !yoshirnj.Intersects(theground))
                {
                    yoshirnj.Y += 4;
                }
                else if (buttons.IsKeyUp(Keys.W) && !yoshirnj.Intersects(theground))
                {
                    yoshirnj.Y += 4;
                }
                if (koopawalking.Left <= 0 || koopawalking.Right >= _graphics.PreferredBackBufferWidth)
                {
                    kMove.X *= -1;
                    ksound++;
                    if (ksound == 3)
                    {
                        koopa.Play();
                        ksound = 0;
                    }
                }
                if (koopawalking.Top <= 0 || koopawalking.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    kMove.Y *= -1;
                }
                if (yoshirnj.Intersects(koopacollision))
                {
                    run.Dispose();
                    screen = Screen.losing;
                        lose.Play();
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
                _spriteBatch.DrawString(cts, "click to start", new Vector2(95, 452), Color.Black);
                _spriteBatch.DrawString(cts, "click to start", new Vector2(98, 450), Color.Blue);
                _spriteBatch.DrawString(cts, "press W to jump", new Vector2(83, 472), Color.Black);
                _spriteBatch.DrawString(cts, "press W to jump", new Vector2(86, 470), Color.Blue);
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    intro.Dispose();
                }
            }
            else if (screen == Screen.Yoshiruns)
            {
                _graphics.PreferredBackBufferWidth = 800;
                _graphics.PreferredBackBufferHeight = 500;
                _graphics.ApplyChanges();
                MediaPlayer.Stop();
                while (song2 == 1)
                {
                    run.Play();
                    song2++;
                }
                _spriteBatch.Draw(transparent, thesky, Color.White);
                _spriteBatch.Draw(koopa1, koopacollision, Color.White);
                _spriteBatch.Draw(introscreenbg, new Vector2(0, 0), Color.White);
                _spriteBatch.Draw(ground, theground, Color.White);
                _spriteBatch.Draw(koopa1, koopawalking, Color.White);
                if (kruns == 0)
                {
                    _spriteBatch.Draw(koopa1, koopawalking, Color.White);
                    kruns++;
                }
                else if (kruns <= 7)
                {
                    _spriteBatch.Draw(koopa1, koopawalking, Color.White);
                    kruns++;
                }
                else if (kruns >= 8 && kruns <= 15)
                {
                    _spriteBatch.Draw(koopa2, koopawalking, Color.White);
                    kruns++;
                }
                else if (kruns == 16)
                {
                    _spriteBatch.Draw(koopa2, koopawalking, Color.White);
                    kruns = 0;
                }
                if (buttons.IsKeyUp(Keys.W))
                {
                    if (yruns == 0)
                    {
                        _spriteBatch.Draw(yoshirun1, yoshirnj, Color.White);
                        yruns++;
                    }
                    else if (yruns <= 5)
                    {
                        _spriteBatch.Draw(yoshirun1, yoshirnj, Color.White);
                        yruns++;
                    }
                    else if (yruns >= 6 && yruns <= 11)
                    {
                        _spriteBatch.Draw(yoshirun2, yoshirnj, Color.White);
                        yruns++;
                    }
                    else if (yruns == 12)
                    {
                        _spriteBatch.Draw(yoshirun2, yoshirnj, Color.White);
                        yruns = 0;
                    }
                }
                else if (buttons.IsKeyDown(Keys.W))
                {
                    _spriteBatch.Draw(yoshijump, yoshirnj, Color.White);
                }
            }
            else if (screen == Screen.losing)
            {
                _graphics.PreferredBackBufferWidth = 358;
                _graphics.PreferredBackBufferHeight = 358;
                _graphics.ApplyChanges();
                while (song3 == 1)
                {
                    lose.Play();
                    song3++;
                }
                _spriteBatch.Draw(yoshilose, new Vector2(0, 0), Color.SkyBlue);
                _spriteBatch.DrawString(writing, "You lost", new Vector2(30, 4), Color.Black);
                _spriteBatch.DrawString(writing, "You lost", new Vector2(33, 1), Color.Red);
                _spriteBatch.DrawString(cts, "How could you do this", new Vector2(9, 273), Color.Black);
                _spriteBatch.DrawString(cts, "How could you do this", new Vector2(12, 270), Color.Red);
                _spriteBatch.DrawString(cts, "Made by Asher H.P.", new Vector2(32, 313), Color.Black);
                _spriteBatch.DrawString(cts, "Made by Asher H.P.", new Vector2(35, 310), Color.Red);
                _spriteBatch.DrawString(cts, "Press E to exit", new Vector2(45, 333), Color.Black);
                _spriteBatch.DrawString(cts, "Press E to exit", new Vector2(48, 330), Color.Red);
                if (buttons.IsKeyDown(Keys.E))
                {
                    Exit();
                }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}