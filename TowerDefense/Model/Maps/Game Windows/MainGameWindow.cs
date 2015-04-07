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

        public MainGameWindow()
        {
            InitializeComponent();
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
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
        }

        private void MainGameWindow_Load(object sender, EventArgs e)
        {
            string mapLocation = File.ReadAllText(FileCommands.TempMapLocation);
            loadedMapGrid = FileCommands.ReadMapFile(mapLocation);
            File.Delete(FileCommands.TempMapLocation);

            loadedMap = new Map();
            loadedMap.GenerateLoadedMap(ClientSize.Width, ClientSize.Height, loadedMapGrid);
        }
    }
}
