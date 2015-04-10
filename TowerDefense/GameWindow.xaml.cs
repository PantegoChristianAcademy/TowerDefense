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
        }

        private void Window_Resized(object sender, SizeChangedEventArgs e)
        {
            if (Game == null) return;

            int width = (int)(winFormHost.ActualWidth);
            int height = (int)(winFormHost.ActualHeight);
            Game.Resize(width, height);
            
            
        }
    }
}
