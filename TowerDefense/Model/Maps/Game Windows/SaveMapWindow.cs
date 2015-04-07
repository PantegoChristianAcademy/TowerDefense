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
    public partial class SaveMapWindow : Form
    {
        string mapName;

        public SaveMapWindow()
        {
            InitializeComponent();
            SaveMapBtn.Enabled = false;

            foreach (MapDifficulty difficulty in Enum.GetValues(typeof(MapDifficulty)))
            {
                ListOfDifficulties.Items.Add(difficulty.ToString());
            }
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            if (MapNameTB.Text == "" || ListOfDifficulties.SelectedItem == null) MapNameCB.Enabled = false;
            else MapNameCB.Enabled = true;

            if(MapNameCB.Checked == true)
            {
                MapNameTB.Enabled = false;
                ListOfDifficulties.Enabled = false;
                SaveMapBtn.Enabled = true;
            }

            else
            {
                MapNameTB.Enabled = true;
                ListOfDifficulties.Enabled = true;
                SaveMapBtn.Enabled = false;
            }
        }

        private void SaveMapBtn_MouseClick(object sender, MouseEventArgs e)
        {
            mapName = MapNameTB.Text;
            File.WriteAllText(FileCommands.TempMapLocation, string.Format("Maps\\{0}\\{1}", ListOfDifficulties.SelectedItem, mapName));
            this.Close();
        }
    }
}
