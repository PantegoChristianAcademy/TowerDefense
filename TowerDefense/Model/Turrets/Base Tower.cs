using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Turrets
{
    public abstract class Base_Tower
    {
        public Enemies.Enemy selectTarget(List<Enemies.Enemy> LS, loadedMap.Path)

        public int Damage;
        // How much damage the turret does
        public float Firerate;
        // how many shots per second
        public int Range;
        // radius from turret in 
        public int Cost;
        // How much gold/money/whatever a turret costs
        public int TotalCost;
        public int SlowPercent;
        // How much each shot slows an enemy up to a cap
        public int DoT;
        // How much damage per second each shot deals
        public int BlastRadius;
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
