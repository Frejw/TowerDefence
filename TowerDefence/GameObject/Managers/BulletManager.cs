using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal static class BulletManager
    {
        static Vector2 bulletTextPos = new Vector2(1000,0);
        static List<Bullet> bulletList = new List<Bullet>();

        public static List<Bullet> BulletList { get { return bulletList; } }

        public static void Update(GameTime gameTime)
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Update(gameTime);

                //if (bulletList[i].Target == null)
                //{
                //    bulletList.RemoveAt(i);
                //}

                if (!EnemyManager.EnemyList.Contains(bulletList[i].Target))
                {
                    bulletList.RemoveAt(i);
                }

                //for (int j = 0; j < EnemyManager.EnemyList.Count; j++)
                //{
                //    if (bulletList[i].Hitbox.Intersects(EnemyManager.EnemyList[j].Hitbox))
                //    {
                //        EnemyManager.EnemyList[j].TakeDamage(bulletList[i].Damage);
                //        bulletList.RemoveAt(i);
                //    }
                //}
                if (bulletList[i].Hitbox.Intersects(bulletList[i].Target.Hitbox))
                {
                    int targetIndex = EnemyManager.EnemyList.IndexOf(bulletList[i].Target);
                    if (targetIndex != -1)
                    {
                        EnemyManager.EnemyList[targetIndex].TakeDamage(bulletList[i].Damage);
                        bulletList.RemoveAt(i);
                    }
                    //for (int j = 0; j < EnemyManager.EnemyList.Count; j++)
                    //{
                    //    if (EnemyManager.EnemyList[j] == bulletList[i].Target)
                    //    {
                    //        EnemyManager.EnemyList[j].TakeDamage(bulletList[i].Damage);
                    //    }
                    //}
                }

                
            }

            //foreach (Bullet bullet in bulletList)
            //{
            //    bullet.Update(gameTime);

            //    foreach (Enemy enemy in EnemyManager.EnemyList)
            //    {
            //        if (bullet.Hitbox.Intersects(enemy.Hitbox))
            //        {

            //        }
            //    }
            //}
        }

        public static void Draw(SpriteBatch spritebatch)
        {
            foreach(Bullet bullet in bulletList)
            {
                bullet.Draw(spritebatch);
            }
            for (int i = 0; i < bulletList.Count; i++)
            {
                spritebatch.DrawString(Assets.fontArial, i + bulletList[i].ToString() + " tI: " + EnemyManager.EnemyList.FindIndex(enemy => enemy == bulletList[i].Target), bulletTextPos + new Vector2(0, bulletTextPos.Y + i*15), Color.Red, 0, Vector2.Zero, 1, SpriteEffects.None, 0.3f);
            }
        }

        public static void CreateBullet(float x, float y, Enemy target, float damage)
        {
            bulletList.Add(new Bullet(x, y, target, damage));
        }
    }
}
