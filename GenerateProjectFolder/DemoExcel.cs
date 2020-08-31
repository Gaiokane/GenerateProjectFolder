using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;

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
    }
}