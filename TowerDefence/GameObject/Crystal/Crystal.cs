using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TowerDefence
{
    internal abstract class Crystal : GameObject
    {
        int projectileVelocity;

        int minDmg;
        int maxDmg;

        //change to circle
        protected Rectangle hitbox;
        public Rectangle Hitbox { get { return hitbox; } }
        public Vector2 HitboxPosition
        {
            get { return new Vector2(hitbox.X, hitbox.Y); }
            set { hitbox.X = (int)value.X; hitbox.Y = (int)value.Y; }
        }




    }
}
