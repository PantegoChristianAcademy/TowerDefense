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
    enum MapSelectionMode
    {
        Load,
        Delete
    }

    public partial class MapSelectorWindow : Form
    {
        string mapName;
        string mapPathName;
        string action;

        public MapSelectorWindow()
        {
            InitializeComponent();

            action = File.ReadAllText(FileCommands.TempMapSelectorActionLocation);
            File.Delete(FileCommands.TempMapSelectorActionLocation);
            SetAllControls();
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            if (ListOfDifficulties.SelectedItem == null)
            {
                ListOfMaps.Enabled = false;
                TakeActionBtn.Enabled = false;
            }

            else ListOfMaps.Enabled = true;

            if (ListOfMaps.Enabled == true && ListOfMaps.SelectedItem != null)
            {
                TakeActionBtn.Enabled = true;
            }

            else TakeActionBtn.Enabled = false;
        }

        private void ListOfDifficulties_SelectedValueChanged(object sender, EventArgs e)
        {
            ListOfMaps.Items.Clear();
            string[] tempListOfFiles = Directory.GetFiles(string.Format("Maps\\{0}", ListOfDifficulties.SelectedItem.ToString()));
            foreach(string fileName in tempListOfFiles)
            {
                string[] fileParts = fileName.Split('\\');
                string tempMapName = fileParts.Last();
                tempMapName = tempMapName.Remove(tempMapName.Length - 4);
                if (!tempMapName.ToLower().Contains("$$$###$$$")) ListOfMaps.Items.Add(tempMapName);
            }
        }

        private void ChooseMapBtn_MouseClick(object sender, MouseEventArgs e)
        {
            mapName = ListOfMaps.SelectedItem.ToString() + ".txt";
            mapPathName = ListOfMaps.SelectedItem.ToString() + "$$$###$$$.txt";
            string mapLocation = string.Format("Maps\\{0}\\{1}", ListOfDifficulties.SelectedItem, mapName);
            string mapPathLocation = string.Format("Maps\\{0}\\{1}", ListOfDifficulties.SelectedItem, mapPathName);


            switch (action)
            { 
                case "delete":
                    File.Delete(mapLocation);
                    File.Delete(mapPathLocation);
                    this.Close();
                    break;

                case "load":
                    File.WriteAllText(FileCommands.TempMapLocation, mapLocation);
                    GameWindow mainMap = new GameWindow();
                    mainMap.ShowDialog();
                    this.Close();
                    break;
            }
        }

        private void SetAllControls()
        {
            TakeActionBtn.Enabled = false;

            foreach (MapDifficulty difficulty in Enum.GetValues(typeof(MapDifficulty)))
            {
                ListOfDifficulties.Items.Add(difficulty.ToString());
            }

            switch(action)
            {
                case "delete":
                    this.Text = "Map Destroyer";
                    TakeActionBtn.Text = "Delete Map";
                    break;

                case "load":
                    this.Text = "Map Loader";
                    TakeActionBtn.Text = "Load Map";
                    break;
            }
        }
    }
}
