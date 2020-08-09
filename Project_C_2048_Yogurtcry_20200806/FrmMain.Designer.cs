namespace Project_C_2048_Yogurtcry_20200806
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlGameInfo = new System.Windows.Forms.Panel();
            this.lblGameScore = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.pnlGameArea = new System.Windows.Forms.Panel();
            this.lbl00 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl20 = new System.Windows.Forms.Label();
            this.lbl30 = new System.Windows.Forms.Label();
            this.lbl01 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl21 = new System.Windows.Forms.Label();
            this.lbl31 = new System.Windows.Forms.Label();
            this.lbl02 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl22 = new System.Windows.Forms.Label();
            this.lbl32 = new System.Windows.Forms.Label();
            this.lbl03 = new System.Windows.Forms.Label();
            this.lbl13 = new System.Windows.Forms.Label();
            this.lbl23 = new System.Windows.Forms.Label();
            this.lbl33 = new System.Windows.Forms.Label();
            this.pnlGameControl = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblGameRemark = new System.Windows.Forms.Label();
            this.pnlGameInfo.SuspendLayout();
            this.pnlGameArea.SuspendLayout();
            this.pnlGameControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGameInfo
            // 
            this.pnlGameInfo.Controls.Add(this.lblGameScore);
            this.pnlGameInfo.Controls.Add(this.lblGameName);
            this.pnlGameInfo.Location = new System.Drawing.Point(52, 60);
            this.pnlGameInfo.Name = "pnlGameInfo";
            this.pnlGameInfo.Size = new System.Drawing.Size(380, 70);
            this.pnlGameInfo.TabIndex = 22;
            // 
            // lblGameScore
            // 
            this.lblGameScore.BackColor = System.Drawing.Color.Transparent;
            this.lblGameScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGameScore.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.lblGameScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lblGameScore.Image = ((System.Drawing.Image)(resources.GetObject("lblGameScore.Image")));
            this.lblGameScore.Location = new System.Drawing.Point(140, 0);
            this.lblGameScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblGameScore.Name = "lblGameScore";
            this.lblGameScore.Size = new System.Drawing.Size(240, 70);
            this.lblGameScore.TabIndex = 22;
            this.lblGameScore.Text = "999,999,999";
            this.lblGameScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameName
            // 
            this.lblGameName.BackColor = System.Drawing.Color.Transparent;
            this.lblGameName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGameName.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.lblGameName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(116)))), ((int)(((byte)(107)))));
            this.lblGameName.Location = new System.Drawing.Point(0, 0);
            this.lblGameName.Margin = new System.Windows.Forms.Padding(5);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(125, 70);
            this.lblGameName.TabIndex = 23;
            this.lblGameName.Text = "2048";
            this.lblGameName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGameArea
            // 
            this.pnlGameArea.BackColor = System.Drawing.Color.Transparent;
            this.pnlGameArea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlGameArea.BackgroundImage")));
            this.pnlGameArea.Controls.Add(this.lbl00);
            this.pnlGameArea.Controls.Add(this.lbl10);
            this.pnlGameArea.Controls.Add(this.lbl20);
            this.pnlGameArea.Controls.Add(this.lbl30);
            this.pnlGameArea.Controls.Add(this.lbl01);
            this.pnlGameArea.Controls.Add(this.lbl11);
            this.pnlGameArea.Controls.Add(this.lbl21);
            this.pnlGameArea.Controls.Add(this.lbl31);
            this.pnlGameArea.Controls.Add(this.lbl02);
            this.pnlGameArea.Controls.Add(this.lbl12);
            this.pnlGameArea.Controls.Add(this.lbl22);
            this.pnlGameArea.Controls.Add(this.lbl32);
            this.pnlGameArea.Controls.Add(this.lbl03);
            this.pnlGameArea.Controls.Add(this.lbl13);
            this.pnlGameArea.Controls.Add(this.lbl23);
            this.pnlGameArea.Controls.Add(this.lbl33);
            this.pnlGameArea.Location = new System.Drawing.Point(52, 160);
            this.pnlGameArea.Name = "pnlGameArea";
            this.pnlGameArea.Padding = new System.Windows.Forms.Padding(5);
            this.pnlGameArea.Size = new System.Drawing.Size(380, 380);
            this.pnlGameArea.TabIndex = 23;
            // 
            // lbl00
            // 
            this.lbl00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl00.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl00.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl00.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl00.Location = new System.Drawing.Point(15, 15);
            this.lbl00.Margin = new System.Windows.Forms.Padding(5);
            this.lbl00.Name = "lbl00";
            this.lbl00.Size = new System.Drawing.Size(80, 80);
            this.lbl00.TabIndex = 18;
            this.lbl00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl10
            // 
            this.lbl10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl10.Location = new System.Drawing.Point(15, 105);
            this.lbl10.Margin = new System.Windows.Forms.Padding(5);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(80, 80);
            this.lbl10.TabIndex = 22;
            this.lbl10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl20
            // 
            this.lbl20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl20.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl20.Location = new System.Drawing.Point(15, 195);
            this.lbl20.Margin = new System.Windows.Forms.Padding(5);
            this.lbl20.Name = "lbl20";
            this.lbl20.Size = new System.Drawing.Size(80, 80);
            this.lbl20.TabIndex = 26;
            this.lbl20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl30
            // 
            this.lbl30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl30.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl30.Location = new System.Drawing.Point(15, 285);
            this.lbl30.Margin = new System.Windows.Forms.Padding(5);
            this.lbl30.Name = "lbl30";
            this.lbl30.Size = new System.Drawing.Size(80, 80);
            this.lbl30.TabIndex = 29;
            this.lbl30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl01
            // 
            this.lbl01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl01.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl01.Location = new System.Drawing.Point(105, 15);
            this.lbl01.Margin = new System.Windows.Forms.Padding(5);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(80, 80);
            this.lbl01.TabIndex = 17;
            this.lbl01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl11
            // 
            this.lbl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl11.Location = new System.Drawing.Point(105, 105);
            this.lbl11.Margin = new System.Windows.Forms.Padding(5);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(80, 80);
            this.lbl11.TabIndex = 21;
            this.lbl11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl21
            // 
            this.lbl21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl21.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl21.Location = new System.Drawing.Point(105, 195);
            this.lbl21.Margin = new System.Windows.Forms.Padding(5);
            this.lbl21.Name = "lbl21";
            this.lbl21.Size = new System.Drawing.Size(80, 80);
            this.lbl21.TabIndex = 25;
            this.lbl21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl31
            // 
            this.lbl31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl31.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl31.Location = new System.Drawing.Point(105, 285);
            this.lbl31.Margin = new System.Windows.Forms.Padding(5);
            this.lbl31.Name = "lbl31";
            this.lbl31.Size = new System.Drawing.Size(80, 80);
            this.lbl31.TabIndex = 14;
            this.lbl31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl02
            // 
            this.lbl02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl02.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl02.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl02.Location = new System.Drawing.Point(195, 15);
            this.lbl02.Margin = new System.Windows.Forms.Padding(5);
            this.lbl02.Name = "lbl02";
            this.lbl02.Size = new System.Drawing.Size(80, 80);
            this.lbl02.TabIndex = 19;
            this.lbl02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl12
            // 
            this.lbl12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl12.Location = new System.Drawing.Point(195, 105);
            this.lbl12.Margin = new System.Windows.Forms.Padding(5);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(80, 80);
            this.lbl12.TabIndex = 23;
            this.lbl12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl22
            // 
            this.lbl22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl22.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl22.Location = new System.Drawing.Point(195, 195);
            this.lbl22.Margin = new System.Windows.Forms.Padding(5);
            this.lbl22.Name = "lbl22";
            this.lbl22.Size = new System.Drawing.Size(80, 80);
            this.lbl22.TabIndex = 27;
            this.lbl22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl32
            // 
            this.lbl32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl32.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl32.Location = new System.Drawing.Point(195, 285);
            this.lbl32.Margin = new System.Windows.Forms.Padding(5);
            this.lbl32.Name = "lbl32";
            this.lbl32.Size = new System.Drawing.Size(80, 80);
            this.lbl32.TabIndex = 15;
            this.lbl32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl03
            // 
            this.lbl03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl03.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl03.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl03.Location = new System.Drawing.Point(285, 15);
            this.lbl03.Margin = new System.Windows.Forms.Padding(5);
            this.lbl03.Name = "lbl03";
            this.lbl03.Size = new System.Drawing.Size(80, 80);
            this.lbl03.TabIndex = 20;
            this.lbl03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl13
            // 
            this.lbl13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl13.Location = new System.Drawing.Point(285, 105);
            this.lbl13.Margin = new System.Windows.Forms.Padding(5);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(80, 80);
            this.lbl13.TabIndex = 24;
            this.lbl13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl23
            // 
            this.lbl23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl23.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl23.Location = new System.Drawing.Point(285, 195);
            this.lbl23.Margin = new System.Windows.Forms.Padding(5);
            this.lbl23.Name = "lbl23";
            this.lbl23.Size = new System.Drawing.Size(80, 80);
            this.lbl23.TabIndex = 28;
            this.lbl23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl33
            // 
            this.lbl33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.lbl33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl33.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbl33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.lbl33.Location = new System.Drawing.Point(285, 285);
            this.lbl33.Margin = new System.Windows.Forms.Padding(5);
            this.lbl33.Name = "lbl33";
            this.lbl33.Size = new System.Drawing.Size(80, 80);
            this.lbl33.TabIndex = 16;
            this.lbl33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGameControl
            // 
            this.pnlGameControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlGameControl.Controls.Add(this.btnRestart);
            this.pnlGameControl.Location = new System.Drawing.Point(438, 175);
            this.pnlGameControl.Name = "pnlGameControl";
            this.pnlGameControl.Size = new System.Drawing.Size(350, 350);
            this.pnlGameControl.TabIndex = 20;
            this.pnlGameControl.Visible = false;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(172)))), ((int)(((byte)(162)))));
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(172)))), ((int)(((byte)(162)))));
            this.btnRestart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(192)))), ((int)(((byte)(178)))));
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.btnRestart.Location = new System.Drawing.Point(88, 135);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(180, 80);
            this.btnRestart.TabIndex = 31;
            this.btnRestart.Text = "重新开始";
            this.btnRestart.UseVisualStyleBackColor = false;
            // 
            // lblGameRemark
            // 
            this.lblGameRemark.BackColor = System.Drawing.Color.Transparent;
            this.lblGameRemark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGameRemark.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblGameRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(116)))), ((int)(((byte)(107)))));
            this.lblGameRemark.Location = new System.Drawing.Point(44, 554);
            this.lblGameRemark.Margin = new System.Windows.Forms.Padding(5);
            this.lblGameRemark.Name = "lblGameRemark";
            this.lblGameRemark.Size = new System.Drawing.Size(396, 40);
            this.lblGameRemark.TabIndex = 24;
            this.lblGameRemark.Text = "使用 W、A、S、D 或  方向键  移动色块，组合成更大的数字";
            this.lblGameRemark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(484, 641);
            this.Controls.Add(this.lblGameRemark);
            this.Controls.Add(this.pnlGameControl);
            this.Controls.Add(this.pnlGameArea);
            this.Controls.Add(this.pnlGameInfo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 680);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 680);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project_2048_Yogurtcry_20200806";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.pnlGameInfo.ResumeLayout(false);
            this.pnlGameArea.ResumeLayout(false);
            this.pnlGameControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGameInfo;
        private System.Windows.Forms.Label lblGameScore;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Panel pnlGameArea;
        private System.Windows.Forms.Panel pnlGameControl;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lbl00;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl20;
        private System.Windows.Forms.Label lbl30;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl21;
        private System.Windows.Forms.Label lbl31;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lbl22;
        private System.Windows.Forms.Label lbl32;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.Label lbl23;
        private System.Windows.Forms.Label lbl33;
        private System.Windows.Forms.Label lblGameRemark;
    }
}

