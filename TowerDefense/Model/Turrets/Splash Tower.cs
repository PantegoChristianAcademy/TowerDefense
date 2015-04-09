using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Turrets
{
    class Splash_Tower : Base_Tower
    {
        public Splash_Tower()
        {
            Damage = 25;
            Firerate = 1;
            Range = 15;
            Cost = 165;
            ResellPercentage = 60;
            additionaleffect = null;
            BlastRadius = 40;
        }
        public override void upgrade()
        {
            upgradelevel++;
            switch(upgradelevel)
            {
                case 2:
                    Damage = 50;
                    Firerate = 1;
                    Range = 18;
                    Cost = 120;
                    ResellPercentage = 65;
                    additionaleffect = null;
                    BlastRadius = 50;
                    break;
                case 3:
                    Damage = 75;
                    Firerate = 1;
                    Range = 21;
                    Cost = 145;
                    ResellPercentage = 70;
                    additionaleffect = null;
                    BlastRadius = 60;
                    break;
            }
            TotalCost = TotalCost + Cost;
        }
    }
 }
