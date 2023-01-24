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
        protected Rectangle hitbox;

        public Texture2D Texture { get { return texture; } }
        public Rectangle Hitbox { get { return hitbox; } }

        //public Vector2 Position { get => position; set => position = value; }
        public Vector2 HitboxPosition 
        {
            get { return new Vector2(hitbox.X, hitbox.Y); }
            set { hitbox.X = (int)value.X; hitbox.Y = (int)value.Y; }
        }
        

        public GameObject()
        {
               
        }

        

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
