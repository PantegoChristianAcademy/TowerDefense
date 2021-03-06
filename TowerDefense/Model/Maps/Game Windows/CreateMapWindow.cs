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
    public partial class CreateMapWindow : Form
    {
        Map mapBeingCreated;

        public CreateMapWindow()
        {
            InitializeComponent();
        }

        private void CreateMapWindow_Load(object sender, EventArgs e)
        {
            mapBeingCreated = new Map();
            mapBeingCreated.tileSize = int.Parse(File.ReadAllText(FileCommands.TempTileSizeLocation));
            File.Delete(FileCommands.TempTileSizeLocation);
            mapBeingCreated.GenerateNewMap(ClientSize.Width, ClientSize.Height);
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var screen = e.Graphics;

            foreach(Tile tempTile in mapBeingCreated.MapGrid)
            {
                screen.DrawRectangle(Tile.TileOutlineColor, tempTile.location.X, tempTile.location.Y, (int)mapBeingCreated.tileSize, (int)mapBeingCreated.tileSize);
                screen.FillRectangle(tempTile.color, tempTile.location.X + 1, tempTile.location.Y + 1, (int)mapBeingCreated.tileSize - 1, (int)mapBeingCreated.tileSize - 1);
            }
        }

        #region WhatHappensWhenClickTile
        private void CreateMapWindow_MouseClick(object sender, MouseEventArgs e)
        {
            int xClick = e.X;
            int yClick = e.Y;

            if (Tile.IsClickWithinMap(xClick, yClick, mapBeingCreated) == true && Tile.IsClickOnTileEdge(xClick, yClick, mapBeingCreated) == false)
            {
                Tile clickedTile = Tile.DetermineClickedTile(xClick, yClick, mapBeingCreated);

                if(e.Button == MouseButtons.Left)
                {
                    if (clickedTile.identity != TileIdentity.Path && clickedTile.identity != TileIdentity.PathStart)
                    {
                        clickedTile.ChangeTileIdentity(TileIdentity.Unoccupied);
                    }

                    else if (clickedTile.identity == TileIdentity.Path || clickedTile.identity == TileIdentity.PathStart)
                    {
                        foreach(Tile tempTile in Tile.CreatePathToBeRemoved(clickedTile, mapBeingCreated.Path))
                        {
                            mapBeingCreated.Path.Remove(tempTile);
                            tempTile.identity = TileIdentity.Unoccupied;
                            tempTile.UpdateTileContent();
                        }
                    }
                }

                if (e.Button == MouseButtons.Right && clickedTile.identity != TileIdentity.Path)
                {
                    clickedTile.ChangeTileIdentity(TileIdentity.Water);
                }
            }
        }

        private void CreateMapWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int xClick = e.X;
            int yClick = e.Y;

            if (Tile.IsClickWithinMap(xClick, yClick, mapBeingCreated) == true && Tile.IsClickOnTileEdge(xClick, yClick, mapBeingCreated) == false)
            {
                Tile clickedTile = Tile.DetermineClickedTile(xClick, yClick, mapBeingCreated);

                if (e.Button == MouseButtons.Left && clickedTile.identity == TileIdentity.Unoccupied)
                {
                    if (mapBeingCreated.Path.Count == 0)
                    {
                        clickedTile.ChangeTileIdentity(TileIdentity.PathStart);
                        mapBeingCreated.Path.Add(clickedTile);
                    }
                    else
                    {
                        if (Tile.IsClickedTileAdjacent(mapBeingCreated.tileSize, mapBeingCreated.Path, clickedTile) == true)
                        {
                            clickedTile.ChangeTileIdentity(TileIdentity.Path);
                            mapBeingCreated.Path.Add(clickedTile);
                        }
                    }
                }

                if (e.Button == MouseButtons.Right && clickedTile.identity != TileIdentity.Path && clickedTile.identity != TileIdentity.PathStart)
                {
                    clickedTile.ChangeTileIdentity(TileIdentity.Blockade);
                }
            }
        }
        #endregion

        private void CreateMapWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Tile PathEnd = mapBeingCreated.Path.Last();
                mapBeingCreated.MapGrid[PathEnd.GridXLoc, PathEnd.GridYLoc].identity = TileIdentity.PathEnd;
                mapBeingCreated.MapGrid[PathEnd.GridXLoc, PathEnd.GridYLoc].UpdateTileContent();

                SaveMapWindow mapSaver = new SaveMapWindow();
                mapSaver.ShowDialog();
                if (File.Exists(FileCommands.TempMapLocation))
                {
                    string fileContent = File.ReadAllText(FileCommands.TempMapLocation);
                    File.Delete(FileCommands.TempMapLocation);

                    string[] mapSaveData = fileContent.Split('\\');
                    string difficulty = mapSaveData[1];
                    string mapName = mapSaveData[2];

                    FileCommands.SaveMapFile(mapBeingCreated, mapName, difficulty);
                    this.Close();
                }
            }
        }
    }
}
