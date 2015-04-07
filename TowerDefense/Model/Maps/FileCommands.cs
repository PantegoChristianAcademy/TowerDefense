using System;
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
    class FileCommands
    {
        #region Variables
        public static string TempMapLocation = "TempData\\Map Name.txt";
        public static string TempMapSelectorActionLocation = "TempData\\Map Selection Action.txt";
        public static string TempTileSizeLocation = "TempData\\Tile Size.txt";
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

            if(!Directory.Exists("Images"))
            {
                Directory.CreateDirectory("Images");

                foreach(TileIdentity terrain in Enum.GetValues(typeof(TileIdentity)))
                {
                    Directory.CreateDirectory(string.Format("Images\\{0}", terrain));
                }

                Directory.CreateDirectory("Images\\Enemies");
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

            using (StreamWriter writer = new StreamWriter(string.Format("Maps\\{0}\\{1}Path.txt", difficulty, name)))
            {
                foreach(Tile tempTile in mapBeingSaved.Path)
                {
                    writer.WriteLine(string.Format("{0}{1}", tempTile.location.X, tempTile.location.Y));
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

            numOfVerticalTiles = arrayOfHorizontalLines.Length;
            numOfHorizontalTiles = arrayOfHorizontalLines[0].Length;

            foreach(char tile in File.ReadAllText(filePath))
            {
                switch(tile)
                {
                    case ' ':
                    case 'P':
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

        public static List<Tile> ReadMapPathFile(string filePath)
        {

        }
    }
}
