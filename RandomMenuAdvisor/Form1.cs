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
        string Menu, Lastmenu,a;         // 오늘 메뉴 저장 변수, 어제 메뉴 저장 변수입니다.

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
            DateTime date1;
            date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            Random r = new Random();
            int menu = r.Next();
            
            DataTable Food = client.GetFoodData();
            DataTable Request = client.GetRandomRequestedData(1);

            int requestcount = Request.Rows.Count;
            // dgrid_Sta.RowCount = 30; = 그리드뷰 행 수를 30개로 지정
            //txt_Rec.Text = "밥";
            while (true)
            {
                // DB 
                // 어제 메뉴를 db에서 불러오는 메소드
                // 오늘 메뉴를 랜덤으로 db에서 불러오는 메소드
 
               // MessageBox.Show(dt.Rows[0]["음식 명"].ToString());

                if (Menu != Lastmenu)
                {
                    
                    txt_Rec. Text = Menu;

                    if(DateTime.Now < date1)
                    {
                        if (requestcount>5)
                        {
                            
                        }
                        else
                        {

                        }

                        // 현서한테 시간 및 메뉴 전송
                        //client.GetFoodData();
                        //client.GetGetRandomRequestedData();

                    }
                    else
                    {
                        //날짜를 오늘에서 하루 더 해서 보내기
                    }

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

