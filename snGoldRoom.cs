using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;  //[DllImport]를 쓰기 위한 클래스
using System.Diagnostics;
using System.Threading;
using System.Drawing;

namespace EK_Sena
{
    class snGoldRoom
    {
        private const uint LBDOWN = 0x00000002;  // 왼쪽 마우스 버튼 눌림
        private const uint LBUP = 0x00000004;  // 왼쪽 마우스 버튼 떼어짐

        private int intSetTeam;

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, int dxExtraInfo);
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);

        public void ConnectGoldRoom(int intSelectedTeam)
        {
            ColorSpoid cs = new ColorSpoid();
            Color clrScreenColor;

            intSetTeam = intSelectedTeam;

            bool boolSwitchFight = false; ;

            // 메인화면인지 확인한다.
            while (true)
            {
                clrScreenColor = cs.ScreenColor(659, 515);
                if ((clrScreenColor.R >= (46 - 5) && clrScreenColor.R <= (46 + 5)) &&
                    (clrScreenColor.G >= (49 - 5) && clrScreenColor.G <= (49 + 5)) &&
                    (clrScreenColor.B >= (59 - 5) && clrScreenColor.B <= (59 + 5)))
                {  // 메인화면 1차 검증 작업
                    clrScreenColor = cs.ScreenColor(829, 523);
                    if ((clrScreenColor.R >= (76 - 5) && clrScreenColor.R <= (76 + 5)) &&
                        (clrScreenColor.G >= (74 - 5) && clrScreenColor.R <= (76 + 5)) &&
                        (clrScreenColor.B >= (74 - 5) && clrScreenColor.B <= (74 + 5)))
                    {  // 메인화면 2차 검증 작업 및 전투입장
                        Thread.Sleep(3000);
                        SetCursorPos(707, 528);
                        mouse_event(LBDOWN | LBUP, 707, 528, 0, 0);
                        break;
                    }
                }
            }

            Thread.Sleep(3000);
            // 전투입장 화면을 확인한다.
            while (true)
            {
                clrScreenColor = cs.ScreenColor(134, 176);
                if ((clrScreenColor.R >= (251 - 5) && clrScreenColor.R <= (251 + 4)) &&
                    (clrScreenColor.G >= (210 - 5) && clrScreenColor.G <= (210 + 5)) &&
                    (clrScreenColor.B >= (220 - 5) && clrScreenColor.B <= (220 + 5)))
                {  // 전투화면 1차 검증 작업
                    clrScreenColor = cs.ScreenColor(621, 147);
                    if ((clrScreenColor.R >= (25 - 5) && clrScreenColor.R <= (25 + 5)) &&
                        (clrScreenColor.G >= (4 - 4) && clrScreenColor.G <= (4 + 5)) &&
                        (clrScreenColor.B >= (4 - 4) && clrScreenColor.B <= (4 + 5)))
                    {  // 전투화면 2차 검증 작업 및 전투입장
                        Thread.Sleep(3000);
                        SetCursorPos(175, 218);
                        mouse_event(LBDOWN | LBUP, 175, 218, 0, 0);
                        break;
                    }
                }
            }

            Thread.Sleep(3000);

            while (true)
            {
                // 무한의탑 화면에서의 처리 확인
                boolSwitchFight = AdmissionGoldRoom();

                // 키가 없으면 할 처리
                if (boolSwitchFight == false)
                {  // 결투장 화면에서 빠져나온다.
                    SetCursorPos(53, 54);
                    mouse_event(LBDOWN | LBUP, 53, 54, 0, 0);
                    Thread.Sleep(3000);
                    SetCursorPos(53, 54);
                    mouse_event(LBDOWN | LBUP, 53, 54, 0, 0);
                    break;
                }

                GoldRoomResult();
            }

            // -->결투장 열쇠 확인

            // 플레이어 스킬 확인

            // 결투 시작
            // --> 결투 시작 중간에는 while문으로 끝나는 것을 확인하기 위해서 
        }

        private void GoldRoomResult()
        {
            ColorSpoid cs = new ColorSpoid();
            Color clrScreenColor;

            while (true)
            {
                Thread.Sleep(5000);
                clrScreenColor = cs.ScreenColor(440, 362);
                if ((clrScreenColor.R >= (255-5) && clrScreenColor.R <= 255) && 
                    (clrScreenColor.G >= (129-5) && clrScreenColor.G <= (129 + 5)) && 
                    (clrScreenColor.B >= (54-5) && clrScreenColor.B <= (54 + 5)))
                {  // 메인화면 1차 검증 작업
                    clrScreenColor = cs.ScreenColor(406, 426);
                    if ((clrScreenColor.R >= (252-5) && clrScreenColor.R <= (252 + 3)) && 
                        (clrScreenColor.G >= (182-5) && clrScreenColor.G <= (182 + 5)) && 
                        (clrScreenColor.B >= (19-5) && clrScreenColor.B <= (19 + 5)))
                    {  // 메인화면 2차 검증 작업 및 전투입장
                        Thread.Sleep(1000);
                        SetCursorPos(905, 398);
                        mouse_event(LBDOWN | LBUP, 905, 398, 0, 0);
                        break;
                    }
                }
            }
        }

        private bool AdmissionGoldRoom()
        {   // 결투장 화면
            ColorSpoid cs = new ColorSpoid();
            Color clrScreenColor;
            bool boolKey = false;


            Thread.Sleep(4000);
            // 결투장 열쇠를 확인한다.
            clrScreenColor = cs.ScreenColor(377, 56);
            if ((clrScreenColor.R >= (172-5) && clrScreenColor.R <= (172 + 5)) && 
                (clrScreenColor.G >= (171-5) && clrScreenColor.G <= (171 + 5)) && 
                (clrScreenColor.B >= (209-5) && clrScreenColor.B <= (209 + 5)))
            {  // 열쇠가 있으면.. 플레이어 스킬 설정
                // 준비하기 접속
                SetCursorPos(907, 517);
                mouse_event(LBDOWN | LBUP, 907, 517, 0, 0);
                Thread.Sleep(3000);

                // 플레이어 팀 설정
                if (intSetTeam == 1)
                {
                    SetCursorPos(165, 111);
                    mouse_event(LBDOWN | LBUP, 165, 111, 0, 0);
                    Thread.Sleep(1000);
                }
                else if (intSetTeam == 2)
                {
                    SetCursorPos(264, 111);
                    mouse_event(LBDOWN | LBUP, 264, 111, 0, 0);
                    Thread.Sleep(1000);
                }
                else if (intSetTeam == 3)
                {
                    SetCursorPos(365, 111);
                    mouse_event(LBDOWN | LBUP, 365, 111, 0, 0);
                    Thread.Sleep(1000);
                }

                // 644 533
                // 결투장 시작
                SetCursorPos(644, 533);
                mouse_event(LBDOWN | LBUP, 644, 533, 0, 0);
                boolKey = true;
            }
            else
            {
                boolKey = false;
            }

            return boolKey;
        }
    }
}
