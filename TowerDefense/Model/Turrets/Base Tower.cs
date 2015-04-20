using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Turrets
{
    public abstract class Base_Tower
    {
        public Bitmap towerImage;
        public Model.Enemies.Enemy selectedEnemy;

        public Enemies.Enemy selectTarget(List<Enemies.Enemy> enemyLS, Map map)
        {
            List<Enemies.Enemy> tempEnemyLS = new List<Enemies.Enemy>();

            Enemies.Enemy chosenEnemy = null;

            //Calculate in range
            foreach (Enemies.Enemy Temp in enemyLS)
            {
                Point midTower = new Point((int)(PosX + map.tileSize / 2), (int)(PosY + map.tileSize / 2));
                Point midEnemy = new Point((int)(Temp.x + map.tileSize / 2), (int)(Temp.y + map.tileSize / 2));

                if(Math.Abs(midTower.X - midEnemy.X) <= Range * map.tileSize && Math.Abs(midTower.Y - midEnemy.Y) <= Range * map.tileSize)
                {
                    tempEnemyLS.Add(Temp);
                }
            }

            //Calculate farthest one
            int farthestPlaceInPath = 0;
            int fastestEnemySpeed = 0;
            foreach(var Temp in tempEnemyLS)
            {
                if (this is Slowing_tower)
                {
                    if (Temp.Speed > fastestEnemySpeed) chosenEnemy = Temp;
                    if (Temp.Speed == fastestEnemySpeed && chosenEnemy != null)
                    {
                        if (Temp.Speed > chosenEnemy.Speed) chosenEnemy = Temp;
                    }

                    fastestEnemySpeed = chosenEnemy.Speed;
                }

                else
                {
                    if (Temp.placeInPath > farthestPlaceInPath) chosenEnemy = Temp;
                    if (Temp.placeInPath == farthestPlaceInPath && chosenEnemy != null)
                    {
                        if (Temp.Health > chosenEnemy.Health) chosenEnemy = Temp;
                    }

                    farthestPlaceInPath = chosenEnemy.placeInPath;
                }
            }

            return chosenEnemy;
        }

        public void LoadImage()
        {
            towerImage.MakeTransparent(Color.FromArgb(255, 174, 201));
        }

        public int Damage;
        // How much damage the turret does
        public float Firerate;
        // how many shots per second
        public float timeSinceLastShot = 0;
        public int Range;
        // radius from turret in 
        public int Cost;
        public int TotalCost;
        // How much gold/money/whatever a turret costs
        public int SlowPercent;
        // How much each shot slows an enemy up to a cap
        public int DoT;
        // How much damage per second each shot deals
        public int BlastRadius;
        public int PosX;
        public int PosY;
        public int GridX;
        public int GridY;
        // How much % damage each shot does spread from the 
        public int Resell
        {
            get
            {
                return ResellPercentage * Cost;
            }
        }
        public int ResellPercentage;
        public string additionaleffect;
        public int upgradelevel = 1;
        public abstract void Upgrade();
    }
}
