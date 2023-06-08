using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;

namespace TowerDefence
{
    internal class UI
    {
        public UI()
        {
            
        }

        public static Grid CreateGrid(GraphicsDevice graphics)
        {
            int panelGridColumns = 4;
            int panelGridRows = 12;

            var grid = new Grid
            {
                ShowGridLines = false,
                RowSpacing = 8,
                ColumnSpacing = 8
            };

            grid.ColumnsProportions.Add(new Proportion
            {
                Type = ProportionType.Pixels,
                Value = graphics.Viewport.Bounds.Width - 300
            });
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Part));

            grid.RowsProportions.Add(new Proportion(ProportionType.Part));

            var panel = new Panel();
            panel.Background = new SolidBrush(Color.Gray);
            panel.GridColumn = 1;

            var panelGrid = new Grid
            {
                ShowGridLines= false,
                RowSpacing = 8,
                ColumnSpacing = 8
            };

            for (int i = 0; i < panelGridColumns; i++)
            {
                panelGrid.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            }

            for (int i = 0; i < panelGridRows; i++)
            {
                panelGrid.RowsProportions.Add(new Proportion(ProportionType.Part));
            }
            panel.Widgets.Add(panelGrid);

            //var playerHealth = new Label
            //{
            //    GridColumn = 0,
            //    GridRow = 0,
            //    Text = "Health: " + Player.Health
            //};
            //panelGrid.Widgets.Add(playerHealth);

            //var playerMoney = new Label
            //{
            //    GridColumn = 0,
            //    GridRow = 1,
            //    Text = "$: " + Player.Money
            //};
            //panelGrid.Widgets.Add(playerMoney);

            var nextWave = new TextButton();
            nextWave.GridColumn = 1;
            nextWave.GridRow = 8;
            nextWave.Text = "Start Wave";
            panelGrid.Widgets.Add(nextWave);

            nextWave.TouchDown += (s, a) =>
            {
                EnemyManager.WaveTimer = EnemyManager.TimeBetweenWaves;
            };

            var crystalPicker = new ComboBox
            {
                GridColumn = 1,
                GridRow = 9
            };
            //these items should be created using a list of crystal types, but that doesn't exist yet
            crystalPicker.Items.Add(new ListItem("Normal", PoisonCrystal.color));
            crystalPicker.Items.Add(new ListItem("Type2", Color.Aqua));
            crystalPicker.SelectedItem = crystalPicker.Items[0];
            panelGrid.Widgets.Add(crystalPicker);

            var crystalCreateButton = new TextButton();
            crystalCreateButton.GridColumn = 2;
            crystalCreateButton.GridRow = 9;
            crystalCreateButton.Text = "Create";

            crystalCreateButton.TouchDown += (s, a) =>
            {
                //if (Player.Money > crystalPicker.SelectedItem.)
                //{

                //}
                switch (crystalPicker.SelectedItem.Text)
                {
                    case "Normal":
                        if (Player.Money >= PoisonCrystal.Cost)
                        {
                            CrystalManager.CreateCrystal(typeof(PoisonCrystal));
                            Player.Money -= PoisonCrystal.Cost;
                        }
                        break;
                    case "Type2":
                        {
                            throw new NotImplementedException();
                        }

                    default:
                        throw new NotImplementedException();
                }
                
            };

            panelGrid.Widgets.Add(crystalCreateButton);

            var tower1Button = new TextButton();
            tower1Button.HorizontalAlignment = HorizontalAlignment.Center;
            tower1Button.VerticalAlignment = VerticalAlignment.Center;
            tower1Button.GridColumn = 1;
            tower1Button.GridRow = 10;
            tower1Button.Text = "Normal Tower";
            tower1Button.Width = 70;
            tower1Button.Height = 50;
            tower1Button.Toggleable = false;
            panelGrid.Widgets.Add(tower1Button);

