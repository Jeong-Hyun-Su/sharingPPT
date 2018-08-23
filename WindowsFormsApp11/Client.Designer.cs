namespace WindowsFormsApp11
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Enter = new System.Windows.Forms.Button();
            this.label_PW = new System.Windows.Forms.Label();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox1_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_ppt0 = new System.Windows.Forms.Button();
            this.label_ppt0 = new System.Windows.Forms.Label();
            this.button_ppt1 = new System.Windows.Forms.Button();
            this.label_ppt2 = new System.Windows.Forms.Label();
            this.button_ppt2 = new System.Windows.Forms.Button();
            this.label_ppt1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Enter
            // 
            this.button_Enter.Location = new System.Drawing.Point(153, 274);
            this.button_Enter.Name = "button_Enter";
            this.button_Enter.Size = new System.Drawing.Size(146, 56);
            this.button_Enter.TabIndex = 9;
            this.button_Enter.Text = "Enter";
            this.button_Enter.UseVisualStyleBackColor = true;
            this.button_Enter.Click += new System.EventHandler(this.button_Enter_Click);
            // 
            // label_PW
            // 
            this.label_PW.AutoSize = true;
            this.label_PW.Location = new System.Drawing.Point(85, 200);
            this.label_PW.Name = "label_PW";
            this.label_PW.Size = new System.Drawing.Size(46, 18);
            this.label_PW.TabIndex = 8;
            this.label_PW.Text = "PW :";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(135, 195);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.PasswordChar = '*';
            this.textBox_PW.Size = new System.Drawing.Size(189, 28);
            this.textBox_PW.TabIndex = 7;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(135, 138);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(189, 28);
            this.textBox_Port.TabIndex = 6;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(79, 143);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(53, 18);
            this.label_Port.TabIndex = 5;
            this.label_Port.Text = "Port :";
            // 
            // textBox1_IP
            // 
            this.textBox1_IP.Location = new System.Drawing.Point(135, 84);
            this.textBox1_IP.Name = "textBox1_IP";
            this.textBox1_IP.Size = new System.Drawing.Size(189, 28);
            this.textBox1_IP.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(13, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 402);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // button_ppt0
            // 
            this.button_ppt0.BackColor = System.Drawing.Color.Transparent;
            this.button_ppt0.BackgroundImage = global::WindowsFormsApp11.Properties.Resources.pptICOn;
            this.button_ppt0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ppt0.Enabled = false;
            this.button_ppt0.Location = new System.Drawing.Point(68, 37);
            this.button_ppt0.Name = "button_ppt0";
            this.button_ppt0.Size = new System.Drawing.Size(61, 65);
            this.button_ppt0.TabIndex = 3;
            this.button_ppt0.UseVisualStyleBackColor = false;
            this.button_ppt0.Visible = false;
            this.button_ppt0.Click += new System.EventHandler(this.ButtonPPT_Click);
            // 
            // label_ppt0
            // 
            this.label_ppt0.AutoSize = true;
            this.label_ppt0.Location = new System.Drawing.Point(75, 105);
            this.label_ppt0.Name = "label_ppt0";
            this.label_ppt0.Size = new System.Drawing.Size(11, 18);
            this.label_ppt0.TabIndex = 6;
            this.label_ppt0.Text = "l";
            this.label_ppt0.Visible = false;
            // 
            // button_ppt1
            // 
            this.button_ppt1.BackColor = System.Drawing.Color.Transparent;
            this.button_ppt1.BackgroundImage = global::WindowsFormsApp11.Properties.Resources.pptICOn;
            this.button_ppt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ppt1.Enabled = false;
            this.button_ppt1.Location = new System.Drawing.Point(68, 141);
            this.button_ppt1.Name = "button_ppt1";
            this.button_ppt1.Size = new System.Drawing.Size(61, 65);
            this.button_ppt1.TabIndex = 1;
            this.button_ppt1.UseVisualStyleBackColor = false;
            this.button_ppt1.Visible = false;
            this.button_ppt1.Click += new System.EventHandler(this.ButtonPPT_Click);
            // 
            // label_ppt2
            // 
            this.label_ppt2.AutoSize = true;
            this.label_ppt2.Location = new System.Drawing.Point(75, 307);
            this.label_ppt2.Name = "label_ppt2";
            this.label_ppt2.Size = new System.Drawing.Size(11, 18);
            this.label_ppt2.TabIndex = 5;
            this.label_ppt2.Text = "l";
            this.label_ppt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ppt2.Visible = false;
            // 
            // button_ppt2
            // 
            this.button_ppt2.BackColor = System.Drawing.Color.Transparent;
            this.button_ppt2.BackgroundImage = global::WindowsFormsApp11.Properties.Resources.pptICOn;
            this.button_ppt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ppt2.Enabled = false;
            this.button_ppt2.Location = new System.Drawing.Point(68, 239);
            this.button_ppt2.Name = "button_ppt2";
            this.button_ppt2.Size = new System.Drawing.Size(61, 65);
            this.button_ppt2.TabIndex = 2;
            this.button_ppt2.UseVisualStyleBackColor = false;
            this.button_ppt2.Visible = false;
            this.button_ppt2.Click += new System.EventHandler(this.ButtonPPT_Click);
            // 
            // label_ppt1
            // 
            this.label_ppt1.AutoSize = true;
            this.label_ppt1.Location = new System.Drawing.Point(75, 208);
            this.label_ppt1.Name = "label_ppt1";
            this.label_ppt1.Size = new System.Drawing.Size(11, 18);
            this.label_ppt1.TabIndex = 4;
            this.label_ppt1.Text = "l";
            this.label_ppt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ppt1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_ppt0);
            this.panel2.Controls.Add(this.label_ppt0);
            this.panel2.Controls.Add(this.button_ppt1);
            this.panel2.Controls.Add(this.label_ppt2);
            this.panel2.Controls.Add(this.button_ppt2);
            this.panel2.Controls.Add(this.label_ppt1);
            this.panel2.Enabled = false;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(122, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 355);
            this.panel2.TabIndex = 13;
            this.panel2.Visible = false;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1_IP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Enter);
            this.Controls.Add(this.label_PW);
            this.Controls.Add(this.textBox_PW);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label_Port);
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Client_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Enter;
        private System.Windows.Forms.Label label_PW;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox1_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_ppt0;
        private System.Windows.Forms.Label label_ppt0;
        private System.Windows.Forms.Button button_ppt1;
        private System.Windows.Forms.Label label_ppt2;
        private System.Windows.Forms.Button button_ppt2;
        private System.Windows.Forms.Label label_ppt1;
        private System.Windows.Forms.Panel panel2;
    }
}