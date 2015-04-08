using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
   public class Lord_Calvin: Enemy
    {
       public Lord_Calvin()
       {
           Imagefile = "Media\\Enemies\\LordCalvin.bmp";
           Health = 955;
           Speed = 10;
           Goldgiven = 100;
       }
    }
}
