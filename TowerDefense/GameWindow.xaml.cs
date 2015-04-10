using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TowerDefense
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : MahApps.Metro.Controls.MetroWindow
    {
        public Model.Turrets.Base_Tower ShopTower = null;
        public Controls.GamePanel Game
        {
            get
            {
                return winFormHost.Child as Controls.GamePanel;
            }
        }

        public GameWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int width = (int)(this.ActualWidth - uiPanelColumn.ActualWidth);
            int height = (int)(this.ActualHeight);
            winFormHost.Child = new Controls.GamePanel(width, height);
            Game.TileClick += Game_TileClick;
        }

        void Game_TileClick(int x, int y)
        {

        }

        private void Window_Resized(object sender, SizeChangedEventArgs e)
        {
            if (Game == null) return;

            int width = (int)(winFormHost.ActualWidth);
            int height = (int)(winFormHost.ActualHeight);
            Game.Resize(width, height);


        }
       
        private void Buy_Turret(object sender, MouseEventArgs e)
        {
            Image ci = sender as Image;
            if (ci == null)
            {
                return;
            }
            string tag = ci.Tag.ToString();
            switch(tag)
            {
                case "basic":
                    ShopTower = new Model.Turrets.Basic_Tower();
                    break;
                case "slow":
                    ShopTower = new Model.Turrets.Slowing_tower();
                    break;
                case "dot":
                    ShopTower = new Model.Turrets.DoT_Tower();
                    break;
                case "splash":
                    ShopTower = new Model.Turrets.Splash_Tower();
                    break;
            }
        }
    }
}
