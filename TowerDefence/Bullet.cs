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
        float velocity = 3f;
        float damage;
        private Point position;
        Rectangle hitbox = new Rectangle();

        public Rectangle Hitbox { get { return hitbox; } }
        public float Damage { get { return damage; } }

        Enemy target;
        public Enemy Target { get { return target; } }

        public Bullet(float x, float y, Enemy target, float damage)
        {
            hitbox = new Rectangle((int)x,(int)y,5,5);
            position = new Point(hitbox.X, hitbox.Y);
            this.target = target;
            this.damage = damage;
        }
        public void Update(GameTime gameTime)
        {
            if (target != null)
            {
                direction = new Vector2(target.Hitbox.Location.X - hitbox.Location.X, target.Hitbox.Location.Y - hitbox.Location.Y);
                direction.Normalize();
                hitbox.X += (int)(direction.X * velocity);
                hitbox.Y += (int)(direction.Y * velocity);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.redTex, hitbox, Color.White);
            spriteBatch.DrawPoint(position.ToVector2(), Color.LimeGreen);
            spriteBatch.DrawLine(new Vector2(hitbox.X, hitbox.Y), new Vector2(hitbox.X + direction.X * 5, hitbox.Y + direction.Y * 20), Color.LimeGreen, 1f);
        }
    }
}
