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
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        //窗体加载事件
        private void FrmSetting_Load(object sender, EventArgs e)
        {
            //隐藏[模板文件设置]->新增/编辑部分
            groupBox3.Visible = false;

            //加载默认生成路径
            Helper.ConfigHelper.init();
            txtbox_DefaultProjectFolder.Text = Helper.ConfigHelper.getappSettings("DefaultProjectFolder");
        }

        //模板文件设置-刷新按钮单击事件
        private void btn_TemplateFileSetting_Refresh_Click(object sender, EventArgs e)
        {
            //设置dgv大小，以显示[模板文件设置]->新增/编辑部分
            dgv_TemplateFileSetting.Height = 244;
            dgv_TemplateFileSetting.Location = new System.Drawing.Point(6, 123);
            //显示[模板文件设置->新增/编辑部分]
            groupBox3.Visible = true;
        }

        //模板文件设置-[新增/编辑]->取消按钮单击事件
        private void btn_TemplateFileSetting_Cancel_Click(object sender, EventArgs e)
        {
            //设置dgv大小，取消显示[模板文件设置->新增/编辑部分]
            dgv_TemplateFileSetting.Height = 318;
            dgv_TemplateFileSetting.Location = new System.Drawing.Point(6, 49);
            //隐藏[模板文件设置->新增/编辑部分]
            groupBox3.Visible = false;
        }

        //生成路径设置-保存按钮单击事件
        private void btn_DefaultProjectFolder_Save_Click(object sender, EventArgs e)
        {
            string defaultprojectfolder = txtbox_DefaultProjectFolder.Text.Trim();

            //默认生成路径为空
            if (string.IsNullOrEmpty(defaultprojectfolder))
            {
                MessageBox.Show("默认生成路径不能为空！");
                txtbox_DefaultProjectFolder.Focus();
            }
            else
            {
                //修改成功
                if (Helper.ConfigHelper.editappSettings("DefaultProjectFolder", defaultprojectfolder))
                {
                    MessageBox.Show("默认生成路径修改成功！");
                }
            }
        }
    }
}