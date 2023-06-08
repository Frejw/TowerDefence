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
        public static Color color = Color.LimeGreen;

        static int cost = 100;

        public static int Cost { get { return cost; } }
        //public static Color Color { get { return color; } }

        public PoisonCrystal()
        {
            texture = Assets.T1Crystal;
            hitbox = new Rectangle(300, 100, 30, 30);
            //center = new Point((int)HitboxPosition.X , (int)HitboxPosition.Y);
            cost = 100;
            defaultRangeRadius = 150;
            rangeRadius = defaultRangeRadius;
            range = new CircleF(HitboxPosition, rangeRadius);
            fireRate = 2;
            minDmg = 10;
            maxDmg = 15;
            crystalColor = color;
        }

        public override void Update()
        {
            //move range to hitbox
            range.Position = HitboxPosition;
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, null, Color.Lime, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            spriteBatch.DrawCircle(range, 100, Color.Gray, 2f, 0.2f);
        }
    }
}
