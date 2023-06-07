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
        protected Color crystalColor;

        public float Damage
        {
            get { return new Random().Next(minDmg, maxDmg); }
        }
        public float FireRate { get { return fireRate; } }

        protected float defaultRangeRadius;
        protected float rangeRadius;

        public float DefaultRangeRadius { get { return defaultRangeRadius; } }
        public float RangeRadius { get { return rangeRadius; } set { rangeRadius = value; } }

        protected bool inTower;

        public bool InTower { get { return inTower; } set { inTower = value; } }

        public Color CrystalColor { get { return crystalColor; } }

        //change to circle
        protected Rectangle hitbox;
        public Rectangle Hitbox { get { return hitbox; } }
        public Vector2 HitboxPosition
        {
            get { return new Vector2(hitbox.X + hitbox.Width/2, hitbox.Y + hitbox.Height/2); }
            set { hitbox.X = (int)value.X - hitbox.Width/2; hitbox.Y = (int)value.Y - hitbox.Height/2; }
        }

        protected Point center;
        protected CircleF range;
        public CircleF RangeCircle { get { return range; } set { range = value; } }
        public float RangeCircleRad { get { return range.Radius; } set { range.Radius = value; } }

        public abstract void Update();

        //public abstract void Shoot();

    }
}
