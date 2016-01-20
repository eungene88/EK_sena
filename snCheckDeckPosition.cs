
namespace EK_Sena
{
    class snCheckDeckPosition
    {
        public int[,] Level30_Position(int DeckNumber)
        {
            int[,] pixels = new int[4, 5];

            if (DeckNumber == 1)
            {
                pixels[0, 0] = 280;
                pixels[0, 1] = 208;
                pixels[0, 2] = 240;
                pixels[0, 3] = 180;
                pixels[0, 4] = 28;     // Complete
                pixels[1, 0] = 280;
                pixels[1, 1] = 209;
                pixels[1, 2] = 226;
                pixels[1, 3] = 124;
                pixels[1, 4] = 2;   // Complete
                pixels[2, 0] = 281;
                pixels[2, 1] = 208;
                pixels[2, 2] = 240;
                pixels[2, 3] = 162;
                pixels[2, 4] = 20;  //
                pixels[3, 0] = 281;
                pixels[3, 1] = 209;
                pixels[3, 2] = 220;
                pixels[3, 3] = 117;
                pixels[3, 4] = 1;  //
            }
            else if (DeckNumber == 2)
            {
                pixels[0, 0] = 280;
                pixels[0, 1] = 306;
                pixels[0, 2] = 162;
                pixels[0, 3] = 101;
                pixels[0, 4] = 4;     // Complete
                pixels[1, 0] = 280;
                pixels[1, 1] = 307;
                pixels[1, 2] = 148;
                pixels[1, 3] = 71;
                pixels[1, 4] = 0;   // Complete
                pixels[2, 0] = 281;
                pixels[2, 1] = 306;
                pixels[2, 2] = 183;
                pixels[2, 3] = 121;
                pixels[2, 4] = 8;  //
                pixels[3, 0] = 281;
                pixels[3, 1] = 307;
                pixels[3, 2] = 166;
                pixels[3, 3] = 82;
                pixels[3, 4] = 0;  //
            }
            else if (DeckNumber == 3)
            {
                pixels[0, 0] = 280;
                pixels[0, 1] = 403;
                pixels[0, 2] = 114;
                pixels[0, 3] = 84;
                pixels[0, 4] = 10;     // Complete
                pixels[1, 0] = 280;
                pixels[1, 1] = 404;
                pixels[1, 2] = 242;
                pixels[1, 3] = 182;
                pixels[1, 4] = 25;   // Complete
                pixels[2, 0] = 281;
                pixels[2, 1] = 403;
                pixels[2, 2] = 149;
                pixels[2, 3] = 117;
                pixels[2, 4] = 14;  //
                pixels[3, 0] = 281;
                pixels[3, 1] = 404;
                pixels[3, 2] = 246;
                pixels[3, 3] = 168;
                pixels[3, 4] = 18;  //
            }
            else if (DeckNumber == 4)
            {
                pixels[0, 0] = 280;
                pixels[0, 1] = 501;
                pixels[0, 2] = 172;
                pixels[0, 3] = 129;
                pixels[0, 4] = 15;     // Complete
                pixels[1, 0] = 280;
                pixels[1, 1] = 502;
                pixels[1, 2] = 242;
                pixels[1, 3] = 163;
                pixels[1, 4] = 16;   // Complete
                pixels[2, 0] = 281;
                pixels[2, 1] = 501;
                pixels[2, 2] = 196;
                pixels[2, 3] = 144;
                pixels[2, 4] = 16;  //
                pixels[3, 0] = 281;
                pixels[3, 1] = 502;
                pixels[3, 2] = 240;
                pixels[3, 3] = 148;
                pixels[3, 4] = 11;  //
            }
            else if (DeckNumber == 5)
            {
                pixels[0, 0] = 188;
                pixels[0, 1] = 354;
                pixels[0, 2] = 84;
                pixels[0, 3] = 56;
                pixels[0, 4] = 12;     // Complete
                pixels[1, 0] = 188;
                pixels[1, 1] = 355;
                pixels[1, 2] = 163;
                pixels[1, 3] = 92;
                pixels[1, 4] = 4;   // Complete
                pixels[2, 0] = 189;
                pixels[2, 1] = 354;
                pixels[2, 2] = 109;
                pixels[2, 3] = 80;
                pixels[2, 4] = 12;  //
                pixels[3, 0] = 189;
                pixels[3, 1] = 355;
                pixels[3, 2] = 189;
                pixels[3, 3] = 111;
                pixels[3, 4] = 4;  //
            }

            //int[,] pixels = new int[39, 5];

            ////278, 207
            //// 첫번째 영웅에 대한 30좌표
            //pixels[0, 0] = 278;
            //pixels[0, 1] = 206;
            //pixels[0, 2] = 231;
            //pixels[0, 3] = 152;
            //pixels[0, 4] = 12;     // Complete
            //pixels[1, 0] = 279;
            //pixels[1, 1] = 206;
            //pixels[1, 2] = 166;
            //pixels[1, 3] = 100;
            //pixels[1, 4] = 7;   // Complete
            //pixels[2, 0] = 278;
            //pixels[2, 1] = 205;
            //pixels[2, 2] = 208;
            //pixels[2, 3] = 171;
            //pixels[2, 4] = 35;  //
            //pixels[3, 0] = 279;
            //pixels[3, 1] = 205;
            //pixels[3, 2] = 224;
            //pixels[3, 3] = 147;
            //pixels[3, 4] = 25;  //
            //pixels[4, 0] = 279;
            //pixels[4, 1] = 204;
            //pixels[4, 2] = 247;
            //pixels[4, 3] = 205;
            //pixels[4, 4] = 57; //
            //pixels[5, 0] = 280;
            //pixels[5, 1] = 204;
            //pixels[5, 2] = 250;
            //pixels[5, 3] = 187;
            //pixels[5, 4] = 48;  //
            //pixels[6, 0] = 281;
            //pixels[6, 1] = 204;
            //pixels[6, 2] = 250;
            //pixels[6, 3] = 187;
            //pixels[6, 4] = 48; //
            //pixels[7, 0] = 282;
            //pixels[7, 1] = 204;
            //pixels[7, 2] = 249;
            //pixels[7, 3] = 192;
            //pixels[7, 4] = 51; //
            //pixels[8, 0] = 283;
            //pixels[8, 1] = 204;
            //pixels[8, 2] = 236;
            //pixels[8, 3] = 186;
            //pixels[8, 4] = 48; //
            //pixels[9, 0] = 282;
            //pixels[9, 1] = 205;
            //pixels[9, 2] = 242;
            //pixels[9, 3] = 160;
            //pixels[9, 4] = 28; //
            //pixels[10, 0] = 283;
            //pixels[10, 1] = 205;
            //pixels[10, 2] = 251;
            //pixels[10, 3] = 166;
            //pixels[10, 4] = 30; //
            //pixels[11, 0] = 284;
            //pixels[11, 1] = 205;
            //pixels[11, 2] = 224;
            //pixels[11, 3] = 146;
            //pixels[11, 4] = 23; //
            //pixels[12, 0] = 283;
            //pixels[12, 1] = 206;
            //pixels[12, 2] = 252;
            //pixels[12, 3] = 158;
            //pixels[12, 4] = 13; //
            //pixels[13, 0] = 284;
            //pixels[13, 1] = 206;
            //pixels[13, 2] = 231;
            //pixels[13, 3] = 143;
            //pixels[13, 4] = 11;//
            //pixels[14, 0] = 283;
            //pixels[14, 1] = 207;
            //pixels[14, 2] = 251;
            //pixels[14, 3] = 172;
            //pixels[14, 4] = 12;//
            //pixels[15, 0] = 280;
            //pixels[15, 1] = 208;
            //pixels[15, 2] = 240;
            //pixels[15, 3] = 179;
            //pixels[15, 4] = 26;//
            //pixels[16, 0] = 281;
            //pixels[16, 1] = 208;
            //pixels[16, 2] = 240;
            //pixels[16, 3] = 161;
            //pixels[16, 4] = 19;//
            //pixels[17, 0] = 282;
            //pixels[17, 1] = 208;
            //pixels[17, 2] = 244;
            //pixels[17, 3] = 148;
            //pixels[17, 4] = 10;//
            //pixels[18, 0] = 283;
            //pixels[18, 1] = 208;
            //pixels[18, 2] = 229;
            //pixels[18, 3] = 122;
            //pixels[18, 4] = 1;//
            //pixels[19, 0] = 280;
            //pixels[19, 1] = 209;
            //pixels[19, 2] = 226;
            //pixels[19, 3] = 124;
            //pixels[19, 4] = 2;//
            //pixels[20, 0] = 281;
            //pixels[20, 1] = 209;
            //pixels[20, 2] = 220;
            //pixels[20, 3] = 117;
            //pixels[20, 4] = 1;//
            //pixels[21, 0] = 282;
            //pixels[21, 1] = 209;
            //pixels[21, 2] = 234;
            //pixels[21, 3] = 123;
            //pixels[21, 4] = 1;//
            //pixels[22, 0] = 283;
            //pixels[22, 1] = 209;
            //pixels[22, 2] = 236;
            //pixels[22, 3] = 123;
            //pixels[22, 4] = 0;//
            //pixels[23, 0] = 283;
            //pixels[23, 1] = 210;
            //pixels[23, 2] = 228;
            //pixels[23, 3] = 119;
            //pixels[23, 4] = 0;//
            //pixels[24, 0] = 284;
            //pixels[24, 1] = 210;
            //pixels[24, 2] = 211;
            //pixels[24, 3] = 110;
            //pixels[24, 4] = 0;//
            //pixels[25, 0] = 283;
            //pixels[25, 1] = 211;
            //pixels[25, 2] = 234;
            //pixels[25, 3] = 126;
            //pixels[25, 4] = 5;//
            //pixels[26, 0] = 284;
            //pixels[26, 1] = 211;
            //pixels[26, 2] = 210;
            //pixels[26, 3] = 107;
            //pixels[26, 4] = 0;//
            //pixels[27, 0] = 283;
            //pixels[27, 1] = 212;
            //pixels[27, 2] = 247;
            //pixels[27, 3] = 148;
            //pixels[27, 4] = 16;//
            //pixels[28, 0] = 284;
            //pixels[28, 1] = 212;
            //pixels[28, 2] = 207;
            //pixels[28, 3] = 106;
            //pixels[28, 4] = 0;//
            //pixels[29, 0] = 282;
            //pixels[29, 1] = 213;
            //pixels[29, 2] = 225;
            //pixels[29, 3] = 161;
            //pixels[29, 4] = 22;//
            //pixels[30, 0] = 283;
            //pixels[30, 1] = 213;
            //pixels[30, 2] = 248;
            //pixels[30, 3] = 151;
            //pixels[30, 4] = 13;//
            //pixels[31, 0] = 284;
            //pixels[31, 1] = 213;
            //pixels[31, 2] = 208;
            //pixels[31, 3] = 111;
            //pixels[31, 4] = 0;//
            //pixels[32, 0] = 282;
            //pixels[32, 1] = 214;
            //pixels[32, 2] = 194;
            //pixels[32, 3] = 106;
            //pixels[32, 4] = 1;//
            //pixels[33, 0] = 281;
            //pixels[33, 1] = 214;
            //pixels[33, 2] = 195;
            //pixels[33, 3] = 107;
            //pixels[33, 4] = 1;//
            //pixels[34, 0] = 280;
            //pixels[34, 1] = 214;
            //pixels[34, 2] = 197;
            //pixels[34, 3] = 107;
            //pixels[34, 4] = 0;//
            //pixels[35, 0] = 279;
            //pixels[35, 1] = 214;
            //pixels[35, 2] = 202;
            //pixels[35, 3] = 110;
            //pixels[35, 4] = 0;//
            //pixels[36, 0] = 279;
            //pixels[36, 1] = 213;
            //pixels[36, 2] = 233;
            //pixels[36, 3] = 136;
            //pixels[36, 4] = 8;//
            //pixels[37, 0] = 278;
            //pixels[37, 1] = 213;
            //pixels[37, 2] = 252;
            //pixels[37, 3] = 159;
            //pixels[37, 4] = 15;
            //pixels[38, 0] = 278;
            //pixels[38, 1] = 212;
            //pixels[38, 2] = 200;
            //pixels[38, 3] = 141;
            //pixels[38, 4] = 22;




            return pixels;
        }
    }
}
