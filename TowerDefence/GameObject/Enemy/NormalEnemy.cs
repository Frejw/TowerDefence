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
        //float curveCurPos = 0;
        //Vector2 position;

        //public float CurveCurPos { get { return curveCurPos; } }

        public NormalEnemy()
        {
            texture = Assets.redTex;
            hitbox = new Rectangle(0,0,30,30);
            speed = 0.01f;
            armor = 0;
            maxHealth = 20;
            health = maxHealth;
            killValue = 20;
            damage = 10;
        }

        public override void Update(GameTime gameTime)
        {
            //curveCurPos += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (curveCurPos > 1.0f)
            //{
            //    //this is for code when you get to the end of the path
            //    Player.Health -= damage;
            //    curveCurPos= 0.0f;
            //}

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
            spriteBatch.DrawString(Assets.fontArial, health.ToString(), new Vector2(hitbox.X + 40, hitbox.Y), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial, position.ToString(), new Vector2(hitbox.X + 40, hitbox.Y + 15), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial, hitbox.X.ToString() + hitbox.Y.ToString(), new Vector2(hitbox.X + 40 + 30, hitbox.Y), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial, curveCurPos.ToString(), new Vector2(hitbox.X + 40 + 30, hitbox.Y + 30), Color.LightBlue);
        }

        public override void TakeDamage(float damage)
        {
            health -= damage * (1 - armor / 100);
        }
    }
}
