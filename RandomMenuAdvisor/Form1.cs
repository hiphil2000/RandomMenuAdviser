using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomMenuAdvisor
{
    public partial class RandomMenu : Form
    {
        string Menu;         // 오늘 저장할 메뉴
        string Lastmenu;     // 어제 저장한 메뉴
        string a;

        public RandomMenu()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 텍스트 박스에 랜덤으로 음식을 띄우는 부분입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

        private void btn_Rec_Click(object sender, EventArgs e)
        {
            while (true)
            {
                Menu = "Select top (1) * from tblname where 통계수치 < 30";

                //a = "Select a from tblname where menu ="+Menu;

                /*if (Menu == Lastmenu)
                {
                    if (a == b)
                    {

                    }
                }*/
                if (Menu != Lastmenu)
                {
                    txt_Rec.Text = Menu;
                }
                else
                {

                }
            }
        }
    }
}

