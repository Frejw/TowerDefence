using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        //protected Vector2 position;
        

        public Texture2D Texture { get { return texture; } }
        
        

        public GameObject()
        {
               
        }

        

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
