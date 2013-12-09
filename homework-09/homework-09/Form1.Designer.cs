namespace homework_09
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_sum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_step = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_auto = new System.Windows.Forms.Button();
            this.btn_former = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_file_auto = new System.Windows.Forms.Button();
            this.btn_file_open = new System.Windows.Forms.Button();
            this.rbtn_hv = new System.Windows.Forms.RadioButton();
            this.rbtn_v = new System.Windows.Forms.RadioButton();
            this.rbtn_h = new System.Windows.Forms.RadioButton();
            this.rbtn_a = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 538);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tb_sum);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tb_step);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_auto);
            this.tabPage1.Controls.Add(this.btn_former);
            this.tabPage1.Controls.Add(this.btn_next);
            this.tabPage1.Controls.Add(this.btn_file_auto);
            this.tabPage1.Controls.Add(this.btn_file_open);
            this.tabPage1.Controls.Add(this.rbtn_hv);
            this.tabPage1.Controls.Add(this.rbtn_v);
            this.tabPage1.Controls.Add(this.rbtn_h);
            this.tabPage1.Controls.Add(this.rbtn_a);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(593, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb_sum
            // 
            this.tb_sum.Location = new System.Drawing.Point(493, 450);
            this.tb_sum.Name = "tb_sum";
            this.tb_sum.ReadOnly = true;
            this.tb_sum.Size = new System.Drawing.Size(82, 20);
            this.tb_sum.TabIndex = 17;
            this.tb_sum.Text = "0";
            this.tb_sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Current Sum";
            // 
            // tb_step
            // 
            this.tb_step.Location = new System.Drawing.Point(493, 389);
            this.tb_step.Name = "tb_step";
            this.tb_step.ReadOnly = true;
            this.tb_step.Size = new System.Drawing.Size(82, 20);
            this.tb_step.TabIndex = 15;
            this.tb_step.Text = "0";
            this.tb_step.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Current Step";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listView1.Location = new System.Drawing.Point(7, 7);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(468, 468);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Control";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Input and Mode";
            // 
            // btn_auto
            // 
            this.btn_auto.Location = new System.Drawing.Point(490, 318);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(87, 23);
            this.btn_auto.TabIndex = 10;
            this.btn_auto.Text = "auto";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // btn_former
            // 
            this.btn_former.Location = new System.Drawing.Point(490, 288);
            this.btn_former.Name = "btn_former";
            this.btn_former.Size = new System.Drawing.Size(87, 23);
            this.btn_former.TabIndex = 9;
            this.btn_former.Text = "former step <<";
            this.btn_former.UseVisualStyleBackColor = true;
            this.btn_former.Click += new System.EventHandler(this.btn_former_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(490, 258);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(87, 23);
            this.btn_next.TabIndex = 8;
            this.btn_next.Text = "next step >>";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_file_auto
            // 
            this.btn_file_auto.Location = new System.Drawing.Point(497, 186);
            this.btn_file_auto.Name = "btn_file_auto";
            this.btn_file_auto.Size = new System.Drawing.Size(75, 23);
            this.btn_file_auto.TabIndex = 7;
            this.btn_file_auto.Text = "auto input";
            this.btn_file_auto.UseVisualStyleBackColor = true;
            this.btn_file_auto.Click += new System.EventHandler(this.btn_file_auto_Click);
            // 
            // btn_file_open
            // 
            this.btn_file_open.Location = new System.Drawing.Point(497, 157);
            this.btn_file_open.Name = "btn_file_open";
            this.btn_file_open.Size = new System.Drawing.Size(75, 23);
            this.btn_file_open.TabIndex = 6;
            this.btn_file_open.Text = "open file";
            this.btn_file_open.UseVisualStyleBackColor = true;
            this.btn_file_open.Click += new System.EventHandler(this.btn_file_open_Click);
            // 
            // rbtn_hv
            // 
            this.rbtn_hv.AutoSize = true;
            this.rbtn_hv.Location = new System.Drawing.Point(497, 119);
            this.rbtn_hv.Name = "rbtn_hv";
            this.rbtn_hv.Size = new System.Drawing.Size(49, 17);
            this.rbtn_hv.TabIndex = 5;
            this.rbtn_hv.Text = "h + v";
            this.rbtn_hv.UseVisualStyleBackColor = true;
            // 
            // rbtn_v
            // 
            this.rbtn_v.AutoSize = true;
            this.rbtn_v.Location = new System.Drawing.Point(497, 96);
            this.rbtn_v.Name = "rbtn_v";
            this.rbtn_v.Size = new System.Drawing.Size(31, 17);
            this.rbtn_v.TabIndex = 4;
            this.rbtn_v.Text = "v";
            this.rbtn_v.UseVisualStyleBackColor = true;
            // 
            // rbtn_h
            // 
            this.rbtn_h.AutoSize = true;
            this.rbtn_h.Checked = true;
            this.rbtn_h.Location = new System.Drawing.Point(497, 72);
            this.rbtn_h.Name = "rbtn_h";
            this.rbtn_h.Size = new System.Drawing.Size(31, 17);
            this.rbtn_h.TabIndex = 3;
            this.rbtn_h.TabStop = true;
            this.rbtn_h.Text = "h";
            this.rbtn_h.UseVisualStyleBackColor = true;
            // 
            // rbtn_a
            // 
            this.rbtn_a.AutoSize = true;
            this.rbtn_a.Location = new System.Drawing.Point(497, 49);
            this.rbtn_a.Name = "rbtn_a";
            this.rbtn_a.Size = new System.Drawing.Size(31, 17);
            this.rbtn_a.TabIndex = 2;
            this.rbtn_a.Text = "a";
            this.rbtn_a.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 502);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "最大连通子数组";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_auto;
        private System.Windows.Forms.Button btn_former;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_file_auto;
        private System.Windows.Forms.Button btn_file_open;
        private System.Windows.Forms.RadioButton rbtn_hv;
        private System.Windows.Forms.RadioButton rbtn_v;
        private System.Windows.Forms.RadioButton rbtn_h;
        private System.Windows.Forms.RadioButton rbtn_a;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox tb_step;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_sum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}

