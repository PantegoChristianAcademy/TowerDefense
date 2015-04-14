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
        public DoT_Tower()
        {
            towerImage = (Bitmap)Image.FromFile("Media\\Tower\\DoTTowers\\DoT.bmp");
            Damage = 10;
            Firerate = 2;
            Range = 6;
            Cost = 100;
            ResellPercentage = 60;
            TotalCost = Cost;
        }

        public override void Upgrade()
        {
            upgradelevel++;
                switch(upgradelevel)
                {
                    case 2:
                        Damage=15;
                        Firerate=2.5f;
                        Range=9;
                        Cost=125;
                        ResellPercentage=65;
                        break;
                    case 3:
                        Damage=20;
                        Firerate=3;
                        Range=12;
                        Cost=150;
                        ResellPercentage=70;
                        break;
                }

            TotalCost= TotalCost+ Cost;
        }

    }
}
