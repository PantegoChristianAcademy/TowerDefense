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

       public void SetInitialSpawnLoc(List<Tile> path)
       {
           x = path[0].location.X;
           y = path[0].location.Y;
       }
       public void Move(List<Tile> path)
       {
           Tile currentlyOccupiedTile = path[placeInPath];
           Tile nextTileInPath = path[placeInPath + 1];

           int xVel = nextTileInPath.GridXLoc - currentlyOccupiedTile.GridXLoc;
           int yVel = nextTileInPath.GridYLoc - currentlyOccupiedTile.GridYLoc;

           if (xVel != 0)
           {
               switch (xVel)
               {
                   case 1:
                       if (x + Speed * xVel < nextTileInPath.location.X) x += Speed * xVel;
                       else
                       {
                           x = nextTileInPath.location.X;
                           int leftover = x - nextTileInPath.location.X;
                           placeInPath++;
                           this.CheckIfCompletedPathAndExecuteCode(path);
                       }
                       break;

                   case -1:
                       if (x + Speed * xVel > nextTileInPath.location.X) x += Speed * xVel;
                       else
                       {
                           x = nextTileInPath.location.X;
                           int leftover = nextTileInPath.location.X - x;
                           placeInPath++;
                           this.CheckIfCompletedPathAndExecuteCode(path);
                       }
                       break;
               }
           }

           if (yVel != 0)
           {
               switch (yVel)
               {
                   case 1:
                       if (y + Speed * yVel < nextTileInPath.location.Y) y += Speed * yVel;
                       else
                       {
                           y = nextTileInPath.location.Y;
                           int leftover = y - nextTileInPath.location.Y;
                           placeInPath++;
                           this.CheckIfCompletedPathAndExecuteCode(path);
                       }
                       break;

                   case -1:
                       if (y + Speed * yVel > nextTileInPath.location.Y) y += Speed * yVel;
                       else
                       {
                           y = nextTileInPath.location.Y;
                           int leftover = nextTileInPath.location.Y - y;
                           placeInPath++;
                           this.CheckIfCompletedPathAndExecuteCode(path);
                       }
                       break;
               }
           }
       }
        
       public void CheckIfCompletedPathAndExecuteCode(List<Tile> path)
       {
           if (placeInPath == path.Count - 1)
           {
               this.SetInitialSpawnLoc(path);
               placeInPath = 0;
           }
       }
    }
}
