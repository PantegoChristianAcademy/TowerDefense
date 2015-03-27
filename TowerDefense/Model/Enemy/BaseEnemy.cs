using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemies
{
    public abstract class Enemy
    {
        public short StrengthLevel =1;
        public short Health;
        public short Speed;
        public int x;
        public int y;
        public short Goldgiven;
       
        public virtual void Upgrade()
        {
            StrengthLevel++;
            Health = (short)(Health + (Health * .05));
        }
    }
}
