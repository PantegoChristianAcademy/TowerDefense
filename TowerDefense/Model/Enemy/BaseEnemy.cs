﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Model.Enemies
{
    public abstract class Enemy
    {
       public string Imagefile;
       public Bitmap enemyImage;
       
       public float Health;
       public int Speed;
       public int x;
       public int y;
       public int Goldgiven;
       public int placeInPath = 0;
       public byte damage;
       public bool needToDelete = false;
       public bool isOnFire = false;
       public int burnDuration = 0;
       public float fireDamage = 0;

       public void SetInitialSpawnLoc(List<Tile> path)
       {
           x = path[0].location.X;
           y = path[0].location.Y;
       }
       public void Move(List<Tile> path)
       {
           Tile currentlyOccupiedTile = path[placeInPath];

           if (placeInPath + 1 == path.Count)
           {
               needToDelete = true;
               return;
           }
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
                           placeInPath++;
                       }
                       break;

                   case -1:
                       if (x + Speed * xVel > nextTileInPath.location.X) x += Speed * xVel;
                       else
                       {
                           x = nextTileInPath.location.X;
                           placeInPath++;
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
                           placeInPath++;
                       }
                       break;

                   case -1:
                       if (y + Speed * yVel > nextTileInPath.location.Y) y += Speed * yVel;
                       else
                       {
                           y = nextTileInPath.location.Y;
                           placeInPath++;
                       }
                       break;
               }

               this.CheckIfCompletedPathAndExecuteCode(path);
           }
       }

       public void CheckIfCompletedPathAndExecuteCode(List<Tile> path)
       {
           if (placeInPath == path.Count - 1)
           {
               needToDelete = true;
           }
       }

       public void LoadImage()
       {
           enemyImage = (Bitmap)Image.FromFile(Imagefile);
           //enemyImage.Size = 
           enemyImage.MakeTransparent(Color.FromArgb(253, 36, 215));
           enemyImage.MakeTransparent(Color.FromArgb(237, 28, 36));
           enemyImage.MakeTransparent(Color.FromArgb(34, 177, 76));
           enemyImage.MakeTransparent(Color.FromArgb(238, 0, 232));
           enemyImage.MakeTransparent(Color.FromArgb(163, 73, 164));
       }
    }
}
