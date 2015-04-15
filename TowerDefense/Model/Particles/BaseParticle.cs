using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Particles
{
    public  class BaseParticle
    {
        private System.Drawing.Bitmap img;
        public System.Drawing.Bitmap Img
        {
            get
            {
                if (img == null) img = (Bitmap)Image.FromFile(file);
                return img;
            }
        }
        public int posX;
        public int posY;
        public double vX;
        public double vY;
        public double angle;
        public string file;
        public int speed;
        public static BaseParticle CreateParticle(Model.Turrets.Base_Tower Tower, Model.Enemies.Enemy Target, Map Tile)
        {
            var particle = new BaseParticle();
            if (Tower is Model.Turrets.Basic_Tower)
            {
                particle.speed = 2;
                particle.file = "Media\\Particle\\New bullet.png";
            }
            else if (Tower is Model.Turrets.DoT_Tower)
            {
                particle.speed = 2;
                particle.file = "Media\\Particle\\Fire.png";
            }
            else if (Tower is Model.Turrets.Slowing_tower)
            {
                particle.speed = 2;
                particle.file = "Media\\Particle\\Freeze projectile.png";
            }
            else if (Tower is Model.Turrets.Splash_Tower)
            {
                particle.speed = 2; 
                particle.file = "Media\\Particle\\Missle Porjectile.png";
            }

            particle.posX = (int)(Tower.PosX + Tile.tileSize / 2);
            particle.posY = (int)(Tower.PosY + Tile.tileSize / 2);
            int ty = (int)(Target.y + Tile.tileSize / 2);
            int tx = (int)(Target.x + Tile.tileSize / 2);
            particle.angle = Math.Atan2(ty - particle.posY, tx - particle.posX) * -1;
            particle.vX = particle.speed * Math.Cos(particle.angle);
            particle.vY = particle.speed * Math.Sign(particle.angle);

            return particle;
        }
    }
}
