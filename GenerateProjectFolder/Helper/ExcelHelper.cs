using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProjectFolder.Helper
{
    class ExcelHelper
    {
        /// <summary>
        /// 读取Excel中指定单元格的值
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <param name="sheetIndex">sheet页index，0开始</param>
        /// <param name="row">行，0开始</param>
        /// <param name="cell">列，0开始</param>
        /// <returns>返回单元格值</returns>
        public static string ReadExcelByCell(string filePath, int sheetIndex, int row, int cell)
        {
            string result = "";
            IWorkbook wk = null;
            string extension = System.IO.Path.GetExtension(filePath);
            try
            {
                FileStream fs = File.OpenRead(filePath);
                if (extension.Equals(".xls"))
                {
                    //把xls文件中的数据写入wk中
                    wk = new HSSFWorkbook(fs);
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    wk = new XSSFWorkbook(fs);
                }

                fs.Close();
                //读取当前表数据
                ISheet sheet = wk.GetSheetAt(sheetIndex);
                result = sheet.GetRow(row).GetCell(cell).ToString();
                return result;
            }

            catch (Exception e)
            {
                //只在Debug模式下才输出
                return e.Message;
            }
        }

        /// <summary>
        /// 读取Excel中全部内容
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <param name="sheetIndex">sheet页index，0开始</param>
        /// <returns>返回sheet页内容</returns>
        public static string ReadExcel(string filePath, int sheetIndex)
        {
            string result = "";
            IWorkbook wk = null;
            string extension = System.IO.Path.GetExtension(filePath);
            try
            {
                FileStream fs = File.OpenRead(filePath);
                if (extension.Equals(".xls"))
                {
                    //把xls文件中的数据写入wk中
                    wk = new HSSFWorkbook(fs);
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    wk = new XSSFWorkbook(fs);
                }

                fs.Close();
                //读取当前表数据
                ISheet sheet = wk.GetSheetAt(sheetIndex);

                IRow row = sheet.GetRow(0);  //读取当前行数据
                                             //LastRowNum 是当前表的总行数-1（注意）
                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    row = sheet.GetRow(i);  //读取当前行数据
                    if (row != null)
                    {
                        //LastCellNum 是当前行的总列数
                        for (int j = 0; j < row.LastCellNum; j++)
                        {
                            //读取该行的第j列数据
                            string value = row.GetCell(j).ToString();
                            result += value.ToString() + " ";
                        }
                        result += "\n";
                    }
                }
                return result;
            }

            catch (Exception e)
            {
                //只在Debug模式下才输出
                return e.Message;
            }
        }

        /// <summary>
        /// 修改Excel中指定单元格的值
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <param name="sheetIndex">sheet页index，0开始</param>
        /// <param name="row">行，0开始</param>
        /// <param name="cell">列，0开始</param>
        /// <param name="cellValue">要修改的单元格数据</param>
        /// <returns></returns>
        public static bool ModifyExcelByCell(string filePath, int sheetIndex, int row, int cell, string cellValue)
        {
            IWorkbook wk = null;
            string extension = System.IO.Path.GetExtension(filePath);
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (extension.Equals(".xls"))
                {
                    //把xls文件中的数据写入wk中
                    wk = new HSSFWorkbook(fs);
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    wk = new XSSFWorkbook(fs);
                }

                fs.Close();

                //修改指定单元格数据
                wk.GetSheetAt(sheetIndex).GetRow(row).GetCell(cell).SetCellValue(cellValue);

                MemoryStream ms = new MemoryStream();
                wk.Write(ms);
                SaveToFile(ms, filePath);

                return true;
            }

            catch (Exception e)
            {
                return false;
                //return e.Message;
            }
        }

        /// <summary>
        /// 保存到文件，如果已存在，则覆盖，否则新建
        /// </summary>
        /// <param name="ms">MemoryStream流</param>
        /// <param name="fileName">文件路径</param>
        static void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                data = null;
            }
        }
    }
}