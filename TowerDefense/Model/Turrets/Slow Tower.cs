using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace TowerDefense.Model.Turrets
{
    public class Slowing_tower : Base_Tower
    {
        public Slowing_tower(int selectedXGrid, int selectedYGrid)
        {
            towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SlowTowers\\Slow.bmp");
            GridX = selectedXGrid;
            GridY = selectedYGrid;
            Damage = 2;
            Firerate = 2f;
            Range = 1;
            Costs[0] = 150;
            Costs[1] = 100;
            Costs[2] = 120;
            ResellPercentage = 60;
            TotalCost += Costs[0];
            currentCost = Costs[0];
        }
        public override void Upgrade()
        {
            upgradelevel++;
            switch (upgradelevel)
            {
                case 2:
                    Damage = 5;
                    Firerate = 1.5f;
                    Range = 12;
                    ResellPercentage = 65;
                    TotalCost += Costs[1];
                    currentCost = Costs[1];
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SlowTowers\\slow2.bmp");
                    this.LoadImage();
                    break;

                case 3:
                    Damage = 10;
                    Firerate = 1f;
                    Range = 15;
                    ResellPercentage = 70;
                    TotalCost += Costs[2];
                    currentCost = Costs[2];
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SlowTowers\\slow3.bmp");
                    this.LoadImage();
                    break;

            }
        }
    }
}

