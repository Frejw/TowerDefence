using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class gameplayManager
    {
        SpriteBatch spriteBatch; 
        GraphicsDevice graphics;

        LevelManager levelManager;

        private static List<ParticleEmitter> particleEmitterList;

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
            
            #region fortesting
            level1 = new Level(spriteBatch, graphics);

            ParticleEmitter emitter1 = new ParticleEmitter(ParticleEmitter.emitterType.Pulse);
            ParticleEmitterList.Add(emitter1);

            //tower1 = new NormalTower();
            //TowerManager.CreateTower(typeof(NormalTower));
            #endregion

        }

        public void Update(GameTime gameTime)
        {
            CrystalManager.Update();
            TowerManager.Update();
            Player.Update();
            foreach (ParticleEmitter emitter in ParticleEmitterList)
            {
                emitter.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
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
        }

        
    }
}
