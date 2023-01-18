using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spline;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Assets
    {
        

        public static Texture2D normalTowerTex;
        public static SpriteFont fontArial;

        public static SimplePath enemyPath;
        

        public static void LoadAssets(ContentManager content, GraphicsDevice graphics)
        {
            normalTowerTex = content.Load<Texture2D>("Towers/normalTower");

            fontArial = content.Load<SpriteFont>("Arial");

            enemyPath = new SimplePath(graphics);
        }
    }
}
