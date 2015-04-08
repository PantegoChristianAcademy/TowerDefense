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
    public partial class MainGameWindow : Form
    {
        Map loadedMap;
        TileIdentity[,] loadedMapGrid;
        List<Model.Enemies.Gaben> listOfGabens = new List<Model.Enemies.Gaben>();

        public MainGameWindow()
        {
            InitializeComponent();
        }

        private void MainGameWindow_Load(object sender, EventArgs e)
        {
            string mapLocation = File.ReadAllText(FileCommands.TempMapLocation);
            File.Delete(FileCommands.TempMapLocation);

            loadedMapGrid = FileCommands.ReadMapFile(mapLocation);
            loadedMap = new Map();
            loadedMap.GenerateLoadedMap(ClientSize.Width, ClientSize.Height, loadedMapGrid);

            string mapPathLocation = mapLocation.Remove(mapLocation.Length - 4) + "$$$###$$$.txt";
            loadedMap.Path = FileCommands.ReadMapPathFile(loadedMap, mapPathLocation);
        }


        private void Refresh_Tick(object sender, EventArgs e)
        {
            if (listOfGabens.Count <= 3)
            {
                Model.Enemies.Gaben freshGaben = new Model.Enemies.Gaben();
                freshGaben.SetInitialSpawnLoc(loadedMap.Path);
                listOfGabens.Add(freshGaben);
            }

            foreach (Model.Enemies.Gaben tempGaben in listOfGabens) tempGaben.Move(loadedMap.Path);

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var screen = e.Graphics;

            foreach (Tile tempTile in loadedMap.MapGrid)
            {
                screen.DrawRectangle(Tile.TileOutlineColor, tempTile.location.X, tempTile.location.Y, (int)loadedMap.tileSize, (int)loadedMap.tileSize);
                screen.FillRectangle(tempTile.color, tempTile.location.X + 1, tempTile.location.Y + 1, (int)loadedMap.tileSize - 1, (int)loadedMap.tileSize - 1);
            }

            foreach (Model.Enemies.Gaben tempGaben in listOfGabens) screen.FillEllipse(Brushes.Red, tempGaben.x, tempGaben.y, (int)loadedMap.tileSize, (int)loadedMap.tileSize);
        }
    }
}
