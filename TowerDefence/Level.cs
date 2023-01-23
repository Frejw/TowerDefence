using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spline;

namespace TowerDefence
{
    public class Level
    {
        SpriteBatch spriteBatch;
        GraphicsDevice graphics;
        public static RenderTarget2D renderTarget;

        private Vector2 backgroundPos = Vector2.Zero; 
        

        //public RenderTarget2D RenderTarget { get { return renderTarget; } }

        Vector2[] levelPoints =
        {
            new Vector2(100, 0),
            new Vector2(100, 300),
            new Vector2(900,300),
            new Vector2(900,500),
            new Vector2(600, 500),
            new Vector2(600, 700),
            new Vector2(1000, 700),
            new Vector2(1000, 0)
        };

        public Level(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            renderTarget = Assets.renderTarget;


            Assets.enemyPath.Clean();
            foreach (Vector2 point in levelPoints)
            {
                Assets.enemyPath.AddPoint(point);
            }

            DrawOnRenderTarget(Assets.level01_background, backgroundPos);
        }

        public void Draw()
        {
            spriteBatch.Draw(Assets.level01_background, new Vector2(0,0), Color.White);
            Assets.enemyPath.Draw(spriteBatch);
            Assets.enemyPath.DrawPoints(spriteBatch);
        }

        public static void DrawOnRenderTarget(Texture2D texture, Vector2 position)
        {
            gameplayManager.level1.graphics.SetRenderTarget(Assets.renderTarget);
            gameplayManager.level1.graphics.Clear(Color.Transparent);
            gameplayManager.level1.spriteBatch.Begin();
            gameplayManager.level1.spriteBatch.Draw(texture, position, Color.White);
            gameplayManager.level1.spriteBatch.End();
            gameplayManager.level1.graphics.SetRenderTarget(null);
        }
    }
}
