using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class PoisonCrystal : Crystal
    {
        int poisonDamage;
        int poisonDuration;
        static Color color = Color.LimeGreen;

        static int cost = 100;

        public static int Cost { get { return cost; } }
        public static Color Color { get { return color; } }

        public PoisonCrystal()
        {
            texture = Assets.T1Crystal;
            hitbox = new Rectangle(300, 100, 30, 30);
            center = new Point(hitbox.X, hitbox.Y);
            cost = 100;
            rangeRadius = 100;
            range = new CircleF(center, rangeRadius);
            fireRate = 2;
            minDmg = 6;
            maxDmg = 10;
        }

        public override void Update()
        {
            //move range circle to crystal pos
            center.X = hitbox.X;
            center.Y = hitbox.Y;
            range.Position = center;

            ////shoot if crystal is in a tower and enemy in rnage
            //if (inTower)
            //{
            //    foreach (Enemy enemy in EnemyManager.EnemyList)
            //    {
            //        if (range.Intersects(rectangle: enemy.Hitbox))
            //        {
            //            Shoot();
            //        }
            //    }
            //}
        }

        //public override void Shoot()
        //{
        //    BulletManager.CreateBullet(HitboxPosition.X, HitboxPosition.Y);
        //}

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, null, Color.Lime, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            spriteBatch.DrawCircle(range, 100, Color.Red, 2f, 0.2f);
        }
    }
}
