namespace WindowsFormsApp11
{
    partial class Home
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
            this.button_S = new System.Windows.Forms.Button();
            this.button_C = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_S
            // 
            this.button_S.Location = new System.Drawing.Point(176, 139);
            this.button_S.Name = "button_S";
            this.button_S.Size = new System.Drawing.Size(115, 49);
            this.button_S.TabIndex = 0;
            this.button_S.Text = "Server";
            this.button_S.UseVisualStyleBackColor = true;
            this.button_S.Click += new System.EventHandler(this.button_S_Click);
            // 
            // button_C
            // 
            this.button_C.Location = new System.Drawing.Point(176, 207);
            this.button_C.Name = "button_C";
            this.button_C.Size = new System.Drawing.Size(115, 49);
            this.button_C.TabIndex = 1;
            this.button_C.Text = "Client";
            this.button_C.UseVisualStyleBackColor = true;
            this.button_C.Click += new System.EventHandler(this.button_C_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.button_C);
            this.Controls.Add(this.button_S);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_S;
        private System.Windows.Forms.Button button_C;
    }
}

