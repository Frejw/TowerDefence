using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public static class Player
    {
        static int health = 100;
        static int money = 300;

        static MouseState mouseState;
        static Vector2 mousePosition;

        static Crystal heldObject;

        public static MouseState MouseState { get { return mouseState; } }
        public static Vector2 MousePosition { get { return mousePosition; } }

        public static int Health { get { return health; } set { health = value; } }
        public static int Money { get { return money; } set { money = value; } }

        public static void Update() 
        {
            mouseState = Mouse.GetState();
            mousePosition.X = mouseState.X;
            mousePosition.Y = mouseState.Y;

            //this could be moved to TowerManager
            //Creates new tower if there are no unplaced towers
            if (TowerManager.HasUnPlacedTower)
            {
                if (KeyMouseReader.LeftClick())
                {
                    foreach (Tower tower in TowerManager.TowerList.Where(tower => !tower.Placed))
                    {

                        if (Tower.CanPlace(tower, gameplayManager.level1.renderTarget))
                        {
                            if (Tower.CanPlace(tower, Assets.UITarget))
                            {
                                tower.Placed = true;
                                gameplayManager.level1.DrawRenderTarget(tower.Texture, tower.HitboxPosition);
                            }
                            
                        }
                    }
                }
            }

            //if (!TowerManager.HasUnPlacedTower)
            //{
            //    if (KeyMouseReader.KeyPressed(Keys.D1))
            //    {
            //        TowerManager.CreateTowerInstance(typeof(NormalTower));
            //    }
            //}
            ////else places unplaced tower
            //else
            //{
            //    if (KeyMouseReader.KeyPressed(Keys.D1))
            //    {
            //        foreach (Tower tower in TowerManager.TowerList.Where(tower => !tower.Placed))
            //        {

            //            if (Tower.CanPlace(tower))
            //            {
            //                tower.Placed = true;
            //                gameplayManager.level1.DrawRenderTarget(tower.Texture, tower.HitboxPosition);
            //            }
            //        }
            //    }
            //}

            //Creates new poison crystal
            if (KeyMouseReader.KeyPressed(Keys.D2))
            {
                CrystalManager.CreateCrystal(typeof(PoisonCrystal));
            }

            if (KeyMouseReader.LeftClick())
            {
                foreach (Crystal crystal in CrystalManager.CrystalList)
                {
                    if (crystal.Hitbox.Contains(MousePosition))
                    {
                        heldObject = crystal;
                        heldObject.InTower = false;
                        foreach (Tower tower in TowerManager.TowerList)
                        {
                            if (tower.CurrentCrystal == heldObject)
                            {
                                tower.CurrentCrystal = null;
                            }
                        }
                    }
                }
            }
            
            if (heldObject != null)
            {
                mousePosition.X -= heldObject.Hitbox.Width / 2;
                mousePosition.Y -= heldObject.Hitbox.Height / 2;
                heldObject.HitboxPosition = mousePosition;

                if (mouseState.LeftButton == ButtonState.Released)
                {
                    foreach (Tower tower in TowerManager.TowerList)
                    {
                        if (heldObject.Hitbox.Intersects(tower.Hitbox))
                        {
                            tower.CurrentCrystal = heldObject;
                            heldObject.HitboxPosition = tower.HitboxPosition;
                            heldObject.InTower = true;
                        }
                    }
                    heldObject = null;
                }
            }

            //Drag&Drop Crystals
            //foreach (Crystal crystal in CrystalManager.CrystalList)
            //{
            //    if (crystal.Hitbox.Contains(MousePosition))
            //    {
            //        if (mouseState.LeftButton == ButtonState.Pressed)
            //        {
            //            //crystal.hitbox to mouse.position
            //            //change to if leftmouse down, get clicked object, set clicked object to object
            //        }
            //    }
            //}
            
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Assets.fontArial, "Health: " + Health, new Vector2(1300, 20), Color.Red);
            spriteBatch.DrawString(Assets.fontArial, "Money: " + Money, new Vector2(1300, 40), Color.Red);
        }
    }
}
