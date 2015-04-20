using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TowerDefense.Model.Turrets;

namespace TowerDefense.Model.Particles
{
    public  class BaseParticle
    {
        public System.Drawing.Bitmap img;
        public System.Drawing.Bitmap Img
        {
            get
            {
                if (img == null)
                {
                    img = (Bitmap)Image.FromFile(file);
                    img.MakeTransparent(Color.FromArgb(255, 255, 255));
                }
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
        public int damage;
        public Model.Enemies.Enemy Target;

        public BaseParticle (Model.Turrets.Base_Tower Tower, Model.Enemies.Enemy target, Map Tile)
        {
            Target = target;
            if (Tower is Basic_Tower)
            {
                speed = 10;
                file = "Media\\Particle\\Bullet.png";
                damage = new Basic_Tower(0,0).Damage;
            }
            else if (Tower is DoT_Tower)
            {
                speed = 8;
                file = "Media\\Particle\\Fire.png";
                damage = new DoT_Tower(0,0).Damage;
            }
            else if (Tower is Slowing_tower)
            {
                speed = 8;
                file = "Media\\Particle\\Freeze.png";
                damage = new Slowing_tower(0,0).Damage;
            }
            else if (Tower is Splash_Tower)
            {
                speed = 5; 
                file = "Media\\Particle\\Missile.png";
                damage = new Splash_Tower(0,0).Damage;
            }

            posX = (int)(Tower.PosX);
            posY = (int)(Tower.PosY);
            int ty = (int)(Target.y + Tile.tileSize / 2);
            int tx = (int)(Target.x + Tile.tileSize / 2);
            angle = Math.Atan2(ty - posY, tx - posX);
            vX = speed * Math.Cos(angle);
            vY = speed * Math.Sign(angle);
        }
        public BaseParticle(Model.Particles.BaseParticle parentParticle, int targetX, int targetY)
        {
            file = "Media\\Particle\\Explosion.png";
            posX = targetX;
            posY = targetY;
        }

        public void MoveParticle(Map Tile)
        {
            int ty = (int)(Target.y);
            int tx = (int)(Target.x);
            angle = Math.Atan2(ty - posY, tx - posX);
            vX = speed * Math.Cos(angle);
            vY = speed * Math.Sign(angle);
            posX += (int)vX;
            posY += (int)vY;
        }

        public override string ToString()
        {
            switch(this.file)
            {
                case "Media\\Particle\\Bullet.png":
                    return "Bullet";

                case "Media\\Particle\\Fire.png":
                    return "Fire";

                case "Media\\Particle\\Freeze.png":
                    return "Freeze";

                case "Media\\Particle\\Missile.png":
                    return "Missile";

                default:
                    return null;
            }
        }
    }
}
