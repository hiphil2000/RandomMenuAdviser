namespace RandomMenuAdvisor
{
    partial class RandomMenu
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
            this.txt_Rec = new System.Windows.Forms.TextBox();
            this.dgrid_Sta = new System.Windows.Forms.DataGridView();
            this.btn_Rec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_Sta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "통계";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "랜덤 돌리기";
            // 
            // txt_Rec
            // 
            this.txt_Rec.Location = new System.Drawing.Point(32, 61);
            this.txt_Rec.Name = "txt_Rec";
            this.txt_Rec.Size = new System.Drawing.Size(188, 21);
            this.txt_Rec.TabIndex = 5;
            // 
            // dgrid_Sta
            // 
            this.dgrid_Sta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_Sta.Location = new System.Drawing.Point(32, 162);
            this.dgrid_Sta.Name = "dgrid_Sta";
            this.dgrid_Sta.RowTemplate.Height = 23;
            this.dgrid_Sta.Size = new System.Drawing.Size(495, 416);
            this.dgrid_Sta.TabIndex = 2;
            // 
            // btn_Rec
            // 
            this.btn_Rec.Location = new System.Drawing.Point(243, 61);
            this.btn_Rec.Name = "btn_Rec";
            this.btn_Rec.Size = new System.Drawing.Size(75, 23);
            this.btn_Rec.TabIndex = 7;
            this.btn_Rec.Text = "button1";
            this.btn_Rec.UseVisualStyleBackColor = true;
            this.btn_Rec.Click += new System.EventHandler(this.btn_Rec_Click);
            // 
            // RandomMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(560, 602);
            this.Controls.Add(this.btn_Rec);
            this.Controls.Add(this.txt_Rec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgrid_Sta);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "RandomMenu";
            this.Text = "RandomMenu";
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_Sta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Rec;
        private System.Windows.Forms.DataGridView dgrid_Sta;
        private System.Windows.Forms.Button btn_Rec;
    }
}

