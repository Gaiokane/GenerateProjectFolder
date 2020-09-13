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
            QuickInsert = getappSettings("QuickInsert");
            QuickInsert_IDIncrement = getappSettings("QuickInsert_IDIncrement");
            QuickInsert_RandomNum = getappSettings("QuickInsert_RandomNum");
            QuickInsert_NewID = getappSettings("QuickInsert_NewID");
            QuickInsert_NewDateTime = getappSettings("QuickInsert_NewDateTime");
            QuickInsert_SameNewID = getappSettings("QuickInsert_SameNewID");
            QuickInsert_RandomStr = getappSettings("QuickInsert_RandomStr");
        }
        #endregion

        #region 如果配置文件中有缺失默认键，则新增
        /// <summary>
        /// 如果配置文件中有缺失默认键，则新增
        /// </summary>
        public static void setDefaultSettingsIfIsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(QuickInsert))
            {
                addappSettings("QuickInsert", "QuickInsert_IDIncrement;QuickInsert_RandomNum;QuickInsert_NewID;QuickInsert_NewDateTime;QuickInsert_SameNewID");
            }
            if (string.IsNullOrEmpty(QuickInsert_IDIncrement))
            {
                addappSettings("QuickInsert_IDIncrement", "指定id递增;{{id:x}};x替换为开始的序号，从x开始生成（包含x）");
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomNum))
            {
                addappSettings("QuickInsert_RandomNum", "指定范围随机数;{{[1-2]}};-左边开始&#xA;-右边结束&#xA;不带小数点生成的随机数也不带");
            }
            if (string.IsNullOrEmpty(QuickInsert_NewID))
            {
                addappSettings("QuickInsert_NewID", "生成newid/uuid;{{newid}};有匹配项就替换为新uuid");
            }
            if (string.IsNullOrEmpty(QuickInsert_NewDateTime))
            {
                addappSettings("QuickInsert_NewDateTime", "指定时间递增;{{timed+x:yyyy-MM-dd HH:mm:ss}};+左边为时间类型（d|h|m|s 对应 日|时|分|秒）&#xA;+右边为递增/递减值");
            }
            if (string.IsNullOrEmpty(QuickInsert_SameNewID))
            {
                addappSettings("QuickInsert_SameNewID", "生成相同newid/uuid;{{samenewid}};一次执行多条sql，使用相同uuid");
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomStr))
            {
                addappSettings("QuickInsert_RandomStr", "在指定元素中随机选择一项;{{[x；y；z...]}};x、y、z为指定元素，\n能在元素中随机选择一项，\n请将；换成英文分号");
            }

            #region (已注释)快捷插入中缺失默认配置会自动新增
            /*
                getAllDefaultSettings();
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
                    SetappSettingsValue("QuickInsert", QuickInsert + append);
                }
                */
            #endregion
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