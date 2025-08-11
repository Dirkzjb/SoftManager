@echo off
chcp 65001 > nul
echo 正在发布内网软件管理系统...

REM 清理旧的发布文件
if exist "publish" rd /s /q "publish"

REM 发布应用程序
dotnet publish -c Release -o publish --self-contained true -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true

if %ERRORLEVEL% NEQ 0 (
    echo 发布失败！
    pause
    exit /b %ERRORLEVEL%
)

echo 发布成功！发布文件位于 publish 目录
echo 正在启动应用程序...
start "" "publish\SoftwareManager.exe"

pause
