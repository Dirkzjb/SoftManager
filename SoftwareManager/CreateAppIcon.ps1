# 创建应用程序图标生成脚本
$htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>应用程序图标生成器</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; background-color: #f5f5f5; }
        .icon-container { display: flex; flex-direction: column; align-items: center; margin: 30px; }
        .icon { 
            width: 128px; 
            height: 128px; 
            display: flex; 
            align-items: center; 
            justify-content: center; 
            border-radius: 20px; 
            color: white; 
            font-weight: bold;
            font-size: 24px;
            background: linear-gradient(135deg, #0078D7 0%, #0063B1 100%);
            box-shadow: 0 10px 20px rgba(0,0,0,0.2);
            position: relative;
            overflow: hidden;
        }
        .icon::before {
            content: '';
            position: absolute;
            top: -10px;
            left: -10px;
            right: -10px;
            bottom: -10px;
            background: linear-gradient(135deg, rgba(255,255,255,0.2) 0%, rgba(255,255,255,0) 50%);
            z-index: 1;
        }
        .icon-inner {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            z-index: 2;
        }
        .icon-text {
            font-size: 36px;
            margin-bottom: 5px;
        }
        .icon-subtext {
            font-size: 14px;
            opacity: 0.9;
        }
        h2 { margin-top: 30px; color: #333; }
        p { margin-bottom: 20px; color: #555; line-height: 1.5; }
        .instructions {
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
            margin-top: 30px;
        }
        .instructions h3 {
            color: #0078D7;
            margin-top: 0;
        }
        .instructions ol {
            padding-left: 20px;
        }
        .instructions li {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <h1>内网软件管理系统 - 应用程序图标</h1>
    <p>以下是为内网软件管理系统生成的应用程序图标。请右键点击图标并选择"另存为图片"来保存为ico文件。</p>
    
    <div class="icon-container">
        <div class="icon">
            <div class="icon-inner">
                <div class="icon-text">软件</div>
                <div class="icon-subtext">管理系统</div>
            </div>
        </div>
        <p>app.ico</p>
    </div>
    
    <div class="instructions">
        <h3>使用说明</h3>
        <ol>
            <li>右键点击上面的图标，选择"另存为图片"</li>
            <li>保存为PNG格式</li>
            <li>使用在线工具将PNG转换为ICO格式：
                <ul>
                    <li><a href="https://convertio.co/png-ico/" target="_blank">https://convertio.co/png-ico/</a></li>
                    <li><a href="https://icoconvert.com/" target="_blank">https://icoconvert.com/</a></li>
                </ul>
            </li>
            <li>将生成的ICO文件保存为app.ico，放在项目根目录下</li>
        </ol>
    </div>
</body>
</html>
"@

$htmlPath = ".\AppIconGenerator.html"
$htmlContent | Out-File -FilePath $htmlPath -Encoding utf8

Write-Host "已创建应用程序图标生成HTML文件: $htmlPath"
Write-Host "请打开此HTML文件，右键点击图标并保存"

# 打开HTML文件
Start-Process $htmlPath