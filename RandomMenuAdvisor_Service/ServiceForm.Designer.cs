namespace RandomMenuAdvisor_Service
{
    partial class randomMenuAdvisor_ServiceForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_ServiceStatus = new System.Windows.Forms.Label();
            this.lab_DbStatus = new System.Windows.Forms.Label();
            this.btn_StartService = new System.Windows.Forms.Button();
            this.btn_StopService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "서비스 상태 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14F);
            this.label2.Location = new System.Drawing.Point(47, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "DB 상태 : ";
            // 
            // lab_ServiceStatus
            // 
            this.lab_ServiceStatus.AutoSize = true;
            this.lab_ServiceStatus.Font = new System.Drawing.Font("굴림", 14F);
            this.lab_ServiceStatus.Location = new System.Drawing.Point(146, 31);
            this.lab_ServiceStatus.Name = "lab_ServiceStatus";
            this.lab_ServiceStatus.Size = new System.Drawing.Size(0, 19);
            this.lab_ServiceStatus.TabIndex = 2;
            // 
            // lab_DbStatus
            // 
            this.lab_DbStatus.AutoSize = true;
            this.lab_DbStatus.Font = new System.Drawing.Font("굴림", 14F);
            this.lab_DbStatus.Location = new System.Drawing.Point(146, 76);
            this.lab_DbStatus.Name = "lab_DbStatus";
            this.lab_DbStatus.Size = new System.Drawing.Size(0, 19);
            this.lab_DbStatus.TabIndex = 2;
            // 
            // btn_StartService
            // 
            this.btn_StartService.Location = new System.Drawing.Point(16, 137);
            this.btn_StartService.Name = "btn_StartService";
            this.btn_StartService.Size = new System.Drawing.Size(99, 23);
            this.btn_StartService.TabIndex = 1;
            this.btn_StartService.Text = "서비스 시작";
            this.btn_StartService.UseVisualStyleBackColor = true;
            this.btn_StartService.Click += new System.EventHandler(this.Btn_StartService_Click);
            // 
            // btn_StopService
            // 
            this.btn_StopService.Location = new System.Drawing.Point(121, 137);
            this.btn_StopService.Name = "btn_StopService";
            this.btn_StopService.Size = new System.Drawing.Size(99, 23);
            this.btn_StopService.TabIndex = 2;
            this.btn_StopService.Text = "서비스 종료";
            this.btn_StopService.UseVisualStyleBackColor = true;
            this.btn_StopService.Click += new System.EventHandler(this.Btn_StopService_Click);
            // 
            // randomMenuAdvisor_ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 198);
            this.Controls.Add(this.btn_StopService);
            this.Controls.Add(this.btn_StartService);
            this.Controls.Add(this.lab_DbStatus);
            this.Controls.Add(this.lab_ServiceStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "randomMenuAdvisor_ServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "서비스";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_ServiceStatus;
        private System.Windows.Forms.Label lab_DbStatus;
        private System.Windows.Forms.Button btn_StartService;
        private System.Windows.Forms.Button btn_StopService;
    }
}

