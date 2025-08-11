using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoftwareManager.Forms
{
    public partial class TabForm : Form
    {
        private MainForm _mainForm;
        private Button btnInitialize;
        private Button btnProgramCheck;
        private Button _activeButton;
        private Panel panelBackground;

        public TabForm(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            _activeButton = btnProgramCheck; // 默认选中软件安装标签
            ActivateButton(_activeButton);
        }

        private void InitializeComponent()
        {
            this.btnInitialize = new Button();
            this.btnProgramCheck = new Button();
            this.panelBackground = new Panel();
            this.SuspendLayout();
            
            // 
            // panelBackground
            // 
            this.panelBackground.BackColor = Color.White;
            this.panelBackground.Dock = DockStyle.Fill;
            this.panelBackground.Location = new Point(0, 0);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new Size(150, 600);
            this.panelBackground.TabIndex = 0;
            
            // 
            // btnInitialize
            // 
            this.btnInitialize.BackColor = Color.White;
            this.btnInitialize.FlatAppearance.BorderSize = 0;
            this.btnInitialize.FlatStyle = FlatStyle.Flat;
            this.btnInitialize.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnInitialize.ForeColor = Color.FromArgb(0, 120, 212);
            this.btnInitialize.Location = new Point(0, 0);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new Size(150, 60);
            this.btnInitialize.TabIndex = 1;
            this.btnInitialize.Text = "初始化";
            this.btnInitialize.UseVisualStyleBackColor = false;
            this.btnInitialize.Click += new EventHandler(this.btnInitialize_Click);
            this.btnInitialize.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.btnInitialize.MouseLeave += new EventHandler(this.btn_MouseLeave);
            
            // 
            // btnProgramCheck
            // 
            this.btnProgramCheck.BackColor = Color.White;
            this.btnProgramCheck.FlatAppearance.BorderSize = 0;
            this.btnProgramCheck.FlatStyle = FlatStyle.Flat;
            this.btnProgramCheck.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnProgramCheck.ForeColor = Color.FromArgb(0, 120, 212);
            this.btnProgramCheck.Location = new Point(0, 60);
            this.btnProgramCheck.Name = "btnProgramCheck";
            this.btnProgramCheck.Size = new Size(150, 60);
            this.btnProgramCheck.TabIndex = 2;
            this.btnProgramCheck.Text = "软件安装";
            this.btnProgramCheck.UseVisualStyleBackColor = false;
            this.btnProgramCheck.Click += new EventHandler(this.btnProgramCheck_Click);
            this.btnProgramCheck.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.btnProgramCheck.MouseLeave += new EventHandler(this.btn_MouseLeave);
            
            // 
            // TabForm
            // 
            this.ClientSize = new Size(150, 600);
            this.Controls.Add(this.btnProgramCheck);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.panelBackground);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false; // 不显示控制按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.Text = string.Empty; // 不显示标题
            this.Name = "TabForm";
            this.ResumeLayout(false);
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            ActivateButton(btnInitialize);
            ShowInitializePanel();
        }

        private void btnProgramCheck_Click(object sender, EventArgs e)
        {
            ActivateButton(btnProgramCheck);
            ShowProgramCheckPanel();
        }

        private void ActivateButton(Button button)
        {
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.White;
                _activeButton.ForeColor = Color.FromArgb(0, 120, 212);
            }
            
            button.BackColor = Color.FromArgb(0, 120, 212);
            button.ForeColor = Color.White;
            _activeButton = button;
        }
        
        // 鼠标悬浮事件处理程序
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn != _activeButton)
            {
                btn.BackColor = Color.FromArgb(230, 230, 230); // 悬浮时使用浅灰色背景
            }
        }
        
        // 鼠标离开事件处理程序
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn != _activeButton)
            {
                btn.BackColor = Color.White; // 恢复白色背景
            }
        }

        private void ShowInitializePanel()
        {
            // 通知主窗体显示初始化面板
            _mainForm.ShowInitializePanel();
        }

        private void ShowProgramCheckPanel()
        {
            // 通知主窗体显示软件安装面板
            _mainForm.ShowProgramCheckPanel();
        }
    }
}