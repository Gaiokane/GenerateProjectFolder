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
        //默认项目文件夹
        public static string DefaultProjectFolder;
        //模板文件列表
        public static string TemplateFileList;
        //系统测试用例模板文件路径
        public static string SystemTestCaseTemplateFilePath;
        //测试服务器部署信息登记表模板文件路径
        public static string TestServerDeploymentInformationTemplateFilePath;
        //项目测试进度模板文件路径
        public static string ProjectTestProgressTemplateFilePath;
        //配置文件路径
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
            TemplateFileList = getappSettings("TemplateFileList");
            SystemTestCaseTemplateFilePath = getappSettings("SystemTestCaseTemplateFilePath");
            TestServerDeploymentInformationTemplateFilePath = getappSettings("TestServerDeploymentInformationTemplateFilePath");
            ProjectTestProgressTemplateFilePath = getappSettings("ProjectTestProgressTemplateFilePath");
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
            if (string.IsNullOrEmpty(TemplateFileList))
            {
                addappSettings("TemplateFileList", "SystemTestCaseTemplateFilePath;TestServerDeploymentInformationTemplateFilePath;ProjectTestProgressTemplateFilePath");
            }
            if (string.IsNullOrEmpty(SystemTestCaseTemplateFilePath))
            {
                addappSettings("SystemTestCaseTemplateFilePath", @"系统测试用例;D:\模板\_ST_系统测试用例.xlsx;");
            }
            if (string.IsNullOrEmpty(TestServerDeploymentInformationTemplateFilePath))
            {
                addappSettings("TestServerDeploymentInformationTemplateFilePath", @"测试服务器部署信息登记表;D:\模板\【重要】测试服务器部署信息登记表-xxx.xls;");
            }
            if (string.IsNullOrEmpty(ProjectTestProgressTemplateFilePath))
            {
                addappSettings("ProjectTestProgressTemplateFilePath", @"项目测试进度;D:\模板\项目测试进度.xls;");
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

        #region 查询appSettings配置，并对键值以分号分割
        /// <summary>
        /// 查询appSettings配置，并对键值以分号分割
        /// </summary>
        /// <param name="Key">appSettings键</param>
        /// <returns>appSettings值，以分号分割，返回数组</returns>
        public static string[] getappSettingsSplitBySemicolon(string key)
        {
            string[] result = { };
            string values = RWConfig.GetappSettingsValue(key, CONFIGPATH);
            for (int i = 0; i < 2; i++)
            {
                if (string.IsNullOrEmpty(values))
                {
                    init();
                }
                else
                {
                    result = values.Split(';');
                    break;
                }
            }
            return result;
        }
        #endregion
    }
}