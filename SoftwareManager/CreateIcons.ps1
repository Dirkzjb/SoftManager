# 创建简单的软件图标
# 此脚本需要安装System.Drawing.Common包

Add-Type -AssemblyName System.Drawing

# 创建图标目录
$iconDir = ".\Icons"
if (-not (Test-Path $iconDir)) {
    New-Item -ItemType Directory -Path $iconDir | Out-Null
}

# 创建简单的图标函数
function Create-SimpleIcon {
    param (
        [string]$name,
        [string]$text,
        [System.Drawing.Color]$backgroundColor,
        [System.Drawing.Color]$textColor
    )
    
    $size = 64
    $bitmap = New-Object System.Drawing.Bitmap($size, $size)
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)
    
    # 填充背景
    $graphics.FillRectangle(
        (New-Object System.Drawing.SolidBrush($backgroundColor)), 
        0, 0, $size, $size
    )
    
    # 添加文本
    $font = New-Object System.Drawing.Font("Arial", 24, [System.Drawing.FontStyle]::Bold)
    $stringFormat = New-Object System.Drawing.StringFormat
    $stringFormat.Alignment = [System.Drawing.StringAlignment]::Center
    $stringFormat.LineAlignment = [System.Drawing.StringAlignment]::Center
    
    $graphics.DrawString(
        $text, 
        $font, 
        (New-Object System.Drawing.SolidBrush($textColor)), 
        (New-Object System.Drawing.RectangleF(0, 0, $size, $size)), 
        $stringFormat
    )
    
    # 保存图标
    $bitmap.Save("$iconDir\$name.png", [System.Drawing.Imaging.ImageFormat]::Png)
    
    $graphics.Dispose()
    $bitmap.Dispose()
    
    Write-Host "Created icon: $name.png"
}

# 创建各种软件图标
Create-SimpleIcon -name "vs" -text "VS" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 255, 153, 0)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "idea" -text "II" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 227, 60, 36)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "as" -text "AS" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 58, 183, 87)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "git" -text "GI" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 51, 153, 255)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "ps" -text "AP" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 255, 153, 0)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "ai" -text "AI" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 255, 102, 0)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "postman" -text "PM" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 255, 102, 0)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "jmeter" -text "JM" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 153, 51, 255)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "office" -text "MO" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 255, 102, 0)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "wps" -text "WP" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 0, 102, 204)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "7zip" -text "7Z" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 102, 102, 102)) -textColor ([System.Drawing.Color]::White)
Create-SimpleIcon -name "teamviewer" -text "TV" -backgroundColor ([System.Drawing.Color]::FromArgb(255, 0, 102, 204)) -textColor ([System.Drawing.Color]::White)

Write-Host "All icons created successfully!"