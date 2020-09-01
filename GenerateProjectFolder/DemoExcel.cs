using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace GenerateProjectFolder
{
    public partial class DemoExcel : Form
    {
        public DemoExcel()
        {
            InitializeComponent();
        }

        private void DemoExcel_Load(object sender, EventArgs e)
        {
            label1.Text = "Excel文件路径";
            textBox1.Width = 300;
            textBox1.Text = @"E:\新建 Microsoft Excel 工作表.xlsx";
            button1.Text = "使用Aspose";
            button2.Text = "使用NPOI";
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择Excel文件";
            ofd.Filter = "Excel文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("不能为空");
                textBox1.Focus();
            }
            else
            {
                Workbook workbook = new Workbook(textBox1.Text);
                MessageBox.Show("打开成功");

                Worksheet worksheet = workbook.Worksheets[0];

                //读数据
                Cell cell = worksheet.Cells[7, 2];
                MessageBox.Show("[7, 2]：" + cell.Value.ToString());

                //写数据
                worksheet.Cells["C8"].PutValue("this is c8");
                cell = worksheet.Cells["C8"];
                MessageBox.Show("[C8]：" + cell.Value.ToString());

                workbook.Save(textBox1.Text);
                MessageBox.Show("保存成功");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //WriteToExcel(@"E:\write.xlsx");
            //MessageBox.Show(ReadFromExcelFile(textBox1.Text, 0));
            MessageBox.Show(ReadFromExcelFileByCell(textBox1.Text, 0, 7, 2));
            WriteToExcelByCell(textBox1.Text, 0, 7, 2, "使用NPOI写入");
            MessageBox.Show(ReadFromExcelFileByCell(textBox1.Text, 0, 7, 2));
        }

        /// <summary>
        /// 读取Excel中指定单元格的值
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <param name="sheetIndex">sheet页index，0开始</param>
        /// <param name="row">行，0开始</param>
        /// <param name="cell">列，0开始</param>
        /// <returns>返回单元格值</returns>
        public string ReadFromExcelFileByCell(string filePath, int sheetIndex, int row, int cell)
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
        public string ReadFromExcelFile(string filePath, int sheetIndex)
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

        public static void SetCellValue(ICell cell, object obj)
        {
            if (obj.GetType() == typeof(int))
            {
                cell.SetCellValue((int)obj);
            }
            else if (obj.GetType() == typeof(double))
            {
                cell.SetCellValue((double)obj);
            }
            else if (obj.GetType() == typeof(IRichTextString))
            {
                cell.SetCellValue((IRichTextString)obj);
            }
            else if (obj.GetType() == typeof(string))
            {
                cell.SetCellValue(obj.ToString());
            }
            else if (obj.GetType() == typeof(DateTime))
            {
                cell.SetCellValue((DateTime)obj);
            }
            else if (obj.GetType() == typeof(bool))
            {
                cell.SetCellValue((bool)obj);
            }
            else
            {
                cell.SetCellValue(obj.ToString());
            }
        }

        public string WriteToExcelByCell(string filePath, int sheetIndex, int row, int cell, string cellValue)
        {
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
                ICell icell = sheet.GetRow(row).GetCell(cell);
                SetCellValue(icell, cellValue);
                //MessageBox.Show(sheet.GetRow(row).GetCell(cell).ToString());

                try
                {
                    /*FileStream fswrite = File.OpenWrite(filePath);
                    wk.Write(fswrite);//向打开的这个Excel文件中写入表单并保存。
                    fswrite.Close();*/


                    /*
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    wk.Write(ms);
                    ms.Flush();
                    ms.Position = 0;//流位置归零

                    saveTofle(ms, filePath);*/

                    /*
                    //Write the stream data of workbook to the root directory
                    FileStream file = new FileStream(filePath, FileMode.Create);
                    wk.Write(file);
                    file.Close();*/

                    //Write the stream data of workbook to the root directory
                    MemoryStream ms = new System.IO.MemoryStream();
                    wk.Write(ms);
                    ms.Flush();
                    ms.Position = 0;
                    SaveToFile(ms, filePath);
                    /*byte[] o = ms.ToArray();

                    FileStream file = new FileStream(filePath, FileMode.Create);
                    file.Write(o, 0, o.Length);
                    file.Close();*/

                    /*
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    wk.Write(ms);
                    FileStream files = new FileStream(filePath, FileMode.Create);
                    //files.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    byte[] o = ms.ToArray();

                    files.Write(o, 0, o.ToString().Length);
                    files.Close();*/



                    /*
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        wk.Write(ms);
                        using (FileStream fss = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        {
                            byte[] d = ms.ToArray();
                            fss.Write(d, 0, d.Length);
                            fss.Flush();
                        }
                        wk = null;
                    }*/

                    /*
                    FileStream fss = new FileStream(filePath, FileMode.Create);
                    wk.Write(fss);
                    fss.Close();
                    wk = null;*/


                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            catch (Exception e)
            {
                //只在Debug模式下才输出
                return e.Message;
            }




            /*
            //创建工作薄  
            IWorkbook wb;
            string extension = System.IO.Path.GetExtension(filePath);
            //根据指定的文件格式创建对应的类
            if (extension.Equals(".xls"))
            {
                wb = new HSSFWorkbook();
            }
            else
            {
                wb = new XSSFWorkbook();
            }

            //创建一个表单
            ISheet sheet = wb.CreateSheet("Sheet0");
            //设置列宽
            int[] columnWidth = { 10, 10, 20, 10 };
            for (int i = 0; i < columnWidth.Length; i++)
            {
                //设置列宽度，256*字符数，因为单位是1/256个字符
                sheet.SetColumnWidth(i, 256 * columnWidth[i]);
            }

            //测试数据
            int rowCount = 3, columnCount = 4;
            object[,] data = {
        {"列0", "列1", "列2", "列3"},
        {"", 400, 5.2, 6.01},
        {"", true, "2014-07-02", DateTime.Now}
        //日期可以直接传字符串，NPOI会自动识别
        //如果是DateTime类型，则要设置CellStyle.DataFormat，否则会显示为数字
    };

            IRow row;
            ICell cell;

            for (int i = 0; i < rowCount; i++)
            {
                row = sheet.CreateRow(i);//创建第i行
                for (int j = 0; j < columnCount; j++)
                {
                    cell = row.CreateCell(j);//创建第j列
                    cell.CellStyle = j % 2 == 0 ? style1 : style2;
                    //根据数据类型设置不同类型的cell
                    object obj = data[i, j];
                    SetCellValue(cell, data[i, j]);
                    //如果是日期，则设置日期显示的格式
                    if (obj.GetType() == typeof(DateTime))
                    {
                        cell.CellStyle = dateStyle;
                    }
                    //如果要根据内容自动调整列宽，需要先setCellValue再调用
                    //sheet.AutoSizeColumn(j);
                }
            }

            //合并单元格，如果要合并的单元格中都有数据，只会保留左上角的
            //CellRangeAddress(0, 2, 0, 0)，合并0-2行，0-0列的单元格
            CellRangeAddress region = new CellRangeAddress(0, 2, 0, 0);
            sheet.AddMergedRegion(region);

            try
            {
                FileStream fs = File.OpenWrite(filePath);
                wb.Write(fs);//向打开的这个Excel文件中写入表单并保存。  
                fs.Close();
                return "true";
            }
            catch (Exception e)
            {
                return e.Message;
            }*/
        }

        private void saveTofle(MemoryStream file, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = file.ToArray();//转化为byte格式存储
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                buffer = null;
            }//使用using可以最后不用关闭fs 比较方便
        }

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

        public string WriteToExcel(string filePath)
        {
            //创建工作薄  
            IWorkbook wb;
            string extension = System.IO.Path.GetExtension(filePath);
            //根据指定的文件格式创建对应的类
            if (extension.Equals(".xls"))
            {
                wb = new HSSFWorkbook();
            }
            else
            {
                wb = new XSSFWorkbook();
            }

            ICellStyle style1 = wb.CreateCellStyle();//样式
            style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;//文字水平对齐方式
            style1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//文字垂直对齐方式
                                                                                  //设置边框
            style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style1.WrapText = true;//自动换行

            ICellStyle style2 = wb.CreateCellStyle();//样式
            IFont font1 = wb.CreateFont();//字体
            font1.FontName = "楷体";
            font1.Color = HSSFColor.Red.Index;//字体颜色
            font1.Boldweight = (short)FontBoldWeight.Normal;//字体加粗样式
            style2.SetFont(font1);//样式里的字体设置具体的字体样式
                                  //设置背景色
            style2.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            style2.FillPattern = FillPattern.SolidForeground;
            style2.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            style2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;//文字水平对齐方式
            style2.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//文字垂直对齐方式

            ICellStyle dateStyle = wb.CreateCellStyle();//样式
            dateStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;//文字水平对齐方式
            dateStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//文字垂直对齐方式
                                                                                     //设置数据显示格式
            IDataFormat dataFormatCustom = wb.CreateDataFormat();
            dateStyle.DataFormat = dataFormatCustom.GetFormat("yyyy-MM-dd HH:mm:ss");

            //创建一个表单
            ISheet sheet = wb.CreateSheet("Sheet0");
            //设置列宽
            int[] columnWidth = { 10, 10, 20, 10 };
            for (int i = 0; i < columnWidth.Length; i++)
            {
                //设置列宽度，256*字符数，因为单位是1/256个字符
                sheet.SetColumnWidth(i, 256 * columnWidth[i]);
            }

            //测试数据
            int rowCount = 3, columnCount = 4;
            object[,] data = {
        {"列0", "列1", "列2", "列3"},
        {"", 400, 5.2, 6.01},
        {"", true, "2014-07-02", DateTime.Now}
        //日期可以直接传字符串，NPOI会自动识别
        //如果是DateTime类型，则要设置CellStyle.DataFormat，否则会显示为数字
    };

            IRow row;
            ICell cell;

            for (int i = 0; i < rowCount; i++)
            {
                row = sheet.CreateRow(i);//创建第i行
                for (int j = 0; j < columnCount; j++)
                {
                    cell = row.CreateCell(j);//创建第j列
                    cell.CellStyle = j % 2 == 0 ? style1 : style2;
                    //根据数据类型设置不同类型的cell
                    object obj = data[i, j];
                    SetCellValue(cell, data[i, j]);
                    //如果是日期，则设置日期显示的格式
                    if (obj.GetType() == typeof(DateTime))
                    {
                        cell.CellStyle = dateStyle;
                    }
                    //如果要根据内容自动调整列宽，需要先setCellValue再调用
                    //sheet.AutoSizeColumn(j);
                }
            }

            //合并单元格，如果要合并的单元格中都有数据，只会保留左上角的
            //CellRangeAddress(0, 2, 0, 0)，合并0-2行，0-0列的单元格
            CellRangeAddress region = new CellRangeAddress(0, 2, 0, 0);
            sheet.AddMergedRegion(region);

            try
            {
                FileStream fs = File.OpenWrite(filePath);
                wb.Write(fs);//向打开的这个Excel文件中写入表单并保存。  
                fs.Close();
                return "true";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}