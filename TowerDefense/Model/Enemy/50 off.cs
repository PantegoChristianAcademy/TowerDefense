using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
    public class _50_off: Enemy
    {
        public _50_off()
        {
            Imagefile = "Media\\Enemies\\50% off.bmp";
            LoadImage();
            Health = 25;
            Speed = 20;
            Goldgiven = 5;
            //enemy not in use right now because there is no split function

        }
    }
}
