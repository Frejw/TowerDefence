using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal abstract class Tower : GameObject
    {
        Crystal currentCrystal;

        public Tower()
        {

        }

        public void Update()
        {
            switch (currentCrystal) 
            {
                
            }
        }
    }
}
