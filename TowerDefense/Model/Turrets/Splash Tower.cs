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
            Damage = 25;
            Firerate = 1;
            Range = 15;
            Cost = 165;
            ResellPercentage = 60;
            additionaleffect = null;
            BlastRadius = 40;
        }
        public override void Upgrade()
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
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SplashTowers\\Splash2.bmp");
                    this.LoadImage();
                    break;
                case 3:
                    Damage = 75;
                    Firerate = 1;
                    Range = 21;
                    Cost = 145;
                    ResellPercentage = 70;
                    additionaleffect = null;
                    BlastRadius = 60;
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SplashTowers\\Splash3.bmp");
                    this.LoadImage();
                    break;
            }
            TotalCost = TotalCost + Cost;
        }
    }
 }
