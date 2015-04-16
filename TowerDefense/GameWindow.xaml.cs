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
        public static int balance = 1000;

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

        const int WH_KEYBOARD_LL = 13; // Номер глобального LowLevel-хука на клавиатуру
        const int WM_KEYDOWN = 0x100; // Сообщения нажатия клавиши

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
            PauseAlert.Visibility = Visibility.Hidden;

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 20);
            dispatcherTimer.Start();
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
             //   case 27:
                 //Pause Game w/esc
               //     break;
                case 38:
                    //highlight object w/ up arrow
                  Game.selectedY--;
                    break;
                case 37:
                   //highlight object w/ left arrow
                   Game.selectedX--; 
                    break;
                case 39:
                  //highlight object w/ right arrow
                 Game.selectedX++;   
                    break;
                case 40:
               //highlight object w/ down arrow
                  Game.selectedY++;
                    break;
                case 13:
                    //confirm highlighted object w/ enter
                    break;
                case 49:
                    ShopTower = new Model.Turrets.Basic_Tower();
                    Game_TileClick(Game.selectedX, Game.selectedY);
                    break;
                case 50:
                  ShopTower = new Model.Turrets.Slowing_tower();  //tower hotkey with 2
                  Game_TileClick(Game.selectedX, Game.selectedY);
                    break;
                case 51:
               ShopTower = new Model.Turrets.DoT_Tower();  //tower hotkey with 3
               Game_TileClick(Game.selectedX, Game.selectedY);
                    break;
                case 52:
                ShopTower = new Model.Turrets.Splash_Tower();   //tower hotkey with 4
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
            Game.TileClick += Game_TileClick;
        }

        private void Window_Exit (object sender, System.ComponentModel.CancelEventArgs e)
        {
            UnHook();
        }

        void Game_TileClick(int x, int y)
        {
            if (ShopTower != null && balance - ShopTower.Cost > 0)
            {
                Tile clickedTile = Game.loadedMap.MapGrid[x, y];
                if(clickedTile.identity == TileIdentity.Unoccupied)
                {
                    ShopTower.PosX = clickedTile.location.X;
                    ShopTower.PosY = clickedTile.location.Y;
                    Game.AddTowerToListOfTowers(ShopTower);

                    clickedTile.identity = TileIdentity.Tower;
                    clickedTile.occupiedTower = ShopTower;
                    balance -= ShopTower.Cost;
                    ShopTower = null;
                }
            }
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

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer(); 
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
