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
            //读取配置文件中默认配置
            txtbox_DefaultProjectFolder.Text = Helper.ConfigHelper.getappSettings("DefaultProjectFolder");

            //模板文件设置-dgv默认4列列名
            dgv_TemplateFileSetting.Columns.Add("TemplateFileNum", "模板文件编码");
            dgv_TemplateFileSetting.Columns.Add("TemplateFileName", "模板文件名称");
            dgv_TemplateFileSetting.Columns.Add("TemplateFilePath", "模板文件路径");
            dgv_TemplateFileSetting.Columns.Add("TemplateFileMark", "模板文件备注");

            //模板文件设置-dgv默认4列宽度
            dgv_TemplateFileSetting.Columns["TemplateFileNum"].Width = 200;
            dgv_TemplateFileSetting.Columns["TemplateFileName"].Width = 200;
            dgv_TemplateFileSetting.Columns["TemplateFilePath"].Width = 500;
            dgv_TemplateFileSetting.Columns["TemplateFileMark"].Width = 100;

            //模板文件设置-dgv读取配置数据
            TemplateFileSetting_dgv_init();
        }

        /// <summary>
        /// 模板文件设置-加载列表数据
        /// </summary>
        private void TemplateFileSetting_dgv_init()
        {
            //清空所有行
            dgv_TemplateFileSetting.Rows.Clear();

            try
            {
                //读取模板文件列表名，并循环读取对应的信息
                foreach (var item in Helper.ConfigHelper.getappSettingsSplitBySemicolon("TemplateFileList"))
                {
                    string[] TemplateFileList = Helper.ConfigHelper.getappSettingsSplitBySemicolon(item);
                    //当前只有三项，模板文件名称、路径、备注
                    for (int i = TemplateFileList.Length; i < 3; i++)
                    {
                        List<string> list = TemplateFileList.ToList();
                        list.Add("");
                        TemplateFileList = list.ToArray();
                    }
                    int index = dgv_TemplateFileSetting.Rows.Add();
                    //对每列赋值
                    dgv_TemplateFileSetting.Rows[index].Cells["TemplateFileNum"].Value = item;
                    dgv_TemplateFileSetting.Rows[index].Cells["TemplateFileName"].Value = TemplateFileList[0];
                    dgv_TemplateFileSetting.Rows[index].Cells["TemplateFilePath"].Value = TemplateFileList[1];
                    dgv_TemplateFileSetting.Rows[index].Cells["TemplateFileMark"].Value = TemplateFileList[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //清除所选行
            dgv_TemplateFileSetting.ClearSelection();
        }

        /// <summary>
        /// 模板文件设置-文本框置空
        /// </summary>
        private void ClearTemplateFileSettingTextBox()
        {
            txtbox_TemplateFileSetting_Num.Text = "";
            txtbox_TemplateFileSetting_Name.Text = "";
            txtbox_TemplateFileSetting_Path.Text = "";
            txtbox_TemplateFileSetting_Remark.Text = "";
        }

        /// <summary>
        /// 模板文件设置-按钮统一状态
        /// </summary>
        /// <param name="Enable">true/false</param>
        private void SetTemplateFileSettingButtonEnable(bool Enable)
        {
            btn_TemplateFileSetting_Refresh.Enabled = Enable;
            btn_TemplateFileSetting_New.Enabled = Enable;
            btn_TemplateFileSetting_Edit.Enabled = Enable;
            btn_TemplateFileSetting_Del.Enabled = Enable;
        }

        //模板文件设置-刷新按钮单击事件
        private void btn_TemplateFileSetting_Refresh_Click(object sender, EventArgs e)
        {
            //模板文件设置-dgv读取配置数据
            TemplateFileSetting_dgv_init();
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
            ClearTemplateFileSettingTextBox();
            //模板文件编码文本框可编辑状态，若上一次点击编辑，则只读
            txtbox_TemplateFileSetting_Num.ReadOnly = false;

            //模板文件设置-是否点击新增/编辑按钮 0=初始,1=新增,2=编辑
            TemplateFileSettingBtnStatus = 1;

            //模板文件设置-按钮统一状态为无法点击
            SetTemplateFileSettingButtonEnable(false);
        }

        //模板文件设置-编辑按钮单击事件
        private void btn_TemplateFileSetting_Edit_Click(object sender, EventArgs e)
        {
            //dgv中无数据
            if (dgv_TemplateFileSetting.Rows.Count == 0)
            {
                MessageBox.Show("没有可编辑的记录！");
            }
            else
            {
                //dgv中未选中行
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
                    txtbox_TemplateFileSetting_Num.Text = dgv_TemplateFileSetting.SelectedCells[0].Value.ToString();
                    txtbox_TemplateFileSetting_Name.Text = dgv_TemplateFileSetting.SelectedCells[1].Value.ToString();
                    txtbox_TemplateFileSetting_Path.Text = dgv_TemplateFileSetting.SelectedCells[2].Value.ToString();
                    txtbox_TemplateFileSetting_Remark.Text = dgv_TemplateFileSetting.SelectedCells[3].Value.ToString();

                    //模板文件编码文本框不可编辑状态，只有新增时可以编辑
                    txtbox_TemplateFileSetting_Num.ReadOnly = true;

                    //模板文件设置-是否点击新增/编辑按钮 0=初始,1=新增,2=编辑
                    TemplateFileSettingBtnStatus = 2;

                    //模板文件设置-按钮统一状态为无法点击
                    SetTemplateFileSettingButtonEnable(false);
                }
            }
        }

        //模板文件设置-删除按钮单击事件
        private void btn_TemplateFileSetting_Del_Click(object sender, EventArgs e)
        {
            //dgv中无数据
            if (dgv_TemplateFileSetting.Rows.Count == 0)
            {
                MessageBox.Show("没有可删除的记录！");
            }
            else
            {
                //dgv中未选中行
                if (dgv_TemplateFileSetting.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要删除的记录！");
                }
                else
                {
                    string TemplateFileNum = dgv_TemplateFileSetting.SelectedCells[0].Value.ToString();
                    string TemplateFileName = dgv_TemplateFileSetting.SelectedCells[1].Value.ToString();

                    //确定删除
                    if (DialogResult.OK == MessageBox.Show("确认删除：" + TemplateFileName + "？", "提示？", MessageBoxButtons.OKCancel))
                    {
                        try
                        {
                            //先去模板文件列表中找是否有指定编码
                            string[] str = Helper.ConfigHelper.getappSettingsSplitBySemicolon("TemplateFileList");
                            foreach (var item in str)
                            {
                                //有所选记录对应编码
                                if (item == TemplateFileNum)
                                {
                                    //删除模板文件配置
                                    if (Helper.ConfigHelper.delappSettings(TemplateFileNum) == true)
                                    {
                                        //删除模板文件列表中对应编码
                                        List<string> list = str.ToList();
                                        list.Remove(item);
                                        str = list.ToArray();
                                        string result = String.Join(";", str);
                                        Helper.ConfigHelper.editappSettings("TemplateFileList", result);
                                        MessageBox.Show(TemplateFileName + "已删除");
                                        //模板文件设置-dgv读取配置数据
                                        TemplateFileSetting_dgv_init();
                                    }
                                    //删除失败，正常不会出错
                                    else
                                    {
                                        MessageBox.Show("删除失败！");
                                    }
                                }
                                //没有所选记录对应编码，如运行软件后手动改了配置文件，正常不会出现这种情况
                                else
                                {
                                    MessageBox.Show("未找到匹配项，删除失败！");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
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

            //模板文件设置-dgv读取配置数据
            TemplateFileSetting_dgv_init();

            //模板文件设置-按钮统一状态为能够点击
            SetTemplateFileSettingButtonEnable(true);
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
                            //有重复
                            if (string.IsNullOrEmpty(Helper.ConfigHelper.getappSettings(num)) != true)
                            {
                                MessageBox.Show("模板文件编码已存在！");
                                txtbox_TemplateFileSetting_Num.Focus();
                                txtbox_TemplateFileSetting_Num.SelectAll();
                            }
                            //没有重复，则新增
                            else
                            {
                                //新增一条配置，编码，名称、路径、备注
                                Helper.ConfigHelper.addappSettings(num, name + ";" + path + ";" + remark);
                                //在模板文件列表结尾增加新增配置的编码
                                string TemplateFileListValue = Helper.ConfigHelper.getappSettings("TemplateFileList");
                                Helper.ConfigHelper.editappSettings("TemplateFileList", TemplateFileListValue + ";" + num);
                                MessageBox.Show("新增成功");
                                //新增成功后文本框置空
                                ClearTemplateFileSettingTextBox();
                                //执行点击取消按钮同样操作，恢复控件状态等
                                btn_TemplateFileSetting_Cancel_Click(null, null);
                            }
                        }
                        //编辑
                        if (TemplateFileSettingBtnStatus == 2)
                        {
                            //判断是否有重复值
                            //没有重复，只有在运行了程序后，手动修改配置才会有这种情况
                            if (string.IsNullOrEmpty(Helper.ConfigHelper.getappSettings(num)) == true)
                            {
                                MessageBox.Show("出现异常！");
                            }
                            //有重复，则编辑
                            else
                            {
                                //修改一条配置，编码，名称、路径、备注
                                Helper.ConfigHelper.editappSettings(num, name + ";" + path + ";" + remark);
                                MessageBox.Show("修改成功");
                                //修改成功后文本框置空
                                ClearTemplateFileSettingTextBox();
                                //执行点击取消按钮同样操作，恢复控件状态等
                                btn_TemplateFileSetting_Cancel_Click(null, null);
                            }
                        }

                        //模板文件设置-dgv读取配置数据
                        TemplateFileSetting_dgv_init();
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
                //更新配置文件，修改成功
                if (Helper.ConfigHelper.editappSettings("DefaultProjectFolder", defaultprojectfolder))
                {
                    MessageBox.Show("默认生成路径修改成功！");
                }
            }
        }

        //默认生成路径文本框双击事件，选择默认生成目录
        private void txtbox_DefaultProjectFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //弹窗选择目录
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
            //弹窗选择文件
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