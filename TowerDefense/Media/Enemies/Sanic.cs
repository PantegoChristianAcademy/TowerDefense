﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Media.Enemies
{
   public class Sanic: Enemy
    {
       public Sanic()
       {
           Health = 75;
           Speed = 30;
           Goldgiven = 15;
       }
    }
}