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
            Firerate = .1f;
            Range = 1;
            Cost = 150;
            ResellPercentage = 60;
            TotalCost = Cost;

        }
        public override void Upgrade()
        {
            upgradelevel++;
            switch (upgradelevel)
            {
                case 2:
                    Damage = 5;
                    Firerate = 0.4f;
                    Range = 12;
                    Cost = 100;
                    ResellPercentage = 65;
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SlowTowers\\slow2.bmp");
                    this.LoadImage();
                    break;

                case 3:
                    Damage = 10;
                    Firerate = 0.3f;
                    Range = 15;
                    Cost = 120;
                    ResellPercentage = 70;
                    towerImage = (Bitmap)Image.FromFile("Media\\Tower\\SlowTowers\\slow3.bmp");
                    this.LoadImage();
                    break;

            }
            TotalCost = TotalCost + Cost;
        }
    }
}

