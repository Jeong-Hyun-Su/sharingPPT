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
            this.button_unlock = new System.Windows.Forms.Button();
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
            this.label_name = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
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
            this.label_PW.Location = new System.Drawing.Point(86, 232);
            this.label_PW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PW.Name = "label_PW";
            this.label_PW.Size = new System.Drawing.Size(46, 18);
            this.label_PW.TabIndex = 8;
            this.label_PW.Text = "PW :";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(136, 226);
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
            this.panel1.Controls.Add(this.button_unlock);
            this.panel1.Controls.Add(this.button_lock);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(11, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 402);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // button_unlock
            // 
            this.button_unlock.Location = new System.Drawing.Point(323, 32);
            this.button_unlock.Name = "button_unlock";
            this.button_unlock.Size = new System.Drawing.Size(96, 55);
            this.button_unlock.TabIndex = 16;
            this.button_unlock.Text = "save";
            this.button_unlock.UseVisualStyleBackColor = true;
            // 
            // button_lock
            // 
            this.button_lock.Location = new System.Drawing.Point(209, 32);
            this.button_lock.Name = "button_lock";
            this.button_lock.Size = new System.Drawing.Size(96, 55);
            this.button_lock.TabIndex = 15;
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
            this.listView1.Location = new System.Drawing.Point(192, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(251, 290);
            this.listView1.TabIndex = 14;
            this.listView1.TileSize = new System.Drawing.Size(308, 40);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "이름";
            this.columnHeader1.Width = 70;
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
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.panel2.Location = new System.Drawing.Point(14, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 355);
            this.panel2.TabIndex = 13;
            this.panel2.Visible = false;
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
            this.button_ppt1.Location = new System.Drawing.Point(50, 145);
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
            this.label_ppt2.Location = new System.Drawing.Point(57, 312);
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
            this.button_ppt2.Location = new System.Drawing.Point(50, 244);
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
            this.label_ppt1.Location = new System.Drawing.Point(57, 212);
            this.label_ppt1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ppt1.Name = "label_ppt1";
            this.label_ppt1.Size = new System.Drawing.Size(11, 18);
            this.label_ppt1.TabIndex = 4;
            this.label_ppt1.Text = "l";
            this.label_ppt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ppt1.Visible = false;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(65, 187);
            this.label_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(67, 18);
            this.label_name.TabIndex = 14;
            this.label_name.Text = "Name :";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(136, 181);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(189, 28);
            this.textBox_name.TabIndex = 13;
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
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.textBox_name);
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
        private System.Windows.Forms.Button button_unlock;
        private System.Windows.Forms.Button button_lock;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_name;
    }
}