using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class PoisonCrystal : Crystal
    {
        int poisonDamage;
        int poisonDuration;
        Color color = Color.LimeGreen;

        public PoisonCrystal()
        {
            hitbox = new Rectangle(300, 100, 40, 40);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.T1Crystal, Hitbox, color);
        }
    }
}
