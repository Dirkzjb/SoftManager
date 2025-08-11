namespace SoftwareManager.Forms
{
    partial class InitializePanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpRepositories = new System.Windows.Forms.GroupBox();
            this.txtGitRepo = new System.Windows.Forms.TextBox();
            this.lblGitRepo = new System.Windows.Forms.Label();
            this.txtSvnRepo = new System.Windows.Forms.TextBox();
            this.lblSvnRepo = new System.Windows.Forms.Label();
            this.grpRole = new System.Windows.Forms.GroupBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.grpCredentials = new System.Windows.Forms.GroupBox();
            this.txtGitPassword = new System.Windows.Forms.TextBox();
            this.lblGitPassword = new System.Windows.Forms.Label();
            this.txtGitUsername = new System.Windows.Forms.TextBox();
            this.lblGitUsername = new System.Windows.Forms.Label();
            this.txtSvnPassword = new System.Windows.Forms.TextBox();
            this.lblSvnPassword = new System.Windows.Forms.Label();
            this.txtSvnUsername = new System.Windows.Forms.TextBox();
            this.lblSvnUsername = new System.Windows.Forms.Label();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.pnlSoftwareCheck = new System.Windows.Forms.Panel();
            this.btnDownloadGit = new System.Windows.Forms.Button();
            this.btnDownloadSvn = new System.Windows.Forms.Button();
            this.lblGitStatus = new System.Windows.Forms.Label();
            this.lblSvnStatus = new System.Windows.Forms.Label();
            this.lblSoftwareCheck = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpRepositories.SuspendLayout();
            this.grpRole.SuspendLayout();
            this.grpCredentials.SuspendLayout();
            this.pnlSoftwareCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "项目初始化配置";
            // 
            // grpRepositories
            // 
            this.grpRepositories.Controls.Add(this.txtGitRepo);
            this.grpRepositories.Controls.Add(this.lblGitRepo);
            this.grpRepositories.Controls.Add(this.txtSvnRepo);
            this.grpRepositories.Controls.Add(this.lblSvnRepo);
            this.grpRepositories.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpRepositories.Location = new System.Drawing.Point(20, 60);
            this.grpRepositories.Name = "grpRepositories";
            this.grpRepositories.Size = new System.Drawing.Size(600, 120);
            this.grpRepositories.TabIndex = 1;
            this.grpRepositories.TabStop = false;
            this.grpRepositories.Text = "仓库地址配置";
            // 
            // txtGitRepo
            // 
            this.txtGitRepo.Location = new System.Drawing.Point(120, 70);
            this.txtGitRepo.Name = "txtGitRepo";
            this.txtGitRepo.Size = new System.Drawing.Size(450, 25);
            this.txtGitRepo.TabIndex = 3;
            // 
            // lblGitRepo
            // 
            this.lblGitRepo.AutoSize = true;
            this.lblGitRepo.Location = new System.Drawing.Point(20, 73);
            this.lblGitRepo.Name = "lblGitRepo";
            this.lblGitRepo.Size = new System.Drawing.Size(65, 20);
            this.lblGitRepo.TabIndex = 2;
            this.lblGitRepo.Text = "Git 地址:";
            // 
            // txtSvnRepo
            // 
            this.txtSvnRepo.Location = new System.Drawing.Point(120, 30);
            this.txtSvnRepo.Name = "txtSvnRepo";
            this.txtSvnRepo.Size = new System.Drawing.Size(450, 25);
            this.txtSvnRepo.TabIndex = 1;
            // 
            // lblSvnRepo
            // 
            this.lblSvnRepo.AutoSize = true;
            this.lblSvnRepo.Location = new System.Drawing.Point(20, 33);
            this.lblSvnRepo.Name = "lblSvnRepo";
            this.lblSvnRepo.Size = new System.Drawing.Size(73, 20);
            this.lblSvnRepo.TabIndex = 0;
            this.lblSvnRepo.Text = "SVN 地址:";
            // 
            // grpRole
            // 
            this.grpRole.Controls.Add(this.cmbRole);
            this.grpRole.Controls.Add(this.lblRole);
            this.grpRole.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpRole.Location = new System.Drawing.Point(20, 190);
            this.grpRole.Name = "grpRole";
            this.grpRole.Size = new System.Drawing.Size(600, 70);
            this.grpRole.TabIndex = 2;
            this.grpRole.TabStop = false;
            this.grpRole.Text = "成员角色选择";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "客户端",
            "服务器",
            "策划",
            "美术",
            "QA"});
            this.cmbRole.Location = new System.Drawing.Point(120, 30);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(200, 27);
            this.cmbRole.TabIndex = 1;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(20, 33);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(79, 20);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "选择角色：";
            // 
            // grpCredentials
            // 
            this.grpCredentials.Controls.Add(this.txtGitPassword);
            this.grpCredentials.Controls.Add(this.lblGitPassword);
            this.grpCredentials.Controls.Add(this.txtGitUsername);
            this.grpCredentials.Controls.Add(this.lblGitUsername);
            this.grpCredentials.Controls.Add(this.txtSvnPassword);
            this.grpCredentials.Controls.Add(this.lblSvnPassword);
            this.grpCredentials.Controls.Add(this.txtSvnUsername);
            this.grpCredentials.Controls.Add(this.lblSvnUsername);
            this.grpCredentials.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpCredentials.Location = new System.Drawing.Point(20, 270);
            this.grpCredentials.Name = "grpCredentials";
            this.grpCredentials.Size = new System.Drawing.Size(600, 150);
            this.grpCredentials.TabIndex = 3;
            this.grpCredentials.TabStop = false;
            this.grpCredentials.Text = "用户名和密码";
            // 
            // txtGitPassword
            // 
            this.txtGitPassword.Location = new System.Drawing.Point(370, 70);
            this.txtGitPassword.Name = "txtGitPassword";
            this.txtGitPassword.PasswordChar = '*';
            this.txtGitPassword.Size = new System.Drawing.Size(200, 25);
            this.txtGitPassword.TabIndex = 7;
            // 
            // lblGitPassword
            // 
            this.lblGitPassword.AutoSize = true;
            this.lblGitPassword.Location = new System.Drawing.Point(290, 73);
            this.lblGitPassword.Name = "lblGitPassword";
            this.lblGitPassword.Size = new System.Drawing.Size(74, 20);
            this.lblGitPassword.TabIndex = 6;
            this.lblGitPassword.Text = "Git 密码：";
            // 
            // txtGitUsername
            // 
            this.txtGitUsername.Location = new System.Drawing.Point(120, 70);
            this.txtGitUsername.Name = "txtGitUsername";
            this.txtGitUsername.Size = new System.Drawing.Size(150, 25);
            this.txtGitUsername.TabIndex = 5;
            // 
            // lblGitUsername
            // 
            this.lblGitUsername.AutoSize = true;
            this.lblGitUsername.Location = new System.Drawing.Point(20, 73);
            this.lblGitUsername.Name = "lblGitUsername";
            this.lblGitUsername.Size = new System.Drawing.Size(89, 20);
            this.lblGitUsername.TabIndex = 4;
            this.lblGitUsername.Text = "Git 用户名：";
            // 
            // txtSvnPassword
            // 
            this.txtSvnPassword.Location = new System.Drawing.Point(370, 30);
            this.txtSvnPassword.Name = "txtSvnPassword";
            this.txtSvnPassword.PasswordChar = '*';
            this.txtSvnPassword.Size = new System.Drawing.Size(200, 25);
            this.txtSvnPassword.TabIndex = 3;
            // 
            // lblSvnPassword
            // 
            this.lblSvnPassword.AutoSize = true;
            this.lblSvnPassword.Location = new System.Drawing.Point(290, 33);
            this.lblSvnPassword.Name = "lblSvnPassword";
            this.lblSvnPassword.Size = new System.Drawing.Size(82, 20);
            this.lblSvnPassword.TabIndex = 2;
            this.lblSvnPassword.Text = "SVN 密码：";
            // 
            // txtSvnUsername
            // 
            this.txtSvnUsername.Location = new System.Drawing.Point(120, 30);
            this.txtSvnUsername.Name = "txtSvnUsername";
            this.txtSvnUsername.Size = new System.Drawing.Size(150, 25);
            this.txtSvnUsername.TabIndex = 1;
            // 
            // lblSvnUsername
            // 
            this.lblSvnUsername.AutoSize = true;
            this.lblSvnUsername.Location = new System.Drawing.Point(20, 33);
            this.lblSvnUsername.Name = "lblSvnUsername";
            this.lblSvnUsername.Size = new System.Drawing.Size(97, 20);
            this.lblSvnUsername.TabIndex = 0;
            this.lblSvnUsername.Text = "SVN 用户名：";
            // 
            // btnInitialize
            // 
            this.btnInitialize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnInitialize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInitialize.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInitialize.ForeColor = System.Drawing.Color.White;
            this.btnInitialize.Location = new System.Drawing.Point(250, 440);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(150, 40);
            this.btnInitialize.TabIndex = 4;
            this.btnInitialize.Text = "初始化";
            this.btnInitialize.UseVisualStyleBackColor = false;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // pnlSoftwareCheck
            // 
            this.pnlSoftwareCheck.Controls.Add(this.btnDownloadGit);
            this.pnlSoftwareCheck.Controls.Add(this.btnDownloadSvn);
            this.pnlSoftwareCheck.Controls.Add(this.lblGitStatus);
            this.pnlSoftwareCheck.Controls.Add(this.lblSvnStatus);
            this.pnlSoftwareCheck.Controls.Add(this.lblSoftwareCheck);
            this.pnlSoftwareCheck.Location = new System.Drawing.Point(20, 60);
            this.pnlSoftwareCheck.Name = "pnlSoftwareCheck";
            this.pnlSoftwareCheck.Size = new System.Drawing.Size(600, 150);
            this.pnlSoftwareCheck.TabIndex = 5;
            this.pnlSoftwareCheck.Visible = false;
            // 
            // btnDownloadGit
            // 
            this.btnDownloadGit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnDownloadGit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadGit.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDownloadGit.ForeColor = System.Drawing.Color.White;
            this.btnDownloadGit.Location = new System.Drawing.Point(350, 100);
            this.btnDownloadGit.Name = "btnDownloadGit";
            this.btnDownloadGit.Size = new System.Drawing.Size(120, 30);
            this.btnDownloadGit.TabIndex = 4;
            this.btnDownloadGit.Text = "下载 Git";
            this.btnDownloadGit.UseVisualStyleBackColor = false;
            this.btnDownloadGit.Click += new System.EventHandler(this.btnDownloadGit_Click);
            // 
            // btnDownloadSvn
            // 
            this.btnDownloadSvn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnDownloadSvn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadSvn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDownloadSvn.ForeColor = System.Drawing.Color.White;
            this.btnDownloadSvn.Location = new System.Drawing.Point(350, 60);
            this.btnDownloadSvn.Name = "btnDownloadSvn";
            this.btnDownloadSvn.Size = new System.Drawing.Size(120, 30);
            this.btnDownloadSvn.TabIndex = 3;
            this.btnDownloadSvn.Text = "下载 SVN";
            this.btnDownloadSvn.UseVisualStyleBackColor = false;
            this.btnDownloadSvn.Click += new System.EventHandler(this.btnDownloadSvn_Click);
            // 
            // lblGitStatus
            // 
            this.lblGitStatus.AutoSize = true;
            this.lblGitStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGitStatus.ForeColor = System.Drawing.Color.Red;
            this.lblGitStatus.Location = new System.Drawing.Point(20, 105);
            this.lblGitStatus.Name = "lblGitStatus";
            this.lblGitStatus.Size = new System.Drawing.Size(196, 20);
            this.lblGitStatus.TabIndex = 2;
            this.lblGitStatus.Text = "未检测到 Git，请安装后继续";
            // 
            // lblSvnStatus
            // 
            this.lblSvnStatus.AutoSize = true;
            this.lblSvnStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSvnStatus.ForeColor = System.Drawing.Color.Red;
            this.lblSvnStatus.Location = new System.Drawing.Point(20, 65);
            this.lblSvnStatus.Name = "lblSvnStatus";
            this.lblSvnStatus.Size = new System.Drawing.Size(204, 20);
            this.lblSvnStatus.TabIndex = 1;
            this.lblSvnStatus.Text = "未检测到 SVN，请安装后继续";
            // 
            // lblSoftwareCheck
            // 
            this.lblSoftwareCheck.AutoSize = true;
            this.lblSoftwareCheck.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSoftwareCheck.Location = new System.Drawing.Point(20, 20);
            this.lblSoftwareCheck.Name = "lblSoftwareCheck";
            this.lblSoftwareCheck.Size = new System.Drawing.Size(138, 22);
            this.lblSoftwareCheck.TabIndex = 0;
            this.lblSoftwareCheck.Text = "软件安装状态检测";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(20, 500);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(600, 23);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(20, 480);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 7;
            // 
            // InitializePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pnlSoftwareCheck);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.grpCredentials);
            this.Controls.Add(this.grpRole);
            this.Controls.Add(this.grpRepositories);
            this.Controls.Add(this.lblTitle);
            this.Name = "InitializePanel";
            this.Size = new System.Drawing.Size(650, 550);
            this.Load += new System.EventHandler(this.InitializePanel_Load);
            this.grpRepositories.ResumeLayout(false);
            this.grpRepositories.PerformLayout();
            this.grpRole.ResumeLayout(false);
            this.grpRole.PerformLayout();
            this.grpCredentials.ResumeLayout(false);
            this.grpCredentials.PerformLayout();
            this.pnlSoftwareCheck.ResumeLayout(false);
            this.pnlSoftwareCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpRepositories;
        private System.Windows.Forms.TextBox txtGitRepo;
        private System.Windows.Forms.Label lblGitRepo;
        private System.Windows.Forms.TextBox txtSvnRepo;
        private System.Windows.Forms.Label lblSvnRepo;
        private System.Windows.Forms.GroupBox grpRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.GroupBox grpCredentials;
        private System.Windows.Forms.TextBox txtGitPassword;
        private System.Windows.Forms.Label lblGitPassword;
        private System.Windows.Forms.TextBox txtGitUsername;
        private System.Windows.Forms.Label lblGitUsername;
        private System.Windows.Forms.TextBox txtSvnPassword;
        private System.Windows.Forms.Label lblSvnPassword;
        private System.Windows.Forms.TextBox txtSvnUsername;
        private System.Windows.Forms.Label lblSvnUsername;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Panel pnlSoftwareCheck;
        private System.Windows.Forms.Button btnDownloadGit;
        private System.Windows.Forms.Button btnDownloadSvn;
        private System.Windows.Forms.Label lblGitStatus;
        private System.Windows.Forms.Label lblSvnStatus;
        private System.Windows.Forms.Label lblSoftwareCheck;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
    }
}