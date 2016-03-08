using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;  //[DllImport]를 쓰기 위한 클래스
using System.Threading;
using System.Drawing;

namespace EK_Sena
{
    class snAdventure
    {
        private const uint LBDOWN = 0x00000002;  // 왼쪽 마우스 버튼 눌림
        private const uint LBUP = 0x00000004;  // 왼쪽 마우스 버튼 떼어짐

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, int dxExtraInfo);
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);

        ColorSpoid cs = new ColorSpoid();
        Color clrScreenColor;

        public void ConnectAdventure(int Level, int Team, int[] Position, int AdventureRepeat, bool[] boolCheckedDeck)
        {
            
            AdventureMapPosition getMaps = new AdventureMapPosition();

            int[] nowPosition = new int[2];
            bool[] boolGoToChangeDeck = new bool[5];

            // 메인화면인지 확인한다.
            while (true)
            {   // 아스트대륙 or 그림자의 눈
                Thread.Sleep(100);
                clrScreenColor = cs.ScreenColor(659, 515);
                if ((clrScreenColor.R >= (46-5) && clrScreenColor.R <= (46 + 5)) && 
                    (clrScreenColor.G >= (49-5) && clrScreenColor.G <= (49 + 5)) && 
                    (clrScreenColor.B >= (59-5) && clrScreenColor.B <= (59 + 5)))
                {  
                    clrScreenColor = cs.ScreenColor(829, 523);
                    if ((clrScreenColor.R >= (76-5) && clrScreenColor.R <= (76 + 5)) && 
                        (clrScreenColor.G >= (74-5) && clrScreenColor.G <= (74 + 5)) && 
                        (clrScreenColor.B >= (74-5) && clrScreenColor.B <= (74 + 5)))
                    {   // 메인화면 2차 검증 작업 및 전투입장
                        Thread.Sleep(3000);
                        SetCursorPos(883, 528);
                        mouse_event(LBDOWN | LBUP, 883, 528, 0, 0);
                        break;
                    }
                }
            }

            Thread.Sleep(3000);
            

            // 현재 나와있는 맵을 확인한다.
            // 아스트, 달빛, 검은 눈인지??
            while (true)
            {
                // 아스트대륙 or 그림자의 눈
                int[] tempPosition = new int[10];
                clrScreenColor = cs.ScreenColor(837, 496);
                if ((clrScreenColor.R >= (249-5) && clrScreenColor.R <= (249 + 5)) && 
                    (clrScreenColor.G >= 110 && clrScreenColor.G <= 115) && 
                    (clrScreenColor.B >= 2 && clrScreenColor.B <= 12))
                {  // 메인화면 1차 검증 작업
                    clrScreenColor = cs.ScreenColor(900, 504);
                    if ((clrScreenColor.R >= 247 && clrScreenColor.R <= 255) && 
                        (clrScreenColor.G >= 241 && clrScreenColor.G <= 251) && 
                        (clrScreenColor.B >= 220 && clrScreenColor.B <= 225))
                    {   // 아스트대륙인지 그림자의 눈인지 확인
                        clrScreenColor = cs.ScreenColor(187, 567);
                        if ((clrScreenColor.R <= 5) && 
                            (clrScreenColor.G <= 5) && 
                            (clrScreenColor.B <= 5))
                        {   // 여기는 그림자의 눈
                            // 맵이 어디인지 보고, 선택한 화면이 어디인지에 따라 진행.
                            if (Position[2] >= 19)
                            {   // 선택한 포지션이 그림자의 눈이 맞는가?
                                SetLevel(Level);

                                SetCursorPos(Position[0], Position[1]);
                                mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                Thread.Sleep(500);
                                break;
                            }
                            else
                            {   // 아니면?
                                if (Position[2] <= 18)
                                {
                                    SetCursorPos(907, 527);
                                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                }
                            }
                        }
                        else
                        {   // 여기는 아스트 대륙
                            // 맵이 어디인지 보고, 선택한 화면이 어디인지에 따라 진행.
                            tempPosition = getMaps.ContinentPosition(Position[2]);
                            if (Position[2] >= 1 && Position[2] <= 7)
                            {   // 선택한 포지션이 달빛의 섬이 맞는가?
                                // 맵 이동하는 프로세스 추가.
                                while (true)
                                {
                                    clrScreenColor = cs.ScreenColor(tempPosition[0], tempPosition[1]);
                                    if ((clrScreenColor.R >= (tempPosition[2]-5) && clrScreenColor.R <= (tempPosition[2] + 5)) &&
                                        (clrScreenColor.G >= (tempPosition[3]-5) && clrScreenColor.G <= (tempPosition[3] + 5)) &&
                                        (clrScreenColor.B >= (tempPosition[4]-5) && clrScreenColor.B <= (tempPosition[4] + 5)))
                                    {
                                        clrScreenColor = cs.ScreenColor(tempPosition[5], tempPosition[6]);
                                        if ((clrScreenColor.R >= (tempPosition[7]-5) && clrScreenColor.R <= (tempPosition[7] + 5)) &&
                                            (clrScreenColor.G >= (tempPosition[8]-5) && clrScreenColor.G <= (tempPosition[8] + 5)) &&
                                            (clrScreenColor.B >= (tempPosition[9]-5) && clrScreenColor.B <= (tempPosition[9] + 5)))
                                        {
                                            // 난이도를 설정한다.
                                            SetLevel(Level);
                                            //선택한 화면을 찾으면 해당 스테이지로 접근
                                            SetCursorPos(Position[0], Position[1]);
                                            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                            Thread.Sleep(1500);
                                            break;
                                        }
                                    }
                                    //화살표를 눌러서 옆화면으로 넘어간다.
                                    SetCursorPos(940, 297);
                                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                    Thread.Sleep(2000);
                                }
                                break;
                            }
                            else
                            {   //아니면??
                                if (Position[2] >= 8)
                                {
                                    SetCursorPos(907, 527);
                                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                    Thread.Sleep(1500);
                                }
                            }
                        }
                    }
                }

                // 달빛의 섬
                clrScreenColor = cs.ScreenColor(654, 494);
                if ((clrScreenColor.R >= 244 && clrScreenColor.R <= 255) && 
                    (clrScreenColor.G >= 81 && clrScreenColor.G <= 90) && 
                    (clrScreenColor.B >= 0 && clrScreenColor.B <= 7))
                {
                    clrScreenColor = cs.ScreenColor(904, 522);
                    if ((clrScreenColor.R >= 108 && clrScreenColor.R <= 118) &&  // 113
                        (clrScreenColor.G >= 58 && clrScreenColor.G <= 68) &&  // 63
                        (clrScreenColor.B >= 44 && clrScreenColor.B <= 54)) //49
                    {   // 여기는 달빛의 섬
                        // 맵이 어디인지 보고, 선택한 화면이 어디인지에 따라 진행.
                        if (Position[2] >= 8 && Position[2] <= 18)
                        {   // 선택한 포지션이 달빛의 섬이 맞는가?
                            // 맵 이동하는 프로세스 추가.
                            tempPosition = getMaps.ContinentPosition(Position[2]);
                            while (true)
                            {
                                clrScreenColor = cs.ScreenColor(tempPosition[0], tempPosition[1]);
                                if ((clrScreenColor.R >= (tempPosition[2]-5) && clrScreenColor.R <= (tempPosition[2] + 5)) &&
                                    (clrScreenColor.G >= (tempPosition[3]-5) && clrScreenColor.G <= (tempPosition[3] + 5)) &&
                                    (clrScreenColor.B >= (tempPosition[4]-5) && clrScreenColor.B <= (tempPosition[4] + 5)))
                                {
                                    clrScreenColor = cs.ScreenColor(tempPosition[5], tempPosition[6]);
                                    if ((clrScreenColor.R >= (tempPosition[7]-5) && clrScreenColor.R <= (tempPosition[7] + 5)) &&
                                        (clrScreenColor.G >= (tempPosition[8]-5) && clrScreenColor.G <= (tempPosition[8] + 5)) &&
                                        (clrScreenColor.B >= (tempPosition[9]-5) && clrScreenColor.B <= (tempPosition[9] + 5)))
                                    {
                                        //난이도를 설정한다.
                                        SetLevel(Level);

                                        // 해당 스테이지로 접근한다.
                                        SetCursorPos(Position[0], Position[1]);
                                        mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                        Thread.Sleep(1500);
                                        break;
                                    }
                                }
                                //옆 화면으로 넘긴다.
                                SetCursorPos(940, 297);
                                mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                Thread.Sleep(2000);
                            }
                            break;
                        }
                        else
                        {   // 아니면?
                            if (Position[2] <= 7)
                            {   // 아스트대륙으로 이동
                                SetCursorPos(819, 523);
                                mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                Thread.Sleep(1500);
                            }
                            else if (Position[2] >= 19)
                            {   //그림자의 눈으로 이동
                                SetCursorPos(905, 533);
                                mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                                Thread.Sleep(1500);
                            }
                        }
                    }
                }
            }

            // 모험준비로 들어간다.
            SetCursorPos(480, 530);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);

            Thread.Sleep(1500);

            //팀을 선택한다.
            switch (Team)
            {
                case 1:
                    SetCursorPos(161, 105);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 2:
                    SetCursorPos(262, 105);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 3:
                    SetCursorPos(363, 105);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
            }
            Thread.Sleep(1000);


            //여기서부터 계속 반복
            // 선택한 영웅진열 번호 중에 30 만렙이 있는지 확인한다.
            //while (AdventureRepeat >= 1)
            //{
            //    AdventureRepeat--;
            //}

            //MainForm에서 몇 번 덱을 선택했는지 값을 가져온다.
            for (int i = 0; i <= 4; i++)
            {
                boolGoToChangeDeck[i] = false;
                if (boolCheckedDeck[i] == true)
                {   // 메인폼에서 쫄작덱을 선택했는지 확인한다.
                    if (CheckDecks(i+1))
                    {   // 체크한 덱의 레벨이 30인지 확인한다.
                        boolGoToChangeDeck[i] = true;
                        //SetCursorPos(202, 545);
                        //mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    }
                }
            }

            //체크 후 바뀔 것이 있으면 체인지
            for (int i = 0; i <= 4; i++)
            {
                if (boolGoToChangeDeck[i] == true)
                {
                    // 영웅관리에 들어간다.
                    SetCursorPos(202, 545);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    Thread.Sleep(1500);
                    ChangeDecks(i);
                    break;
                }
            }



            //덱을 해제한 후에 레벨 1짜리를 그 자리에 다시 배치해준다.
            //if (boolChangeNumber[0] == true) // 1번
            //{
            //    bool boolExist;
            //    // 레벨 1짜리 덱이 남아 있는지 확인
            //    boolExist = SearchLevel1(intUsedDeck);
            //    // 30짜리 덱을 선택
            //    SetCursorPos(171, 179);
            //    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
            //    Thread.Sleep(1000);
            //    // 덱을 해제
            //    SetCursorPos(848, 519);
            //    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
            //    Thread.Sleep(1000);

            //}




            //////////////////////////////////////////////
            // 게임을 시작한다.
            //////////////////////////////////////////////
            SetCursorPos(697, 528);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);


            Thread.Sleep(1000);
        }

        private void ChangeDecks(int DeckNumber)
        {
            // 정렬기준을 레벨로 선택을 한다.
            SetCursorPos(825, 111);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
            Thread.Sleep(1000);
            SetCursorPos(825, 354);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
            Thread.Sleep(1000);
            // 화살표 버튼을 클릭한다.
            SetCursorPos(889, 111);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
            Thread.Sleep(1000);
            clrScreenColor = cs.ScreenColor(889, 111);
            if ((clrScreenColor.R >= 92 - 3) && (clrScreenColor.R <= 92 + 3) &&
               (clrScreenColor.G >= 38 - 3) && (clrScreenColor.G <= 38 + 3) &&
               (clrScreenColor.B >= 14 - 3) && (clrScreenColor.B <= 14 + 3))
            {   // 내림차선 정렬이 되어 있으면 다시 재클릭 해준다.
                SetCursorPos(889, 111);
                mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
            }

            // Deck Number에 따라서 덱을 바꿔준다.
            // 1. 덱을 해제해준다.
            ClearDeck(DeckNumber);

            // 2. 레벨 1짜리 덱을 넣어준다.
            SearchLevel1(DeckNumber);

            switch (DeckNumber)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        private void ClearDeck(int DeckNumber)
        {
            switch (DeckNumber)
            {
                case 0:
                    SetCursorPos(74, 325);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 1:
                    SetCursorPos(171, 178);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 2:
                    SetCursorPos(161, 272);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 3:
                    SetCursorPos(171, 376);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 4:
                    SetCursorPos(171, 468);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
            }

            // 덱 해제 버튼을 누른다.
            SetCursorPos(852, 520);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
        }

        private void SearchLevel1(int DeckNumber)
        {
            int[,] tempLevel30Position = new int[4, 5];
            
            tempLevel30Position[0, 0] = 435;
            tempLevel30Position[0, 1] = 263;
            tempLevel30Position[0, 2] = 190;
            tempLevel30Position[0, 3] = 133;
            tempLevel30Position[0, 4] = 17;
            tempLevel30Position[1, 0] = 588;
            tempLevel30Position[1, 1] = 262;
            tempLevel30Position[1, 2] = 251;
            tempLevel30Position[1, 3] = 206;
            tempLevel30Position[1, 4] = 43;
            tempLevel30Position[2, 0] = 741;
            tempLevel30Position[2, 1] = 262;
            tempLevel30Position[2, 2] = 254;
            tempLevel30Position[2, 3] = 211;
            tempLevel30Position[2, 4] = 45;
            tempLevel30Position[3, 0] = 893;
            tempLevel30Position[3, 1] = 262;
            tempLevel30Position[3, 2] = 248;
            tempLevel30Position[3, 3] = 204;
            tempLevel30Position[3, 4] = 43;


            //clrScreenColor = cs.ScreenColor(tempLevel30Position[DeckNumber, 0], tempLevel30Position[DeckNumber, 1]);
            //// 레벨 오름차순으로 했는데도, 첫 번째 덱이 레벨 30인지 확인한다.
            //if ((clrScreenColor.R >= tempLevel30Position[DeckNumber, 2] - 5) && (clrScreenColor.R <= tempLevel30Position[DeckNumber, 2] + 5) &&
            //    (clrScreenColor.G >= tempLevel30Position[DeckNumber, 3] - 5) && (clrScreenColor.G <= tempLevel30Position[DeckNumber, 3] + 5) &&
            //    (clrScreenColor.B >= tempLevel30Position[DeckNumber, 4] - 5) && (clrScreenColor.B <= tempLevel30Position[DeckNumber, 4] + 5))
            //{   // 일반 영웅 레벨이 30이라서 쫄작할게 없다면, 원소영웅을 클릭한다.
            //    SetCursorPos(713, 113);
            //    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
            //    Thread.Sleep(400);


            //    if ((clrScreenColor.R >= tempLevel30Position[DeckNumber, 2] - 3) && (clrScreenColor.R <= tempLevel30Position[DeckNumber, 2] + 3) &&
            //    (clrScreenColor.G >= tempLevel30Position[DeckNumber, 3] - 3) && (clrScreenColor.G <= tempLevel30Position[DeckNumber, 3] + 3) &&
            //    (clrScreenColor.B >= tempLevel30Position[DeckNumber, 4] - 3) && (clrScreenColor.B <= tempLevel30Position[DeckNumber, 4] + 3))
            //    {   // 또 레벨 30짜리가 있으면, 쫄짝이 완료된 상태이므로 그 자리에 레벨 30짜리 캐릭터를 아무거나 넣어준다.

            //    }
            //}
            // 첫 번째 덱 선택
            SetCursorPos(393, 236);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
            // 팀 배치
            SetCursorPos(851, 523);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);

            switch (DeckNumber)
            {
                case 0:
                    SetCursorPos(74, 325);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 1:
                    SetCursorPos(171, 178);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 2:
                    SetCursorPos(161, 272);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 3:
                    SetCursorPos(171, 376);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
                case 4:
                    SetCursorPos(171, 468);
                    mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);
                    break;
            }
            //뒤로가기
            SetCursorPos(51, 54);
            mouse_event(LBDOWN | LBUP, 0, 0, 0, 0);

            Thread.Sleep(200);
        }


        // 만렙(30)짜리 덱이 있는지 확인한다.
        private bool CheckDecks(int ChangeDeckNumber)
        {
            ColorSpoid cs = new ColorSpoid();
            Color clrScreenColor;
            snCheckDeckPosition cdp = new snCheckDeckPosition();

            bool match = false;
            int[,] tempPixels = new int[38, 5];
            
            // 영웅에 빈칸이 있다면, 그 빈칸에 대한 처리를 이 곳에 해준다.
            // 지금은 하지 않는다.

            tempPixels = cdp.Level30_Position(ChangeDeckNumber);
            
            for(int i = 0; i<4; i++)
            {
                clrScreenColor = cs.ScreenColor(tempPixels[i, 0], tempPixels[i, 1]);
                if (((clrScreenColor.R >= tempPixels[i, 2]-6) && (clrScreenColor.R <= tempPixels[i, 2]+6)) && 
                    ((clrScreenColor.G >= tempPixels[i, 3]-6) && (clrScreenColor.G <= tempPixels[i, 3]+6)) && 
                    ((clrScreenColor.B >= tempPixels[i, 4]-6) && (clrScreenColor.B <= tempPixels[i, 4]+6)))
                {
                    match = true;
                }
                else
                {
                    match = false;
                    break;
                }
            }

            return match;
        }

        private void SetLevel(int Level)
        {
            // 난이도 조정 method
            SetCursorPos(84, 543);
            mouse_event(LBDOWN | LBUP, 84, 543, 0, 0);
            Thread.Sleep(1000);
            if (Level == 1)
            {
                SetCursorPos(84, 503);
                mouse_event(LBDOWN | LBUP, 84, 503, 0, 0);
            }
            else if (Level == 2)
            {
                SetCursorPos(84, 464);
                mouse_event(LBDOWN | LBUP, 84, 464, 0, 0);
            }
            else if (Level == 3)
            {
                SetCursorPos(84, 427);
                mouse_event(LBDOWN | LBUP, 84, 427, 0, 0);

            }
            Thread.Sleep(1000);
        }
    }
}
