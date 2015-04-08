using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemies
{
    public abstract class Enemy
    {
        public string Imagefile;
        
        
       public int Health;
       public int Speed;
       public int x;
       public int y;
       public int Goldgiven;
       public int placeInPath = 0;

       public void Move(List<Tile> Path, double tileSize)
       {
           Tile currentlyOccupiedTile = Path[placeInPath];
           Tile nextTileInPath = Path[placeInPath + 1];

           int xVel = nextTileInPath.GridXLoc - currentlyOccupiedTile.GridXLoc;
           int yVel = nextTileInPath.GridYLoc - currentlyOccupiedTile.GridYLoc;

           if (xVel != 0)
           {
               switch (xVel)
               {
                   case 1:
                       if (x + Speed * xVel < currentlyOccupiedTile.location.X) x += Speed * xVel;
                       else
                       {
                           x = currentlyOccupiedTile.location.X;
                           int leftover = x - currentlyOccupiedTile.location.X;
                           placeInPath++;
                           this.SecondaryMove(Path, tileSize, leftover);
                       }
                       break;

                   case -1:
                       if (x + Speed * xVel > currentlyOccupiedTile.location.X + tileSize) x += Speed * xVel;
                       else
                       {
                           x = currentlyOccupiedTile.location.X;
                           int leftover = currentlyOccupiedTile.location.X - x;
                           placeInPath++;
                           this.SecondaryMove(Path, tileSize, leftover);
                       }
                       break;
               }
           }

           if (yVel != 0)
           {
               switch (yVel)
               {
                   case 1:
                       if (y + Speed * yVel < currentlyOccupiedTile.location.Y + tileSize) y += Speed * yVel;
                       else
                       {
                           y = currentlyOccupiedTile.location.Y;
                           int leftover = y - currentlyOccupiedTile.location.Y;
                           placeInPath++;
                           this.SecondaryMove(Path, tileSize, leftover);
                       }
                       break;

                   case -1:
                       if (y + Speed * yVel > currentlyOccupiedTile.location.Y) y += Speed * yVel;
                       else
                       {
                           y = currentlyOccupiedTile.location.Y;
                           int leftover = currentlyOccupiedTile.location.Y - y;
                           placeInPath++;
                           this.SecondaryMove(Path, tileSize, leftover);
                       }
                       break;
               }
           }
       }

       public void SecondaryMove(List<Tile> Path, double tileSize, int leftover)
       {
           Tile currentlyOccupiedTile = Path[placeInPath];
           Tile nextTileInPath = Path[placeInPath + 1];

           int xVel = nextTileInPath.GridXLoc - currentlyOccupiedTile.GridXLoc;
           int yVel = nextTileInPath.GridYLoc - currentlyOccupiedTile.GridYLoc;

           if (xVel != 0)
           {
               switch (xVel)
               {
                   case 1:
                       x += leftover;
                       break;

                   case -1:
                       x -= leftover;
                       break;
               }
           }

           if (yVel != 0)
           {
               switch (yVel)
               {
                   case 1:
                       y += leftover;
                       break;

                   case -1:
                       y -= leftover;
                       break;
               }
           }
       }
    }
}
