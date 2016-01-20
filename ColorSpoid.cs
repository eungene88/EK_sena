using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace EK_Sena
{
    class ColorSpoid
    {
        public Color ScreenColor(int x, int y)
        { // 스크린 Color값을 가져온다.
            System.Drawing.Size sz = new System.Drawing.Size(1, 1);
            Bitmap bmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(x, y, 0, 0, sz);

            return bmp.GetPixel(0, 0);
        }
    }
}
