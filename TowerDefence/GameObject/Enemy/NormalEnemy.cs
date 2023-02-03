using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefence
{
    internal class NormalEnemy : Enemy
    {
        float curveCurPos = 0;
        Vector2 position;
        public NormalEnemy()
        {
            texture = Assets.normalEnemyTex;
            hitbox = new Rectangle(0,0,texture.Width,texture.Height);
            speed = 0.01f;
        }

        public override void Update(GameTime gameTime)
        {
            curveCurPos += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (curveCurPos > 1.0f)
            {
                //this is for code when you get to the end of the path
                Player.Health -= damage;
            }

            position = gameplayManager.level1.EnemyPath.EvaluateAt(curveCurPos);

            hitbox.X = (int)position.X - hitbox.Width/2;
            hitbox.Y = (int)position.Y - hitbox.Height/2;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
    }
}
