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
    enum TileIdentity 
        {
            Unoccupied,
            Path,
            Water,
            Blockade,
            Tower
        }
        
    class Tile
    {
        #region Variables
        public static Pen TileOutlineColor = Pens.Black;

        public Point location;
        public Brush color;
        public TileIdentity identity;
        public char shortIdentity;
        public string GridLoc;
        #endregion

        public Tile(int xLoc, int yLoc, TileIdentity desiredIdentity, int xGrid, int yGrid)
        {
            location = new Point(xLoc, yLoc);
            identity = desiredIdentity;
            GridLoc = string.Format("{0}~{1}", xGrid, yGrid);
            UpdateTileContent();
        }

        #region DeterminingSelectedTile
        public static bool IsClickWithinMap(int mouseX, int mouseY, Map map)
        {
            Tile topLeft = map.MapGrid[0,0];
            Tile bottomRight = map.MapGrid[(int)map.numOfHorizontalTiles - 1, (int)map.numOfVerticalTiles - 1];

            if (mouseX > topLeft.location.X && mouseX < bottomRight.location.X + map.tileSize && mouseY > topLeft.location.Y && mouseY < bottomRight.location.Y + map.tileSize)
            {
                return true;
            }

            else return false;
        }

        public static bool IsClickOnTileEdge(int mouseX, int mouseY, Map map)
        {
            double horzDistanceToEdge = (mouseX - map.horizontalGap) % map.tileSize;
            double vertDistanceToEdge = (mouseY - map.verticalGap) % map.tileSize;

            if ((horzDistanceToEdge < 1 || horzDistanceToEdge > map.tileSize - 1) || (vertDistanceToEdge < 1 || vertDistanceToEdge > map.tileSize - 1))
            {
                return true;
            }

            else return false;
        }

        public static Tile DetermineClickedTile(int mouseX, int mouseY, Map map)
        {
            foreach (Tile tempTile in map.MapGrid)
            {
                if (mouseX > tempTile.location.X && mouseX < tempTile.location.X + map.tileSize && mouseY > tempTile.location.Y && mouseY < tempTile.location.Y + map.tileSize)
                {
                    return tempTile;
                }
            }

            return map.MapGrid[0,0];
        }
        #endregion

        public static bool IsClickedTileAdjacent(double tileSize, List<Tile> Path, Tile selectedTile)
        {
            Tile lastTile = Path.Last();
            if (Math.Abs(lastTile.location.X - selectedTile.location.X) == tileSize && Math.Abs(lastTile.location.Y - selectedTile.location.Y) == 0) return true;
            else if (Math.Abs(lastTile.location.X - selectedTile.location.X) == 0 && Math.Abs(lastTile.location.Y - selectedTile.location.Y) == tileSize) return true;
            else return false;
        }

        public static List<Tile> CreatePathToBeRemoved(Tile clickedTile, List<Tile> Path)
        {
            int TilePosition = 0;
            List<Tile> listOfTilesToBeRemoved = new List<Tile>();

            foreach(Tile tempTile in Path)
            {
                if (clickedTile == tempTile) break;
                else TilePosition++;
            }

            for(int i = TilePosition; i < Path.Count; i++)
            {
                listOfTilesToBeRemoved.Add(Path[i]);
            }

            return listOfTilesToBeRemoved;
        }

        public void ChangeTileIdentity(TileIdentity chosenIdentity)
        {
            identity = chosenIdentity;
            UpdateTileContent();
        }

        public void UpdateTileContent()
        {
            switch(identity)
            {
                case TileIdentity.Unoccupied:
                    this.color = Brushes.Green;
                    break;

                case TileIdentity.Path:
                    this.color = Brushes.Yellow;
                    break;

                case TileIdentity.Water:
                    this.color = Brushes.Blue;
                    break;

                case TileIdentity.Blockade:
                    this.color = Brushes.Black;
                    break;

                case TileIdentity.Tower:
                    this.color = Brushes.Purple;
                    break;

                default:
                    this.color = Brushes.LightPink;
                    break;
            }

            ConvertIdentityToShortIdentity(identity);
        }

        public void ConvertIdentityToShortIdentity(TileIdentity identity)
        {
            switch (identity)
            {
                case TileIdentity.Unoccupied:
                    this.shortIdentity = ' ';
                    break;

                case TileIdentity.Path:
                    this.shortIdentity = 'P';
                    break;

                case TileIdentity.Water:
                    this.shortIdentity = 'W';
                    break;

                case TileIdentity.Blockade:
                    this.shortIdentity = 'B';
                    break;

                case TileIdentity.Tower:
                    this.shortIdentity = 'T';
                    break;

                default:
                    break;
            }
        }

        public static TileIdentity ConvertShortIdentityToIdentity(char shortIdentity)
        {
            switch (shortIdentity)
            {
                case ' ': 
                    return TileIdentity.Unoccupied;

                case 'P':
                    return TileIdentity.Path;

                case 'W':
                    return TileIdentity.Water;

                case 'B':
                    return TileIdentity.Blockade;

                case 'T':
                    return TileIdentity.Tower;

                default:
                    return TileIdentity.Unoccupied;
            }
        }
    }
}
