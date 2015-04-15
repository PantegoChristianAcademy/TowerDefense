using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
   public class Sanic: Enemy
    {
       public Sanic()
       {
           Imagefile = "Media\\Enemies\\sanicfortower.bmp";
           LoadImage();
           Health = 45;
           Speed = 3;
           Goldgiven = 15;
           LifeValue = 1;
       }
    }
}
