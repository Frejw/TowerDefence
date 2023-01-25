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

        #region fortesting
        PoisonCrystal crystal1;
        public static Level level1;
        //NormalTower tower1;
        #endregion

        public gameplayManager(SpriteBatch spriteBatch, GraphicsDevice graphics) 
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;

            levelManager = new LevelManager(spriteBatch, graphics);

            #region fortesting
            level1 = new Level(spriteBatch, graphics);
            crystal1 = new PoisonCrystal();
            //tower1 = new NormalTower();
            //TowerManager.CreateTower(typeof(NormalTower));
            #endregion

        }

        public void Update()
        {
            TowerManager.Update();
            Player.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //levelManager.Draw();
            if (level1 != null)
            {
                 level1.Draw();
            }
            crystal1.Draw(spriteBatch);
            TowerManager.Draw(spriteBatch);
        }

        
    }
}
