using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemy
{
   public class Trey: TowerDefense.Model.Enemies.Enemy
    {
       public Trey()
       {
           Imagefile = "Media\\Enemies\\Trey.bmp";
           LoadImage();
           Health = 230;
           Speed = 1;
           Goldgiven = 230;
           damage = 23;
       }
    }
}
