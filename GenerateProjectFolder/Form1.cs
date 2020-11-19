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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * ———————执行流程———————
         * 1.生成至路径读取配置文件，默认保存上一次新增成功的路径（暂未实现，是否有必要保存上一次新增成功的路径）
         * 2.在主窗体中填写项目编号（必填）、项目名称（必填）、项目简称（非必填）
         * 3.点击生成按钮，在生成至路径中创建项目目录，文件夹名（项目编号项目名称）
         * 4.项目目录中含有设置窗体中配置的文件项（文件项有用到文件名，最好处理下，不在乎模板文件名）
         * 5.
         * 6.
         * 7.
         * 整体思路：
         * ———————项目文件生成类———————
         * 1.√调用全部方法——[ProjectFilesConfig.cs]init()
         * 2.√文件夹_部署包——[ProjectFilesConfig.cs]folder_DeploymentPackage()
         * 3.√文件夹_测试用例——[ProjectFilesConfig.cs]folder_TestCase()
         * 4.√文件夹_缺陷截图——[ProjectFilesConfig.cs]folder_DefectScreenshot()
         * 5.√文件夹_文档备份——[ProjectFilesConfig.cs]folder_DocumentBackup()
         * 6.√文件夹_最终文档——[ProjectFilesConfig.cs]folder_FinalDocument()
         * 7.√Excel_系统测试用例——[ProjectFilesConfig.cs]excel_SystemTestCase()
         * 8.√Excel_测试服务器部署信息登记表——[ProjectFilesConfig.cs]excel_TestServerDeploymentInformation()
         * 9.√Excel_项目测试进度——[ProjectFilesConfig.cs]excel_ProjectTestProgress()
         * 10.Excel_测试估算——[ProjectFilesConfig.cs]excel_TestEstimate()
         * 11.√TXT_版本更新日志——[ProjectFilesConfig.cs]txt_VersionUpdateLog()
         * 12.√TXT_问题——[ProjectFilesConfig.cs]txt_Problem()
         * 13.√TXT_部署记录——[ProjectFilesConfig.cs]txt_DeploymentRecord()
         * 14.√项目文件夹在桌面建快捷方式[FileHelper.cs]CreateShortcutOnDesktop(string ShortcutName, string TargetPath)
         * 15.√缺陷截图在桌面建快捷方式[FileHelper.cs]CreateShortcutOnDesktop(string ShortcutName, string TargetPath)
         * 16.
         * 17.
         * ———————配置文件———————
         * 1.√<文件项> 存 文件路径键值对中的键，分号间隔。如<add key="TemplateFileList" value="FileName_01;FileName_02;FileName_03" />
         * 2.√<文件路径> 存 文件路径，如<add key="xxTemplateFilePath" value="D:/vs-program/GitHub/GenerateProjectFolder/GenerateProjectFolder.sln" />
         * 3.√<生成目录文件路径> 存 生成的目录、文件保存路径，如<add key="DefaultProjectFolder" value="D:/vs-program/GitHub/" />
         * 4.文件项是否启用、复制、复制并修改（待设计）
         * 5.
         * 6.
         * 7.
         * ———————窗体设计———————
         * √1.主窗体（生成至：[label、textbox]、路径选择[button]、项目编号[label、textbox]、项目名称[label、textbox]、项目简称[label、textbox]、生成[button]、设置[button]）
         * √2.主窗体—设置窗体（生成路径设置、模板文件设置）
         * √3.设置窗体—生成路径设置（功能组合[groupbox]、默认生成路径[label]、默认生成路径[textbox]、保存[button]）
         * √4.设置窗体—模板文件设置（功能组合[groupbox]、刷新[button]、新增[button]、编辑[button]、删除[button]、列表[datagridview]：模板文件编码、模板文件名称、模板文件路径、模板文件备注）
         * √5.模板文件设置—新增/编辑（模板文件编码[label、textbox]、模板文件名称[label、textbox]、模板文件路径[label、textbox]、路径选择[button]、模板文件备注[label、richtextbox]、保存[button]、取消[button]）
         * 6.
         * 7.
         * 备注：
         * 1.项目简称：用在 xx缺陷截图、xx问题.txt、xx估算、xx项目测试进度 等
         * ———————通用方法设计———————
         * √1.配置文件默认值设置方法（对不存在的key进行新增）——[ConfigHelper.cs]init()
         * √2.是否存在[配置文件中的key]——[ConfigHelper.cs]IsappSettingsExists(string key)
         * √3.新增配置方法（传入key、value）——[ConfigHelper.cs]addappSettings(string key, string value)
         * √4.编辑配置方法（传入key、value）——[ConfigHelper.cs]editappSettings(string key, string value)
         * √5.删除配置方法（传入key）——[ConfigHelper.cs]delappSettings(string key)
         * √6.查询配置方法（传入key）——[ConfigHelper.cs]getappSettings(string key)
         * √7.是否指定文件夹——[FileHelper.cs]IsDirectoryExists(string path)
         * √8.新建文件夹——[FileHelper.cs]CreateNewDirectory(string path)
         * √9.是否存在指定文件——[FileHelper.cs]IsFileExists(string fileName)
         * √10.复制文件——[FileHelper.cs]CopyFileTo(string source, string dest)
         * √11.重命名/移动文件/目录——[FileHelper.cs]MoveFileTo(string source, string dest)
         * √12.文件是否在使用——[FileHelper.cs]IsFileInUsed(string fileName)
         * √13.文件操作类-新建文件，如新建txt并写入——[FileHelper.cs]CreateNewFile(string fileName, string content)
         * √14.文件操作类-读取excel——[ExcelHelper.cs]ReadExcel(string filePath, int sheetIndex)
         * √15.文件操作类-读取excel指定单元格——[ExcelHelper.cs]ReadExcelByCell(string filePath, int sheetIndex, int row, int cell)
         * √16.文件操作类-修改excel指定单元格——[ExcelHelper.cs]ModifyExcelByCell(string filePath, int sheetIndex, int row, int cell, string cellValue)
         * √17.获取指定日期测试版本号——[CommonHelper.cs]GetTestVersionNum(DateTime dt)
         * √18.在桌面创建快捷方式[FileHelper.cs]CreateShortcutOnDesktop(string ShortcutName, string TargetPath)
         * √19.读取Excel中指定Sheet的所有批注——[ExcelHelper.cs]ReadExcelCommentBySheet(string filePath, int sheetIndex)/ReadExcelCommentBySheet(string filePath)（两个重载，一个指定sheet，一个全部sheet）
         * √20.复制文本到剪切板——[CommonHelper.cs]CopyToClipboard(string str)
         * 21.
         * 22.
         * 23.
         * 24.
         * 25.
         * 备注：
         * 1）1.默认值如文件项、生成至路径
         * ———————用到的工具类———————
         * 1.Gaiokane.dll[2.0.0.0]——独写配置文件[https://github.com/Gaiokane/Gaiokane-RWConfig_DLL]
         * 2.（收费不用）Aspose.Cells[20.8.0.0]——Excel操作类，vs中程序包管理器[Install-Package Aspose.Cells][https://github.com/aspose-cells/Aspose.Cells-for-.NET][https://github.com/Jimmey-Jiang/Common.Utility/blob/master/src/Utility%E5%9F%BA%E7%A1%80%E7%B1%BB%E5%A4%A7%E5%85%A8_CN/Excel%E6%93%8D%E4%BD%9C%E7%B1%BB/excel.txt]
         * 3.NPOI[2.4.1.0]、NPOI.OOXML[2.4.1.0]、NPOI.OpenXml4Net[2.4.1.0]、NPOI.OpenXmlFormats[2.4.1.0]、——Excel操作类，功能同Aspose.Cells，免费[https://github.com/tonyqus/npoi]
         * 4.ICSharpCode.SharpZipLib[1.0.0.999]，NPOI会用到
         * 5.
         * ———————存在的问题———————
         * 1.对模板文件xlsx修改并生成新Excel文件会异常，原因：NPOI对xlsx兼容性问题，2.4.1、2.5.1都有相同问题，xls没问题
         * 2.读取Excel批注独立出来做，并加入导出功能
         * 3.
         * 4.
         * 5.
         */
    }
}