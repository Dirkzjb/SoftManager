using SoftwareManager.Models;
using SoftwareManager.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareManager.Forms
{
    public partial class MainForm : Form
    {
        private DataManager _dataManager;
        private SoftwareData _softwareData;
        private Dictionary<string, List<SoftwareItemControl>> _softwareControls;
        private string _configPath;
        private string _remoteConfigUrl;

public MainForm()
{
    InitializeComponent();
    _softwareControls = new Dictionary<string, List<SoftwareItemControl>>();
    
    // 设置窗体边框
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    
    // 设置TabControl绘制模式
    tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
    
    // 配置文件路径
    _configPath = Path.Combine(Application.StartupPath, "config.json");
    // 远程配置URL（实际使用时替换为真实URL）
    _remoteConfigUrl = "http://example.com/config.json";
    
    _dataManager = new DataManager(_configPath, _remoteConfigUrl);
    
    // 初始化并添加TabForm
    TabForm tabForm = new TabForm(this);
    tabForm.TopLevel = false;
    tabForm.Dock = DockStyle.Left;
    tabForm.Width = 150;
    tabForm.FormBorderStyle = FormBorderStyle.FixedSingle; // 添加边框
    this.Controls.Add(tabForm);
    tabForm.Show();
    
    // 调整工具栏位置
    toolStrip.Location = new System.Drawing.Point(150, 0);
    toolStrip.Width = this.ClientSize.Width - 150;
    
    // 调整tabControl的位置，让它在工具栏下方显示，并与主窗体右边对齐
    tabControl.Location = new System.Drawing.Point(150, toolStrip.Height);
    tabControl.Width = this.ClientSize.Width - 150;
    tabControl.Height = this.ClientSize.Height - toolStrip.Height - statusStrip.Height;
    tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
    
    // 调整状态栏位置
    statusStrip.Location = new System.Drawing.Point(0, this.ClientSize.Height - statusStrip.Height);
    
    // 设置版本信息
    versionLabel.Text = $"配置加载成功 (版本: 1.0.1)";
    versionLabel.Alignment = ToolStripItemAlignment.Right;
}

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // 显示加载中状态
            statusLabel.Text = "正在加载软件数据...";
            
            // 异步加载软件数据
            await LoadSoftwareDataAsync();
        }

        private async Task LoadSoftwareDataAsync()
        {
            try
            {
                // 加载软件数据
                _softwareData = await _dataManager.LoadSoftwareDataAsync();
                
                if (_softwareData == null)
                {
                    MessageBox.Show("无法加载软件数据，请检查配置文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // 创建"全部"类别
                var allSoftware = new List<Software>();
                foreach (var category in _softwareData.Categories)
                {
                    allSoftware.AddRange(category.Software);
                }
                
                // 添加"全部"标签页
                var allCategory = new SoftwareCategory
                {
                    Name = "全部",
                    Software = allSoftware
                };
                
                // 清空现有标签页
                tabControl.TabPages.Clear();
                _softwareControls.Clear();
                
                // 添加"全部"标签页
                AddCategoryTab(allCategory);
                
                // 添加其他类别标签页
                foreach (var category in _softwareData.Categories)
                {
                    AddCategoryTab(category);
                }
                
            // 更新状态栏
            statusLabel.Text = "软件数据加载完成";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载软件数据时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "加载软件数据失败";
            }
        }

        private void AddCategoryTab(SoftwareCategory category)
        {
            // 创建新标签页
            TabPage tabPage = new TabPage(category.Name);
            tabPage.BackColor = Color.White;
            
            // 创建滚动面板
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White
            };
            
            // 添加软件项控件
            List<SoftwareItemControl> controls = new List<SoftwareItemControl>();
            int yPos = 10;
            
            foreach (var software in category.Software)
            {
                SoftwareItemControl control = new SoftwareItemControl();
                control.SetSoftware(software);
                control.Location = new Point(10, yPos);
                control.Width = panel.Width - 20; // 减少边距，使控件更宽
                control.BackColor = Color.White;
                control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right; // 添加锚点，使控件宽度随面板变化
                
                panel.Controls.Add(control);
                controls.Add(control);
                
                yPos += control.Height + 10; // 增加间距
            }
            
            // 添加到字典
            _softwareControls[category.Name] = controls;
            
            // 添加面板到标签页
            tabPage.Controls.Add(panel);
            
            // 添加标签页到标签控件
            tabControl.TabPages.Add(tabPage);
            
            // 处理面板大小变化
            panel.Resize += (sender, e) =>
            {
                foreach (var control in controls)
                {
                    control.Width = panel.Width - 40;
                }
            };
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshSoftwareStatus();
        }

        private void RefreshSoftwareStatus()
        {
            if (_softwareControls == null || !_softwareControls.Any())
                return;
                
            statusLabel.Text = "正在刷新软件状态...";
            
            // 刷新所有软件项控件
            foreach (var controls in _softwareControls.Values)
            {
                foreach (var control in controls)
                {
                    control.RefreshStatus();
                }
            }
            
            statusLabel.Text = "软件状态已刷新";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            
            if (string.IsNullOrEmpty(searchText))
            {
                // 显示所有软件
                foreach (var controls in _softwareControls.Values)
                {
                    foreach (var control in controls)
                    {
                        control.Visible = true;
                    }
                }
                return;
            }
            
            // 获取当前标签页名称
            string currentTabName = tabControl.SelectedTab?.Text;
            if (string.IsNullOrEmpty(currentTabName) || !_softwareControls.ContainsKey(currentTabName))
                return;
                
            // 过滤当前标签页中的软件
            var controlsList = _softwareControls[currentTabName];
            foreach (var control in controlsList)
            {
                // 获取软件名称和描述
                string name = control.Controls["lblName"].Text.ToLower();
                string description = control.Controls["lblDescription"].Text.ToLower();
                
                // 如果名称或描述包含搜索文本，则显示
                control.Visible = name.Contains(searchText) || description.Contains(searchText);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 清空搜索框
            txtSearch.Text = string.Empty;
        }
        
        // 显示初始化面板
        public void ShowInitializePanel()
        {
            // 隐藏标签控件
            tabControl.Visible = false;
            
            // 创建并显示初始化面板
            InitializePanel initPanel = new InitializePanel();
            initPanel.ConfigurationCompleted += (s, e) => {
                // 配置完成后，移除面板并显示标签控件
                this.Controls.Remove(initPanel);
                tabControl.Visible = true;
                
                // 重新加载软件数据
                _ = LoadSoftwareDataAsync();
            };
            
            initPanel.Dock = DockStyle.Fill;
            this.Controls.Add(initPanel);
            initPanel.BringToFront();
        }
        
        // 显示软件安装面板（即主标签控件）
        public void ShowProgramCheckPanel()
        {
            // 确保标签控件可见
            tabControl.Visible = true;
            
            // 移除可能存在的其他面板
            foreach (Control control in this.Controls)
            {
                if (control is InitializePanel)
                {
                    this.Controls.Remove(control);
                    break;
                }
            }
        }
        
        // 窗口大小调整事件处理
        private void MainForm_Resize(object sender, EventArgs e)
        {
            // 调整工具栏位置
            toolStrip.Width = this.ClientSize.Width - 150;
            
            // 调整tabControl的位置
            tabControl.Width = this.ClientSize.Width - 150;
            tabControl.Height = this.ClientSize.Height - toolStrip.Height - statusStrip.Height;
            
            // 调整状态栏位置
            statusStrip.Location = new System.Drawing.Point(0, this.ClientSize.Height - statusStrip.Height);
            statusStrip.Width = this.ClientSize.Width;
        }
        
        // 自定义绘制标签页
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl.TabPages[e.Index];
            Rectangle tabBounds = tabControl.GetTabRect(e.Index);
            
            // 选中的标签页使用蓝色背景
            if (e.Index == tabControl.SelectedIndex)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 122, 204)), tabBounds);
                TextRenderer.DrawText(e.Graphics, page.Text, e.Font, tabBounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), tabBounds);
                TextRenderer.DrawText(e.Graphics, page.Text, e.Font, tabBounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
