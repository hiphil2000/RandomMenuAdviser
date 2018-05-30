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
        Service service;

        public randomMenuAdvisor_ServiceForm()
        {
            InitializeComponent();
            service = new Service();
            CheckServices();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

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
    }
}
