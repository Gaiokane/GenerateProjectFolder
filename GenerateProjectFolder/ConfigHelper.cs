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
        public static string CommonlyUsedSQL, CommonlyUsedSQL_Default;
        public static string ConfigPath = "./InsertDataInBatches.exe";

        #region 获取配置文件中快捷插入配置
        /// <summary>
        /// 获取配置文件中快捷插入配置
        /// </summary>
        public static void getQuickInsertSettingsByappSettings()
        {
            QuickInsert = RWConfig.GetappSettingsValue("QuickInsert", ConfigPath);
            QuickInsert_IDIncrement = RWConfig.GetappSettingsValue("QuickInsert_IDIncrement", ConfigPath);
            QuickInsert_RandomNum = RWConfig.GetappSettingsValue("QuickInsert_RandomNum", ConfigPath);
            QuickInsert_NewID = RWConfig.GetappSettingsValue("QuickInsert_NewID", ConfigPath);
            QuickInsert_NewDateTime = RWConfig.GetappSettingsValue("QuickInsert_NewDateTime", ConfigPath);
            QuickInsert_SameNewID = RWConfig.GetappSettingsValue("QuickInsert_SameNewID", ConfigPath);
            QuickInsert_RandomStr = RWConfig.GetappSettingsValue("QuickInsert_RandomStr", ConfigPath);
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
                RWConfig.SetappSettingsValue("QuickInsert", "QuickInsert_IDIncrement;QuickInsert_RandomNum;QuickInsert_NewID;QuickInsert_NewDateTime;QuickInsert_SameNewID", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_IDIncrement))
            {
                RWConfig.SetappSettingsValue("QuickInsert_IDIncrement", "指定id递增;{{id:x}};x替换为开始的序号，从x开始生成（包含x）", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomNum))
            {
                RWConfig.SetappSettingsValue("QuickInsert_RandomNum", "指定范围随机数;{{[1-2]}};-左边开始&#xA;-右边结束&#xA;不带小数点生成的随机数也不带", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_NewID))
            {
                RWConfig.SetappSettingsValue("QuickInsert_NewID", "生成newid/uuid;{{newid}};有匹配项就替换为新uuid", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_NewDateTime))
            {
                RWConfig.SetappSettingsValue("QuickInsert_NewDateTime", "指定时间递增;{{timed+x:yyyy-MM-dd HH:mm:ss}};+左边为时间类型（d|h|m|s 对应 日|时|分|秒）&#xA;+右边为递增/递减值", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_SameNewID))
            {
                RWConfig.SetappSettingsValue("QuickInsert_SameNewID", "生成相同newid/uuid;{{samenewid}};一次执行多条sql，使用相同uuid", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomStr))
            {
                RWConfig.SetappSettingsValue("QuickInsert_RandomStr", "在指定元素中随机选择一项;{{[x；y；z...]}};x、y、z为指定元素，\n能在元素中随机选择一项，\n请将；换成英文分号", ConfigPath);
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
                RWConfig.SetappSettingsValue("QuickInsert", QuickInsert + append, ConfigPath);
            }
        }
        #endregion

        #region 新增快捷插入配置
        /// <summary>
        /// 新增快捷插入配置
        /// </summary>
        /// <param name="Code">快捷插入配置编码</param>
        /// <param name="Name">快捷插入配置名称</param>
        /// <param name="Value">快捷插入配置值</param>
        /// <returns>string：新增成功/新增失败/新增项已存在，新增失败/报错信息</returns>
        public static string setQuickInsertModelCodeNameValue(string Code, string Name, string Value, string Instruction)
        {
            try
            {
                if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value) || string.IsNullOrEmpty(Instruction))
                {
                    return "快捷插入配置编码/名称/值/使用说明不能为空！";
                }
                else
                {
                    string[] str = getQuickInsertSettingsAllCodes();
                    foreach (var item in str)
                    {
                        if (item == Code)
                        {
                            return "在快捷插入配置编码中已存在相同编码，请确认！";
                        }
                    }

                    str = getCommonlyUsedSQLAllCodes();
                    foreach (var item in str)
                    {
                        if (item == Code)
                        {
                            return "在常用SQL配置编码中已存在相同编码，请确认！";
                        }
                    }

                    QuickInsert = RWConfig.GetappSettingsValue("QuickInsert", ConfigPath);
                    RWConfig.SetappSettingsValue(Code, Name + ";" + Value + ";" + Instruction, ConfigPath);
                    RWConfig.SetappSettingsValue("QuickInsert", QuickInsert + ";" + Code, ConfigPath);
                    return "新增成功";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 修改快捷插入配置
        /// <summary>
        /// 修改快捷插入配置
        /// </summary>
        /// <param name="Code">快捷插入配置编码</param>
        /// <param name="Name">快捷插入配置名称</param>
        /// <param name="Value">快捷插入配置值</param>
        /// <returns>string：修改成功/修改失败/报错信息</returns>
        public static string editQuickInsertModelCodeNameValue(string Code, string Name, string Value, string Instruction)
        {
            try
            {
                if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value) || string.IsNullOrEmpty(Instruction))
                {
                    return "快捷插入配置编码/名称/值/使用说明不能为空！";
                }
                else
                {

                    RWConfig.SetappSettingsValue(Code, Name + ";" + Value + ";" + Instruction, ConfigPath);
                    return "修改成功";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 如果配置文件中无常用SQL配置，则新建配置，值默认
        /// <summary>
        /// 如果配置文件中无常用SQL配置，则新建配置，值默认
        /// </summary>
        public static void setDefaultCommonlyUsedSQLIfIsNullOrEmptyByappSettings()
        {
            if (string.IsNullOrEmpty(CommonlyUsedSQL))
            {
                RWConfig.SetappSettingsValue("CommonlyUsedSQL", "CommonlyUsedSQL_Default", ConfigPath);
            }
            if (string.IsNullOrEmpty(CommonlyUsedSQL_Default))
            {
                RWConfig.SetappSettingsValue("CommonlyUsedSQL_Default", "常用SQL名;select * from xxx", ConfigPath);
            }
        }
        #endregion

        #region 根据常用SQL编码删除常用SQL
        /// <summary>
        /// 根据常用SQL编码删除常用SQL
        /// </summary>
        /// <param name="CommonlyUsedSQLCode">常用SQL编码</param>
        /// <returns>string：删除成功/删除失败/没有匹配项/报错信息</returns>
        public static string delCommonlyUsedSQLCodeNameValue(string CommonlyUsedSQLCode)
        {
            try
            {
                string[] str = getCommonlyUsedSQLAllCodes();
                foreach (var item in str)
                {
                    if (item == CommonlyUsedSQLCode)
                    {
                        if (RWConfig.DelappSettingsValue(CommonlyUsedSQLCode, ConfigPath) == true)
                        {
                            List<string> list = str.ToList();
                            list.Remove(item);
                            str = list.ToArray();
                            string result = String.Join(";", str);
                            RWConfig.SetappSettingsValue("CommonlyUsedSQL", result, ConfigPath);
                            return CommonlyUsedSQLCode + " 删除成功！";
                        }
                        else
                        {
                            return CommonlyUsedSQLCode + " 删除失败！";
                        }
                    }
                }
                return "没有匹配项！";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 根据配置文件中的Key获取对应Value
        /// <summary>
        /// 根据配置文件中的Key获取对应Value
        /// </summary>
        /// <param name="ConfigKey">配置文件中的Key</param>
        /// <returns>返回Key对应Value，数组</returns>
        public static string[] getConfigValueByKey(string ConfigKey)
        {
            string[] result = { };
            string str = RWConfig.GetappSettingsValue(ConfigKey, ConfigPath);
            result = str.Split(';');
            return result;
        }
        #endregion

        /// <summary>
        #region 获取指定Key下Value中匹配字符串数量
        /// 获取指定Key下Value中匹配字符串数量
        /// </summary>
        /// <param name="ConfigKey">配置文件中的Key</param>
        /// <param name="Value">需要判断的Value</param>
        /// <returns>匹配数量</returns>
        public static int getSameValueLenth(string ConfigKey, string Value)
        {
            int n = 0;//计数
            string[] result = getConfigValueByKey(ConfigKey);
            foreach (var item in result)
            {
                if (Value == item)
                {
                    n += 1;
                }
            }
            return n;
        }
        #endregion
    }
}