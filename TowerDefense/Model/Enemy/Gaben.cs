﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
    public class Gaben: Enemy
    {
        public Gaben()
        {
            Imagefile = "Media\\Enemies\\GabenIsGod.bmp";
            LoadImage();
            Health = 100;
            Speed = 3;
            Goldgiven = 15;
            damage = 1;
            //needs a split function for 50% and 75% enemies to be able to use them, but the enemy still works
        }
    }
}
