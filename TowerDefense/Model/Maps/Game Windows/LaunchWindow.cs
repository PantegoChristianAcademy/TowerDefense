using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TowerDefense
{
    public partial class LaunchWindow : Form
    {
        public LaunchWindow()
        {
            InitializeComponent();
            FileCommands.ValidateFiles();
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var screen = e.Graphics;
        }

        #region WhatHappensWhenClickButton
        private void CreateMapButton_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTileSizeWindow tileSizeWindow = new SelectTileSizeWindow();
            tileSizeWindow.ShowDialog();
        }

        private void DeleteMapBtn_MouseClick(object sender, MouseEventArgs e)
        {
            File.WriteAllText(FileCommands.TempMapSelectorActionLocation, "delete");

            MapSelectorWindow mapDeleter = new MapSelectorWindow();
            mapDeleter.ShowDialog();
        }

        private void LoadMapButton_MouseClick(object sender, MouseEventArgs e)
        {
            File.WriteAllText(FileCommands.TempMapSelectorActionLocation, "load");

            MapSelectorWindow mapLoader = new MapSelectorWindow();
            mapLoader.ShowDialog();
        }
        #endregion
    }
}
