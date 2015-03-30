using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemies
{
    public class Plane: Enemy
    {
        public Plane()
        {
            Imagefile = "Media\\Enemies\\airplane.bmp";
            Health = 75;
            Speed = 25;
            Goldgiven = 15;
        }
    }
}
