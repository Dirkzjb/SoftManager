using SoftwareManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftwareManager.Utils
{
    public class DataManager
    {
        // 单例实例
        private static DataManager _instance;
        public static DataManager Instance => _instance ?? (_instance = new DataManager("config.json", "http://127.0.0.1:9090/config.json"));

        // 当前加载的软件数据
        public SoftwareData SoftwareData { get; private set; }

        private readonly string _localConfigPath;
        private readonly string _remoteConfigUrl;
        private readonly HttpClient _httpClient;

        public DataManager(string localConfigPath, string remoteConfigUrl = null)
        {
            _localConfigPath = localConfigPath;
            _remoteConfigUrl = remoteConfigUrl;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(5); // 设置5秒超时
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
                // 直接使用HttpClient获取远程数据
                HttpResponseMessage response = await _httpClient.GetAsync(_remoteConfigUrl);
                if (!response.IsSuccessStatusCode)
                    return null;

                string jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<SoftwareData>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                
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
        /// 加载软件数据，根据版本号判断是否需要从远程加载
        /// </summary>
        /// <returns>软件数据对象</returns>
        public async Task<SoftwareData> LoadSoftwareDataAsync()
        {
            // 先从本地加载数据
            SoftwareData localData = LoadDataFromLocal();
            string localVersion = localData?.Version ?? "0.0.0";
            
            if (!string.IsNullOrEmpty(_remoteConfigUrl))
            {
                try
                {
                    // 尝试从远程获取数据
                    SoftwareData remoteData = await LoadDataFromRemoteAsync();
                    
                    if (remoteData != null && !string.IsNullOrEmpty(remoteData.Version))
                    {
                        // 比较版本号
                        if (CompareVersions(remoteData.Version, localVersion) > 0)
                        {
                            // 远程版本更新，保存到本地并返回
                            Console.WriteLine($"发现新版本配置: {remoteData.Version}，正在更新...");
                            SaveData(remoteData);
                            SoftwareData = remoteData;
                            return remoteData;
                        }
                        else
                        {
                            Console.WriteLine($"本地配置已是最新版本: {localVersion}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"检查远程配置时出错: {ex.Message}");
                }
            }
            
            // 如果远程获取失败或版本相同，返回本地数据
            SoftwareData = localData;
            return localData;
        }
        
        /// <summary>
        /// 比较两个版本号
        /// </summary>
        /// <param name="version1">版本号1</param>
        /// <param name="version2">版本号2</param>
        /// <returns>如果version1大于version2返回1，相等返回0，小于返回-1</returns>
        private int CompareVersions(string version1, string version2)
        {
            if (string.IsNullOrEmpty(version1) && string.IsNullOrEmpty(version2))
                return 0;
            if (string.IsNullOrEmpty(version1))
                return -1;
            if (string.IsNullOrEmpty(version2))
                return 1;
                
            try
            {
                // 分割版本号为主版本号、次版本号和修订号
                string[] v1Parts = version1.Split('.');
                string[] v2Parts = version2.Split('.');
                
                // 比较每个部分
                int length = Math.Max(v1Parts.Length, v2Parts.Length);
                for (int i = 0; i < length; i++)
                {
                    int v1Part = i < v1Parts.Length ? int.Parse(v1Parts[i]) : 0;
                    int v2Part = i < v2Parts.Length ? int.Parse(v2Parts[i]) : 0;
                    
                    if (v1Part > v2Part)
                        return 1;
                    if (v1Part < v2Part)
                        return -1;
                }
                
                // 所有部分都相等
                return 0;
            }
            catch
            {
                // 如果解析失败，进行字符串比较
                return string.Compare(version1, version2, StringComparison.Ordinal);
            }
        }
    }
}
