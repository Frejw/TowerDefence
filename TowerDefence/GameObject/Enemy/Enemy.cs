using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal abstract class Enemy : GameObject
    {
        protected float health;
        protected float speed;
        protected int armor;
        protected int damage;
        protected int killValue;
        protected float curveCurPos = 0;
        public float CurveCurPos { get { return curveCurPos; } }
        public float Health { get { return health; } }
        public int KillValue { get { return killValue; } }

        protected Rectangle hitbox;

        public Rectangle Hitbox { get { return hitbox; } }

        public abstract void Update(GameTime gameTime);

        public abstract void TakeDamage(float damage);
    }
}
