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
    public partial class Form1 : Form
    {
        Form2 subForm2 = new Form2(); // 產生子表單
        Form3 subForm3 = new Form3();

        public Form1()
        {
            InitializeComponent();

            //------------------------------------------------
            subForm2.MdiParent = this; // 設定子表單2的父表單
            subForm2.Text = "畫具";
            subForm2.Show(); // 顯示子表單
            //------------------------------------------------

            //------------------------------------------------
            subForm3.MdiParent = this;
            subForm3.Left = 0;
            subForm3.Top = 0;
            subForm3.Width = 1000;
            subForm3.Height = 1000;
            subForm3.FormBorderStyle = FormBorderStyle.None;
            subForm3.Show();
            //------------------------------------------------

            //------------------------------------------------
            // 動態產生subForm2的按鈕及屬性設定
            Button btn1 = new Button();
            btn1.Image = Image.FromFile("C:\\Users\\janson\\Documents\\Visual Studio 2013\\Projects\\Paint\\Paint\\pic\\1.PNG");
            btn1.ImageAlign = ContentAlignment.MiddleRight;
            btn1.Size = new System.Drawing.Size(30, 30);
            btn1.Location = new Point(0, 0); // 設定按鈕所在位置(相對於子表單而言)
            btn1.Click += new System.EventHandler(this.subFormBtClick); //註冊按下事件
            btn1.Tag = 0; //設定動態產生的按鈕tag編號
            subForm2.Controls.Add(btn1); // 將按鈕新增至子表單

            Button btn2 = new Button();
            btn2.Image = Image.FromFile("C:\\Users\\janson\\Documents\\Visual Studio 2013\\Projects\\Paint\\Paint\\pic\\2.PNG");
            btn2.ImageAlign = ContentAlignment.MiddleRight;
            btn2.Size = new System.Drawing.Size(30, 30);
            btn2.Location = new Point(0, 30);
            btn2.Click += new System.EventHandler(this.subFormBtClick);
            btn2.Tag = 1;
            subForm2.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Image = Image.FromFile("C:\\Users\\janson\\Documents\\Visual Studio 2013\\Projects\\Paint\\Paint\\pic\\3.PNG");
            btn3.ImageAlign = ContentAlignment.MiddleRight;
            btn3.Size = new System.Drawing.Size(30, 30);
            btn3.Location = new Point(0, 60);
            btn3.Click += new System.EventHandler(this.subFormBtClick);
            btn3.Tag = 2;
            subForm2.Controls.Add(btn3);

            Button btn4 = new Button();
            btn4.Image = Image.FromFile("C:\\Users\\janson\\Documents\\Visual Studio 2013\\Projects\\Paint\\Paint\\pic\\4.PNG");
            btn4.ImageAlign = ContentAlignment.MiddleRight;
            btn4.Size = new System.Drawing.Size(30, 30);
            btn4.Location = new Point(0, 90);
            btn4.Click += new System.EventHandler(this.subFormBtClick);
            btn4.Tag = 3;
            subForm2.Controls.Add(btn4);

            Button btn5 = new Button();
            btn5.Image = Image.FromFile("C:\\Users\\janson\\Documents\\Visual Studio 2013\\Projects\\Paint\\Paint\\pic\\5.PNG");
            btn5.ImageAlign = ContentAlignment.MiddleRight;
            btn5.Size = new System.Drawing.Size(30, 30);
            btn5.Location = new Point(0, 120);
            btn5.Click += new System.EventHandler(this.subFormBtClick);
            btn5.Tag = 4;
            subForm2.Controls.Add(btn5);
            //------------------------------------------------

            //------------------------------------------------
            // Default
            lineToolStripMenuItem.Checked = true; //在工具列Tool下方的Line左方顯示勾勾
            subForm2.Controls[0].Focus();
        }

        int ToolSelected, BtnSelected;
        private void ToolItemClick(object sender, EventArgs e)
        {// 該func功能:按下工具列上Tool下方這五個其中一個會做的事情
            
            //subForm按鈕Enabled初始化
            subForm2.Controls[0].Enabled = true;
            subForm2.Controls[1].Enabled = true;
            subForm2.Controls[2].Enabled = true;
            subForm2.Controls[3].Enabled = true;
            subForm2.Controls[4].Enabled = true;

            //工具列Tool下方按鈕Checked初始化
            lineToolStripMenuItem.Checked = false;
            rectToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = false;
            selectToolStripMenuItem.Checked = false;

            switch (((ToolStripMenuItem)sender).Text)
            {
                case "Line":
                    //subForm.Controls[0].Enabled = false;
                    subForm2.Controls[0].Focus(); //產生有藍色框框的
                    lineToolStripMenuItem.Checked = true; //顯示勾勾
                    ToolSelected = 0;
                    break;
                case "Rect":
                    //subForm.Controls[1].Enabled = false;
                    subForm2.Controls[1].Focus();
                    rectToolStripMenuItem.Checked = true;
                    ToolSelected = 1;
                    break;
                case "Ellipse":
                    //subForm.Controls[2].Enabled = false;
                    subForm2.Controls[2].Focus();
                    ellipseToolStripMenuItem.Checked = true;
                    ToolSelected = 2;
                    break;
                case "Text":
                    //subForm.Controls[3].Enabled = false;
                    subForm2.Controls[3].Focus();
                    textToolStripMenuItem.Checked = true;
                    ToolSelected = 3;
                    break;
                case "Select":
                    //subForm.Controls[4].Enabled = false;
                    subForm2.Controls[4].Focus();
                    selectToolStripMenuItem.Checked = true;
                    ToolSelected = 4;
                    break;
            }
            //Singleton CurrentIndex = Singleton.Instance();
            //CurrentIndex.SelectedIndex = ToolSelected;
            Singleton.Instance().SelectedShapeIndex = ToolSelected; //將選到的index值傳進去singleton給SelectedIndex變數
        }

        private void subFormBtClick(object sender, EventArgs e)
        {// 該func功能:子選單按鈕被選取

            //subForm按鈕Enabled初始化
            subForm2.Controls[0].Enabled = true;
            subForm2.Controls[1].Enabled = true;
            subForm2.Controls[2].Enabled = true;
            subForm2.Controls[3].Enabled = true;
            subForm2.Controls[4].Enabled = true;

            //工具列Tool下方按鈕Checked初始化
            lineToolStripMenuItem.Checked = false;
            rectToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = false;
            selectToolStripMenuItem.Checked = false;

            switch (((Button)sender).Tag.ToString()) //取得tag編號
            {
                case "0":
                    lineToolStripMenuItem.Checked = true;
                    BtnSelected = 0;
                    break;
                case "1":
                    rectToolStripMenuItem.Checked = true;
                    BtnSelected = 1;
                    break;
                case "2":
                    ellipseToolStripMenuItem.Checked = true;
                    BtnSelected = 2;
                    break;
                case "3":
                    textToolStripMenuItem.Checked = true;
                    BtnSelected = 3;
                    break;
                case "4":
                    selectToolStripMenuItem.Checked = true;
                    BtnSelected = 4;
                    break;
            }
            Singleton.Instance().SelectedShapeIndex = BtnSelected;
        }
        
        int Cindex = 0; //索引值
        private void SubColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cindex = int.Parse(((ToolStripMenuItem)sender).Tag.ToString()); //選取後把TAG的內容用index暫存索引值
            Singleton.Instance().SelectedColorIndex = Cindex;
        }
       
        int Windex = 0;
        private void SubWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windex = int.Parse(((ToolStripMenuItem)sender).Tag.ToString());
            Singleton.Instance().SelectedWidthIndex = Windex;
        }
       
        int BGindex = 0;
        private void SubBGColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BGindex = int.Parse(((ToolStripMenuItem)sender).Tag.ToString());
            Singleton.Instance().SelectedBGColorIndex = BGindex;
        }

        private void toolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //刷新上次選取的顏色
            for (int i = 0; i < colorToolStripMenuItem.DropDownItems.Count; i++)
            {
                if (i != Cindex)
                    ((ToolStripMenuItem)colorToolStripMenuItem.DropDownItems[i]).Checked = false;
                else
                    ((ToolStripMenuItem)colorToolStripMenuItem.DropDownItems[i]).Checked = true; //.Checked = true -> 選取的意思
            }
            //刷新上次選取的筆刷
            for (int i = 0; i < widthToolStripMenuItem.DropDownItems.Count; i++)
            {
                if (i != Windex)
                    ((ToolStripMenuItem)widthToolStripMenuItem.DropDownItems[i]).Checked = false;
                else
                    ((ToolStripMenuItem)widthToolStripMenuItem.DropDownItems[i]).Checked = true;
            }
            //刷新上次選取的背景色
            for (int i = 0; i < backgroundToolStripMenuItem.DropDownItems.Count; i++)
            {
                if (i != BGindex)
                    ((ToolStripMenuItem)backgroundToolStripMenuItem.DropDownItems[i]).Checked = false;
                else
                    ((ToolStripMenuItem)backgroundToolStripMenuItem.DropDownItems[i]).Checked = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            subForm2.BringToFront(); //時間到就把subForm2移到最上層
        }
    }
}
