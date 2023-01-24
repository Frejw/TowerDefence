﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spline;
using CatmullRom;

namespace TowerDefence
{
    public class Level
    {
        SpriteBatch spriteBatch;
        GraphicsDevice graphics;
        public RenderTarget2D renderTarget;

        private Vector2 backgroundPos = Vector2.Zero;

        CatmullRomPath enemyPath;
        


        //public RenderTarget2D RenderTarget { get { return renderTarget; } }

        Vector2[] levelPoints =
        {
            new Vector2(100, -10),
            new Vector2(100, 0),
            new Vector2(100, 300),
            new Vector2(800,300),
            new Vector2(800,500),
            new Vector2(450, 500),
            new Vector2(450, 700),
            new Vector2(1000, 700),
            new Vector2(1000, 0),
            new Vector2(1000, -10)
        };

        public Level(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            renderTarget = Assets.renderTarget;

            float pathTension = 0f;
            enemyPath = new CatmullRomPath(graphics, pathTension);

            enemyPath.Clear();
            foreach (Vector2 point in levelPoints)
            {
                enemyPath.AddPoint(point);
            }

            DrawRenderTarget(null, null);
        }

        

        public void Draw()
        {
            //draw on z-level 0
            spriteBatch.Draw(Assets.level01_background, Vector2.Zero, Color.White);

            spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
        }

        //Draws a texture to a possiton on the rendertarget if a texture is passed
        //Re-draws all towers in towerlist and the enemypath to rendertarget every time something is added to rendertarget
        //Probably a really bad idaea doing it this way, should rewrite
        public void DrawRenderTarget(Texture2D texture, Vector2? position)
        {
            graphics.SetRenderTarget(renderTarget);
            graphics.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.Identity);

            DrawPath();

            foreach (Tower tower in TowerManager.TowerList)
            {
                spriteBatch.Draw(tower.Texture, tower.Hitbox, Color.White);
            }

            if (texture != null)
            {
                if (position.HasValue)
                {
                    spriteBatch.Draw(texture, position.Value, Color.White);
                }
            }
            
            spriteBatch.End();
            graphics.SetRenderTarget(null);
        }

        //Draws the enemy path and path points
        private void DrawPath()
        {
            //Draw path on rendertarget
            //graphics.SetRenderTarget(renderTarget);
            //graphics.Clear(Color.Transparent);
            //draw road
            enemyPath.DrawFillSetup(graphics, 30, 50, 75);
            enemyPath.DrawFill(graphics, Assets.asphaltRoadTex1);
            //draw path
            enemyPath.DrawFillSetup(graphics, 2, 1, 256);
            enemyPath.DrawFill(graphics, Assets.redTex);
            //draw path points
            enemyPath.DrawPoints(spriteBatch, Color.Black, 6);
            //graphics.SetRenderTarget(null);
        }

    }
}
