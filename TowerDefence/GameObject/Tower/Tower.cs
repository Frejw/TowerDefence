using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal abstract class Tower : GameObject
    {
        protected Crystal currentCrystal;
        protected Enemy target;

        protected float shootTimer;
        int towerWidth = 40;
        int towerHeight = 40;

        bool placed = false;

        protected Rectangle hitbox;
        public Rectangle Hitbox { get { return hitbox; } }

        public Vector2 HitboxPosition
        {
            get { return new Vector2(hitbox.X, hitbox.Y); }
            set { hitbox.X = (int)value.X; hitbox.Y = (int)value.Y; }
        }

        public bool Placed { get => placed; set => placed = value; }
        public Crystal CurrentCrystal { get => currentCrystal; set => currentCrystal = value; }


        public Tower()
        {
            //Position = new Vector2(Player.MousePosition.X, Player.MousePosition.Y);
            hitbox = new Rectangle((int)Player.MousePosition.X, (int)Player.MousePosition.Y, towerWidth, towerHeight);
        }

        public abstract void Update(GameTime gameTime);

        #region methods

        //returns true if the tower is within the backgrounds transparent part
        public static bool CanPlace(Tower tower, RenderTarget2D renderTarget)
        {
            Color[] pixels = new Color[tower.texture.Width * tower.texture.Height];
            Color[] pixels2 = new Color[tower.texture.Width * tower.texture.Height];
            tower.texture.GetData<Color>(pixels2);
            renderTarget.GetData(0, tower.hitbox, pixels, 0, pixels.Length);
            for (int i = 0; i < pixels.Length; i++)
            {
                if (pixels[i].A > 0.0f && pixels2[i].A > 0.0f)
                {
                    return false;
                }

            }
            return true;
        }

        public abstract void Shoot();

        #endregion
    }
}
