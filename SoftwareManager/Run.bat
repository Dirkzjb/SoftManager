@echo off
chcp 65001 > nul
echo 正在启动内网软件管理系统...
cd /d %~dp0
cd bin\Release\net8.0-windows
start SoftwareManager.exe
