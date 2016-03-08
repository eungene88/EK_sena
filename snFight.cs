using System;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;  //[DllImport]를 쓰기 위한 클래스
using System.Threading;
using System.Drawing;


namespace EK_Sena
{

    public class snFight
    {
        private const uint LBDOWN = 0x00000002;  // 왼쪽 마우스 버튼 눌림
        private const uint LBUP = 0x00000004;  // 왼쪽 마우스 버튼 떼어짐

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, int dxExtraInfo);
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);

        public void ConnectFight()
        {
            ColorSpoid cs = new ColorSpoid();
            Color clrScreenColor;

            bool boolSwitchFight = false; ;


            // 메인화면인지 확인한다.
            while (true)
            {
                clrScreenColor = cs.ScreenColor(659, 515);
                if ((clrScreenColor.R >= (46-5) && clrScreenColor.R <= (46 + 5)) && 
                    (clrScreenColor.G >= (49-5) && clrScreenColor.G <= (49 + 5)) && 
                    (clrScreenColor.B >= (59-5) && clrScreenColor.B <= (59 + 5)))
                {  // 메인화면 1차 검증 작업
                    clrScreenColor = cs.ScreenColor(829, 523);
                    if ((clrScreenColor.R >= (76-5) && clrScreenColor.R <= (76 + 5)) && 
                        (clrScreenColor.G >= (74-5) && clrScreenColor.R <= (76 + 5)) && 
                        (clrScreenColor.B >= (74-5) && clrScreenColor.B <= (74 + 5)))
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
                if ((clrScreenColor.R >= (251-5) && clrScreenColor.R <= (251 + 4)) && 
                    (clrScreenColor.G >= (210-5) && clrScreenColor.G <= (210 + 5)) && 
                    (clrScreenColor.B >= (220-5) && clrScreenColor.B <= (220 + 5)))
                {  // 전투화면 1차 검증 작업
                    clrScreenColor = cs.ScreenColor(621, 147);
                    if ((clrScreenColor.R >= (25-5) && clrScreenColor.R <= (25+5)) && 
                        (clrScreenColor.G >= (4-4) && clrScreenColor.G <= (4 + 5)) && 
                        (clrScreenColor.B >= (4-4) && clrScreenColor.B <= (4 + 5)))
                    {  // 전투화면 2차 검증 작업 및 전투입장
                        Thread.Sleep(3000);
                        SetCursorPos(712, 224);
                        mouse_event(LBDOWN | LBUP, 712, 224, 0, 0);
                        break;
                    }
                }
            }

            Thread.Sleep(3000);

            while (true)
            {
                // 결투장 화면에서의 처리 확인
                boolSwitchFight = AdmissionFight();

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

                FightResult();
            }
            // -->결투장 열쇠 확인

            // 플레이어 스킬 확인

            // 결투 시작
            // --> 결투 시작 중간에는 while문으로 끝나는 것을 확인하기 위해서 
        }

        private bool AdmissionFight()
        {   // 결투장 화면
            ColorSpoid cs = new ColorSpoid();
            Color clrScreenColor;
            bool boolKey = false;


            // 결투장 열쇠를 확인한다.
            clrScreenColor = cs.ScreenColor(403, 46);
            if ((clrScreenColor.R >= (246-5) && clrScreenColor.R <= (246 + 5)) && 
                (clrScreenColor.G >= (8-5) && clrScreenColor.G <= (8 + 5)) && 
                (clrScreenColor.B >= 0 && clrScreenColor.B <= (0 + 5)))
            {  // 열쇠가 있으면.. 플레이어 스킬 설정
                // 준비하기 접속
                SetCursorPos(748, 532);
                mouse_event(LBDOWN | LBUP, 748, 532, 0, 0);
                Thread.Sleep(3000);

                //플레이어 스킬 첫 번째로 설정
                SetCursorPos(298, 180);
                mouse_event(LBDOWN | LBUP, 298, 180, 0, 0);
                Thread.Sleep(2000);
                SetCursorPos(519, 95);
                mouse_event(LBDOWN | LBUP, 519, 95, 0, 0);
                Thread.Sleep(2000);
                SetCursorPos(875, 96);
                mouse_event(LBDOWN | LBUP, 875, 96, 0, 0);
                Thread.Sleep(2000);


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

        private void FightResult()
        {
            ColorSpoid cs = new ColorSpoid();
            Color clrScreenColor;

            while (true)
            {
                Thread.Sleep(5000);
                clrScreenColor = cs.ScreenColor(93, 475);
                if ((clrScreenColor.R >= (255-5) && clrScreenColor.R <= 255) && 
                    (clrScreenColor.G >= (255-5) && clrScreenColor.G <= 255) && 
                    (clrScreenColor.B >= (255-5) && clrScreenColor.B <= 255))
                {  // 메인화면 1차 검증 작업
                    clrScreenColor = cs.ScreenColor(98, 567);
                    if ((clrScreenColor.R >= (255-5) && clrScreenColor.R <= 255) && 
                        (clrScreenColor.G >= (255-5) && clrScreenColor.G <= 255) && 
                        (clrScreenColor.B >= (255-5) && clrScreenColor.B <= 255))
                    {  // 메인화면 2차 검증 작업 및 전투입장
                        Thread.Sleep(1000);
                        SetCursorPos(905, 398);
                        mouse_event(LBDOWN | LBUP, 905, 398, 0, 0);
                        Thread.Sleep(3000);
                        break;
                    }
                }
            }
        }
        //private void StartMACRO()
        //{
        //    ColorSpoid cs = new ColorSpoid();
        //    Color clrScreenColor;

        //    bool boolSwitchFight = false; ;

            
        //    // 메인화면을 확인한다.
        //    while (true)
        //    {
        //        clrScreenColor = cs.ScreenColor(659, 515);
        //        if ((clrScreenColor.R.ToString() == "46") && (clrScreenColor.G.ToString() == "49") && (clrScreenColor.B.ToString() == "59"))
        //        {  // 메인화면 1차 검증 작업
        //            clrScreenColor = cs.ScreenColor(829, 523);
        //            if ((clrScreenColor.R.ToString() == "76") && (clrScreenColor.G.ToString() == "74") && (clrScreenColor.B.ToString() == "74"))
        //            {  // 메인화면 2차 검증 작업 및 전투입장
        //                Thread.Sleep(3000);
        //                SetCursorPos(707, 528);
        //                mouse_event(LBDOWN | LBUP, 707, 528, 0, 0);
        //                break;
        //            }
        //        }
        //    }

        //    Thread.Sleep(3000);
        //    // 전투입장 화면을 확인한다.
        //    while (true)
        //    {
        //        clrScreenColor = cs.ScreenColor(134, 176);
        //        if ((clrScreenColor.R.ToString() == "251") && (clrScreenColor.G.ToString() == "210") && (clrScreenColor.B.ToString() == "220"))
        //        {  // 메인화면 1차 검증 작업
        //            clrScreenColor = cs.ScreenColor(621, 147);
        //            if ((clrScreenColor.R.ToString() == "254") && (clrScreenColor.G.ToString() == "253") && (clrScreenColor.B.ToString() == "225"))
        //            {  // 메인화면 2차 검증 작업 및 전투입장
        //                Thread.Sleep(3000);
        //                SetCursorPos(712, 224);
        //                mouse_event(LBDOWN | LBUP, 712, 224, 0, 0);
        //                break;
        //            }
        //        }
        //    }

        //    Thread.Sleep(3000);

        //    while (true)
        //    {
        //        // 결투장 화면에서의 처리 확인
        //        boolSwitchFight = AdmissionFight();

        //        // 키가 없으면 할 처리
        //        if (boolSwitchFight == false)
        //        {  // 결투장 화면에서 빠져나온다.
        //            SetCursorPos(53, 54);
        //            mouse_event(LBDOWN | LBUP, 53, 54, 0, 0);
        //            Thread.Sleep(3000);
        //            SetCursorPos(53, 54);
        //            mouse_event(LBDOWN | LBUP, 53, 54, 0, 0);
        //            break;
        //        }

        //        FightResult();
        //    }

        //    _thread.Abort();
        //}
    }
}
