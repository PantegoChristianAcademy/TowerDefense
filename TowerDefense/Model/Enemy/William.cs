using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemy
{
    public class William : TowerDefense.Model.Enemies.Enemy
    {
        public William()
        {
            Imagefile = "Media\\Enemies\\William.bmp";
            LoadImage();
            Health = 4200;
            Speed = 1;
            Goldgiven = 420;
            damage = 10;
            //#420
            //#420
        }
    }
    
}
