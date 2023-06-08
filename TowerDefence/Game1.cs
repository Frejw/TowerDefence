using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;

namespace TowerDefence
{
    public class Game1 : Game
    {
        //create a "gamewindow" that is as big as the "game" screen, excluding UI, then render UI outside of that screen

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public gameplayManager gameplayManager;

        Controls menuControls;
        
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

            menuControls = new Controls(this);
            //this.Components.Add(new Controls(this));

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
                    if (!this.Components.Contains(menuControls))
                    {
                        this.Components.Add(menuControls);
                    }
                    break;


                case gameState.Playing:
                    gameplayManager.Update(gameTime);
                    if (this.Components.Contains(menuControls))
                    {
                        this.Components.Remove(menuControls);
                    }
                    break;


                case gameState.Paused:

                    break;


                case gameState.EndScreen:
                    EndScreen.Update();
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
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
                    EndScreen.Draw(spriteBatch);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        
    }
}