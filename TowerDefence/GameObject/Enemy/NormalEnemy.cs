using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefence
{
    internal class NormalEnemy : Enemy
    {
        public NormalEnemy()
        {
            texture = Assets.normalEnemyTex;
            hitbox = new Rectangle(0,0,40,40);
            speed = 0.015f;
            armor = 0;
            maxHealth = 20;
            health = maxHealth;
            killValue = 20;
            damage = 15;
        }

        public override void Update(GameTime gameTime)
        {
            position = gameplayManager.level1.EnemyPath.EvaluateAt(curveCurPos);

            hitbox.X = (int)position.X - hitbox.Width/2;
            hitbox.Y = (int)position.Y - hitbox.Height/2;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            float healthBarFillWidth = (float)health / maxHealth * hitbox.Width;
            //spriteBatch.Draw(Assets.blackTex, new Rectangle(hitbox.X, hitbox.Y - 5, texture.Width, 5), Color.White);
            spriteBatch.Draw(Assets.redTex, new Rectangle(hitbox.X, hitbox.Y - 10, (int)healthBarFillWidth, 5), Color.White);

            spriteBatch.Draw(texture, hitbox, Color.White);
            //spriteBatch.DrawString(Assets.fontArial, health.ToString(), new Vector2(hitbox.X + 40, hitbox.Y), Color.LightBlue);
            //spriteBatch.DrawString(Assets.fontArial, position.ToString(), new Vector2(hitbox.X + 40, hitbox.Y + 15), Color.LightBlue);
            //spriteBatch.DrawString(Assets.fontArial, hitbox.X.ToString() + hitbox.Y.ToString(), new Vector2(hitbox.X + 40 + 30, hitbox.Y), Color.LightBlue);
            //spriteBatch.DrawString(Assets.fontArial, curveCurPos.ToString(), new Vector2(hitbox.X + 40 + 30, hitbox.Y + 30), Color.LightBlue);
        }

        public override void TakeDamage(float damage)
        {
            health -= damage * (1 - armor / 100);
        }
    }
}
