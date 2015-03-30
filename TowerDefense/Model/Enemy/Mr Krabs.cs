using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemies
{
  public  class Mr_Krabs: Enemy
    {
        public Mr_Krabs()
      {
          Imagefile = "Media\\Enemies\\oh yeah mr krabs.bmp";
          Health = 225;
          Speed = 15;
          Goldgiven = 25;

      }
    }
}
