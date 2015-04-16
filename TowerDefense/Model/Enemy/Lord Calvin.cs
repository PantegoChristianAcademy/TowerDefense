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
           LoadImage();
           Health = 650;
           Speed = 1;
           Goldgiven = 250;
           LifeValue = 15;
           //enemy not in use right now because this is the boss and the wave has not been set yet
       }
    }
}
