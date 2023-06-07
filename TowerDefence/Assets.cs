using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Spline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CatmullRom;

namespace TowerDefence
{
    internal static class Assets
    {
        public static Texture2D level01_background;
        public static Texture2D asphaltRoadTex1, asphaltRoadTex2, gravelRoadTex1, gravelRoadTex2;
        public static Texture2D T1Crystal, T2Crystal, T3Crystal;
        public static Texture2D normalTowerTex, trapTex, AoETowerTex;
        public static Texture2D normalEnemyTex, fastEnemyTex;
        public static Texture2D redTex, blackTex, greenTex;

        public static SpriteFont fontArial;

        //public static SimplePath enemyPath;
        //public static CatmullRomPath enemyPath;

        public static RenderTarget2D renderTarget;
        public static RenderTarget2D UITarget;

        public static void LoadAssets(ContentManager content, GraphicsDevice graphics)
        {
            asphaltRoadTex1 = content.Load<Texture2D>("asphalt");
            asphaltRoadTex2 = content.Load<Texture2D>("asphalt2");
            gravelRoadTex1 = content.Load<Texture2D>("gravel");
            gravelRoadTex2 = content.Load<Texture2D>("gravel2");
            T1Crystal = content.Load<Texture2D>("Crystals/C1-test");
            normalEnemyTex = content.Load<Texture2D>("Enemy/normalEnemy");

            redTex = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            redTex.SetData<Color>(new Color[] { Color.Red });

            blackTex = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            blackTex.SetData<Color>(new Color[] { Color.Black });

            greenTex = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            greenTex.SetData<Color>(new Color[] { Color.Green });

            level01_background = content.Load<Texture2D>("grassBG");

            normalTowerTex = content.Load<Texture2D>("Towers/normalTower");

            fontArial = content.Load<SpriteFont>("Arial");

            //enemyPath = new SimplePath(graphics);
            
            renderTarget = new RenderTarget2D(graphics, graphics.Viewport.Bounds.Width, graphics.Viewport.Bounds.Height);
            //renderTarget = new RenderTarget2D(graphics, graphics.Viewport.Bounds.Width - 300, graphics.Viewport.Bounds.Height);
            UITarget = new RenderTarget2D(graphics, graphics.Viewport.Bounds.Width, graphics.Viewport.Bounds.Height);

        }

    }
}
