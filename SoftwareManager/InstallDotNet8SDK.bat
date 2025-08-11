@echo off
echo 正在下载并安装.NET 8.0 SDK...
echo 这可能需要一些时间，请耐心等待...

:: 下载.NET 8.0 SDK安装程序
powershell -Command "& {Invoke-WebRequest -Uri 'https://download.visualstudio.microsoft.com/download/pr/b0c1a9c5-7340-4acf-95c4-d4b990a71858/4ab1c954a908c1c6c2f3e2c4c7b1c2d9/dotnet-sdk-8.0.100-win-x64.exe' -OutFile 'dotnet-sdk-8.0.100-win-x64.exe'}"

:: 安装.NET 8.0 SDK
echo 正在安装.NET 8.0 SDK...
start /wait dotnet-sdk-8.0.100-win-x64.exe /install /quiet /norestart

:: 检查安装是否成功
dotnet --version
if %ERRORLEVEL% NEQ 0 (
    echo 安装失败，请手动下载并安装.NET 8.0 SDK。
    echo 下载地址: https://dotnet.microsoft.com/download/dotnet/8.0
) else (
    echo .NET 8.0 SDK安装成功！
    echo 现在可以编译和运行内网软件管理系统了。
)

:: 删除安装程序
del dotnet-sdk-8.0.100-win-x64.exe

pause