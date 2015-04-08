using System;
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
            //Imagefile = "Media\\Enemies\\GabenIsGod.bmp"
            Imagefile = "Images\\Enemies\\Swag.jpg";
            enemyImage = Image.FromFile(Imagefile);
            Health = 110;
            Speed = 15;
            Goldgiven = 25;
        }
    }
}
