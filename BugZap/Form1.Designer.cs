namespace BugZap
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.score_label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gameOverPanel = new System.Windows.Forms.Panel();
            this.sdgManager1 = new Sdgt.SdgManager(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sdgButton2 = new Sdgt.Widgets.SDGButton();
            this.sdgButton1 = new Sdgt.Widgets.SDGButton();
            this.gameOverPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(484, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 234);
            this.panel2.TabIndex = 4;
            // 
            // score_label
            // 
            this.score_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score_label.AutoSize = true;
            this.score_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_label.Location = new System.Drawing.Point(782, 23);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(31, 33);
            this.score_label.TabIndex = 13;
            this.score_label.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(829, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 31);
            this.label9.TabIndex = 14;
            this.label9.Text = "Bugs Zapped!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 31);
            this.label10.TabIndex = 15;
            this.label10.Text = "Time Remaining: ";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(230, 12);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(103, 33);
            this.timeLabel.TabIndex = 16;
            this.timeLabel.Text = "label11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "GAME OVER!!";
            // 
            // gameOverPanel
            // 
            this.gameOverPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.gameOverPanel.Controls.Add(this.label1);
            this.gameOverPanel.Location = new System.Drawing.Point(336, 252);
            this.gameOverPanel.Name = "gameOverPanel";
            this.gameOverPanel.Size = new System.Drawing.Size(607, 255);
            this.gameOverPanel.TabIndex = 17;
            this.gameOverPanel.Visible = false;
            // 
            // sdgManager1
            // 
            this.sdgManager1.EmulateSystemMouseMode = Sdgt.EmulateSystemMouseModes.Park;
            this.sdgManager1.Keyboards = null;
            this.sdgManager1.Mice = null;
            this.sdgManager1.MouseToFollow = 0;
            this.sdgManager1.ParkSystemMouseLocation = new System.Drawing.Point(350, 350);
            this.sdgManager1.RelativeTo = this;
            this.sdgManager1.MouseMove += new Sdgt.SdgMouseEventHandler(this.sdgManager1_MouseMove);
            this.sdgManager1.MouseWheel += new Sdgt.SdgMouseEventHandler(this.sdgManager1_MouseWheel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 31);
            this.label2.TabIndex = 18;
            this.label2.Text = "Current Level:";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.Location = new System.Drawing.Point(230, 74);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(88, 33);
            this.levelLabel.TabIndex = 19;
            this.levelLabel.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(498, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 33);
            this.label3.TabIndex = 20;
            this.label3.Text = "SPEED INCREASE!!";
            this.label3.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(-11, 640);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 100);
            this.panel1.TabIndex = 21;
            // 
            // sdgButton2
            // 
            this.sdgButton2.CausesValidation = false;
            this.sdgButton2.Location = new System.Drawing.Point(721, 413);
            this.sdgButton2.Name = "sdgButton2";
            this.sdgButton2.Size = new System.Drawing.Size(152, 72);
            this.sdgButton2.TabIndex = 2;
            this.sdgButton2.UseLock = false;
            this.sdgButton2.sdgClick += new Sdgt.Widgets.buttonClickHandler(this.sdgButton2_sdgClick);
            // 
            // sdgButton1
            // 
            this.sdgButton1.CausesValidation = false;
            this.sdgButton1.Location = new System.Drawing.Point(462, 413);
            this.sdgButton1.Name = "sdgButton1";
            this.sdgButton1.Size = new System.Drawing.Size(152, 72);
            this.sdgButton1.TabIndex = 1;
            this.sdgButton1.UseLock = false;
            this.sdgButton1.sdgClick += new Sdgt.Widgets.buttonClickHandler(this.sdgButton1_sdgClick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1016, 739);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sdgButton2);
            this.Controls.Add(this.sdgButton1);
            this.Controls.Add(this.gameOverPanel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.panel2);
            this.Name = "mainForm";
            this.Text = "BugZap!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gameOverPanel.ResumeLayout(false);
            this.gameOverPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel gameOverPanel;
        private System.Windows.Forms.Label label1;
        private Sdgt.SdgManager sdgManager1;
        private Sdgt.Widgets.SDGButton sdgButton2;
        private Sdgt.Widgets.SDGButton sdgButton1;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}

