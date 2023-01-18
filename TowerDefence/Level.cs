using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spline;

namespace TowerDefence
{
    internal class Level
    {
        Vector2[] levelPoints =
        {
            new Vector2(100, 0),
            new Vector2(100, 300),
            new Vector2(900,300),
            new Vector2(900,500),
            new Vector2(600, 500),
            new Vector2(600, 700),
            new Vector2(1000, 700),
            new Vector2(1000, 0)
        };

        public Level()
        {
            Assets.enemyPath.Clean();
            foreach (Vector2 point in levelPoints)
            {
                Assets.enemyPath.AddPoint(point);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Assets.enemyPath.Draw(spriteBatch);
            Assets.enemyPath.DrawPoints(spriteBatch);
        }
    }
}
