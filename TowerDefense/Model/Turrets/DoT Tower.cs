using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Turrets
{
    public class DoT_Tower : Base_Tower
    {
        public DoT_Tower(int selectedXGrid, int selectedYGrid)
        {
            burnDuration = 1;
            
            towerImage = (Bitmap)Image.FromFile("Media\\Tower\\DoTTowers\\DoT.bmp");
            GridX = selectedXGrid;
            GridY = selectedYGrid;
            Damage = 1.5f;
            Firerate = 2;
            Range = 5;
            Costs[0] = 100;
            Costs[1] = 125;
            Costs[2] = 150;
            ResellPercentage = 60;
            currentCost = Costs[0];
            TotalCost += Costs[0];
        }

        public override void Upgrade()
        {
            upgradelevel++;
                switch(upgradelevel)
                {
                    case 2:
                        burnDuration++;
                        Damage = 5f;
                        Firerate=1.5f;
                        Range=7;
                        ResellPercentage=65;
                        TotalCost += Costs[1];
                        currentCost = Costs[1];
                        towerImage = (Bitmap)Image.FromFile("Media\\Tower\\DoTTowers\\DoT2.bmp");
                        this.LoadImage();
                        break;
                    case 3:
                        burnDuration++;
                        Damage = 10f;
                        Firerate=1f;
                        Range=10;
                        ResellPercentage=70;
                        TotalCost += Costs[2];
                        currentCost = Costs[2];
                        towerImage = (Bitmap)Image.FromFile("Media\\Tower\\DoTTowers\\DoT3.bmp");
                        this.LoadImage();
                        break;
                }
        }

    }
}
