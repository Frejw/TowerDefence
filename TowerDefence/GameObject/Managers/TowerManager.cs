using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal static class TowerManager
    {
        static List<Tower> towerList= new List<Tower>();
        static bool hasUnPlacedTower = false;

        public static List<Tower> TowerList { get { return towerList; } }
        public static bool HasUnPlacedTower { get { return hasUnPlacedTower; } }

        public static void Update()
        {
            hasUnPlacedTower = towerList.Any(t => t.Placed == false) ? true : false;

            foreach (Tower tower in towerList)
            {
                if (!tower.Placed)
                {
                    //probably suboptimal way of setting the offset
                    Vector2 mouseOffset = new Vector2(tower.Texture.Width / 2, tower.Texture.Height / 2);
                    tower.HitboxPosition = Player.MousePosition - mouseOffset;
                }
            }

            //if (HasUnPlacedTower)
            //{
            //    if (KeyMouseReader.KeyPressed(Keys.D2))
            //    {
            //        foreach (Tower tower in towerList.Where(tower => !tower.Placed))
            //        {
                        
            //            if (Tower.CanPlace(tower))
            //            {
            //                tower.Placed = true;
            //                gameplayManager.level1.DrawRenderTarget(Assets.normalTowerTex, tower.HitboxPosition);
            //            }
            //        }
            //    }
            //}
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tower tower in towerList)
            {
                tower.Draw(spriteBatch);
            }
        }


        #region methods

        //takes a Type typeof(child of Tower) and creates a new Tower instance of that type
        public static void CreateTowerInstance(Type tower)
        {
            towerList.Add((Tower)Activator.CreateInstance(tower));
        }

        #endregion
    }
}