            tower1Button.TouchDown += (s, a) =>
            {
                if (!TowerManager.HasUnPlacedTower)
                {
                    TowerManager.CreateTowerInstance(typeof(NormalTower));
                }
                else
                {
                    foreach (Tower tower in TowerManager.TowerList.Where(tower => !tower.Placed).ToList())
                    {
                        TowerManager.TowerList.Remove(tower);
                    }
                }
            };

            var tower2Button = new TextButton();
            tower2Button.HorizontalAlignment = HorizontalAlignment.Center;
            tower2Button.VerticalAlignment = VerticalAlignment.Center;
            tower2Button.GridColumn = 2;
            tower2Button.GridRow = 10;
            tower2Button.Text = "AoE Tower";
            tower2Button.Width = 70;
            tower2Button.Height = 50;
            panelGrid.Widgets.Add(tower2Button);

            tower2Button.TouchDown += (s, a) =>
            {
                if (!TowerManager.HasUnPlacedTower)
                {
                    TowerManager.CreateTowerInstance(typeof(AoeTower));
                }
                else
                {
                    foreach (Tower tower in TowerManager.TowerList.Where(tower => !tower.Placed).ToList())
                    {
                        TowerManager.TowerList.Remove(tower);
                    }
                }
            };
            
            //var helloWorld = new Label
            //{
            //    GridColumn = 1,
            //    GridRow = 1,
            //    Id = "label",
            //    Text = "Hello, World!"
            //};
            //grid.Widgets.Add(helloWorld);

            //// ComboBox
            //var combo = new ComboBox
            //{
            //    GridColumn = 1,
            //    GridRow = 0
            //};

            //combo.Items.Add(new ListItem("Red", Color.Red));
            //combo.Items.Add(new ListItem("Green", Color.Green));
            //combo.Items.Add(new ListItem("Blue", Color.Blue));
            //grid.Widgets.Add(combo);

            //// Button
            //var button = new TextButton
            //{
            //    GridColumn = 1,
            //    GridRow = 1,
            //    Text = "Show"
            //};

            //button.Click += (s, a) =>
            //{
            //    var messageBox = Dialog.CreateMessageBox("Message", "Some message!");
            //    messageBox.ShowModal(gameplayManager.desktop);
            //};

            //grid.Widgets.Add(button);

            //// Spin button
            //var spinButton = new SpinButton
            //{
            //    GridColumn = 1,
            //    GridRow = 1,
            //    Width = 100,
            //    Nullable = true
            //};
            //grid.Widgets.Add(spinButton);

            grid.Widgets.Add(panel);

            return grid;
        }

        private static void Tower2Button_TouchDown1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Tower2Button_TouchDown(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Tower1Button_TouchDown(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void LoadContent()
        {
            
            var grid = new Grid
            {
                RowSpacing = 8,
                ColumnSpacing = 8
            };

            //grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            //grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            //grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            //grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            var helloWorld = new Label
            {
                Id = "label",
                Text = "Hello, World!"
            };
            grid.Widgets.Add(helloWorld);

            // ComboBox
            var combo = new ComboBox
            {
                GridColumn = 1,
                GridRow = 0
            };

            combo.Items.Add(new ListItem("Red", Color.Red));
            combo.Items.Add(new ListItem("Green", Color.Green));
            combo.Items.Add(new ListItem("Blue", Color.Blue));
            grid.Widgets.Add(combo);

            // Button
            var button = new TextButton
            {
                GridColumn = 0,
                GridRow = 1,
                Text = "Show"
            };

            button.Click += (s, a) =>
            {
                var messageBox = Dialog.CreateMessageBox("Message", "Some message!");
                messageBox.ShowModal(gameplayManager.desktop);
            };

            grid.Widgets.Add(button);

            // Spin button
            var spinButton = new SpinButton
            {
                GridColumn = 1,
                GridRow = 1,
                Width = 100,
                Nullable = true
            };
            grid.Widgets.Add(spinButton);

            // Add it to the desktop
            //gameplayManager.desktop.Root = grid;
        }

    }
}
