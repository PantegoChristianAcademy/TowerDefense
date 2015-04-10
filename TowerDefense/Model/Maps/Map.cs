using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    enum MapDifficulty
    {
        Easy,
        Normal,
        Hard
    }

    public class Map
    {
        #region Variables
        public double tileSize;

        public Tile[,] MapGrid;
        public List<Tile> Path; 
        public double horizontalGap;
        public double verticalGap;
        public double numOfHorizontalTiles;
        public double numOfVerticalTiles;
        #endregion

        public Map ()
	    {
            Path = new List<Tile>(); 
	    }

        public void GenerateNewMap(int width, int height)
        {
            horizontalGap = ((width - 1) % tileSize) / 2;
            verticalGap = ((height - 1) % tileSize) / 2;
            numOfHorizontalTiles = Math.Floor((width - 1) / tileSize);
            numOfVerticalTiles = Math.Floor((height - 1) / tileSize);

            MapGrid = new Tile[(int)numOfHorizontalTiles, (int)numOfVerticalTiles];

            for (int i = 0; i < numOfHorizontalTiles; i++)
            {
                for (int ii = 0; ii < numOfVerticalTiles; ii++)
                {
                    MapGrid[i, ii] = new Tile((int)(i * tileSize + horizontalGap), (int)(ii * tileSize + verticalGap), TileIdentity.Unoccupied, i, ii);
                }
            }
        }

        public void Resize(int width, int height)
        {
            horizontalGap = (width - numOfHorizontalTiles * tileSize) / 2;
            verticalGap = (height - numOfVerticalTiles * tileSize) / 2;

            tileSize = 1;

            while (numOfHorizontalTiles * tileSize < width && numOfVerticalTiles * tileSize < height)
            {
                tileSize += 1;
            }

            horizontalGap = (width - numOfHorizontalTiles * tileSize) / 2;
            verticalGap = (height - numOfVerticalTiles * tileSize) / 2;

            for (int i = 0; i < numOfHorizontalTiles; i++)
            {
                for (int ii = 0; ii < numOfVerticalTiles; ii++)
                {
                    MapGrid[i, ii].location = new Point((int)(i * tileSize + horizontalGap), (int)(ii * tileSize + verticalGap));
                }
            }
        }

        public void GenerateLoadedMap(int width, int height, TileIdentity[,] desiredMapGrid)
        {
            tileSize = 1;
            numOfHorizontalTiles = desiredMapGrid.GetLength(0);
            numOfVerticalTiles = desiredMapGrid.GetLength(1);

            MapGrid = new Tile[(int)numOfHorizontalTiles, (int)numOfVerticalTiles];

            while(numOfHorizontalTiles * tileSize < width && numOfVerticalTiles * tileSize < height)
            {
                tileSize += 1;
            }

            horizontalGap = (width - numOfHorizontalTiles * tileSize) / 2;
            verticalGap = (height - numOfVerticalTiles * tileSize) / 2;

            for (int i = 0; i < numOfHorizontalTiles; i++)
            {
                for (int ii = 0; ii < numOfVerticalTiles; ii++)
                {
                    MapGrid[i, ii] = new Tile((int)(i * tileSize + horizontalGap), (int)(ii * tileSize + verticalGap), desiredMapGrid[i,ii], i, ii);
                }
            }
        }
    }
}
