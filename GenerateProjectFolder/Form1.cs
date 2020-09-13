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
         * ———————执行流程———————
         * 1.生成至路径读取配置文件，默认保存上一次新增成功的路径
         * 2.在主窗体中填写项目编号（非必填）、项目名称（必填）、项目简称（必填）
         * 3.点击生成按钮，在生成至路径中创建项目目录，文件夹名（项目编号项目名称）
         * 4.项目目录中含有设置窗体中配置的文件项
         * 5.
         * 6.
         * 7.
         * 整体思路：
         * ———————配置文件———————
         * 1.<文件项> 存 文件路径键值对中的键，分号间隔。如<add key="FileName" value="FileName_01;FileName_02;FileName_03" />
         * 2.<文件路径> 存 文件路径，如<add key="FileName_01" value="D:/vs-program/GitHub/GenerateProjectFolder/GenerateProjectFolder.sln" />
         * 3.<生成目录文件路径> 存 生成的目录、文件保存路径，如<add key="ProjectFolderPath" value="D:/vs-program/GitHub/" />
         * 4.文件项是否启用、复制、复制并修改（待设计）
         * 5.
         * 6.
         * 7.
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
         * 1.配置文件默认值设置方法（对不存在的key进行新增）——init()
         * 2.是否存在[配置文件中的key]——IsappSettingsExists(string key)
         * 3.新增配置方法（传入key、value）——addappSettings(string key, string value)
         * 4.编辑配置方法（传入key、value）——editappSettings(string key, string value)
         * 5.删除配置方法（传入key）——delappSettings(string key)
         * 6.查询配置方法（传入key）——getappSettings(string key)
         * 7.是否指定文件夹——IsDirectoryExists(string path)
         * 8.新建文件夹——CreateNewDirectory(string path)
         * 9.是否存在指定文件——IsFileExists(string fileName)
         * 10.复制文件——CopyFileTo(string source, string dest)
         * 11.重命名文件
         * 12.文件是否在使用——IsFileInUsed(string fileName)
         * 13.文件操作类-新建文件——CreateNewFile(string fileName, string content)
         * 14.文件操作类-读取excel——ReadExcel(string filePath, int sheetIndex)
         * 15.文件操作类-读取excel指定单元格——ReadExcelByCell(string filePath, int sheetIndex, int row, int cell)
         * 16.文件操作类-修改excel指定单元格——ModifyExcelByCell(string filePath, int sheetIndex, int row, int cell, string cellValue)
         * 17.文件操作类（写入txt、新增/修改excel）
         * 18.
         * 19.
         * 备注：
         * 1）1.默认值如文件项、生成至路径
         * ———————用到的工具类———————
         * 1.Gaiokane.dll[2.0.0.0]——独写配置文件[https://github.com/Gaiokane/Gaiokane-RWConfig_DLL]
         * 2.（收费不用）Aspose.Cells[20.8.0.0]——Excel操作类，vs中程序包管理器[Install-Package Aspose.Cells][https://github.com/aspose-cells/Aspose.Cells-for-.NET][https://github.com/Jimmey-Jiang/Common.Utility/blob/master/src/Utility%E5%9F%BA%E7%A1%80%E7%B1%BB%E5%A4%A7%E5%85%A8_CN/Excel%E6%93%8D%E4%BD%9C%E7%B1%BB/excel.txt]
         * 3.NPOI[2.4.1.0]、NPOI.OOXML[2.4.1.0]、NPOI.OpenXml4Net[2.4.1.0]、NPOI.OpenXmlFormats[2.4.1.0]、——Excel操作类，功能同Aspose.Cells，免费[https://github.com/tonyqus/npoi]
         * 4.ICSharpCode.SharpZipLib[1.0.0.999]，NPOI会用到
         * 5.
         */
    }
}