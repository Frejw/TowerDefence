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
    internal static class EndScreen
    {
        public static void Update()
        {
            if (KeyMouseReader.KeyPressed(Keys.Space))
            {
                System.Environment.Exit(0);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Assets.fontArial, "Press Space to exit", new Vector2(700, 500), Color.White);
            //spriteBatch.Draw(Assets.endScreen, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
