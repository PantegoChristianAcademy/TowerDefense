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
    public partial class SelectTileSizeWindow : Form
    {        
        public SelectTileSizeWindow()
        {
            InitializeComponent();
            for(int i = 5; i <= 200; i++)
            {
                TileSizeCB.Items.Add(i);
            }
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            if (TileSizeCB.Text != "Choose Size") CreateMapBtn.Enabled = true;
        }

        private void CreateMapBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
                {
                    File.WriteAllText(FileCommands.TempTileSizeLocation, TileSizeCB.SelectedItem.ToString());

                    CreateMapWindow mapCreator = new CreateMapWindow();
                    mapCreator.ShowDialog();
                    this.Close();
                }

            catch { }
        }
    }
}
