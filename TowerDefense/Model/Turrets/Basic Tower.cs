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
        public Basic_Tower(int selectedXGrid, int selectedYGrid)
        {
           towerImage = (Bitmap)Image.FromFile("Media\\Tower\\BasicTowers\\Turret.bmp");
           GridX = selectedXGrid;
           GridY = selectedYGrid;
           Damage = 5;
           Firerate = 1F;
           Range = 2;
            Costs[0] = 100;
            Costs[1] = 75;
            Costs[2] = 95;
           ResellPercentage = 60;
           currentCost = Costs[0];
           TotalCost += Costs[0];
           additionaleffect = null;
        }


       public override void Upgrade()
       {
           upgradelevel++;
           switch (upgradelevel)
           {
               case 2:
                    Damage = 20;
                    Firerate = .5f;
                    Range = 9;
                    ResellPercentage = 65;
                    currentCost = Costs[1];
                    TotalCost += Costs[1];
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\BasicTowers\\Turret2.bmp");
                    this.LoadImage();
                    additionaleffect = null;
                    break;
               case 3:
                    Damage = 30;
                    Firerate = .1f;
                    Range = 12;
                    ResellPercentage = 70;
                    currentCost = Costs[2];
                    TotalCost += Costs[2];
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\BasicTowers\\Turret3.bmp");
                    this.LoadImage();
                    additionaleffect = null;
                break;
           }
       }
    }

    }

