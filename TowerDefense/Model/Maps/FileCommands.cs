﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TowerDefense
{
    public class FileCommands
    {
        #region Variables
        public static string TempMapLocation = "TempData\\Map Name.txt";
        public static string TempMapSelectorActionLocation = "TempData\\Map Selection Action.txt";
        public static string TempTileSizeLocation = "TempData\\Tile Size.txt";
        public static string TempMapDifficulty = "TempData\\Map Difficulty.txt";
        #endregion

        public static void ValidateFiles()
        {
            if (!Directory.Exists("Maps")) 
            {
                Directory.CreateDirectory("Maps"); 

                foreach(MapDifficulty difficulty in Enum.GetValues(typeof(MapDifficulty)))
                {
                    Directory.CreateDirectory(string.Format("Maps\\{0}", difficulty));
                }
            }

            if(!Directory.Exists("TempData"))
            {
                Directory.CreateDirectory("TempData");
            }
        }

        public static void SaveMapFile(Map mapBeingSaved, string name, string difficulty)
        {
            using(StreamWriter writer = new StreamWriter(string.Format("Maps\\{0}\\{1}.txt", difficulty, name)))
            {
                for(int y = 0; y < mapBeingSaved.numOfVerticalTiles; y++)
                {
                    for(int x = 0; x < mapBeingSaved.numOfHorizontalTiles; x++)
                    {
                        writer.Write(mapBeingSaved.MapGrid[x, y].shortIdentity);
                    }
                    if(y != mapBeingSaved.numOfVerticalTiles - 1) writer.WriteLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(string.Format("Maps\\{0}\\{1}$$$###$$$.txt", difficulty, name)))
            {
                foreach(Tile tempTile in mapBeingSaved.Path)
                {
                    writer.WriteLine(string.Format("{0}~{1}", tempTile.GridXLoc, tempTile.GridYLoc));
                }
            }
        }

        public static TileIdentity[,] ReadMapFile(string filePath)
        {
            int counter = 0;
            int numOfVerticalTiles;
            int numOfHorizontalTiles;
            string allTiles = "";
            string[] arrayOfHorizontalLines = File.ReadAllLines(filePath);

            string[] filePathComponents = filePath.Split('\\');
            string difficulty = filePathComponents[1];
            File.WriteAllText(TempMapDifficulty, difficulty);

            numOfVerticalTiles = arrayOfHorizontalLines.Length;
            numOfHorizontalTiles = arrayOfHorizontalLines[0].Length;

            foreach(char tile in File.ReadAllText(filePath))
            {
                switch(tile)
                {
                    case ' ':
                    case 'P':
                    case '!':
                    case '*':
                    case 'W':
                    case 'B':
                    case 'T':
                    allTiles += tile;
                    break;

                    default:
                    break;
                }
            }

            TileIdentity[,] identityGrid = new TileIdentity[numOfHorizontalTiles, numOfVerticalTiles];

            for (int y = 0; y < (int)numOfVerticalTiles; y++)
            {
                for (int x = 0; x < (int)numOfHorizontalTiles; x++)
                {
                    identityGrid[x, y] = Tile.ConvertShortIdentityToIdentity(allTiles[counter]);
                    counter++;
                }
            }

            return identityGrid;
        }

        public static List<Tile> ReadMapPathFile(Map loadedMap, string filePath)
        {
            List<Tile> Path = new List<Tile>();

            string[] listOfGridLoc = File.ReadAllLines(filePath);

            foreach(string gridLoc in listOfGridLoc)
            {
                string[] gridLocData = gridLoc.Split('~');
                int gridXLoc = int.Parse(gridLocData[0]);
                int gridYLoc = int.Parse(gridLocData[1]);
                foreach(Tile tempTile in loadedMap.MapGrid)
                {
                    if (gridXLoc == tempTile.GridXLoc && gridYLoc == tempTile.GridYLoc)
                    {
                        Path.Add(tempTile); 
                    }
                }
            }

            return Path;
        }
    }
}
