using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
    public class Plane: Enemy
    {
        public Plane()
        {
            Imagefile = "Media\\Enemies\\airplane.bmp";
            LoadImage();
            Health = 55;
            Speed = 25;
            Goldgiven = 15;
            //enemy not in use right now because we cant use the freeze function anymore,can still be used as a normal enemy though
        }
    }
}
