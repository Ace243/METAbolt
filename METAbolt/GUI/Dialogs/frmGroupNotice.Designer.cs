﻿namespace METAbolt
{
    partial class frmGroupNotice
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
            this.picInsignia = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.rtbTitle = new System.Windows.Forms.RichTextBox();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picInsignia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picInsignia
            // 
            this.picInsignia.AccessibleName = "Group image";
            this.picInsignia.Location = new System.Drawing.Point(4, 4);
            this.picInsignia.Name = "picInsignia";
            this.picInsignia.Size = new System.Drawing.Size(100, 93);
            this.picInsignia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInsignia.TabIndex = 0;
            this.picInsignia.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group Notice";
            // 
            // label2
            // 
            this.label2.AccessibleName = "sent by label";
            this.label2.Location = new System.Drawing.Point(108, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sent by";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button5
            // 
            this.button5.AccessibleName = "Close this window button";
            this.button5.BackColor = System.Drawing.Color.RoyalBlue;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(337, 265);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "&Close";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // rtbTitle
            // 
            this.rtbTitle.AccessibleName = "Notice subject label";
            this.rtbTitle.BackColor = System.Drawing.Color.White;
            this.rtbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTitle.Location = new System.Drawing.Point(108, 57);
            this.rtbTitle.Name = "rtbTitle";
            this.rtbTitle.ReadOnly = true;
            this.rtbTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbTitle.Size = new System.Drawing.Size(284, 38);
            this.rtbTitle.TabIndex = 1;
            this.rtbTitle.Text = "";
            this.rtbTitle.WordWrap = false;
            // 
            // rtbBody
            // 
            this.rtbBody.AccessibleName = "Notice body textbox";
            this.rtbBody.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbBody.Location = new System.Drawing.Point(108, 97);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.ReadOnly = true;
            this.rtbBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbBody.Size = new System.Drawing.Size(284, 123);
            this.rtbBody.TabIndex = 2;
            this.rtbBody.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleName = "Notice icon";
            this.pictureBox1.Location = new System.Drawing.Point(3, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AccessibleName = "Notice attachment name label";
            this.label3.Location = new System.Drawing.Point(25, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(108, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 33);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "to open the attachment";
            this.button1.AccessibleName = "Open button";
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(228, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "&Open";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Attached: ";
            this.label4.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmGroupNotice
            // 
            this.AccessibleName = "Group notice window";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 291);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbBody);
            this.Controls.Add(this.rtbTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picInsignia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGroupNotice";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group Notice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGroupNotice_FormClosing);
            this.Load += new System.EventHandler(this.frmGroupNotice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picInsignia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picInsignia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RichTextBox rtbTitle;
        private System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}