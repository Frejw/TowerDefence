using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;

namespace TowerDefence
{
    public class Game1 : Game
    {
        //create a "gamewindow" that is as big as the "game" screen, excluding UI, then render UI outside of that screen to fix draw order issues
        //path points will need to be changed
        //limit placement of things to only be on gamescreen

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public gameplayManager gameplayManager;

        //static Rectangle viewport;

        //public static Rectangle Viewport { get { return viewport; } }
        
        public static gameState currentGameState;

        public enum gameState
        {
            MainMenu,
            Playing,
            Paused,
            EndScreen
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1560;
            graphics.PreferredBackBufferHeight = 960;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //viewport = new Rectangle(0, 0, graphics.PreferredBackBufferWidth - 250, graphics.PreferredBackBufferHeight - 100);

            MyraEnvironment.Game = this;
            Assets.LoadAssets(Content, GraphicsDevice);
            //UI.LoadContent();
            
            gameplayManager = new gameplayManager(spriteBatch, GraphicsDevice);
            currentGameState = gameState.MainMenu;
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyMouseReader.Update();


            switch (currentGameState)
            {
                case gameState.MainMenu:
                    MainMenu.Update();
                    break;


                case gameState.Playing:
                    gameplayManager.Update(gameTime);
                    break;


                case gameState.Paused:

                    break;


                case gameState.EndScreen:

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront);

            switch (currentGameState)
            {
                case gameState.MainMenu:
                    MainMenu.Draw(spriteBatch);
                    break;


                case gameState.Playing:
                    gameplayManager.Draw(spriteBatch);
                    break;


                case gameState.Paused:

                    break;


                case gameState.EndScreen:

                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        
    }
}