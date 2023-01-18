using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal abstract class GameObject
    {
        protected Texture2D texture;
        protected Vector2 position;

        public GameObject()
        {

        }

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
