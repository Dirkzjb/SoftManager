@echo off
chcp 65001 > nul
echo 正在编译内网软件管理系统...

REM 编译应用程序
dotnet build -c Release

if %ERRORLEVEL% NEQ 0 (
    echo 编译失败！
    pause
    exit /b %ERRORLEVEL%
)

echo 编译成功！
echo 应用程序位于 bin\Release\net8.0-windows 目录
cd bin\Release\net8.0-windows
start SoftwareManager.exe
