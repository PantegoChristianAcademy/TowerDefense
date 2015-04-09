using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
    public class Gaben: Enemy
    {
        public Gaben()
        {
            Imagefile = "Media\\Enemies\\GabenIsGod.bmp";
            LoadImage();
            Health = 110;
            Speed = 1;
            Goldgiven = 25;
            LifeValue = 5;

        }
    }
}
