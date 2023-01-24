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
            if (!TowerManager.HasUnPlacedTower)
            {
                if (KeyMouseReader.KeyPressed(Keys.D1))
                {
                    TowerManager.CreateTowerInstance(typeof(NormalTower));
                }
            }
            else
            {
                if (KeyMouseReader.KeyPressed(Keys.D1))
                {
                    foreach (Tower tower in TowerManager.TowerList.Where(tower => !tower.Placed))
                    {

                        if (Tower.CanPlace(tower))
                        {
                            tower.Placed = true;
                            gameplayManager.level1.DrawRenderTarget(Assets.normalTowerTex, tower.HitboxPosition);
                        }
                    }
                }
            }

            
            
        }
    }
}
