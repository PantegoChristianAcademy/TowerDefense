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
        List<Model.Enemies.Enemy> listOfEnemies = new List<Model.Enemies.Enemy>();
         Queue<Model.Enemies.Enemy> enemyQueue = new Queue<Model.Enemies.Enemy>();
        List<Model.Turrets.Base_Tower> listOfTowers = new List<Model.Turrets.Base_Tower>();
        int timeElapsedSinceRoundStart = 0;
        int spawnIntervalinMS = 400;
        int roundNum = 0;

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

            //supposed to go at beginning of each round
            enemyQueue = new Queue<Model.Enemies.Enemy>(TowerDefense.Model.Enemy.EnemyFactory.GenerateWave(0, loadedMap.difficulty));        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (timeElapsedSinceRoundStart >= spawnIntervalinMS && enemyQueue.Count >= 1)
            {
                timeElapsedSinceRoundStart = 0;
                Model.Enemies.Enemy newEnemy = enemyQueue.Dequeue();
                listOfEnemies.Add(newEnemy);
                newEnemy.SetInitialSpawnLoc(loadedMap.Path);
            }

            foreach (Model.Enemies.Enemy tempEnemy in listOfEnemies) tempEnemy.Move(loadedMap.Path);
            for (int i = 0; i < listOfEnemies.Count; i++ )
            {
                if(listOfEnemies[i].needToDelete == true)
                {
                    listOfEnemies.RemoveAt(i);
                    i--;
                }
            }

                timeElapsedSinceRoundStart += timer.Interval;
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

            foreach (Model.Enemies.Enemy tempEnemy in listOfEnemies) screen.DrawImage(tempEnemy.enemyImage, tempEnemy.x, tempEnemy.y, (int)loadedMap.tileSize, (int)loadedMap.tileSize);
        }
    }
}
