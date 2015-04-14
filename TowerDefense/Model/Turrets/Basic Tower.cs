using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Turrets
{
    public class Basic_Tower : Base_Tower
    {
        public Basic_Tower()
        {
            towerImage = (Bitmap)Image.FromFile("Media\\Tower\\BasicTowers\\Turret.bmp");
           Damage = 10;
           Firerate = 2;
           Range = 6;
           Cost = 100;
           ResellPercentage = 60;
           additionaleffect = null;
           TotalCost = Cost;
        }


       public override void Upgrade()
       {
           upgradelevel++;
           switch (upgradelevel)
           {
               case 2:
                    Damage = 20;
                    Firerate = 2.5f;
                    Range = 9;
                    Cost = 75;
                    ResellPercentage = 65;
                    additionaleffect = null;
                    break;
               case 3:
                    Damage = 30;
            Firerate = 3;
            Range = 12;
            Cost = 95;
            ResellPercentage = 70;
            additionaleffect = null;
            break;
           }

           TotalCost = TotalCost + Cost;
       }
    }

    }

