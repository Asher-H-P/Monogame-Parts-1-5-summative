using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Parts_1_5_summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D yoshirun1;
        Texture2D yoshirun2;
        Texture2D yoshijump;
        Texture2D yoshilose;
        Texture2D koopa1;
        Texture2D koopa2;
        Texture2D introscreen;
        SoundEffect intro;
        SoundEffect run;
        SoundEffect lose;
        private SpriteFont writing;
        int song = 1;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 443;
            _graphics.PreferredBackBufferHeight = 563;
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
            intro = Content.Load<SoundEffect>("Yoshi Story");
            run = Content.Load<SoundEffect>("yoshirunning");
            lose = Content.Load<SoundEffect>("yoshiloses");
            writing = Content.Load<SpriteFont>("text");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Salmon);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            while (song == 1)
            {
                intro.Play();
                song++;
            }
            _spriteBatch.Draw(introscreen, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(writing, "Yoshi Hop", new Vector2(37, 403), Color.Black);
            _spriteBatch.DrawString(writing, "Yoshi Hop", new Vector2(40, 400), Color.Blue);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}