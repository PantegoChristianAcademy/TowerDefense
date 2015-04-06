using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemies
{
    public class _50_off: Enemy
    {
        public _50_off()
        {
            Imagefile = "Media\\Enemies\\50% off.bmp";
            Health = 25;
            Speed = 25;
            Goldgiven = 5;
        }
    }
}
