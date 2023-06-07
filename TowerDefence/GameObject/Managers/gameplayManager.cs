using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Myra;
using Myra.Graphics2D.UI;

namespace TowerDefence
{
    public class gameplayManager
    {
        SpriteBatch spriteBatch; 
        GraphicsDevice graphics;

        LevelManager levelManager;

        private static List<ParticleEmitter> particleEmitterList;

        //UI gameUI;

        public static Desktop desktop;

        #region fortesting

        public static Level level1;
        
        internal static List<ParticleEmitter> ParticleEmitterList { get => particleEmitterList; set => particleEmitterList = value; }

        //NormalTower tower1;
        #endregion

        public gameplayManager(SpriteBatch spriteBatch, GraphicsDevice graphics) 
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;

            levelManager = new LevelManager(spriteBatch, graphics);

            ParticleEmitterList = new List<ParticleEmitter>();

            //gameUI= new UI();

            desktop = new Desktop();
            desktop.Root = UI.CreateGrid(graphics);
            
            #region fortesting
            level1 = new Level(spriteBatch, graphics);

            ParticleEmitter emitter1 = new ParticleEmitter(ParticleEmitter.emitterType.Pulse);
            ParticleEmitterList.Add(emitter1);

            //Enemy enemy1 = new NormalEnemy();
            //EnemyManager.CreateEnemy(typeof(NormalEnemy));

            //tower1 = new NormalTower();
            //TowerManager.CreateTower(typeof(NormalTower));
            #endregion

        }

        public void Update(GameTime gameTime)
        {
            CrystalManager.Update();
            TowerManager.Update(gameTime);
            Player.Update();
            EnemyManager.Update(gameTime);
            BulletManager.Update(gameTime);
            foreach (ParticleEmitter emitter in ParticleEmitterList)
            {
                emitter.Update(gameTime);
            }

            //print FPS
            if ((int)(gameTime.TotalGameTime.TotalMilliseconds) % 1000 == 0)
                System.Diagnostics.Debug.WriteLine((int)(1.0f / gameTime.ElapsedGameTime.TotalSeconds) + " fps");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Layers:
            //1f = background
            //0.9f = rendertarget with path and towers
            //0.8f = UI rendertarget
            //0.3f = non rendertarget tower
            //0.2f = crystal

            //levelManager.Draw();
            if (level1 != null)
            {
                level1.Draw();
            }

            foreach (ParticleEmitter emitter in ParticleEmitterList)
            {
                emitter.Draw(spriteBatch);
            }

            CrystalManager.Draw(spriteBatch);
            TowerManager.Draw(spriteBatch);
            EnemyManager.Draw(spriteBatch);
            BulletManager.Draw(spriteBatch);
            Player.Draw(spriteBatch);

            DrawUI();
            
            spriteBatch.Draw(Assets.UITarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.8f);
        }

        #region methods

        void DrawUI()
        {
            graphics.SetRenderTarget(Assets.UITarget);
            graphics.Clear(Color.Transparent);

            desktop.Render();
            graphics.SetRenderTarget(null);
        }

        #endregion
    }
}
