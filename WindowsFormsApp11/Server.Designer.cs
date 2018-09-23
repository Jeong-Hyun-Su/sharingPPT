namespace WindowsFormsApp11
{
    partial class Server
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
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.label_PW = new System.Windows.Forms.Label();
            this.button_Make = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_unlock = new System.Windows.Forms.Button();
            this.button_Upload = new System.Windows.Forms.Button();
            this.button_lock = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_ppt0 = new System.Windows.Forms.Button();
            this.label_ppt0 = new System.Windows.Forms.Label();
            this.button_ppt1 = new System.Windows.Forms.Button();
            this.label_ppt2 = new System.Windows.Forms.Label();
            this.button_ppt2 = new System.Windows.Forms.Button();
            this.label_ppt1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label_IP = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(92, 107);
            this.label_Port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(53, 18);
            this.label_Port.TabIndex = 0;
            this.label_Port.Text = "Port :";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(149, 101);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(189, 28);
            this.textBox_Port.TabIndex = 1;
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(149, 198);
            this.textBox_PW.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.PasswordChar = '*';
            this.textBox_PW.Size = new System.Drawing.Size(189, 28);
            this.textBox_PW.TabIndex = 2;
            // 
            // label_PW
            // 
            this.label_PW.AutoSize = true;
            this.label_PW.Location = new System.Drawing.Point(99, 203);
            this.label_PW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PW.Name = "label_PW";
            this.label_PW.Size = new System.Drawing.Size(46, 18);
            this.label_PW.TabIndex = 3;
            this.label_PW.Text = "PW :";
            // 
            // button_Make
            // 
            this.button_Make.Location = new System.Drawing.Point(168, 277);
            this.button_Make.Margin = new System.Windows.Forms.Padding(2);
            this.button_Make.Name = "button_Make";
            this.button_Make.Size = new System.Drawing.Size(146, 56);
            this.button_Make.TabIndex = 4;
            this.button_Make.Text = "Make";
            this.button_Make.UseVisualStyleBackColor = true;
            this.button_Make.Click += new System.EventHandler(this.button_Make_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_unlock);
            this.panel1.Controls.Add(this.button_Upload);
            this.panel1.Controls.Add(this.button_lock);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(11, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 402);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            // 
            // button_unlock
            // 
            this.button_unlock.Location = new System.Drawing.Point(324, 32);
            this.button_unlock.Name = "button_unlock";
            this.button_unlock.Size = new System.Drawing.Size(96, 55);
            this.button_unlock.TabIndex = 19;
            this.button_unlock.Text = "save";
            this.button_unlock.UseVisualStyleBackColor = true;
            // 
            // button_Upload
            // 
            this.button_Upload.Location = new System.Drawing.Point(55, 13);
            this.button_Upload.Margin = new System.Windows.Forms.Padding(2);
            this.button_Upload.Name = "button_Upload";
            this.button_Upload.Size = new System.Drawing.Size(91, 34);
            this.button_Upload.TabIndex = 0;
            this.button_Upload.Text = "업로드";
            this.button_Upload.UseVisualStyleBackColor = true;
            this.button_Upload.Click += new System.EventHandler(this.button_Upload_Click);
            // 
            // button_lock
            // 
            this.button_lock.Location = new System.Drawing.Point(210, 32);
            this.button_lock.Name = "button_lock";
            this.button_lock.Size = new System.Drawing.Size(96, 55);
            this.button_lock.TabIndex = 18;
            this.button_lock.Text = "lock";
            this.button_lock.UseVisualStyleBackColor = true;
            this.button_lock.Click += new System.EventHandler(this.button_lock_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(191, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(251, 290);
            this.listView1.TabIndex = 17;
            this.listView1.TileSize = new System.Drawing.Size(30, 40);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "이름";
            this.columnHeader1.Width = 57;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PPT";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "PAGE";
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
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(14, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 355);
            this.panel2.TabIndex = 7;
            // 
            // button_ppt0
            // 
            this.button_ppt0.BackColor = System.Drawing.Color.Transparent;
            this.button_ppt0.BackgroundImage = global::WindowsFormsApp11.Properties.Resources.pptICOn;
            this.button_ppt0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ppt0.Enabled = false;
            this.button_ppt0.Location = new System.Drawing.Point(50, 37);
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
            this.label_ppt0.Location = new System.Drawing.Point(57, 104);
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
            this.button_ppt1.Location = new System.Drawing.Point(50, 140);
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
            this.label_ppt2.Location = new System.Drawing.Point(57, 307);
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
            this.button_ppt2.Location = new System.Drawing.Point(50, 239);
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
            this.label_ppt1.Location = new System.Drawing.Point(57, 208);
            this.label_ppt1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ppt1.Name = "label_ppt1";
            this.label_ppt1.Size = new System.Drawing.Size(11, 18);
            this.label_ppt1.TabIndex = 4;
            this.label_ppt1.Text = "l";
            this.label_ppt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ppt1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "현재접속자 수 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(149, 155);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(189, 28);
            this.textBox_name.TabIndex = 11;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(79, 161);
            this.label_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(67, 18);
            this.label_name.TabIndex = 10;
            this.label_name.Text = "Name :";
            // 
            // label_IP
            // 
            this.label_IP.Location = new System.Drawing.Point(57, 3);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(205, 28);
            this.label_IP.TabIndex = 12;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Make);
            this.Controls.Add(this.label_PW);
            this.Controls.Add(this.textBox_PW);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label_name);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.Load += new System.EventHandler(this.Server_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Label label_PW;
        private System.Windows.Forms.Button button_Make;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Upload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_ppt1;
        private System.Windows.Forms.Label label_ppt0;
        private System.Windows.Forms.Label label_ppt2;
        private System.Windows.Forms.Label label_ppt1;
        private System.Windows.Forms.Button button_ppt0;
        private System.Windows.Forms.Button button_ppt2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_unlock;
        private System.Windows.Forms.Button button_lock;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox label_IP;
    }
}