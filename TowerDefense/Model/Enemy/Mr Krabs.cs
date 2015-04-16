using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
  public  class Mr_Krabs: Enemy
    {
        public Mr_Krabs()
      {
          Imagefile = "Media\\Enemies\\oh yeah mr krabs.bmp";
          LoadImage();
          Health = 90;
          Speed = 2;
          Goldgiven = 45;
          LifeValue = 3;
      }
    }
}
