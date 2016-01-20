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
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Runtime.InteropServices;  //[DllImport]를 쓰기 위한 클래스
using System.Diagnostics;
using System.Threading;
using System.Drawing;



namespace EK_Sena
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private const uint LBDOWN = 0x00000002;  // 왼쪽 마우스 버튼 눌림
        private const uint LBUP = 0x00000004;  // 왼쪽 마우스 버튼 떼어짐

        Thread _MainThread;

        bool boolSWFight = false;
        bool boolSWGoldRoom = false;
        bool boolSWAdventure = false;
        bool boolSWRaid = false;

        int intGoldTeam;        // 황금의방 접근 팀
        int intAdventureTeam;   // 모험(쫄짝) 접근 팀
        int intAdventureLevel;  // 모험 난이도
        int intAdventurePlace;  // 모헌 쫄작 장소
        int intAdventureRepeat; // 모험 반복 횟수
        bool[] boolChangeDeck = new bool[5];

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int ccx, int cy, int wFlags);
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, int dxExtraInfo);
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmEK_Sena_Loaded(object sender, RoutedEventArgs e)
        {
            //Process[] processes = Process.GetProcessesByName("HD-Frontend.exe");
        }

        private void btnBlueStart_Click(object sender, RoutedEventArgs e)
        {
            const int SWP_SHOWWINDOW = 0x0040;

            Process[] prsGetList = Process.GetProcesses();
            bool boolBluestackSwitch = false;
            IntPtr handleBluestack; //블루스택 윈도우 핸들

            for (int i = 0; i < prsGetList.Length; i++)
            {
                //string strProcessName = prsGetList[i].ProcessName;
                if (prsGetList[i].ProcessName.Equals("HD-Frontend"))
                {
                    boolBluestackSwitch = true;
                    MessageBox.Show("이미 실행중입니다.");
                    break;
                }
            }

            if (boolBluestackSwitch == false)
            {
                Process prsBluestack = new Process();
                boolBluestackSwitch = true;
                prsBluestack.StartInfo.FileName = "C:\\Program Files (x86)\\BlueStacks\\HD-StartLauncher.exe";
                prsBluestack.Start();
                Thread.Sleep(5000);

                for (int i = 0; i < prsGetList.Length; i++)
                {
                    if (prsGetList[i].ProcessName.Equals("HD-Frontend"))
                    {
                        handleBluestack = prsGetList[i].MainWindowHandle;
                        SetWindowPos(handleBluestack, 0, 0, 0, 962, 627, SWP_SHOWWINDOW);
                        break;
                    }
                }
            }

            //if (boolBluestackSwitch == true)
            //{
            //    for (int i = 0; i < prsGetList.Length; i++)
            //    {
            //        if (prsGetList[i].ProcessName.Equals("HD-Frontend"))
            //        {
            //            handleBluestack = prsGetList[i].MainWindowHandle;
            //            SetWindowPos(handleBluestack, 0, 0, 0, 0, 0, SWP_SHOWWINDOW);
            //            break;
            //        }
            //    }
            //    MessageBox.Show("완료");
                
            //}

            //SetWindowPos(handleBluestack, 0, 0, 0, )
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            const int SWP_SHOWWINDOW = 0x0040;

            IntPtr handleBluestack;
            Process[] prsGetList = Process.GetProcesses();
            for (int i = 0; i < prsGetList.Length; i++)
            {
                if (prsGetList[i].ProcessName.Equals("HD-Frontend"))
                {
                    handleBluestack = prsGetList[i].MainWindowHandle;
                    SetWindowPos(handleBluestack, 0, 0, 0, 962, 627, SWP_SHOWWINDOW);
                    break;
                }
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStop.IsEnabled = true;

            chkFight.IsEnabled = false;
            chkGoldRoom.IsEnabled = false;
            chkAdventure.IsEnabled = false;
            chkRide.IsEnabled = false;
            btnStart.IsEnabled = false;



            if(chkFight.IsChecked == true)
                boolSWFight = true;

            if (chkGoldRoom.IsChecked == true)
            {
                boolSWGoldRoom = true;
                intGoldTeam = cmbGoldRoomTeam.SelectedIndex+1;
            }

            if (chkAdventure.IsChecked == true)
            {
                boolSWAdventure = true;
                intAdventureLevel = cmbLevel.SelectedIndex + 1;
                intAdventureTeam = cmbAdventureTeam.SelectedIndex + 1;
                intAdventurePlace = cmbPlace.SelectedIndex;
                intAdventureRepeat = cmbRepeat.SelectedIndex + 1;

                for (int i = 0; i <= 4; i++)
                    boolChangeDeck[i] = false;

                if (chk1Deck.IsChecked == true)
                    boolChangeDeck[0] = true;
                if (chk2Deck.IsChecked == true)
                    boolChangeDeck[1] = true;
                if (chk3Deck.IsChecked == true)
                    boolChangeDeck[2] = true;
                if (chk4Deck.IsChecked == true)
                    boolChangeDeck[3] = true;
                if (chk5Deck.IsChecked == true)
                    boolChangeDeck[4] = true;
            }

            if (chkRide.IsChecked == true)
            {
                boolSWRaid = true;
            }

            _MainThread = new Thread(new ThreadStart(MacroLoop));
            _MainThread.IsBackground = true;
            _MainThread.Start();
        }

        private void MacroLoop()
        {
            snFight snFightConnect = new snFight();
            snGoldRoom snGoldRoomConnect = new snGoldRoom();
            snAdventure snAdventureConnect = new snAdventure();

            while (true)
            {
                if (boolSWFight == true)
                {
                    Thread.Sleep(1000);
                    snFightConnect.ConnectFight();
                }

                if (boolSWGoldRoom == true)
                {
                    Thread.Sleep(1000);

                    if (intGoldTeam == 1)
                        snGoldRoomConnect.ConnectGoldRoom(1);
                    else if (intGoldTeam == 2)
                        snGoldRoomConnect.ConnectGoldRoom(2);
                    else if (intGoldTeam == 3)
                        snGoldRoomConnect.ConnectGoldRoom(3);
                }

                if (boolSWAdventure == true)
                {
                    int[] MapPosition = new int[3];
                    // 선택 영지에 따른 마우스 좌표
                    AdventureMapPosition amp = new AdventureMapPosition();
                    MapPosition = amp.MapPosition(intAdventurePlace);

                    snAdventureConnect.ConnectAdventure(intAdventureLevel, intAdventureTeam, MapPosition, intAdventureRepeat, boolChangeDeck);

                }

                if (boolSWRaid == true)
                {

                }
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            _MainThread.Abort();
            btnStart.IsEnabled = true;
            chkFight.IsEnabled = true;
            chkGoldRoom.IsEnabled = true;
            chkAdventure.IsEnabled = true;
            chkRide.IsEnabled = true;

            btnStop.IsEnabled = false;
            
            
        }
    }
}
