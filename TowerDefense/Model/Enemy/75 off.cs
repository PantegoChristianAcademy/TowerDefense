using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
    public class _75_off: Enemy
    {
        public _75_off()
        {
            Imagefile = "Media\\Enemies\\75% off.bmp";
            Health = 45;
            Speed = 25;
            Goldgiven = 10;
        }
    }
}
