﻿using System;
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
           Health = 1800;
           Speed = 1;
           Goldgiven = 500;
           damage = 20;
           //enemy not in use right now because this is the boss and the wave has not been set yet
       }
    }
}
