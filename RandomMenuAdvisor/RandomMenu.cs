﻿using RandomMenuAdvisor.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RandomMenuAdvisor
{
    public partial class RandomMenu : Form
    {
        MenuAdvisorClient client;

        delegate void TextboxUpdateCallback(string text);   // 텍스트 다이나믹 효과를 위한 대리자입니다.
        delegate void ButtonEnabledCallback();              // 버튼 활성화 효과를 위한 대리자입니다.

        Random r = new Random();

        int plusSleepTime = 0;                              // 스레드의 슬립 시간을 증가시키는 변수입니다.

        DataTable foodList;

        public RandomMenu()
        {
            InitializeComponent();
            client = new MenuAdvisorClient();

            try
            {
                foodList = client.GetFoodData();
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("서비스에 연결할 수 없습니다.");
            }
        }

        private void btn_Rec_Click(object sender, EventArgs e)
        {
            if (plusSleepTime != 0)
            {
                plusSleepTime = 0;
            }

            Thread thread = new Thread(new ThreadStart(Run));

            thread.Start();

            btn_Rec.Enabled = false;

            txt_Rec.BackColor = txt_Rec.BackColor;
        }

        /// <summary>
        /// 스레드의 실행 부분입니다.
        /// 일정 시간동안 다이나믹 효과를 실행시킵니다.
        /// </summary>
        public void Run()
        {
            DateTime startTime = DateTime.Now;          // 시작 시간입니다.
            DateTime endTime = startTime.AddSeconds(5); // 종료 시간입니다.

            while (DateTime.Now <= endTime)
            {
                Thread.Sleep(100 + plusSleepTime);
                txt_Rec.Invoke(new TextboxUpdateCallback(TextUpdate), new object[] { foodList.Rows[r.Next(0, foodList.Rows.Count)]["음식 명"] });
                plusSleepTime += 50;
            }

            txt_Rec.Invoke(new ButtonEnabledCallback(ButtonEnabled));
        }

        /// <summary>
        /// ### 컨트롤의 텍스트, 텍스트 속성을 변경합니다. 
        /// </summary>
        /// <param name="text">변경할 텍스트</param>
        private void TextUpdate(string text)
        {
            txt_Rec.Text = text;
            txt_Rec.ForeColor = Color.FromArgb(r.Next(0, 220), r.Next(0, 230), r.Next(0, 240));
            txt_Rec.Font = new Font(txt_Rec.Font, FontStyle.Bold);
        }

        /// <summary>
        /// ### 컨트롤을 활성화합니다.
        /// </summary>
        private void ButtonEnabled()
        {
            btn_Rec.Enabled = true;
        }
    }
}
