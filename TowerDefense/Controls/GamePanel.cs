using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Runtime.InteropServices;

namespace TowerDefense.Controls
{
    public class GamePanel : Panel
    {
        public static short roundNum = 0;
        public static int timeUntilNextRoundMS = 0;

        public static Map loadedMap;
        TileIdentity[,] loadedMapGrid;
        Timer timer;
        List<Model.Enemies.Enemy> listOfEnemies = new List<Model.Enemies.Enemy>();
        List<Model.Particles.BaseParticle> particles = new List<Model.Particles.BaseParticle>();
        List<Model.Particles.BaseParticle> tempParticles = new List<Model.Particles.BaseParticle>();
        Queue<Model.Enemies.Enemy> enemyQueue = new Queue<Model.Enemies.Enemy>();
        List<Model.Turrets.Base_Tower> listOfTowers = new List<Model.Turrets.Base_Tower>();
        int timeElapsedSinceRoundStart = 0;
        int spawnIntervalinMS = 400;

        public int selectedX = 0;
        public int selectedY = 0;

        public delegate void TileClickHandler(int x, int y);
        public event TileClickHandler TileClick;

        public GamePanel(int Mwidth, int Mheight)
        {
            MouseDown += GamePanel_MouseDown;
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

        void GamePanel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TileClick((int)(e.X / loadedMap.tileSize), (int)(e.Y / loadedMap.tileSize)-1);
            }
            catch { }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (timeUntilNextRoundMS == 0)
            {
                GameWindow._window.RoundTime.Visibility = System.Windows.Visibility.Hidden;

                #region SpawnEnemy
                if (timeElapsedSinceRoundStart >= spawnIntervalinMS && enemyQueue.Count >= 1)
                {
                    timeElapsedSinceRoundStart = 0;
                    Model.Enemies.Enemy newEnemy = enemyQueue.Dequeue();
                    listOfEnemies.Add(newEnemy);
                    newEnemy.SetInitialSpawnLoc(loadedMap.Path);
                }
                #endregion

                if (listOfEnemies.Count >= 1)
                {
                    #region MoveEnemies
                    foreach (Model.Enemies.Enemy tempEnemy in listOfEnemies) tempEnemy.Move(loadedMap.Path);
                    for (int i = 0; i < listOfEnemies.Count; i++)
                    {
                        if (listOfEnemies[i].needToDelete == true)
                        {
                            GameWindow.health -= listOfEnemies[i].damage;
                            listOfEnemies.RemoveAt(i);
                            i--;
                        }
                    }
                    #endregion

                    #region ManageTowers
                    foreach (TowerDefense.Model.Turrets.Base_Tower tower in listOfTowers)
                    {
                        if (tower.timeSinceLastShot > 0)
                        {
                            tower.timeSinceLastShot -= timer.Interval;
                            tower.LoadImage();
                        }

                        else if (tower.timeSinceLastShot <= 0)
                        {
                            tower.timeSinceLastShot = 0;

                            try
                            {
                                tower.selectedEnemy = tower.selectTarget(listOfEnemies, loadedMap);

                                if (tower.selectedEnemy != null)
                                {
                                    Model.Particles.BaseParticle particle = new Model.Particles.BaseParticle(tower, tower.selectedEnemy, loadedMap);
                                    particles.Add(particle);

                                    tower.timeSinceLastShot += tower.Firerate * 1000;
                                }
                            }

                            catch { }
                        }
                    }
                    #endregion

                    #region ManageParticles
                    for (int i = 0; i < particles.Count; i++)
                    {
                        var particle = particles[i];
                        particle.MoveParticle(loadedMap);
                            
                            if (!listOfEnemies.Contains(particle.Target) && listOfEnemies.Count > 1)
                            {
                                particle.Target = listOfEnemies[0];
                            }

                            else if (Math.Abs(particle.posX - particle.Target.x) <= loadedMap.tileSize / 4 && Math.Abs(particle.posY - particle.Target.y) <= loadedMap.tileSize / 4)
                            {
                                particle.Target.Health -= particle.damage;

                                if (particle.Target.Health <= 0)
                                {
                                    GameWindow.balance += particle.Target.Goldgiven;
                                    listOfEnemies.Remove(particle.Target);
                                    tempParticles.Add(new Model.Particles.BaseParticle(particle, particle.Target.x, particle.Target.y));
                                }

                                particles.RemoveAt(i);
                                i--;
                                break;
                            }
                    }
                    #endregion
                }

                else if (listOfEnemies.Count == 0)
                {
                    particles.Clear();

                    #region ManageRounds
                    if (enemyQueue.Count == 0)
                    {
                        roundNum++;
                        enemyQueue = new Queue<Model.Enemies.Enemy>(TowerDefense.Model.Enemy.EnemyFactory.GenerateWave(roundNum, loadedMap.difficulty));
                        timeUntilNextRoundMS = 2000;
                        GameWindow._window.RoundTime.Visibility = System.Windows.Visibility.Visible;
                    }
                    #endregion
                }

                timeElapsedSinceRoundStart += timer.Interval;
            }

            else
            {
                timeUntilNextRoundMS -= timer.Interval;
            }

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

                if (tempTile.GridXLoc == selectedX && tempTile.GridYLoc == selectedY)
                {
                    var originalColor = (tempTile.color as SolidBrush).Color;
                    screen.FillRectangle(new SolidBrush(Color.FromArgb(255,255,255)), tempTile.location.X + 1, tempTile.location.Y + 1, (int)loadedMap.tileSize - 1, (int)loadedMap.tileSize - 1);
                }
                else
                {
                    screen.FillRectangle(tempTile.color, tempTile.location.X + 1, tempTile.location.Y + 1, (int)loadedMap.tileSize - 1, (int)loadedMap.tileSize - 1);
                }
            }


            foreach (Model.Enemies.Enemy tempEnemy in listOfEnemies)
            {
                screen.DrawImage(tempEnemy.enemyImage, tempEnemy.x, tempEnemy.y, (int)loadedMap.tileSize, (int)loadedMap.tileSize);
            }

            foreach (Model.Turrets.Base_Tower tempTower in listOfTowers) screen.DrawImage(tempTower.towerImage, tempTower.PosX, tempTower.PosY, (int)loadedMap.tileSize, (int)loadedMap.tileSize);

            foreach (Model.Particles.BaseParticle particle in particles) screen.DrawImage(particle.Img, new Point(particle.posX, particle.posY));

            foreach (Model.Particles.BaseParticle particle in tempParticles) screen.DrawImage(particle.Img, new Point(particle.posX, particle.posY));

            tempParticles.Clear();
        }

        public Tile GetClickedTile(int x, int y)
        {
            return Tile.DetermineClickedTile(x, y, loadedMap);
        }

        public void AddTowerToListOfTowers(Model.Turrets.Base_Tower tower)
        {
                tower.LoadImage();
                listOfTowers.Add(tower);
        }

        public bool ManagePauseState()
        {
            if (timer.Enabled == true)
            {
                timer.Enabled = false;
                return true;
            }
            else
            {
                timer.Enabled = true;
                return false;
            }
        }
    }
}
