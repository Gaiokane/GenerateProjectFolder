using Gaiokane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProjectFolder
{
    class ConfigHelper
    {
        public static string QuickInsert, QuickInsert_IDIncrement, QuickInsert_RandomNum, QuickInsert_NewID, QuickInsert_NewDateTime, QuickInsert_SameNewID, QuickInsert_RandomStr;
        public static string CONFIGPATH = "./GenerateProjectFolder.exe";

        #region 获取配置文件中快捷插入配置
        /// <summary>
        /// 获取配置文件中快捷插入配置
        /// </summary>
        public static void getQuickInsertSettingsByappSettings()
        {
            QuickInsert = RWConfig.GetappSettingsValue("QuickInsert", CONFIGPATH);
            QuickInsert_IDIncrement = RWConfig.GetappSettingsValue("QuickInsert_IDIncrement", CONFIGPATH);
            QuickInsert_RandomNum = RWConfig.GetappSettingsValue("QuickInsert_RandomNum", CONFIGPATH);
            QuickInsert_NewID = RWConfig.GetappSettingsValue("QuickInsert_NewID", CONFIGPATH);
            QuickInsert_NewDateTime = RWConfig.GetappSettingsValue("QuickInsert_NewDateTime", CONFIGPATH);
            QuickInsert_SameNewID = RWConfig.GetappSettingsValue("QuickInsert_SameNewID", CONFIGPATH);
            QuickInsert_RandomStr = RWConfig.GetappSettingsValue("QuickInsert_RandomStr", CONFIGPATH);
        }
        #endregion

        #region 如果配置文件中无快捷插入配置，则新建配置，值默认
        /// <summary>
        /// 如果配置文件中无快捷插入配置，则新建配置，值默认
        /// </summary>
        public static void setDefaultQuickInsertSettingsIfIsNullOrEmptyByappSettings()
        {
            if (string.IsNullOrEmpty(QuickInsert))
            {
                RWConfig.SetappSettingsValue("QuickInsert", "QuickInsert_IDIncrement;QuickInsert_RandomNum;QuickInsert_NewID;QuickInsert_NewDateTime;QuickInsert_SameNewID", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(QuickInsert_IDIncrement))
            {
                RWConfig.SetappSettingsValue("QuickInsert_IDIncrement", "指定id递增;{{id:x}};x替换为开始的序号，从x开始生成（包含x）", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomNum))
            {
                RWConfig.SetappSettingsValue("QuickInsert_RandomNum", "指定范围随机数;{{[1-2]}};-左边开始&#xA;-右边结束&#xA;不带小数点生成的随机数也不带", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(QuickInsert_NewID))
            {
                RWConfig.SetappSettingsValue("QuickInsert_NewID", "生成newid/uuid;{{newid}};有匹配项就替换为新uuid", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(QuickInsert_NewDateTime))
            {
                RWConfig.SetappSettingsValue("QuickInsert_NewDateTime", "指定时间递增;{{timed+x:yyyy-MM-dd HH:mm:ss}};+左边为时间类型（d|h|m|s 对应 日|时|分|秒）&#xA;+右边为递增/递减值", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(QuickInsert_SameNewID))
            {
                RWConfig.SetappSettingsValue("QuickInsert_SameNewID", "生成相同newid/uuid;{{samenewid}};一次执行多条sql，使用相同uuid", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomStr))
            {
                RWConfig.SetappSettingsValue("QuickInsert_RandomStr", "在指定元素中随机选择一项;{{[x；y；z...]}};x、y、z为指定元素，\n能在元素中随机选择一项，\n请将；换成英文分号", CONFIGPATH);
            }

            //快捷插入中缺失默认配置会自动新增
            getQuickInsertSettingsByappSettings();
            string append = "";
            string[] arrayQuickInsert = QuickInsert.Split(';');
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_IDIncrement") == -1)
            {
                append += ";QuickInsert_IDIncrement";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_RandomNum") == -1)
            {
                append += ";QuickInsert_RandomNum";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_NewID") == -1)
            {
                append += ";QuickInsert_NewID";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_NewDateTime") == -1)
            {
                append += ";QuickInsert_NewDateTime";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_SameNewID") == -1)
            {
                append += ";QuickInsert_SameNewID";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_RandomStr") == -1)
            {
                append += ";QuickInsert_RandomStr";
            }
            //不为空才更新，否则每次运行都会更新
            if (!string.IsNullOrEmpty(append))
            {
                RWConfig.SetappSettingsValue("QuickInsert", QuickInsert + append, CONFIGPATH);
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
        public static bool SetappSettingsValue(string Key, string Value)
        {
            try
            {
                RWConfig.SetappSettingsValue(Key, Value, CONFIGPATH);
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
        public static bool DelappSettingsValue(string Key)
        {
            try
            {
                if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(Key, CONFIGPATH)))
                {
                    RWConfig.DelappSettingsValue(Key, CONFIGPATH);
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
        public static bool EditappSettingsValue(string Key, string Value)
        {
            try
            {
                if (!string.IsNullOrEmpty(RWConfig.GetappSettingsValue(Key, CONFIGPATH)))
                {
                    RWConfig.SetappSettingsValue(Key, Value, CONFIGPATH);
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
        public static string getConfigValueByKey(string Key)
        {
            string result = RWConfig.GetappSettingsValue(Key, CONFIGPATH);
            return result;
        }
        #endregion
    }
}