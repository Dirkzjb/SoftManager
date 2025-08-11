using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftwareManager.Utils
{
    public static class FileHelper
    {
        /// <summary>
        /// 检查安装包是否存在
        /// </summary>
        /// <param name="installPackagePath">安装包路径</param>
        /// <returns>如果安装包存在返回true，否则返回false</returns>
        public static bool InstallPackageExists(string installPackagePath)
        {
            if (string.IsNullOrEmpty(installPackagePath))
                return false;

            try
            {
                return File.Exists(installPackagePath);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 启动安装包
        /// </summary>
        /// <param name="installPackagePath">安装包路径</param>
        /// <returns>如果成功启动返回true，否则返回false</returns>
        public static bool LaunchInstallPackage(string installPackagePath)
        {
            if (!InstallPackageExists(installPackagePath))
                return false;

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = installPackagePath,
                    UseShellExecute = true
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 打开下载链接
        /// </summary>
        /// <param name="downloadUrl">下载链接</param>
        /// <returns>如果成功打开返回true，否则返回false</returns>
        public static bool OpenDownloadUrl(string downloadUrl)
        {
            if (string.IsNullOrEmpty(downloadUrl))
                return false;

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = downloadUrl,
                    UseShellExecute = true
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 从远程URL下载文件
        /// </summary>
        /// <param name="url">远程URL</param>
        /// <param name="localPath">本地保存路径</param>
        /// <returns>异步任务</returns>
        public static async Task DownloadFileAsync(string url, string localPath)
        {
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                }
            }
        }
    }
}