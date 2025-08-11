@echo off
chcp 65001 > nul
echo 正在编译并运行内网软件管理系统...
cd /d %~dp0
call PublishSimple.bat
if %ERRORLEVEL% NEQ 0 (
    echo 编译失败，请检查错误信息。
    pause
    exit /b 1
)
echo 编译成功，正在启动应用程序...
cd bin\Release\net8.0-windows
start SoftwareManager.exe
