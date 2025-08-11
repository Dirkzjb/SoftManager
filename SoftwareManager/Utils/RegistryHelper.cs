using Microsoft.Win32;
using System;

namespace SoftwareManager.Utils
{
    public static class RegistryHelper
    {
        /// <summary>
        /// 检查软件是否已安装（通过注册表路径）
        /// </summary>
        /// <param name="registryPath">注册表路径</param>
        /// <returns>如果软件已安装返回true，否则返回false</returns>
        public static bool IsSoftwareInstalled(string registryPath)
        {
            if (string.IsNullOrEmpty(registryPath))
                return false;

            try
            {
                // 解析注册表路径
                string[] parts = registryPath.Split('\\');
                if (parts.Length < 2)
                    return false;

                // 获取根键
                RegistryKey rootKey = GetRootKey(parts[0]);
                if (rootKey == null)
                    return false;

                // 构建子键路径
                string subKeyPath = string.Join("\\", parts, 1, parts.Length - 1);

                // 尝试打开子键
                using (RegistryKey subKey = rootKey.OpenSubKey(subKeyPath))
                {
                    return subKey != null;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据注册表根键名称获取对应的RegistryKey对象
        /// </summary>
        private static RegistryKey GetRootKey(string rootKeyName)
        {
            switch (rootKeyName.ToUpper())
            {
                case "HKEY_LOCAL_MACHINE":
                case "HKLM":
                    return Registry.LocalMachine;
                case "HKEY_CURRENT_USER":
                case "HKCU":
                    return Registry.CurrentUser;
                case "HKEY_CLASSES_ROOT":
                case "HKCR":
                    return Registry.ClassesRoot;
                case "HKEY_USERS":
                case "HKU":
                    return Registry.Users;
                case "HKEY_CURRENT_CONFIG":
                case "HKCC":
                    return Registry.CurrentConfig;
                default:
                    return null;
            }
        }
    }
}