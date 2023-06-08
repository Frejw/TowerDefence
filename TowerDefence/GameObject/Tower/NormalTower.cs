using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefence
{
    internal class NormalTower : Tower
    {
        public NormalTower()
        {
            texture = Assets.normalTowerTex;
            cost = 150;
            rangeMultiplier = 1;
            damageMultiplier = 1;
        }

        public override void Update(GameTime gameTime)
        {
            //set target that is in range and furthest along the path as the target
            if (currentCrystal != null)
            {
                float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                shootTimer += deltaTime;

                target = EnemyManager.EnemyList.Where(enemy => enemy.Hitbox.Intersects(currentCrystal.RangeCircle)).OrderByDescending(enemy => enemy.CurveCurPos).FirstOrDefault();
                

                if (target != null)
                {
                    if (shootTimer >= currentCrystal.FireRate)
                    {
                        Shoot();
                        shootTimer = 0;
                    }
                }
                
                //foreach (Enemy enemy in EnemyManager.EnemyList)
                //{
                //    if (enemy.Hitbox.Intersects(currentCrystal.Range))
                //    {
                        
                //    }

                //}
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.3f );
            //if (currentCrystal != null)
            //{
            //    spriteBatch.DrawString(Assets.fontArial, currentCrystal.ToString(), HitboxPosition + new Vector2(50,0), Color.Red, 0f, Vector2.Zero, 1, SpriteEffects.None, 0.3f);
            //    spriteBatch.DrawString(Assets.fontArial, shootTimer.ToString(), HitboxPosition + new Vector2(50,15), Color.Red, 0f, Vector2.Zero, 1, SpriteEffects.None, 0.3f);
            //}

        }

        public override void Shoot()
        {
            BulletManager.CreateBullet(HitboxPosition.X + hitbox.Width/2, HitboxPosition.Y + hitbox.Height/2, target, currentCrystal.Damage * damageMultiplier, currentCrystal.CrystalColor);
        }
    }
}
