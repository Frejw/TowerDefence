using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class LevelManager
    {
        //Level currentLevel;
        

        //public Level Level { get { return level1; } }

        public LevelManager(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            
        }
        public void Draw()
        {
            gameplayManager.level1.Draw();
        }
    }
}
