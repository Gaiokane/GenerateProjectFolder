using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateProjectFolder
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //窗体加载事件
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Helper.ConfigHelper.init();
            txtbox_GenerateTo.Text = Helper.ConfigHelper.getappSettings("DefaultProjectFolder");
            txtbox_ProjectNum.Select();
        }

        //生成按钮单击事件
        private void btn_Generate_Click(object sender, EventArgs e)
        {
            string generateto = txtbox_GenerateTo.Text.Trim();
            string projectnum = txtbox_ProjectNum.Text.Trim();
            string projectname = txtbox_ProjectName.Text.Trim();
            string projectabbreviation = txtbox_ProjectAbbreviation.Text.Trim();

            //生成至为空
            if (string.IsNullOrEmpty(generateto))
            {
                MessageBox.Show("生成至不能为空！");
                txtbox_GenerateTo.Focus();
            }
            else
            {
                //项目编号为空
                if (string.IsNullOrEmpty(projectnum))
                {
                    MessageBox.Show("项目编号不能为空！");
                    txtbox_ProjectNum.Focus();
                }
                else
                {
                    //项目名称为空
                    if (string.IsNullOrEmpty(projectname))
                    {
                        MessageBox.Show("项目名称不能为空！");
                        txtbox_ProjectName.Focus();
                    }
                    else
                    {
                        //只有项目简称为空
                        if (string.IsNullOrEmpty(projectabbreviation))
                        {
                            projectabbreviation = projectname;
                        }

                        //判空结束
                        //MessageBox.Show("判空结束" + projectabbreviation);
                        if (ProjectFilesConfig.init(generateto, projectnum, projectname, projectabbreviation))
                        {
                            if (MessageBox.Show("是否打开？", "text", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                System.Diagnostics.Process.Start(generateto + @"\" + projectnum + projectname);
                            }
                        }
                        else
                        {
                            MessageBox.Show("生成失败！");
                        }
                    }
                }
            }
        }

        //设置按钮单击事件
        private void btn_Setting_Click(object sender, EventArgs e)
        {
            //设置只能打开一个，配合窗体中中的Get窗体名()设置
            FrmSetting.GetFrmSetting().Activate();

            //接收窗体FormClosed事件返回的DialogResult，执行相应操作
            FrmSetting fs = new FrmSetting();
            if (fs.ShowDialog() == DialogResult.OK)
            {
                txtbox_GenerateTo.Text = Helper.ConfigHelper.getappSettings("DefaultProjectFolder");
            }
        }

        //生成至文本框双击事件，选择生成至目录
        private void txtbox_GenerateTo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtbox_GenerateTo.Text = fbd.SelectedPath;
                txtbox_GenerateTo.SelectionStart = txtbox_GenerateTo.Text.Length;
            }
        }

        //打开DemoExcel测试功能窗体
        private void btn_Test_Click(object sender, EventArgs e)
        {
            DemoExcel de = new DemoExcel();
            de.Show();
        }
    }
}