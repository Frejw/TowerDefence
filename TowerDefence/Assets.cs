using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spline;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal static class Assets
    {
        public static Texture2D level01_background;
        public static Texture2D normalTowerTex, trapTex, AoETowerTex;
        public static SpriteFont fontArial;

        public static SimplePath enemyPath;

        public static RenderTarget2D renderTarget;

        public static void LoadAssets(ContentManager content, GraphicsDevice graphics)
        {
            level01_background = content.Load<Texture2D>("level01");

            normalTowerTex = content.Load<Texture2D>("Towers/normalTower");

            fontArial = content.Load<SpriteFont>("Arial");

            enemyPath = new SimplePath(graphics);
            
            renderTarget = new RenderTarget2D(graphics, graphics.Viewport.Bounds.Width, graphics.Viewport.Bounds.Height);

        }

    }
}
