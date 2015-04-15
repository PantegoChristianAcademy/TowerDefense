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

        public Enemies.Enemy selectTarget(List<Enemies.Enemy> LS, Map map)
        {
            Dictionary<Point, Enemies.Enemy> Dict = new Dictionary<Point, Enemies.Enemy>();
           foreach (Enemies.Enemy Temp in LS)
           {
               Point pos = new Point(Temp.x, Temp.y);
               if(!Dict.ContainsKey(pos)) Dict.Add(pos, Temp);
           }
           List<Point> points = new List<Point>();


            for (int x = PosX - Range; x < PosX + Range; x++)
            {
                for (int y = PosY - Range; y < PosY + Range; y++)
                {
                    if (Dict.ContainsKey(new Point(x, y)))
                    {
                        points.Add(new Point(x, y));

                    }
                }
            }

            var ls = new List<Tile>(map.Path);
            ls.Reverse();
           foreach (Tile temp in ls)
           {
               if (points.Contains(temp.location)) return Dict[temp.location];
           }
           return null;
        }

        public void LoadImage()
        {
            towerImage.MakeTransparent(Color.FromArgb(255, 174, 201));
        }

        public int Damage;
        // How much damage the turret does
        public float Firerate;
        // how many shots per second
        public int timeSinceLastShot = 0;
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
