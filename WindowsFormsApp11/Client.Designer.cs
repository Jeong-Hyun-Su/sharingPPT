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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ppt2_panel = new System.Windows.Forms.Panel();
            this.ppt3_panel = new System.Windows.Forms.Panel();
            this.ppt1_panel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveBtn3 = new System.Windows.Forms.Button();
            this.saveBtn2 = new System.Windows.Forms.Button();
            this.saveBtn1 = new System.Windows.Forms.Button();
            this.selectBtn3 = new System.Windows.Forms.Button();
            this.selectBtn2 = new System.Windows.Forms.Button();
            this.ppt3pagenum = new System.Windows.Forms.TextBox();
            this.selectBtn1 = new System.Windows.Forms.Button();
            this.ppt2pagenum = new System.Windows.Forms.TextBox();
            this.ppt1pagenum = new System.Windows.Forms.TextBox();
            this.button_ppt0 = new System.Windows.Forms.Button();
            this.label_ppt0 = new System.Windows.Forms.Label();
            this.button_ppt1 = new System.Windows.Forms.Button();
            this.label_ppt2 = new System.Windows.Forms.Label();
            this.button_ppt2 = new System.Windows.Forms.Button();
            this.label_ppt1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Enter
            // 
            this.button_Enter.Location = new System.Drawing.Point(152, 274);
            this.button_Enter.Margin = new System.Windows.Forms.Padding(2);
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
            this.label_PW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PW.Name = "label_PW";
            this.label_PW.Size = new System.Drawing.Size(46, 18);
            this.label_PW.TabIndex = 8;
            this.label_PW.Text = "PW :";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(135, 194);
            this.textBox_PW.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.PasswordChar = '*';
            this.textBox_PW.Size = new System.Drawing.Size(189, 28);
            this.textBox_PW.TabIndex = 7;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(135, 138);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(189, 28);
            this.textBox_Port.TabIndex = 6;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(79, 143);
            this.label_Port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(53, 18);
            this.label_Port.TabIndex = 5;
            this.label_Port.Text = "Port :";
            // 
            // textBox1_IP
            // 
            this.textBox1_IP.Location = new System.Drawing.Point(135, 84);
            this.textBox1_IP.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1_IP.Name = "textBox1_IP";
            this.textBox1_IP.Size = new System.Drawing.Size(189, 28);
            this.textBox1_IP.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(12, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 402);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ppt2_panel);
            this.panel2.Controls.Add(this.ppt3_panel);
            this.panel2.Controls.Add(this.ppt1_panel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.saveBtn3);
            this.panel2.Controls.Add(this.saveBtn2);
            this.panel2.Controls.Add(this.saveBtn1);
            this.panel2.Controls.Add(this.selectBtn3);
            this.panel2.Controls.Add(this.selectBtn2);
            this.panel2.Controls.Add(this.ppt3pagenum);
            this.panel2.Controls.Add(this.selectBtn1);
            this.panel2.Controls.Add(this.ppt2pagenum);
            this.panel2.Controls.Add(this.ppt1pagenum);
            this.panel2.Controls.Add(this.button_ppt0);
            this.panel2.Controls.Add(this.label_ppt0);
            this.panel2.Controls.Add(this.button_ppt1);
            this.panel2.Controls.Add(this.label_ppt2);
            this.panel2.Controls.Add(this.button_ppt2);
            this.panel2.Controls.Add(this.label_ppt1);
            this.panel2.Enabled = false;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(14, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 355);
            this.panel2.TabIndex = 13;
            this.panel2.Visible = false;
            // 
            // ppt2_panel
            // 
            this.ppt2_panel.Location = new System.Drawing.Point(144, 126);
            this.ppt2_panel.Margin = new System.Windows.Forms.Padding(4);
            this.ppt2_panel.Name = "ppt2_panel";
            this.ppt2_panel.Size = new System.Drawing.Size(238, 104);
            this.ppt2_panel.TabIndex = 17;
            // 
            // ppt3_panel
            // 
            this.ppt3_panel.Location = new System.Drawing.Point(144, 232);
            this.ppt3_panel.Margin = new System.Windows.Forms.Padding(4);
            this.ppt3_panel.Name = "ppt3_panel";
            this.ppt3_panel.Size = new System.Drawing.Size(238, 112);
            this.ppt3_panel.TabIndex = 17;
            // 
            // ppt1_panel
            // 
            this.ppt1_panel.Location = new System.Drawing.Point(144, 16);
            this.ppt1_panel.Margin = new System.Windows.Forms.Padding(4);
            this.ppt1_panel.Name = "ppt1_panel";
            this.ppt1_panel.Size = new System.Drawing.Size(238, 104);
            this.ppt1_panel.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "page.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "page.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "page.";
            // 
            // saveBtn3
            // 
            this.saveBtn3.Location = new System.Drawing.Point(262, 286);
            this.saveBtn3.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn3.Name = "saveBtn3";
            this.saveBtn3.Size = new System.Drawing.Size(108, 36);
            this.saveBtn3.TabIndex = 15;
            this.saveBtn3.Text = "save";
            this.saveBtn3.UseVisualStyleBackColor = true;
            this.saveBtn3.Click += new System.EventHandler(this.saveBtn3_Click);
            // 
            // saveBtn2
            // 
            this.saveBtn2.Location = new System.Drawing.Point(262, 182);
            this.saveBtn2.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn2.Name = "saveBtn2";
            this.saveBtn2.Size = new System.Drawing.Size(108, 36);
            this.saveBtn2.TabIndex = 15;
            this.saveBtn2.Text = "save";
            this.saveBtn2.UseVisualStyleBackColor = true;
            this.saveBtn2.Click += new System.EventHandler(this.saveBtn2_Click);
            // 
            // saveBtn1
            // 
            this.saveBtn1.Location = new System.Drawing.Point(262, 74);
            this.saveBtn1.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn1.Name = "saveBtn1";
            this.saveBtn1.Size = new System.Drawing.Size(108, 36);
            this.saveBtn1.TabIndex = 15;
            this.saveBtn1.Text = "save";
            this.saveBtn1.UseVisualStyleBackColor = true;
            this.saveBtn1.Click += new System.EventHandler(this.saveBtn1_Click);
            // 
            // selectBtn3
            // 
            this.selectBtn3.Location = new System.Drawing.Point(262, 244);
            this.selectBtn3.Margin = new System.Windows.Forms.Padding(4);
            this.selectBtn3.Name = "selectBtn3";
            this.selectBtn3.Size = new System.Drawing.Size(108, 35);
            this.selectBtn3.TabIndex = 13;
            this.selectBtn3.Text = "select";
            this.selectBtn3.UseVisualStyleBackColor = true;
            this.selectBtn3.Click += new System.EventHandler(this.selectBtn3_Click);
            // 
            // selectBtn2
            // 
            this.selectBtn2.Location = new System.Drawing.Point(262, 140);
            this.selectBtn2.Margin = new System.Windows.Forms.Padding(4);
            this.selectBtn2.Name = "selectBtn2";
            this.selectBtn2.Size = new System.Drawing.Size(108, 35);
            this.selectBtn2.TabIndex = 13;
            this.selectBtn2.Text = "select";
            this.selectBtn2.UseVisualStyleBackColor = true;
            this.selectBtn2.Click += new System.EventHandler(this.selectBtn2_Click);
            // 
            // ppt3pagenum
            // 
            this.ppt3pagenum.Location = new System.Drawing.Point(208, 246);
            this.ppt3pagenum.Margin = new System.Windows.Forms.Padding(4);
            this.ppt3pagenum.Name = "ppt3pagenum";
            this.ppt3pagenum.ReadOnly = true;
            this.ppt3pagenum.Size = new System.Drawing.Size(52, 28);
            this.ppt3pagenum.TabIndex = 14;
            // 
            // selectBtn1
            // 
            this.selectBtn1.Location = new System.Drawing.Point(262, 32);
            this.selectBtn1.Margin = new System.Windows.Forms.Padding(4);
            this.selectBtn1.Name = "selectBtn1";
            this.selectBtn1.Size = new System.Drawing.Size(108, 35);
            this.selectBtn1.TabIndex = 13;
            this.selectBtn1.Text = "select";
            this.selectBtn1.UseVisualStyleBackColor = true;
            this.selectBtn1.Click += new System.EventHandler(this.selectBtn1_Click);
            // 
            // ppt2pagenum
            // 
            this.ppt2pagenum.Location = new System.Drawing.Point(208, 143);
            this.ppt2pagenum.Margin = new System.Windows.Forms.Padding(4);
            this.ppt2pagenum.Name = "ppt2pagenum";
            this.ppt2pagenum.ReadOnly = true;
            this.ppt2pagenum.Size = new System.Drawing.Size(52, 28);
            this.ppt2pagenum.TabIndex = 14;
            // 
            // ppt1pagenum
            // 
            this.ppt1pagenum.Location = new System.Drawing.Point(208, 35);
            this.ppt1pagenum.Margin = new System.Windows.Forms.Padding(4);
            this.ppt1pagenum.Name = "ppt1pagenum";
            this.ppt1pagenum.ReadOnly = true;
            this.ppt1pagenum.Size = new System.Drawing.Size(52, 28);
            this.ppt1pagenum.TabIndex = 14;
            // 
            // button_ppt0
            // 
            this.button_ppt0.BackColor = System.Drawing.Color.Transparent;
            this.button_ppt0.BackgroundImage = global::WindowsFormsApp11.Properties.Resources.pptICOn;
            this.button_ppt0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ppt0.Enabled = false;
            this.button_ppt0.Location = new System.Drawing.Point(41, 37);
            this.button_ppt0.Margin = new System.Windows.Forms.Padding(2);
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
            this.label_ppt0.Location = new System.Drawing.Point(49, 104);
            this.label_ppt0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.button_ppt1.Location = new System.Drawing.Point(41, 145);
            this.button_ppt1.Margin = new System.Windows.Forms.Padding(2);
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
            this.label_ppt2.Location = new System.Drawing.Point(49, 312);
            this.label_ppt2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.button_ppt2.Location = new System.Drawing.Point(41, 244);
            this.button_ppt2.Margin = new System.Windows.Forms.Padding(2);
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
            this.label_ppt1.Location = new System.Drawing.Point(49, 212);
            this.label_ppt1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ppt1.Name = "label_ppt1";
            this.label_ppt1.Size = new System.Drawing.Size(11, 18);
            this.label_ppt1.TabIndex = 4;
            this.label_ppt1.Text = "l";
            this.label_ppt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ppt1.Visible = false;
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button selectBtn1;
        private System.Windows.Forms.TextBox ppt1pagenum;
        private System.Windows.Forms.Button saveBtn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveBtn3;
        private System.Windows.Forms.Button saveBtn2;
        private System.Windows.Forms.Button selectBtn3;
        private System.Windows.Forms.Button selectBtn2;
        private System.Windows.Forms.TextBox ppt3pagenum;
        private System.Windows.Forms.TextBox ppt2pagenum;
        private System.Windows.Forms.Panel ppt3_panel;
        private System.Windows.Forms.Panel ppt2_panel;
        private System.Windows.Forms.Panel ppt1_panel;
    }
}