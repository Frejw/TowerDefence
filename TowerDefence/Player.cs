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
    public static class Player
    {
        static int health = 100;
        static int money = 500;

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

            if (health <= 0)
            {
                Game1.currentGameState = Game1.gameState.EndScreen;
            }

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
                                if (money >= tower.Cost)
                                {
                                    tower.Placed = true;
                                    money -= tower.Cost;
                                    gameplayManager.level1.DrawRenderTarget(tower.Texture, tower.HitboxPosition);
                                }
                            }
                        }
                    }
                }
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
                                tower.CurrentCrystal.RangeRadius = tower.CurrentCrystal.DefaultRangeRadius;
                                tower.CurrentCrystal = null;
                            }
                        }
                    }
                }
            }
            
            if (heldObject != null)
            {
                heldObject.HitboxPosition = mousePosition;

                if (mouseState.LeftButton == ButtonState.Released)
                {
                    foreach (Tower tower in TowerManager.TowerList)
                    {
                        if (heldObject.Hitbox.Intersects(tower.Hitbox))
                        {
                            if (tower.CurrentCrystal == null)
                            {
                                tower.CurrentCrystal = heldObject;
                                tower.CurrentCrystal.RangeRadius *= tower.RangeMultiplier;
                                tower.CurrentCrystal.RangeCircleRad = tower.CurrentCrystal.RangeRadius;
                                heldObject.HitboxPosition = tower.HitboxPosition + new Vector2(tower.Hitbox.Width/2, tower.Hitbox.Height/2);
                                heldObject.InTower = true;
                            }
                        }
                    }
                    heldObject = null;
                }
            }
            
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Assets.fontArial, "Health: " + Health, new Vector2(1300, 20), Color.Red);
            spriteBatch.DrawString(Assets.fontArial, "Money: " + Money, new Vector2(1300, 40), Color.Red);
        }
    }
}
