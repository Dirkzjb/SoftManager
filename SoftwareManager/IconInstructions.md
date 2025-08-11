# 软件图标说明

内网软件管理系统使用简单的文字图标来表示不同的软件。图标使用两个字母的缩写，背景颜色区分不同的软件。

## 图标生成

系统中的图标可以通过运行 `CreateIcons.ps1` PowerShell脚本生成。该脚本会在 `Icons` 目录下创建所有软件的图标。

## 图标列表

- **VS** - Visual Studio Code (橙色)
- **II** - IntelliJ IDEA (红色)
- **AS** - Android Studio (绿色)
- **GI** - Git (蓝色)
- **AP** - Adobe Photoshop (橙色)
- **AI** - Adobe Illustrator (橙色)
- **PM** - Postman (橙色)
- **JM** - JMeter (紫色)
- **MO** - Microsoft Office (橙色)
- **WP** - WPS Office (蓝色)
- **7Z** - 7-Zip (灰色)
- **TV** - TeamViewer (蓝色)

## 自定义图标

如果需要添加新的软件图标，可以修改 `CreateIcons.ps1` 脚本，添加新的图标生成代码。例如：

```powershell
Create-SimpleIcon -name "新图标名" -text "缩写" -backgroundColor ([System.Drawing.Color]::FromArgb(255, R, G, B)) -textColor ([System.Drawing.Color]::White)
```

然后在 `config.json` 文件中引用新图标：

```json
"IconPath": "新图标名.png"