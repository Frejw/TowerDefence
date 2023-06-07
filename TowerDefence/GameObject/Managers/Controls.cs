using Microsoft.Xna.Framework;
using MonoGame.UI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Controls : ControlManager
    {
        public Controls(Game game) : base(game)
        {

        }

        public override void InitializeComponent()
        {
            var btnPlay = new Button
            {
                Text = "Play",
                Size = new Vector2(200, 50),
                Location = new Vector2(500, 200),
                BackgroundColor = Color.DarkBlue
            };

            btnPlay.Clicked += BtnPlay_Clicked;
            Controls.Add(btnPlay);

            var btnQuit = new Button
            {
                Text = "Quit",
                Size = new Vector2(200, 50),
                Location = new Vector2(500, 270),
                BackgroundColor = Color.DarkBlue
            };

            btnQuit.Clicked += BtnQuit_Clicked;
            Controls.Add(btnQuit);
        }

        private void BtnPlay_Clicked(object sender, EventArgs e) 
        {   
            Game1.currentGameState = Game1.gameState.Playing;
        }

        private void BtnQuit_Clicked(object sender, EventArgs e)
        {
            Game.Exit();
        }
    }
}
