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




    }
}
