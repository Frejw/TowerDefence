using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal static class CrystalManager
    {
        static List<Crystal> crystalList = new List<Crystal>();

        public static List<Crystal> CrystalList { get { return crystalList; } }

        public static void Update()
        {
            foreach (Crystal crystal in crystalList)
            {
                crystal.Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Crystal crystal in crystalList)
            {
                crystal.Draw(spriteBatch);
            }
        }

        public static void CreateCrystal(Type crystal)
        {
            crystalList.Add((Crystal)Activator.CreateInstance(crystal));
        }
    }
}
