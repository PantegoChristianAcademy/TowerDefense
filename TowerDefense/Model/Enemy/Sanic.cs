using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemies
{
   public class Sanic: Enemy
    {
       public Sanic()
       {
           Imagefile = "Media\\Enemies\\sanicfortower.bmp";
           Health = 75;
           Speed = 30;
           Goldgiven = 15;
       }
    }
}
