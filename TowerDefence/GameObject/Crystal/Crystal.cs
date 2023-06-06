using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace TowerDefence
{
    internal abstract class Crystal : GameObject
    {
        int projectileVelocity;

        protected int minDmg;
        protected int maxDmg;
        protected float fireRate;

        public float Damage
        {
            get { return new Random().Next(minDmg, maxDmg); }
        }
        public float FireRate { get { return fireRate; } }

        protected float rangeRadius;

        protected bool inTower;

        public bool InTower { get { return inTower; } set { inTower = value; } }

        //change to circle
        protected Rectangle hitbox;
        public Rectangle Hitbox { get { return hitbox; } }
        public Vector2 HitboxPosition
        {
            get { return new Vector2(hitbox.X, hitbox.Y); }
            set { hitbox.X = (int)value.X; hitbox.Y = (int)value.Y; }
        }

        protected Point center;
        protected CircleF range;
        public CircleF Range { get { return range; } }

        public abstract void Update();

        //public abstract void Shoot();

    }
}
