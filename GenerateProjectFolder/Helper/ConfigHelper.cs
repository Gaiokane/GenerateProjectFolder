using Gaiokane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProjectFolder.Helper
{
    class ConfigHelper
    {
        public static string DefaultProjectFolder;
        public static string CONFIGPATH = "./GenerateProjectFolder.exe";

        #region 配置文件初始化，检查默认键是否有缺失，有则新增
        /// <summary>
        /// 配置文件初始化，检查默认键是否有缺失，有则新增
        /// </summary>
        public static void init()
        {
            getAllDefaultappSettings();
            setDefaultSettingsIfIsNullOrEmpty();
        }
        #endregion

        #region 获取配置文件中所有默认键值
        /// <summary>
        /// 获取配置文件中所有默认键值
        /// </summary>
        public static void getAllDefaultappSettings()
        {
            DefaultProjectFolder = getappSettings("DefaultProjectFolder");
        }
        #endregion

        #region 如果配置文件中有缺失默认键，则新增
        /// <summary>
        /// 如果配置文件中有缺失默认键，则新增
        /// </summary>
        public static void setDefaultSettingsIfIsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(DefaultProjectFolder))
            {
                addappSettings("DefaultProjectFolder", @"E:\2020");
            }
        }
        #endregion

        #region 是否存在配置文件中的key
        /// <summary>
        /// 是否存在配置文件中的key
        /// </summary>
        /// <param name="key">appSettings键</param>
        /// <returns>true, false</returns>
        public static bool IsappSettingsExists(string key)
        {
            if (!string.IsNullOrEmpty(getappSettings(key)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 新增appSettings配置
        /// <summary>
        /// 新增appSettings配置
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <param name="Value">appSettings值</param>
        /// <returns>true, false</returns>
        public static bool addappSettings(string key, string value)
        {
            try
            {
                RWConfig.SetappSettingsValue(key, value, CONFIGPATH);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 删除appSettings配置
        /// <summary>
        /// 删除appSettings配置
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <returns>true, false</returns>
        public static bool delappSettings(string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(key, CONFIGPATH)))
                {
                    RWConfig.DelappSettingsValue(key, CONFIGPATH);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 修改appSettings配置
        /// <summary>
        /// 修改appSettings配置
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <param name="Value">appSettings值</param>
        /// <returns>true, false</returns>
        public static bool editappSettings(string key, string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(key, CONFIGPATH)))
                {
                    RWConfig.SetappSettingsValue(key, value, CONFIGPATH);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 查询appSettings配置
        /// <summary>
        /// 查询appSettings配置
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <returns>appSettings值</returns>
        public static string getappSettings(string key)
        {
            string result = RWConfig.GetappSettingsValue(key, CONFIGPATH);
            return result;
        }
        #endregion
    }
}