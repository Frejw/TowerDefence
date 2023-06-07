using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class FastEnemy : Enemy
    {
        public FastEnemy()
        {
            texture = Assets.normalEnemyTex;
            hitbox = new Rectangle(0, 0, texture.Width, texture.Height);
            speed = 0.05f;
            maxHealth = 10;
            health = maxHealth;
            killValue = 10;
            damage = 5;
        }

        public override void Update(GameTime gameTime)
        {
            //curveCurPos += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            position = gameplayManager.level1.EnemyPath.EvaluateAt(curveCurPos);

            hitbox.X = (int)position.X - hitbox.Width / 2;
            hitbox.Y = (int)position.Y - hitbox.Height / 2;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            float healthBarFillWidth = (float)health / maxHealth * texture.Width;
            spriteBatch.Draw(Assets.blackTex, new Rectangle(hitbox.X, hitbox.Y - 5, texture.Width, 5), Color.White);
            spriteBatch.Draw(Assets.redTex, new Rectangle(hitbox.X, hitbox.Y - 5, (int)healthBarFillWidth, 5), Color.White);

            spriteBatch.Draw(texture, hitbox, Color.Blue);
            spriteBatch.DrawString(Assets.fontArial, health.ToString(), new Vector2(hitbox.X + 40, hitbox.Y), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial, position.ToString(), new Vector2(hitbox.X + 40, hitbox.Y + 15), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial, "x: " + hitbox.X.ToString() + " y: " + hitbox.Y.ToString(), new Vector2(hitbox.X + 40 + 30, hitbox.Y), Color.LightBlue);
        }

        public override void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
}
