using RandomMenuAdvisor.ServiceReference1;
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
        string Menu, Lastmenu;         // 오늘 메뉴 저장 변수, 어제 메뉴 저장 변수입니다.

        MenuAdvisorClient client;


        public RandomMenu()
        {
            InitializeComponent();
            client = new MenuAdvisorClient();

        }

        /// <summary>
        /// 텍스트 박스에 랜덤으로 음식을 띄우는 부분입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void btn_Rec_Click(object sender, EventArgs e)
        {
            // dgrid_Sta.RowCount = 30; = 그리드뷰 행 수를 30개로 지정
            //txt_Rec.Text = "밥";
            while (true)
            {
                // DB select
                Lastmenu = "Select menu, max(날짜) from tblname group by menu"; // 어제 메뉴를 db에서 불러와서 변수에 넣는 부분입니다.
                Menu = "Select top (1) * from tblname where 통계수치 < 30";     // 오늘 메뉴를 랜덤으로 db에서 불러와 변수에 넣는 부분입니다.

                if (Menu != Lastmenu)
                {
                    txt_Rec.Text = Menu;
                    // 메뉴 및 시간 서버 전송 (insert, update)
                    /* 
                     * string toDayTime = DateTime.Now.ToString("HHmmss");
                     * int ab = Int32.Parse(toDayTime);
                     */
                }
                else
                {
                    // 다시 돌아가서 실행
                }
            }
        }
        public void SetDataSource(DataTable dt)
        {
            dgrid_Sta.DataSource = dt;
        }
    }
}

