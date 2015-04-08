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
            Health = 55;
            Speed = 25;
            Goldgiven = 15;
        }
    }
}
