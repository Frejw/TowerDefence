using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class AoeTower : Tower
    {
        ParticleEmitter shootEmitter;
        public AoeTower()
        {
            texture = Assets.AoETowerTex;
            shootEmitter = new ParticleEmitter(ParticleEmitter.emitterType.OnCall);
            shootEmitter.ParticleAge = 0.3f;
            shootEmitter.ParticleVelocity = 400;
            gameplayManager.ParticleEmitterList.Add(shootEmitter);
            cost = 250;
            rangeMultiplier = 0.75f;
        }

        public override void Update(GameTime gameTime)
        {
            shootEmitter.Position = HitboxPosition + new Vector2(hitbox.Width/2, hitbox.Height/2);
            if (currentCrystal != null)
            {
                float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                shootTimer += deltaTime;

                if (shootTimer >= currentCrystal.FireRate)
                {
                    Shoot();
                    shootEmitter.ShouldEmit = true;
                    shootTimer = 0;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.3f);
            //if (currentCrystal != null)
            //{
            //    spriteBatch.DrawString(Assets.fontArial, currentCrystal.ToString(), HitboxPosition + new Vector2(50, 0), Color.Red, 0f, Vector2.Zero, 1, SpriteEffects.None, 0.3f);
            //    spriteBatch.DrawString(Assets.fontArial, shootTimer.ToString(), HitboxPosition + new Vector2(50, 15), Color.Red, 0f, Vector2.Zero, 1, SpriteEffects.None, 0.3f);
            //}
        }

        public override void Shoot()
        {
            foreach (Enemy enemy in EnemyManager.EnemyList)
            {
                if (enemy.Hitbox.Intersects(currentCrystal.RangeCircle))
                {
                    enemy.TakeDamage(currentCrystal.Damage);
                }
            }
        }

        
    }
}
