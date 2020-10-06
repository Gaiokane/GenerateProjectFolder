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

            textBox2.Width = 300;
            textBox2.Text = @"E:\codecreatefile.txt";
            button3.Text = "新建文件";

            button4.Text = "复制文件";

            button5.Text = "新建目录";

            button6.Width = 100;
            button6.Text = "移动文件/目录";

            button7.Text = "FrmMain";

            button8.Text = "当前第几周";

            button9.Text = "创建快捷方式";
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
            MessageBox.Show(ReadExcelByCell(textBox1.Text, 0, 7, 2));
            ModifyExcelByCell(textBox1.Text, 0, 7, 2, "hhh使用NPOI写入123");
            MessageBox.Show(ReadExcelByCell(textBox1.Text, 0, 7, 2));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("不能为空");
                textBox2.Focus();
            }
            else
            {
                CreateNewFile(textBox2.Text, "123\n321");
                MessageBox.Show("OK");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CopyFileTo(@"E:\新建 Microsoft Excel 工作表.xls", @"E:\新建 Microsoft Excel 工作表1.xls");
            MessageBox.Show("OK");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (IsDirectoryExists(textBox2.Text) || IsFileExists(textBox2.Text))
            {
                MessageBox.Show("同名文件或目录已存在");
            }
            else
            {
                CreateNewDirectory(textBox2.Text);
                MessageBox.Show("OK");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MoveFileTo(@"E:\write1.xlsx", @"E:\write.xlsx");
        }

        /// <summary>
        /// 读取Excel中指定单元格的值
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <param name="sheetIndex">sheet页index，0开始</param>
        /// <param name="row">行，0开始</param>
        /// <param name="cell">列，0开始</param>
        /// <returns>返回单元格值</returns>
        public string ReadExcelByCell(string filePath, int sheetIndex, int row, int cell)
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
        public string ReadExcel(string filePath, int sheetIndex)
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
        public string ModifyExcelByCell(string filePath, int sheetIndex, int row, int cell, string cellValue)
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
                SaveToFile(ms, textBox1.Text);

                return "true";
            }

            catch (Exception e)
            {
                return e.Message;
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

        /// <summary>
        /// 新建文件并写入内容，如果已存在，则覆盖
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="content">文件内容</param>
        static void CreateNewFile(string fileName, string content)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content);
                sw.Close();
            }
        }

        /// <summary>
        /// 复制文件，如果目标路径已存在同名文件，则覆盖，否则新建
        /// </summary>
        /// <param name="source">源文件路径</param>
        /// <param name="dest">目标文件路径</param>
        static void CopyFileTo(string source, string dest)
        {
            if (File.Exists(source))//必须判断要复制的文件是否存在
            {
                if (IsFileInUsed(source) == false)
                {
                    File.Copy(source, dest, true);//三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
                }
                else
                {
                    MessageBox.Show("所选文件被占用，无法复制");
                }
            }
        }

        /// <summary>
        /// 移动文件/目录
        /// </summary>
        /// <param name="source">源路径</param>
        /// <param name="dest">目标路径</param>
        static void MoveFileTo(string source, string dest)
        {
            if (File.Exists(source))
            {
                if (IsFileInUsed(source) == false)
                {
                    File.Move(source, dest);
                }
                else
                {
                    MessageBox.Show("所选文件被占用，无法移动");
                }
            }
            else if (Directory.Exists(source))
            {
                try
                {
                    Directory.Move(source, dest);
                }
                catch
                {
                    MessageBox.Show("所选文件夹被占用，无法移动");
                }
            }
            else
            {
                MessageBox.Show("所选文件/文件夹不存在");
            }
        }

        /// <summary>
        /// 判断指定文件是否在使用
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>true, false</returns>
        public static bool IsFileInUsed(string fileName)
        {
            bool inUse = true;
            if (File.Exists(fileName))
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    inUse = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                return inUse;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断指定文件是否存在
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>true, false</returns>
        public bool IsFileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        /// <summary>
        /// 判断指定目录是否存在
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>true, false</returns>
        public bool IsDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// 新建目录，如果已存在，则不进行操作
        /// </summary>
        /// <param name="path">目录路径</param>
        public void CreateNewDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmMain fm = new FrmMain();
            fm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //获取指定日期，在为一年中为第几周
            //MessageBox.Show(Helper.CommonHelper.GetWeekOfYear(DateTime.Now).ToString());

            //周数1位数
            //DateTime dt = Convert.ToDateTime("2020-01-01 11:11:11");
            //MessageBox.Show(Helper.CommonHelper.GetWeekOfYear(dt).ToString());

            //获取年份后两位
            //DateTime dt = Convert.ToDateTime("2021-01-01 11:11:11");
            //MessageBox.Show(dt.Year.ToString().Substring(2));

            //DateTime dt = Convert.ToDateTime("2021-01-01 11:11:11");
            DateTime dt = DateTime.Now;
            MessageBox.Show(Helper.CommonHelper.GetTestVersionNum(dt));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Helper.FileHelper.CreateShortcutOnDesktop("test123qqq", @"E:\2020\123qqq");
        }
    }
}