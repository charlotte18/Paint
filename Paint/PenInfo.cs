using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint
{
    class PenInfo 
    {
        public int StarX1, StarY1;
        public int StarX2, StarY2;
        public int PenColor;
        public int PenWidth;
        public int PenBGColor;
        public int PenShape;
        Pen myPen;
        SolidBrush myPenBrush;

        public PenInfo()
        {// 設初始值
            this.StarX1 = -1;
            this.StarX2 = -1;
            this.StarY1 = -1;
            this.StarY2 = -1;
            this.PenColor = 0;
            this.PenWidth = 0;
            this.PenBGColor = 0;
            this.PenShape = 0;
        }

        public void DrawGraphics(Graphics g)
        {
            switch (PenColor)
            {
                case 0:
                    myPen = new Pen(Color.Black);
                    break;
                case 1:
                    myPen = new Pen(Color.Red);
                    break;
                case 2:
                    myPen = new Pen(Color.Green);
                    break;
                case 3:
                    myPen = new Pen(Color.Blue);
                    break;
            }
            switch (PenWidth)
            {
                case 0:
                    myPen.Width = 1;
                    break;
                case 1:
                    myPen.Width = 3;
                    break;
                case 2:
                    myPen.Width = 5;
                    break;
                case 3:
                    myPen.Width = 7;
                    break;
            }
            switch (PenBGColor)
            {
                case 0:
                    myPenBrush = new SolidBrush(Color.Transparent);
                    break;
                case 1:
                    myPenBrush = new SolidBrush(Color.Black);
                    break;
                case 2:
                    myPenBrush = new SolidBrush(Color.Red);
                    break;
                case 3:
                    myPenBrush = new SolidBrush(Color.Green);
                    break;
                case 4:
                    myPenBrush = new SolidBrush(Color.Blue);
                    break;
            }

            switch (PenShape)
            {
                case 0:
                    g.DrawLine(myPen, StarX1, StarY1, StarX2, StarY2);
                    break;
                case 1:
                    g.FillRectangle(myPenBrush, StarX1, StarY1, (StarX2 - StarX1), (StarY2 - StarY1));
                    g.DrawRectangle(myPen, StarX1, StarY1, (StarX2 - StarX1), (StarY2 - StarY1));
                    break;
                case 2:
                    g.FillEllipse(myPenBrush, StarX1, StarY1, (StarX2 - StarX1), (StarY2 - StarY1));
                    g.DrawEllipse(myPen, StarX1, StarY1, (StarX2 - StarX1), (StarY2 - StarY1));
                    break;
            }
        }

    }
}
