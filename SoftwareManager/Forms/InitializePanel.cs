using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareManager.Forms
{
    public partial class InitializePanel : UserControl
    {
        public event EventHandler ConfigurationCompleted;
        
        private bool _svnInstalled = false;
        private bool _gitInstalled = false;
        private const string SVN_DOWNLOAD_URL = "https://tortoisesvn.net/downloads.html";
        private const string GIT_DOWNLOAD_URL = "https://git-scm.com/download/win";
        private const string TARGET_DIR = @"D:\xgame";
        
        // 默认用户名和密码（仅用于策划、美术、QA角色）
        private const string DEFAULT_USERNAME = "readonly";
        private const string DEFAULT_PASSWORD = "readonly123";

        public InitializePanel()
        {
            InitializeComponent();
            
            // 默认选择客户端角色
            cmbRole.SelectedIndex = 0;
        }

        private void InitializePanel_Load(object sender, EventArgs e)
        {
            // 检查软件安装状态
            CheckSoftwareInstallation();
            
            // 根据软件安装状态显示相应界面
            UpdateUI();
        }

        private void CheckSoftwareInstallation()
        {
            // 检查SVN是否安装
            _svnInstalled = IsSvnInstalled();
            lblSvnStatus.Text = _svnInstalled ? 
                "SVN 已安装" : 
                "未检测到 SVN，请安装后继续";
            lblSvnStatus.ForeColor = _svnInstalled ? Color.Green : Color.Red;
            btnDownloadSvn.Visible = !_svnInstalled;
            
            // 检查Git是否安装
            _gitInstalled = IsGitInstalled();
            lblGitStatus.Text = _gitInstalled ? 
                "Git 已安装" : 
                "未检测到 Git，请安装后继续";
            lblGitStatus.ForeColor = _gitInstalled ? Color.Green : Color.Red;
            btnDownloadGit.Visible = !_gitInstalled;
        }

        private bool IsSvnInstalled()
        {
            try
            {
                // 检查TortoiseSVN注册表项
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\TortoiseSVN"))
                {
                    if (key != null)
                        return true;
                }
                
                // 检查SVN命令行工具
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "svn";
                    process.StartInfo.Arguments = "--version";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    
                    try
                    {
                        process.Start();
                        process.WaitForExit();
                        return process.ExitCode == 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private bool IsGitInstalled()
        {
            try
            {
                // 检查Git注册表项
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\GitForWindows"))
                {
                    if (key != null)
                        return true;
                }
                
                // 检查Git命令行工具
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "git";
                    process.StartInfo.Arguments = "--version";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    
                    try
                    {
                        process.Start();
                        process.WaitForExit();
                        return process.ExitCode == 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void UpdateUI()
        {
            if (_svnInstalled && _gitInstalled)
            {
                // 显示配置界面
                pnlSoftwareCheck.Visible = false;
                grpRepositories.Visible = true;
                grpRole.Visible = true;
                grpCredentials.Visible = true;
                btnInitialize.Visible = true;
            }
            else
            {
                // 显示软件安装检测界面
                pnlSoftwareCheck.Visible = true;
                grpRepositories.Visible = false;
                grpRole.Visible = false;
                grpCredentials.Visible = false;
                btnInitialize.Visible = false;
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 根据角色选择显示或隐藏用户名和密码输入框
            bool showGitCredentials = cmbRole.SelectedIndex <= 1; // 客户端或服务器角色需要Git凭据
            bool showSvnCredentials = true; // 所有角色都需要SVN凭据
            
            // 显示或隐藏SVN用户名和密码输入框（所有角色都需要）
            lblSvnUsername.Visible = showSvnCredentials;
            txtSvnUsername.Visible = showSvnCredentials;
            lblSvnPassword.Visible = showSvnCredentials;
            txtSvnPassword.Visible = showSvnCredentials;
            
            // 显示或隐藏Git用户名和密码输入框（仅客户端和服务器角色需要）
            lblGitUsername.Visible = showGitCredentials;
            txtGitUsername.Visible = showGitCredentials;
            lblGitPassword.Visible = showGitCredentials;
            txtGitPassword.Visible = showGitCredentials;
            
            // 如果是策划、美术、QA角色，使用默认Git用户名和密码
            if (!showGitCredentials)
            {
                txtGitUsername.Text = DEFAULT_USERNAME;
                txtGitPassword.Text = DEFAULT_PASSWORD;
            }
            else
            {
                // 清空Git用户名和密码
                txtGitUsername.Text = "";
                txtGitPassword.Text = "";
            }
            
            // 清空SVN用户名和密码（所有角色都需要手动输入）
            txtSvnUsername.Text = "";
            txtSvnPassword.Text = "";
        }

        private void btnDownloadSvn_Click(object sender, EventArgs e)
        {
            // 打开SVN下载页面
            Process.Start(new ProcessStartInfo
            {
                FileName = SVN_DOWNLOAD_URL,
                UseShellExecute = true
            });
        }

        private void btnDownloadGit_Click(object sender, EventArgs e)
        {
            // 打开Git下载页面
            Process.Start(new ProcessStartInfo
            {
                FileName = GIT_DOWNLOAD_URL,
                UseShellExecute = true
            });
        }

        private async void btnInitialize_Click(object sender, EventArgs e)
        {
            // 验证输入
            if (!ValidateInput())
                return;
                
            // 显示进度条
            progressBar.Visible = true;
            progressBar.Value = 0;
            btnInitialize.Enabled = false;
            
            try
            {
                // 更新状态
                lblStatus.Text = "正在初始化...";
                
                // 创建目标目录
                progressBar.Value = 10;
                await Task.Delay(100); // 让UI有时间更新
                
                if (!Directory.Exists(TARGET_DIR))
                {
                    lblStatus.Text = "创建目标目录...";
                    Directory.CreateDirectory(TARGET_DIR);
                }
                
                // 克隆SVN代码
                progressBar.Value = 20;
                lblStatus.Text = "正在克隆SVN代码...";
                await Task.Delay(100);
                
                bool svnSuccess = await CloneSvnRepositoryAsync(
                    txtSvnRepo.Text,
                    Path.Combine(TARGET_DIR, "svn_repo"),
                    txtSvnUsername.Text,
                    txtSvnPassword.Text
                );
                
                if (!svnSuccess)
                {
                    MessageBox.Show("SVN代码克隆失败，请检查仓库地址和凭据。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar.Visible = false;
                    btnInitialize.Enabled = true;
                    return;
                }
                
                // 克隆Git代码
                progressBar.Value = 60;
                lblStatus.Text = "正在克隆Git代码...";
                await Task.Delay(100);
                
                bool gitSuccess = await CloneGitRepositoryAsync(
                    txtGitRepo.Text,
                    Path.Combine(TARGET_DIR, "git_repo"),
                    txtGitUsername.Text,
                    txtGitPassword.Text
                );
                
                if (!gitSuccess)
                {
                    MessageBox.Show("Git代码克隆失败，请检查仓库地址和凭据。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar.Visible = false;
                    btnInitialize.Enabled = true;
                    return;
                }
                
                // 完成初始化
                progressBar.Value = 100;
                lblStatus.Text = "初始化完成！";
                await Task.Delay(500);
                
                MessageBox.Show("项目初始化成功！代码已克隆到 " + TARGET_DIR, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // 触发配置完成事件
                ConfigurationCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化过程中出错: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
                btnInitialize.Enabled = true;
            }
        }

        private bool ValidateInput()
        {
            // 验证SVN仓库地址
            if (string.IsNullOrWhiteSpace(txtSvnRepo.Text))
            {
                MessageBox.Show("请输入SVN仓库地址。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSvnRepo.Focus();
                return false;
            }
            
            // 验证Git仓库地址
            if (string.IsNullOrWhiteSpace(txtGitRepo.Text))
            {
                MessageBox.Show("请输入Git仓库地址。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGitRepo.Focus();
                return false;
            }
            
            // 如果是客户端或服务器角色，验证用户名和密码
            if (cmbRole.SelectedIndex <= 1)
            {
                if (string.IsNullOrWhiteSpace(txtSvnUsername.Text))
                {
                    MessageBox.Show("请输入SVN用户名。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSvnUsername.Focus();
                    return false;
                }
                
                if (string.IsNullOrWhiteSpace(txtSvnPassword.Text))
                {
                    MessageBox.Show("请输入SVN密码。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSvnPassword.Focus();
                    return false;
                }
                
                if (string.IsNullOrWhiteSpace(txtGitUsername.Text))
                {
                    MessageBox.Show("请输入Git用户名。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGitUsername.Focus();
                    return false;
                }
                
                if (string.IsNullOrWhiteSpace(txtGitPassword.Text))
                {
                    MessageBox.Show("请输入Git密码。", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGitPassword.Focus();
                    return false;
                }
            }
            
            return true;
        }

        private async Task<bool> CloneSvnRepositoryAsync(string repoUrl, string targetDir, string username, string password)
        {
            try
            {
                // 创建进程启动信息
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "svn",
                    Arguments = $"checkout {repoUrl} \"{targetDir}\" --username {username} --password {password} --non-interactive",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };
                
                // 启动进程
                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    
                    // 异步读取输出
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    
                    // 等待进程完成
                    await Task.Run(() => process.WaitForExit());
                    
                    // 检查是否成功
                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SVN克隆过程中出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async Task<bool> CloneGitRepositoryAsync(string repoUrl, string targetDir, string username, string password)
        {
            try
            {
                // 构建带凭据的URL
                string credentialUrl = repoUrl;
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    Uri uri = new Uri(repoUrl);
                    string userInfo = Uri.EscapeDataString(username) + ":" + Uri.EscapeDataString(password);
                    credentialUrl = $"{uri.Scheme}://{userInfo}@{uri.Host}{uri.PathAndQuery}";
                }
                
                // 创建进程启动信息
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = $"clone {credentialUrl} \"{targetDir}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };
                
                // 启动进程
                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    
                    // 异步读取输出
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    
                    // 等待进程完成
                    await Task.Run(() => process.WaitForExit());
                    
                    // 检查是否成功
                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Git克隆过程中出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}