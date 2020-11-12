using GenerateProjectFolder.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProjectFolder
{
    class ProjectFilesConfig
    {
        //项目文件夹路径
        private static string projectfolderpath = null;
        //项目编号
        private static string projectnum = null;
        //项目名称
        private static string projectname = null;
        //项目简称
        private static string projectabbreviation = null;
        //测试用例文件夹路径
        private static string systemtestcasefolderpath = null;
        //测试用例路径
        private static string systemtestcasefilepath = null;
        //缺陷截图文件夹路径
        private static string defectscreenshotfolderpath = null;
        //测试服务器部署信息登记表路径
        private static string testserverdeploymentinformationfilepath = null;
        //项目测试进度路径
        private static string projecttestprogressfilepath = null;

        /// <summary>
        /// 调用以下所有方法
        /// </summary>
        /// <param name="GenerateToPath">生成至路径</param>
        /// <param name="ProjectNum">项目编号</param>
        /// <param name="ProjectName">项目名称</param>
        /// <param name="ProjectAbbreviation">项目简称</param>
        /// <returns>true, false</returns>
        public static bool init(string GenerateToPath, string ProjectNum, string ProjectName, string ProjectAbbreviation)
        {
            try
            {
                //文件夹_项目文件夹
                folder_ProjectFolder(GenerateToPath, ProjectNum, ProjectName, ProjectAbbreviation);
                //文件夹_部署包
                folder_DeploymentPackage(projectfolderpath);
                //文件夹_测试用例
                folder_SystemTestCase(projectfolderpath);
                //文件夹_缺陷截图
                folder_DefectScreenshot(projectfolderpath);
                //文件夹_文档备份
                folder_DocumentBackup(projectfolderpath);
                //文件夹_最终文档
                folder_FinalDocument(projectfolderpath);
                //Excel_系统测试用例
                excel_SystemTestCase();
                //Excel_测试服务器部署信息登记表
                excel_TestServerDeploymentInformation();
                //Excel_项目测试进度
                excel_ProjectTestProgress();
                //TXT_版本更新日志
                txt_VersionUpdateLog();
                //TXT_问题
                txt_Problem();
                //TXT_部署记录
                txt_DeploymentRecord();
                //项目文件夹桌面快捷方式
                FileHelper.CreateShortcutOnDesktop(projectnum + projectname, projectfolderpath);
                //缺陷截图文件夹桌面快捷方式
                FileHelper.CreateShortcutOnDesktop(projectabbreviation + "缺陷截图", defectscreenshotfolderpath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 文件夹_项目文件夹
        /// </summary>
        /// <param name="GenerateToPath">生成至路径</param>
        /// <param name="ProjectNum">项目编号</param>
        /// <param name="ProjectName">项目名称</param>
        /// <param name="ProjectAbbreviation">项目简称</param>
        /// <returns>成功、失败（项目文件夹已存在）</returns>
        private static bool folder_ProjectFolder(string GenerateToPath, string ProjectNum, string ProjectName, string ProjectAbbreviation)
        {
            try
            {
                string generateto = GenerateToPath + @"\" + ProjectNum + ProjectName;
                if (FileHelper.IsDirectoryExists(generateto))
                {
                    //项目文件夹已存在
                    return false;
                }
                else
                {
                    //项目文件夹不存在
                    FileHelper.CreateNewDirectory(generateto);

                    //赋值给全局变量
                    projectfolderpath = generateto;
                    projectnum = ProjectNum;
                    projectname = ProjectName;
                    projectabbreviation = ProjectAbbreviation;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 文件夹_部署包
        /// </summary>
        /// <param name="ProjectFolderPath">项目文件夹路径</param>
        /// <returns>成功、失败（新建文件夹失败，文件夹已存在被占用）</returns>
        private static bool folder_DeploymentPackage(string ProjectFolderPath)
        {
            try
            {
                //建项目文件夹时判断了是否存在相同文件夹，此处无需判断
                if (string.IsNullOrEmpty(ProjectFolderPath))
                {
                    //ProjectFolderPath判空
                    return false;
                }
                else
                {
                    FileHelper.CreateNewDirectory(ProjectFolderPath + @"\部署包");
                    FileHelper.CreateNewDirectory(ProjectFolderPath + @"\部署包\" + CommonHelper.GetTestVersionNum(DateTime.Now));
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 文件夹_测试用例
        /// </summary>
        /// <param name="ProjectFolderPath">项目文件夹路径</param>
        /// <returns>成功、失败（新建文件夹失败，文件夹已存在被占用）</returns>
        private static bool folder_SystemTestCase(string ProjectFolderPath)
        {
            try
            {
                //建项目文件夹时判断了是否存在相同文件夹，此处无需判断
                if (string.IsNullOrEmpty(ProjectFolderPath))
                {
                    //ProjectFolderPath判空
                    return false;
                }
                else
                {
                    FileHelper.CreateNewDirectory(ProjectFolderPath + @"\测试用例");
                    systemtestcasefolderpath = ProjectFolderPath + @"\测试用例";
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 文件夹_缺陷截图
        /// </summary>
        /// <param name="ProjectFolderPath">项目文件夹路径</param>
        /// <returns>成功、失败（新建文件夹失败，文件夹已存在被占用）</returns>
        private static bool folder_DefectScreenshot(string ProjectFolderPath)
        {
            try
            {
                //建项目文件夹时判断了是否存在相同文件夹，此处无需判断
                if (string.IsNullOrEmpty(ProjectFolderPath))
                {
                    //ProjectFolderPath判空
                    return false;
                }
                else
                {
                    defectscreenshotfolderpath = ProjectFolderPath + @"\" + projectabbreviation + "缺陷截图";
                    FileHelper.CreateNewDirectory(defectscreenshotfolderpath);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 文件夹_文档备份
        /// </summary>
        /// <param name="ProjectFolderPath">项目文件夹路径</param>
        /// <returns>成功、失败（新建文件夹失败，文件夹已存在被占用）</returns>
        private static bool folder_DocumentBackup(string ProjectFolderPath)
        {
            try
            {
                //建项目文件夹时判断了是否存在相同文件夹，此处无需判断
                if (string.IsNullOrEmpty(ProjectFolderPath))
                {
                    //ProjectFolderPath判空
                    return false;
                }
                else
                {
                    FileHelper.CreateNewDirectory(ProjectFolderPath + @"\文档备份");
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 文件夹_最终文档
        /// </summary>
        /// <param name="ProjectFolderPath">项目文件夹路径</param>
        /// <returns>成功、失败（新建文件夹失败，文件夹已存在被占用）</returns>
        private static bool folder_FinalDocument(string ProjectFolderPath)
        {
            try
            {
                //建项目文件夹时判断了是否存在相同文件夹，此处无需判断
                if (string.IsNullOrEmpty(ProjectFolderPath))
                {
                    //ProjectFolderPath判空
                    return false;
                }
                else
                {
                    FileHelper.CreateNewDirectory(ProjectFolderPath + @"\最终文档");
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Excel_系统测试用例
        /// </summary>
        /// <returns>成功、失败（文件不存在、文件被占用）</returns>
        private static bool excel_SystemTestCase()
        {
            try
            {
                //读取配置文件中模板文件路径
                string SystemTestCaseTemplateFilePath = ConfigHelper.getappSettings("SystemTestCaseTemplateFilePath").Split(';')[1];
                //按“\”分割，取最后一个匹配项的索引位置
                int index = SystemTestCaseTemplateFilePath.LastIndexOf(@"\");
                //取出上方索引位置+1开始至末尾的文件名
                string TestCaseFileName = SystemTestCaseTemplateFilePath.Substring(index + 1);
                //测试用例文件路径，并将模板文件名称修改为带项目编号的名称
                systemtestcasefilepath = systemtestcasefolderpath + @"\" + projectnum + TestCaseFileName;
                //复制模板文件至项目文件测试用例路径下
                if (FileHelper.CopyFileTo(SystemTestCaseTemplateFilePath, systemtestcasefilepath))
                {
                    //封面-B14项目名称
                    ExcelHelper.ModifyExcelByCell(systemtestcasefilepath, 0, 13, 1, projectname);
                    //版本记录-F2项目名称
                    ExcelHelper.ModifyExcelByCell(systemtestcasefilepath, 1, 1, 5, projectname);
                    //版本记录-1.文档属性-D6文档编号
                    ExcelHelper.ModifyExcelByCell(systemtestcasefilepath, 1, 5, 3, projectnum + "_ST_系统测试用例");
                    //版本记录-2.版本历史-B12日期
                    ExcelHelper.ModifyExcelByCell(systemtestcasefilepath, 1, 11, 1, DateTime.Now.ToString("yyyy/MM/dd"));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Excel_测试服务器部署信息登记表
        /// </summary>
        /// <returns>成功、失败（文件不存在、文件被占用）</returns>
        private static bool excel_TestServerDeploymentInformation()
        {
            try
            {
                //读取配置文件中模板文件路径
                string TestServerDeploymentInformationTemplateFilePath = ConfigHelper.getappSettings("TestServerDeploymentInformationTemplateFilePath").Split(';')[1];
                //按“\”分割，取最后一个匹配项的索引位置
                int index = TestServerDeploymentInformationTemplateFilePath.LastIndexOf(@"\");
                //取出上方索引位置+1开始至末尾的文件名，并将xxx替换为项目名称
                string TestServerDeploymentInformationFileName = TestServerDeploymentInformationTemplateFilePath.Substring(index + 1).Replace("xxx", projectname);
                //测试服务器部署信息登记表文件路径，并将模板文件名称xxx修改为项目名称
                testserverdeploymentinformationfilepath = projectfolderpath + @"\" + TestServerDeploymentInformationFileName;
                //复制模板文件至项目文件夹下
                if (FileHelper.CopyFileTo(TestServerDeploymentInformationTemplateFilePath, testserverdeploymentinformationfilepath))
                {
                    //A2项目名称
                    ExcelHelper.ModifyExcelByCell(testserverdeploymentinformationfilepath, 0, 1, 0, projectname);
                    //B2测试负责人置空
                    ExcelHelper.ModifyExcelByCell(testserverdeploymentinformationfilepath, 0, 1, 1, "");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Excel_项目测试进度
        /// </summary>
        /// <returns>成功、失败（文件不存在、文件被占用）</returns>
        private static bool excel_ProjectTestProgress()
        {
            try
            {
                //读取配置文件中模板文件路径
                string ProjectTestProgressTemplateFilePath = ConfigHelper.getappSettings("ProjectTestProgressTemplateFilePath").Split(';')[1];
                //按“\”分割，取最后一个匹配项的索引位置
                int index = ProjectTestProgressTemplateFilePath.LastIndexOf(@"\");
                //取出上方索引位置+1开始至末尾的文件名
                string ProjectTestProgressFileName = ProjectTestProgressTemplateFilePath.Substring(index + 1);
                //项目测试进度文件路径
                projecttestprogressfilepath = projectfolderpath + @"\" + ProjectTestProgressFileName;
                //复制模板文件至项目文件夹下
                if (FileHelper.CopyFileTo(ProjectTestProgressTemplateFilePath, projecttestprogressfilepath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// TXT_版本更新日志
        /// </summary>
        /// <returns>成功、失败</returns>
        private static bool txt_VersionUpdateLog()
        {
            /* \n
             * 2020-09-18：
             * （版本：B2038）
             * 新增：xxx
             * \n
             * --------------------------------------------------
             * 
             * 更新：xxx【第1轮】
             */
            try
            {
                string content = "\n" + DateTime.Now.ToString("yyyy-MM-dd")
                    + "：\n（版本：" + CommonHelper.GetTestVersionNum(DateTime.Now)
                    + "）\n新增：\n\n--------------------------------------------------\n\n更新：xxx【第1轮】";
                if (FileHelper.CreateNewFile(projectfolderpath + @"\版本更新日志.txt", content))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// TXT_问题
        /// </summary>
        /// <returns>成功、失败</returns>
        private static bool txt_Problem()
        {
            try
            {
                if (FileHelper.CreateNewFile(projectfolderpath + @"\" + projectabbreviation + "问题.txt", ""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// TXT_部署记录
        /// </summary>
        /// <returns>成功、失败</returns>
        private static bool txt_DeploymentRecord()
        {
            /* \n
             *  -> 
             * \n
             */
            try
            {
                string content = "\n -> \n";
                if (FileHelper.CreateNewFile(projectfolderpath + @"\" + projectabbreviation + "部署记录.txt", content))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}