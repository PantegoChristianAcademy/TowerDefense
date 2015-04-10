using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TowerDefense.Controls
{
    public class GamePanel : Panel
    {
        Map loadedMap;
        TileIdentity[,] loadedMapGrid;
        Timer timer;
        List<Model.Enemies.Plane> listOfGabens = new List<Model.Enemies.Plane>();

        public GamePanel(int Mwidth, int Mheight)
        {
            DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();

            string mapLocation = File.ReadAllText(FileCommands.TempMapLocation);
            File.Delete(FileCommands.TempMapLocation);

            loadedMapGrid = FileCommands.ReadMapFile(mapLocation);
            loadedMap = new Map();
            loadedMap.GenerateLoadedMap(Mwidth, Mheight, loadedMapGrid);

            string mapPathLocation = mapLocation.Remove(mapLocation.Length - 4) + "$$$###$$$.txt";
            loadedMap.Path = FileCommands.ReadMapPathFile(loadedMap, mapPathLocation);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (listOfGabens.Count <= 1)
            {
                Model.Enemies.Plane freshGaben = new Model.Enemies.Plane();
                freshGaben.SetInitialSpawnLoc(loadedMap.Path);
                listOfGabens.Add(freshGaben);
            }

            foreach (Model.Enemies.Plane tempGaben in listOfGabens) tempGaben.Move(loadedMap.Path);

            this.Invalidate();
        }

        public new void Resize(int width, int height)
        {
            loadedMap.Resize(width, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var screen = e.Graphics;

            foreach (Tile tempTile in loadedMap.MapGrid)
            {
                screen.DrawRectangle(Tile.TileOutlineColor, tempTile.location.X, tempTile.location.Y, (int)loadedMap.tileSize, (int)loadedMap.tileSize);
                screen.FillRectangle(tempTile.color, tempTile.location.X + 1, tempTile.location.Y + 1, (int)loadedMap.tileSize - 1, (int)loadedMap.tileSize - 1);
            }

            foreach (Model.Enemies.Plane tempGaben in listOfGabens) screen.DrawImage(tempGaben.enemyImage, tempGaben.x, tempGaben.y, (int)loadedMap.tileSize, (int)loadedMap.tileSize);
        }
    }
}
