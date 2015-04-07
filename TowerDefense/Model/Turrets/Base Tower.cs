using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Turrets
{
    public abstract class Base_Tower
    {
        public int Damage;
        // How much damage the turret does
        public float Firerate;
        // how many shots per second
        public int Range;
        // radius from turret in 
        public int Cost;
        // How much gold/money/whatever a turret costs
        public int TotalCost;
        //
        public int SlowPercent;
        public int DoT;
        public int BlastRadius;
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
