using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomMenuAdvisor_Service
{
    public partial class randomMenuAdvisor_ServiceForm : Form
    {
        Service service;                    // 서비스 
        ServiceLibrary.DatabaseService db;

        public randomMenuAdvisor_ServiceForm()
        {
            InitializeComponent();
            service = new Service();
            db = new ServiceLibrary.DatabaseService();
            CheckServices();
            CheckDatabase();
        }

        /// <summary>
        /// 현재 서비스의 동작상태를 확인하고 상태 표시를 업데이트합니다.
        /// </summary>
        private void CheckServices()
        {
            if (service.IsRunning)
            {
                lab_ServiceStatus.Text = "동작중";
                lab_ServiceStatus.ForeColor = Color.LightGreen;
                btn_StartService.Enabled = false;
                btn_StopService.Enabled = true;
            }
            else
            {
                lab_ServiceStatus.Text = "멈춤";
                lab_ServiceStatus.ForeColor = Color.Gray;
                btn_StartService.Enabled = true;
                btn_StopService.Enabled = false;
            }
        }

        /// <summary>
        /// 데이터베이스의 연결상태를 확인하고 상태 표시를 업데이트합니다.
        /// </summary>
        private void CheckDatabase()
        {
            db.DatabaseConnectionTest();
            if (db.IsRunning)
            {
                lab_DbStatus.Text = "동작중";
                lab_DbStatus.ForeColor = Color.LightGreen;
            }
            else
            {
                lab_DbStatus.Text = "접속중";
                lab_DbStatus.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// 서비스 시작 버튼을 누르면 서비스를 시작합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_StartService_Click(object sender, EventArgs e)
        {
            if (service.StartService())
            {
                MessageBox.Show("서비스가 이제 동작합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("서비스 시작에 실패했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CheckServices();
        }

        /// <summary>
        /// 서비스 종료 버튼을 누르면 서비스를 종료합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_StopService_Click(object sender, EventArgs e)
        {
            if (service.StopService())
            {
                MessageBox.Show("서비스가 이제 멈췄습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("서비스 종료에 실패했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CheckServices();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckDatabase();
        }
    }
}
