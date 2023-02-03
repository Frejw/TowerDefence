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
        protected int health;
        protected float speed;
        protected int armor;
        protected int damage;
        
        protected Rectangle hitbox;

        public abstract void Update(GameTime gameTime);
    }
}
