using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemies
{
    public class Gaben: Enemy
    {
        public Gaben()
        {
            Imagefile = "Media\\Enemies\\GabenIsGod.bmp";
            Health = 110;
            Speed = 15;
            Goldgiven = 25;

        }
        
    }
}
