using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GetToThing
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;


        Texture2D player_texture;
        Vector2 player_Position;

        //Goal
        Texture2D goal_texture;
        Vector2 goal_Position;

        //wall1
        Texture2D wall1;
        Vector2 wall1_Posiiton;

        //wall2-3
        Texture2D wall2;
        Texture2D wall3;
        Vector2 wall2_Position;
        Vector2 wall3_Position;


       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            
        }

        public void level1()
        {

            player_Position = new Vector2(100, 100);
            goal_Position = new Vector2(500, 100);
                
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
        
            level1();

           

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
            player_texture = Content.Load<Texture2D>("player");
            goal_texture = Content.Load<Texture2D>("goal");
            font = Content.Load<SpriteFont>("score");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            KeyboardState state = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();




            int speed = 6;
            
            if (state.IsKeyDown(Keys.Right) && player_Position.X < 750)
                player_Position.X += speed;
            if (state.IsKeyDown(Keys.Left) && player_Position.X > 0)
                player_Position.X -= speed;
            if (state.IsKeyDown(Keys.Up) && player_Position.Y > 0)
                player_Position.Y -= speed;
            if (state.IsKeyDown(Keys.Down) && player_Position.Y < 430)
                player_Position.Y += speed;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SeaShell);
            spriteBatch.Begin();
            spriteBatch.Draw(goal_texture, new Rectangle((int)goal_Position.X, (int)goal_Position.Y, 50, 50), Color.White);
            spriteBatch.Draw(player_texture, new Rectangle((int)player_Position.X, (int)player_Position.Y, 50, 50), Color.White);
            spriteBatch.DrawString(font, "X: " + player_Position.X, new Vector2(10, 400), Color.Black);
            spriteBatch.DrawString(font, "Y: " + player_Position.Y, new Vector2(15, 440), Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
