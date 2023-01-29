using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Particle
    {
        int width = 5;
        int height = 5;
        float velocity;
        float age = 0;
        float lifeTime = 1f;

        Vector2 position;
        Vector2 direction;
        Rectangle box;

        public float Age { get => age; set => age = value; }
        public float LifeTime { get => lifeTime; set => lifeTime = value; }
        public Vector2 Position { get=> position; set => position = value; }
        public Vector2 Direction { get=> direction; set => direction = value; }

        public Particle(Vector2 position, Vector2 direction)
        {
            this.position = position;
            this.direction = direction;
            velocity = 50;
            box = new Rectangle((int)position.X,(int)position.Y,width,height);
        }

        public void Update(GameTime gameTime)
        {
            position += direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            box.X = (int)position.X;
            box.Y = (int)position.Y;
        }

        Vector2 drawPos = new Vector2(0,500);
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.redTex, box, Color.White);
            
            //spriteBatch.DrawString(Assets.fontArial, "direction" + direction, drawPos, Color.Black);
        }
    }
}
