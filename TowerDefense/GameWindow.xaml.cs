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

using System.Runtime.InteropServices;

namespace TowerDefense
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : MahApps.Metro.Controls.MetroWindow
    {
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
                //////ОБРАБОТКА НАЖАТИЯ
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
                    MessageBox.Show("You pressed pause");//pause w/ p button
                    break;
                case 27:
                  MessageBox.Show("You pressed pause with esc");  //Pause Game w/esc
                    break;
                case 38:
                  MessageBox.Show("You pressed up arrow.");  //highlight object w/ up arrow
                    break;
                case 37:
                   MessageBox.Show("You pressed left arrow."); //highlight object w/ left arrow
                    break;
                case 39:
                 MessageBox.Show("You pressed right arrow.");   //highlight object w/ right arrow
                    break;
                case 40:
                  MessageBox.Show("You pressed down arrow.");  //highlight object w/ down arrow
                    break;
                case 13:
                  MessageBox.Show("You pressed enter.");  //confirm highlighted object w/ enter
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
