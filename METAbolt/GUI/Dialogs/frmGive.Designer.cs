﻿namespace METAbolt
{
    partial class frmGive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGive));
            this.btnGive = new System.Windows.Forms.Button();
            this.lvwFindFriends = new System.Windows.Forms.ListView();
            this.chdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwSelected = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnFind = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGive
            // 
            this.btnGive.AccessibleName = "Give the item to all chosen avatars";
            this.btnGive.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGive.Enabled = false;
            this.btnGive.ForeColor = System.Drawing.Color.White;
            this.btnGive.Location = new System.Drawing.Point(268, 289);
            this.btnGive.Name = "btnGive";
            this.btnGive.Size = new System.Drawing.Size(53, 23);
            this.btnGive.TabIndex = 8;
            this.btnGive.Text = "&Give";
            this.btnGive.UseVisualStyleBackColor = false;
            this.btnGive.Click += new System.EventHandler(this.button2_Click);
            // 
            // lvwFindFriends
            // 
            this.lvwFindFriends.AccessibleName = "List of found avatars to select from";
            this.lvwFindFriends.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvwFindFriends.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdName});
            this.lvwFindFriends.Location = new System.Drawing.Point(17, 87);
            this.lvwFindFriends.Name = "lvwFindFriends";
            this.lvwFindFriends.Size = new System.Drawing.Size(205, 185);
            this.lvwFindFriends.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwFindFriends.TabIndex = 2;
            this.lvwFindFriends.UseCompatibleStateImageBehavior = false;
            this.lvwFindFriends.View = System.Windows.Forms.View.Details;
            this.lvwFindFriends.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwFindFriends_ColumnClick);
            this.lvwFindFriends.SelectedIndexChanged += new System.EventHandler(this.lvwFindPeople_SelectedIndexChanged);
            // 
            // chdName
            // 
            this.chdName.Text = "Name";
            this.chdName.Width = 180;
            // 
            // lvwSelected
            // 
            this.lvwSelected.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvwSelected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwSelected.Location = new System.Drawing.Point(255, 87);
            this.lvwSelected.Name = "lvwSelected";
            this.lvwSelected.Size = new System.Drawing.Size(205, 185);
            this.lvwSelected.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwSelected.TabIndex = 7;
            this.lvwSelected.UseCompatibleStateImageBehavior = false;
            this.lvwSelected.View = System.Windows.Forms.View.Details;
            this.lvwSelected.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwSelected_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Selected Name";
            this.columnHeader1.Width = 180;
            // 
            // button1
            // 
            this.button1.AccessibleName = "Chose selected avatar";
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(222, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 3;
            this.button1.Tag = "Select";
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleName = "Un-chose selected avatar";
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(222, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 4;
            this.button2.Tag = "Remove";
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.AccessibleName = "Chose all avatar";
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(222, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 23);
            this.button3.TabIndex = 5;
            this.button3.Tag = "Select all";
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.AccessibleName = "Un-chose all avatars";
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(222, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 23);
            this.button4.TabIndex = 6;
            this.button4.Tag = "Remove all";
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.AccessibleName = "Close this window";
            this.button5.BackColor = System.Drawing.Color.RoyalBlue;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(417, 289);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "&Close";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pb1
            // 
            this.pb1.AccessibleName = "Progress bar";
            this.pb1.Location = new System.Drawing.Point(255, 76);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(205, 10);
            this.pb1.TabIndex = 15;
            this.pb1.Visible = false;
            // 
            // label1
            // 
            this.label1.AccessibleName = "Information on give operation";
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(14, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "SEND/GIVE COMPLETED...";
            this.label1.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.AccessibleName = "Friends tab";
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(454, 251);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Friends";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.AccessibleName = "Groups tab";
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.pic1);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(454, 251);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Groups";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // pic1
            // 
            this.pic1.Image = ((System.Drawing.Image)(resources.GetObject("pic1.Image")));
            this.pic1.Location = new System.Drawing.Point(217, 63);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(20, 20);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic1.TabIndex = 43;
            this.pic1.TabStop = false;
            this.pic1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleDescription = "Chose the desired group from the list";
            this.comboBox1.AccessibleName = "Groups drop down box";
            this.comboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(326, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleName = "Search tab";
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnFind);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(454, 251);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnFind
            // 
            this.btnFind.AccessibleDescription = "Find the entered avatar";
            this.btnFind.AccessibleName = "Find button";
            this.btnFind.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFind.Enabled = false;
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(393, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(55, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleName = "Enter avatar name to find";
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(3, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "enter avatar name";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "Tabs";
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(8, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(462, 280);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // frmGive
            // 
            this.AccessibleDescription = "Utility to give one or more items to avatars";
            this.AccessibleName = "Give item/s window";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(476, 318);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvwSelected);
            this.Controls.Add(this.lvwFindFriends);
            this.Controls.Add(this.btnGive);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGive";
            this.ShowInTaskbar = false;
            this.Text = "Give inventory item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGive_FormClosing);
            this.Load += new System.EventHandler(this.frmGive_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGive;
        private System.Windows.Forms.ListView lvwFindFriends;
        private System.Windows.Forms.ColumnHeader chdName;
        private System.Windows.Forms.ListView lvwSelected;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}