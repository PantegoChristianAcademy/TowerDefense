using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Turrets
{
    public class Slowing_tower : Base_Tower
    {
        public Slowing_tower()
        {
            Damage = 0;
            Firerate = 0.5f;
            Range = 9;
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
                    break;

                case 3:
                    Damage = 10;
                    Firerate = 0.3f;
                    Range = 15;
                    Cost = 120;
                    ResellPercentage = 70;
                    break;

            }
            TotalCost = TotalCost + Cost;
        }
    }
}

