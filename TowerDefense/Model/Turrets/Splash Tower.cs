using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Turrets
{
    public class Splash_Tower : Base_Tower
    {
        public Splash_Tower(int selectedXGrid, int selectedYGrid)
        {
            towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SplashTowers\\Splash1.bmp");
            GridX = selectedXGrid;
            GridY = selectedYGrid;
            Damage = 75;
            Firerate = 3f;
            Range = 4;
            Costs[0] = 165;
            Costs[1] = 120;
            Costs[2] = 145;
            ResellPercentage = 60;
            additionaleffect = null;
            BlastRadius = 40;
            TotalCost += Costs[0];
            currentCost = Costs[0];
        }
        public override void Upgrade()
        {
            upgradelevel++;
            switch(upgradelevel)
            {
                case 2:
                    Damage = 125;
                    Firerate = 2f;
                    Range = 7;
                    ResellPercentage = 65;
                    additionaleffect = null;
                    BlastRadius = 50;
                    TotalCost += Costs[1];
                    currentCost = Costs[1];
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SplashTowers\\Splash2.bmp");
                    this.LoadImage();
                    break;
                case 3:
                    Damage = 200;
                    Firerate = 1.5f;
                    Range = 9;
                    ResellPercentage = 70;
                    additionaleffect = null;
                    BlastRadius = 60;
                    TotalCost += Costs[2];
                    currentCost = Costs[2];
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SplashTowers\\Splash3.bmp");
                    this.LoadImage();
                    break;
            }
        }
    }
 }
