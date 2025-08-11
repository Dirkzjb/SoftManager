using SoftwareManager.Models;
using SoftwareManager.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoftwareManager.Forms
{
    public partial class SoftwareItemControl : UserControl
    {
        private Software _software;

        public SoftwareItemControl()
        {
            InitializeComponent();
        }

        public void SetSoftware(Software software)
        {
            _software = software;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_software == null)
                return;

            lblName.Text = _software.Name;
            lblDescription.Text = _software.Description;
            
            // 加载软件图标
            try
            {
                if (!string.IsNullOrEmpty(_software.IconPath))
                {
                    string iconPath = System.IO.Path.Combine(Application.StartupPath, "Icons", _software.IconPath);
                    if (System.IO.File.Exists(iconPath))
                    {
                        pictureBoxIcon.Image = Image.FromFile(iconPath);
                    }
                    else
                    {
                        // 使用默认图标或生成字母图标
                        pictureBoxIcon.Image = GenerateLetterIcon(_software.Name);
                    }
                }
                else
                {
                    // 使用默认图标或生成字母图标
                    pictureBoxIcon.Image = GenerateLetterIcon(_software.Name);
                }
            }
            catch
            {
                // 出错时生成字母图标
                pictureBoxIcon.Image = GenerateLetterIcon(_software.Name);
            }

            // 检查软件是否已安装
            bool isInstalled = RegistryHelper.IsSoftwareInstalled(_software.RegistryPath);
            _software.Installed = isInstalled;

            // 更新安装状态
            if (isInstalled)
            {
                lblStatus.Text = "已安装";
                lblStatus.ForeColor = Color.Green;
                btnAction.Visible = false;
            }
            else
            {
                lblStatus.Text = "未安装";
                lblStatus.ForeColor = Color.Red;

                // 检查安装包是否存在
                bool packageExists = FileHelper.InstallPackageExists(_software.InstallPackagePath);
                if (packageExists)
                {
                    btnAction.Text = "下载安装";
                    btnAction.Tag = _software.InstallPackagePath;
                }
                else
                {
                    btnAction.Text = "下载安装";
                    btnAction.Tag = _software.DownloadUrl;
                }
                btnAction.Visible = true;
                
                // 设置按钮样式
                btnAction.BackColor = Color.FromArgb(0, 122, 204);
                btnAction.ForeColor = Color.White;
                btnAction.FlatStyle = FlatStyle.Flat;
                btnAction.FlatAppearance.BorderSize = 0;
            }
        }
        
        /// <summary>
        /// 生成基于首字母的图标
        /// </summary>
        private Image GenerateLetterIcon(string name)
        {
            if (string.IsNullOrEmpty(name))
                return SystemIcons.Application.ToBitmap();
                
            // 获取首字母（支持中文）
            string firstLetter = name.Substring(0, 1).ToUpper();
            
            // 创建位图
            Bitmap bitmap = new Bitmap(60, 60);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // 根据软件名称生成随机但固定的颜色
                int hashCode = name.GetHashCode();
                Random random = new Random(hashCode);
                Color backgroundColor = Color.FromArgb(
                    random.Next(100, 200),  // R
                    random.Next(100, 200),  // G
                    random.Next(100, 200)   // B
                );
                
                // 填充背景
                g.FillRectangle(new SolidBrush(backgroundColor), 0, 0, 60, 60);
                
                // 绘制文字
                using (Font font = new Font("Arial", 24, FontStyle.Bold))
                {
                    SizeF textSize = g.MeasureString(firstLetter, font);
                    g.DrawString(
                        firstLetter,
                        font,
                        Brushes.White,
                        (60 - textSize.Width) / 2,
                        (60 - textSize.Height) / 2
                    );
                }
            }
            
            return bitmap;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "安装")
            {
                string installPath = btnAction.Tag as string;
                if (!string.IsNullOrEmpty(installPath))
                {
                    FileHelper.LaunchInstallPackage(installPath);
                }
            }
            else if (btnAction.Text == "下载")
            {
                string downloadUrl = btnAction.Tag as string;
                if (!string.IsNullOrEmpty(downloadUrl))
                {
                    FileHelper.OpenDownloadUrl(downloadUrl);
                }
            }
        }

        public void RefreshStatus()
        {
            UpdateUI();
        }
    }
}