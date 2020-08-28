﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * 整体思路：
         * ———————配置文件———————
         * 1.<文件项> 存 文件路径键值对中的键，分号间隔。如<add key="FileName" value="FileName_01;FileName_02;FileName_03" />
         * 2.<文件路径> 存 文件路径，如<add key="FileName_01" value="D:/vs-program/GitHub/GenerateProjectFolder/GenerateProjectFolder.sln" />
         * 3.<生成目录文件路径> 存 生成的目录、文件保存路径，如<add key="ProjectFolderPath" value="D:/vs-program/GitHub/" />
         * 4.
         * ———————窗体设计———————
         * 1.主窗体（生成至：[label、textbox]、路径选择[button]、项目编号[label、textbox]、项目名称[label、textbox]、项目简称[label、textbox]、生成[button]、设置[button]）
         * 2.主窗体—设置窗体（模板文件设置、）
         * 3.设置窗体—模板文件设置（功能组合[groupbox]、刷新[button]、新增[button]、编辑[button]、删除[button]、列表[datagridview]：模板文件编码、模板文件名称、模板文件路径、模板文件备注）
         * 4.模板文件设置—新增/编辑（模板文件编码[label、textbox]、模板文件名称[label、textbox]、模板文件路径[label、textbox]、路径选择[button]、模板文件备注[label、richtextbox]、保存[button]、取消[button]）
         * 5.
         * 6.
         * 7.
         * 备注：
         * 1.项目简称：用在 xx缺陷截图、xx问题.txt、xx估算、xx项目测试进度 等
         * ———————通用方法设计———————
         * 1.配置文件默认值设置方法（对不存在的key进行新增）
         * 2.是否存在[配置文件中的key]
         * 3.新增配置方法（传入key、value）
         * 4.编辑配置方法（传入key、value）
         * 5.是否存在指定路径下指定文件夹
         * 6.是否存在指定文件
         * 7.新建文件夹
         * 8.复制文件
         * 9.重命名文件
         * 10.文件操作类（写入txt、新增/修改excel）
         * 11.
         * 12.
         * 13.
         * 14.
         * 15.
         */
    }
}