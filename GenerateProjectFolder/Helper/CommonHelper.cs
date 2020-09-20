using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProjectFolder.Helper
{
    class CommonHelper
    {
        /// <summary>
        /// /// 获取指定日期，在为一年中为第几周
        /// /// </summary>
        /// /// <param name="dt">指定时间</param>
        /// /// <reutrn>返回第几周</reutrn>
        public static int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }

        /// <summary>
        /// 获取指定日期测试版本号
        /// </summary>
        /// <param name="dt">指定时间，DateTime.Now</param>
        /// <returns>测试版本号，B20xx</returns>
        public static string GetTestVersionNum(DateTime dt)
        {
            string result = null;

            //B2038
            //周数一位数前面补0
            string weekofyear = GetWeekOfYear(dt).ToString();
            if (weekofyear.Length == 1)
            {
                weekofyear = "0" + weekofyear;
            }

            //获取年份后两位
            string year = dt.Year.ToString().Substring(2);

            result = "B" + year + weekofyear;

            return result;
        }
    }
}