using Microsoft.Xna.Framework;
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
        static MouseState mouseState;
        static Vector2 mousePosition;

        public static MouseState MouseState { get { return mouseState; } }
        public static Vector2 MousePosition { get { return mousePosition; } }

        public static void Update() 
        {
            mouseState = Mouse.GetState();
            mousePosition.X = mouseState.X;
            mousePosition.Y = mouseState.Y;

            //this could be moved to TowerManager
            //Creates new tower if there are no unplaced towers
            if (!TowerManager.HasUnPlacedTower)
            {
                if (KeyMouseReader.KeyPressed(Keys.D1))
                {
                    TowerManager.CreateTowerInstance(typeof(NormalTower));
                }
            }
            //else places unplaced tower
            else
            {
                if (KeyMouseReader.KeyPressed(Keys.D1))
                {
                    foreach (Tower tower in TowerManager.TowerList.Where(tower => !tower.Placed))
                    {

                        if (Tower.CanPlace(tower))
                        {
                            tower.Placed = true;
                            gameplayManager.level1.DrawRenderTarget(tower.Texture, tower.HitboxPosition);
                        }
                    }
                }
            }

            //Creates new poison crystal
            if (KeyMouseReader.KeyPressed(Keys.D2))
            {
                CrystalManager.CreateCrystal(typeof(PoisonCrystal));
            }

            //Drag&Drop Crystals
            foreach (Crystal crystal in CrystalManager.CrystalList)
            {
                if (crystal.Hitbox.Contains(MousePosition))
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        //crystal.hitbox to mouse.position
                        //change to if leftmouse down, get clicked object, set clicked object to object
                    }
                }
            }
            
        }
    }
}
