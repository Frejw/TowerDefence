using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal static class MainMenu
    {
        
        public static void Update()
        {
            if (KeyMouseReader.KeyPressed(Keys.Space))
            {
                Game1.currentGameState = Game1.gameState.Playing;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Assets.fontArial, "Main Menu", new Vector2(0, 0), Color.Black);
        }
    }
}
