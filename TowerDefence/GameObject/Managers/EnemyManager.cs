using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    static class EnemyManager
    {
        static List<Enemy> enemyList = new List<Enemy>();

        public static List<Enemy> EnemyList { get { return enemyList; } }

        public static void Update(GameTime gameTime)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Update(gameTime);

                if (enemyList[i].Health <= 0)
                {
                    Player.Money += enemyList[i].KillValue;
                    enemyList.RemoveAt(i);
                }
            }
            
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
        }

        public static void CreateEnemy(Type enemy)
        {
            enemyList.Add((Enemy)Activator.CreateInstance(enemy));
        }
    }
}
