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
        protected float maxHealth;
        protected float speed;
        protected int armor;
        protected int damage;
        protected int killValue;
        protected float curveCurPos = 0;
        protected Vector2 position;
        public float CurveCurPos { get { return curveCurPos; } set { curveCurPos = value; } }
        public float Health { get { return health; } }
        public float MaxHealth { get { return maxHealth; } }
        public int KillValue { get { return killValue; } }
        public int Damage { get { return damage; } }
        public float Speed { get { return speed; } }
        public Vector2 Position { get { return position; } set { position = value; } }

        protected Rectangle hitbox;

        public Rectangle Hitbox { get { return hitbox; } }

        public abstract void Update(GameTime gameTime);

        public abstract void TakeDamage(float damage);
    }
}
