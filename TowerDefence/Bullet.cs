using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Bullet : GameObject
    {
        Vector2 direction;
        float velocity = 5f;
        float damage;
        private Point position;
        Rectangle hitbox = new Rectangle();
        Color bulletColor;

        public Rectangle Hitbox { get { return hitbox; } }
        public float Damage { get { return damage; } }

        Enemy target;
        public Enemy Target { get { return target; } }

        public Bullet(float x, float y, Enemy target, float damage, Color color)
        {
            hitbox = new Rectangle((int)x,(int)y,8,8);
            position = new Point(hitbox.X, hitbox.Y);
            this.target = target;
            this.damage = damage;
            bulletColor = color;
        }
        public void Update(GameTime gameTime)
        {
            if (target != null)
            {
                direction = new Vector2(target.Hitbox.Center.X - hitbox.Center.X, target.Hitbox.Center.Y - hitbox.Center.Y);
                direction.Normalize();
                hitbox.X += (int)(direction.X * velocity);
                hitbox.Y += (int)(direction.Y * velocity);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.whiteTex, hitbox, bulletColor);
            //spriteBatch.DrawPoint(position.ToVector2(), Color.LimeGreen);
            //spriteBatch.DrawLine(new Vector2(hitbox.X, hitbox.Y), new Vector2(hitbox.X + direction.X * 5, hitbox.Y + direction.Y * 30), Color.HotPink, 2f);
        }
    }
}
