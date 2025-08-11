using SoftwareManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftwareManager.Utils
{
    public class DataManager
    {
        private readonly string _localConfigPath;
        private readonly string _remoteConfigUrl;

        public DataManager(string localConfigPath, string remoteConfigUrl = null)
        {
            _localConfigPath = localConfigPath;
            _remoteConfigUrl = remoteConfigUrl;
        }

        /// <summary>
        /// 从远程加载数据
        /// </summary>
        /// <returns>软件数据对象</returns>
        public async Task<SoftwareData> LoadDataFromRemoteAsync()
        {
            if (string.IsNullOrEmpty(_remoteConfigUrl))
                return null;

            try
            {
                string tempFilePath = Path.GetTempFileName();
                await FileHelper.DownloadFileAsync(_remoteConfigUrl, tempFilePath);
                
                string jsonContent = await File.ReadAllTextAsync(tempFilePath);
                var data = JsonSerializer.Deserialize<SoftwareData>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                
                File.Delete(tempFilePath);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"从远程加载数据失败: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 从本地加载数据
        /// </summary>
        /// <returns>软件数据对象</returns>
        public SoftwareData LoadDataFromLocal()
        {
            try
            {
                if (!File.Exists(_localConfigPath))
                    return null;

                string jsonContent = File.ReadAllText(_localConfigPath);
                return JsonSerializer.Deserialize<SoftwareData>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"从本地加载数据失败: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        /// <param name="data">软件数据对象</param>
        /// <returns>是否保存成功</returns>
        public bool SaveData(SoftwareData data)
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(_localConfigPath);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                string jsonContent = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                
                File.WriteAllText(_localConfigPath, jsonContent);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"保存数据失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 加载软件数据，直接从本地加载，不尝试远程加载
        /// </summary>
        /// <returns>软件数据对象</returns>
        public async Task<SoftwareData> LoadSoftwareDataAsync()
        {
            // 直接从本地加载数据，不尝试远程加载
            SoftwareData localData = LoadDataFromLocal();
            return localData;
        }
    }
}
