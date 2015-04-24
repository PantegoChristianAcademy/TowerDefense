using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

using System.Runtime.InteropServices;

namespace TowerDefense
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : MahApps.Metro.Controls.MetroWindow
    {
        public Model.Turrets.Base_Tower ShopTower = null;
        public static int balance = 3000;
        public static int health = 1000000;

        // ... { GLOBAL HOOK }
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13; 
        const int WM_KEYDOWN = 0x100; 

        private LowLevelKeyboardProc _proc = hookProc;

        private static IntPtr hhook = IntPtr.Zero;

        public void SetHook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        public static void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }

        public static GameWindow _window;
        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                _window.KeyPress(vkCode);
                return (IntPtr)1;
            }
            else
                return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }

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
            _window = this;
        }

        public void KeyPress(int code)
        {
            switch (code)
            {
                case 80:
                    //pause w/ p button
                    
                    bool shouldBeVisible= Game.ManagePauseState();
                    if (shouldBeVisible == true)
                    {
                        PauseAlert.Visibility = Visibility.Visible;
                        this.IsEnabled = false;
                    }
                    else
                    {
                        PauseAlert.Visibility = Visibility.Hidden;
                        this.IsEnabled = true;
                    }
                    break;
                    //help button w/ ?
                case 48:
                    System.Diagnostics.Process.Start("chrome.exe", "http://gamedev.pantego.com/?page_id=71");
                    break;
                    //destroy water w/ enter
                case 32:
                    Game.ConvertWater();
                    break;
                    //Sell Tower
                case 8:
                    Game.SellTower();
                    break;
                case 38:
                    //highlight object w/ up arrow
                    if(Game.selectedY - 1 >= 0) Game.selectedY--;
                    break;
                case 37:
                   //highlight object w/ left arrow
                   if(Game.selectedX - 1 >= 0) Game.selectedX--; 
                    break;
                case 39:
                  //highlight object w/ right arrow
                 if(Game.selectedX + 1 <= TowerDefense.Controls.GamePanel.loadedMap.numOfHorizontalTiles - 1) Game.selectedX++;   
                    break;
                case 40:
               //highlight object w/ down arrow
                    if (Game.selectedY + 1 <= TowerDefense.Controls.GamePanel.loadedMap.numOfVerticalTiles - 1) Game.selectedY++;
                    break;
                case 13:
                    Game.UpgradeTower();
                    break;
                case 49:
                    ShopTower = new Model.Turrets.Basic_Tower(Game.selectedX, Game.selectedY);
                    Game_TileClick(Game.selectedX, Game.selectedY);
                    break;
                case 50:
                  ShopTower = new Model.Turrets.Slowing_tower(Game.selectedX, Game.selectedY);  //tower hotkey with 2
                  Game_TileClick(Game.selectedX, Game.selectedY);
                    break;
                case 51:
               ShopTower = new Model.Turrets.DoT_Tower(Game.selectedX, Game.selectedY);  //tower hotkey with 3
               Game_TileClick(Game.selectedX, Game.selectedY);
                    break;
                case 52:
                ShopTower = new Model.Turrets.Splash_Tower(Game.selectedX, Game.selectedY);   //tower hotkey with 4
                Game_TileClick(Game.selectedX, Game.selectedY);
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetHook();

            int width = (int)(this.ActualWidth - uiPanelColumn.ActualWidth);
            int height = (int)(this.ActualHeight);
            winFormHost.Child = new Controls.GamePanel(width, height);

            PauseAlert.Visibility = Visibility.Hidden;

            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            Timer.Start();

            Game.TileClick += Game_TileClick;
        }

        private void Window_Exit (object sender, System.ComponentModel.CancelEventArgs e)
        {
            UnHook();
            Environment.Exit(1);
        }

        void Game_TileClick(int x, int y)
        {
            if (ShopTower != null && balance - ShopTower.currentCost >= 0)
            {
                Tile clickedTile = TowerDefense.Controls.GamePanel.loadedMap.MapGrid[x, y];
                if(clickedTile.identity == TileIdentity.Unoccupied)
                {
                    ShopTower.PosX = clickedTile.location.X;
                    ShopTower.PosY = clickedTile.location.Y;
                    Game.AddTowerToListOfTowers(ShopTower);

                    clickedTile.identity = TileIdentity.Tower;
                    clickedTile.occupiedTower = ShopTower;
                    balance -= ShopTower.currentCost;
                    ShopTower = null;
                }
            }
        }

        void Game_TowerUpgrade(TowerDefense.Model.Turrets.Base_Tower tower)
        {
            tower.Upgrade();
        }

        private void Window_Resized(object sender, SizeChangedEventArgs e)
        {
            if (Game == null) return;

            int width = (int)(winFormHost.ActualWidth);
            int height = (int)(winFormHost.ActualHeight);
            Game.Resize(width, height);
        }
       
        private void Buy_Tower(object sender, MouseEventArgs e)
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
                    ShopTower = new Model.Turrets.Basic_Tower(Game.selectedX, Game.selectedY);
                    break;
                case "slow":
                    ShopTower = new Model.Turrets.Slowing_tower(Game.selectedX, Game.selectedY);
                    break;
                case "dot":
                    ShopTower = new Model.Turrets.DoT_Tower(Game.selectedX, Game.selectedY);
                    break;
                case "splash":
                    ShopTower = new Model.Turrets.Splash_Tower(Game.selectedX, Game.selectedY);
                    break;
            }
        }

        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer(); 
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            RoundNumLbl.Content = string.Format("Round: {0}", TowerDefense.Controls.GamePanel.roundNum);
            CoinsLbl.Content = string.Format("Coins: {0}", balance);
            LifeLbl.Content = string.Format("Life Force: {0}", health);
            RoundTime.Content = string.Format("Round Starts in: {0}", TowerDefense.Controls.GamePanel.timeUntilNextRoundMS);
        }
    }
}
