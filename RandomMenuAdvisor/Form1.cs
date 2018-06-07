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

               
        private void btn_Rec_Click(object sender, EventArgs e)
        {
            
        }

        
        public void SetDataSource(DataTable dt)
        {
            dgrid_Sta.DataSource = dt;
        }
    }
}

