using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing.Text;

namespace TowerDefence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public gameplayManager gameplayManager;
        
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
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 960;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Assets.LoadAssets(Content, GraphicsDevice);

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
                    
                    gameplayManager.Update();
                    
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
            spriteBatch.Begin();

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