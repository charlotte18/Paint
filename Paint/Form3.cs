using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        int x1, y1; //x1,y1為滑鼠座標
        int x2, y2; //x2,y2為滑鼠座標
        
        private void Form3_Load(object sender, EventArgs e)
        {
        }

        bool isDrag = false;
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {//當滑鼠按了左鍵，設定第一個點的座標，並設定拖曳值drag=true
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                x1 = x2 = e.X;
                y1 = y2 = e.Y;
            }
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        { //isDrag為true表示滑鼠正在移動中,抓第二個點的座標,然後call Invalidate() & Refresh()來呼叫Form3_Paint event做畫畫的動作
            if (isDrag == true)
            {
                x2 = e.X;
                y2 = e.Y;
                this.Invalidate();
            }
        }

        List<PenInfo> AllPenInfo = new List<PenInfo>();
        private void Form3_MouseUp(object sender, MouseEventArgs e)
        { //滑鼠放開時表示畫完了，就將拖曳值設為false
            isDrag = false;
            x2 = e.X;
            y2 = e.Y;

            //將需要的資訊存進class中定義的變數(起始座標/終止座標/外框顏色/筆刷粗細/背景顏色/形狀),最後加入AllPenInfo中
            PenInfo OldPenParam = new PenInfo();
            OldPenParam.StarX1 = x1;
            OldPenParam.StarY1 = y1;
            OldPenParam.StarX2 = x2;
            OldPenParam.StarY2 = y2;
            OldPenParam.PenColor = Singleton.Instance().SelectedColorIndex;
            OldPenParam.PenWidth = Singleton.Instance().SelectedWidthIndex;
            OldPenParam.PenBGColor = Singleton.Instance().SelectedBGColorIndex;
            OldPenParam.PenShape = Singleton.Instance().SelectedShapeIndex;
            AllPenInfo.Add(OldPenParam);

            this.Invalidate();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (PenInfo pa in AllPenInfo)
            {//從AllPenInfo抓到的每筆pa都存有六個資料
                pa.DrawGraphics(g); //將舊的資料先畫上畫布
            }

            if (isDrag)
            { //設定當前畫的這筆圖形資料給param
                PenInfo CurPenParam = new PenInfo();
                CurPenParam.StarX1 = x1;
                CurPenParam.StarY1 = y1;
                CurPenParam.StarX2 = x2;
                CurPenParam.StarY2 = y2;
                CurPenParam.PenColor = Singleton.Instance().SelectedColorIndex;
                CurPenParam.PenWidth = Singleton.Instance().SelectedWidthIndex;
                CurPenParam.PenBGColor = Singleton.Instance().SelectedBGColorIndex;
                CurPenParam.PenShape = Singleton.Instance().SelectedShapeIndex;
                CurPenParam.DrawGraphics(g);
            }
        }
    }
}
