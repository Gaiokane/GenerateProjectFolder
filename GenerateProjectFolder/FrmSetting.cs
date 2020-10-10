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
        //模板文件设置-是否点击新增/编辑按钮 0=初始,1=新增,2=编辑
        int TemplateFileSettingBtnStatus = 0;

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

            dgv_TemplateFileSetting.Columns.Add("TemplateFileCode", "模板文件编码");
            dgv_TemplateFileSetting.Columns.Add("TemplateFileName", "模板文件名称");
            dgv_TemplateFileSetting.Columns.Add("TemplateFilePath", "模板文件路径");
            dgv_TemplateFileSetting.Columns.Add("TemplateFileMark", "模板文件备注");

            dgv_TemplateFileSetting.Columns["TemplateFileCode"].Width = 200;
            dgv_TemplateFileSetting.Columns["TemplateFileName"].Width = 200;
            dgv_TemplateFileSetting.Columns["TemplateFilePath"].Width = 500;
            dgv_TemplateFileSetting.Columns["TemplateFileMark"].Width = 100;

            TemplateFileSetting_dgv_init();
        }

        //模板文件设置-加载列表数据
        private void TemplateFileSetting_dgv_init()
        {
            dgv_TemplateFileSetting.Rows.Clear();

            try
            {
                foreach (var item in Helper.ConfigHelper.getappSettingsSplitBySemicolon("TemplateFileList"))
                {
                    string[] TemplateFileList = Helper.ConfigHelper.getappSettingsSplitBySemicolon(item);
                    for (int i = TemplateFileList.Length; i < 3; i++)
                    {
                        List<string> list = TemplateFileList.ToList();
                        list.Add("");
                        TemplateFileList = list.ToArray();
                    }
                    int index = dgv_TemplateFileSetting.Rows.Add();
                    dgv_TemplateFileSetting.Rows[index].Cells["TemplateFileCode"].Value = item;
                    dgv_TemplateFileSetting.Rows[index].Cells["TemplateFileName"].Value = TemplateFileList[0];
                    dgv_TemplateFileSetting.Rows[index].Cells["TemplateFilePath"].Value = TemplateFileList[1];
                    dgv_TemplateFileSetting.Rows[index].Cells["TemplateFileMark"].Value = TemplateFileList[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgv_TemplateFileSetting.ClearSelection();
        }

        //模板文件设置-刷新按钮单击事件
        private void btn_TemplateFileSetting_Refresh_Click(object sender, EventArgs e)
        {
            dgv_TemplateFileSetting.ClearSelection();
        }

        //模板文件设置-新增按钮单击事件
        private void btn_TemplateFileSetting_New_Click(object sender, EventArgs e)
        {
            //设置dgv大小，以显示[模板文件设置]->新增/编辑部分
            dgv_TemplateFileSetting.Height = 244;
            dgv_TemplateFileSetting.Location = new System.Drawing.Point(6, 123);
            //显示[模板文件设置->新增/编辑部分]
            groupBox3.Visible = true;

            //新增操作 文本框置空
            txtbox_TemplateFileSetting_Num.Text = "";
            txtbox_TemplateFileSetting_Name.Text = "";
            txtbox_TemplateFileSetting_Remark.Text = "";
            txtbox_TemplateFileSetting_Path.Text = "";

            //模板文件设置-是否点击新增/编辑按钮 0=初始,1=新增,2=编辑
            TemplateFileSettingBtnStatus = 1;
        }

        //模板文件设置-编辑按钮单击事件
        private void btn_TemplateFileSetting_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_TemplateFileSetting.Rows.Count == 0)
            {
                MessageBox.Show("没有可编辑的记录！");
            }
            else
            {
                if (dgv_TemplateFileSetting.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要编辑的记录！");
                }
                else
                {
                    //设置dgv大小，以显示[模板文件设置]->新增/编辑部分
                    dgv_TemplateFileSetting.Height = 244;
                    dgv_TemplateFileSetting.Location = new System.Drawing.Point(6, 123);
                    //显示[模板文件设置->新增/编辑部分]
                    groupBox3.Visible = true;

                    //编辑操作-文本框取所选行数据
                    txtbox_TemplateFileSetting_Num.Text = "";
                    txtbox_TemplateFileSetting_Name.Text = "";
                    txtbox_TemplateFileSetting_Remark.Text = "";
                    txtbox_TemplateFileSetting_Path.Text = "";

                    //模板文件设置-是否点击新增/编辑按钮 0=初始,1=新增,2=编辑
                    TemplateFileSettingBtnStatus = 2;
                }
            }
        }

        //模板文件设置-删除按钮单击事件
        private void btn_TemplateFileSetting_Del_Click(object sender, EventArgs e)
        {
            if (dgv_TemplateFileSetting.Rows.Count == 0)
            {
                MessageBox.Show("没有可删除的记录！");
            }
            else
            {
                if (dgv_TemplateFileSetting.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要删除的记录！");
                }
                else
                {

                }
            }
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

        //模板文件设置-[新增/编辑]->保存按钮单击事件
        private void btn_TemplateFileSetting_Save_Click(object sender, EventArgs e)
        {
            //模板文件编码
            string num = txtbox_TemplateFileSetting_Num.Text.Trim();
            //模板文件名称
            string name = txtbox_TemplateFileSetting_Name.Text.Trim();
            //模板文件路径
            string path = txtbox_TemplateFileSetting_Path.Text.Trim();
            //模板文件备注
            string remark = txtbox_TemplateFileSetting_Remark.Text.Trim();

            //模板文件编码为空
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("请输入模板文件编码！");
                txtbox_TemplateFileSetting_Num.Focus();
            }
            else
            {
                //模板文件名称为空
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("请输入模板文件名称！");
                    txtbox_TemplateFileSetting_Name.Focus();
                }
                else
                {
                    //模板文件路径为空
                    if (string.IsNullOrEmpty(path))
                    {
                        MessageBox.Show("请输入模板文件路径！");
                        txtbox_TemplateFileSetting_Path.Focus();
                    }
                    else
                    {
                        //模板文件设置-是否点击新增/编辑按钮 0=初始,1=新增,2=编辑
                        //新增
                        if (TemplateFileSettingBtnStatus == 1)
                        {
                            //判断是否有重复值
                        }
                        //编辑
                        if (TemplateFileSettingBtnStatus == 2)
                        {
                            //判断是否有重复值
                        }
                    }
                }
            }
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

        //默认生成路径文本框双击事件，选择默认生成目录
        private void txtbox_DefaultProjectFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtbox_DefaultProjectFolder.Text = fbd.SelectedPath;
                txtbox_DefaultProjectFolder.SelectionStart = txtbox_DefaultProjectFolder.Text.Length;
            }
        }

        //模板文件路径文本框双击事件，选择模板文件
        private void txtbox_TemplateFileSetting_Path_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择模板文件";
            ofd.Filter = "所有文件(*.*)|*.*";
            ofd.InitialDirectory = @"E:\";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtbox_TemplateFileSetting_Path.Text = ofd.FileName;
            }
        }

        //设置该窗口只能打开一个，配合前一窗体中按钮设置
        private static FrmSetting fs = new FrmSetting();
        public static FrmSetting GetFrmSetting()
        {
            if (fs.IsDisposed)
            {
                fs = new FrmSetting();
                return fs;
            }
            else
            {
                return fs;
            }
        }

        //窗体关闭时返回一个DialogResult，前一窗体接收返回值
        private void FrmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}