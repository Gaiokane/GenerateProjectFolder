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
        private static string testcasefolderpath = null;
        //测试用例路径
        private static string testcasefilepath = null;

        //调用以下所有方法
        public static bool init(string GenerateToPath, string ProjectNum, string ProjectName, string ProjectAbbreviation)
        {
            try
            {
                //文件夹_项目文件夹
                folder_ProjectFolder(GenerateToPath, ProjectNum, ProjectName, ProjectAbbreviation);
                //文件夹_部署包
                folder_DeploymentPackage(projectfolderpath);
                //文件夹_测试用例
                folder_TestCase(projectfolderpath);
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
        private static bool folder_TestCase(string ProjectFolderPath)
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
                    testcasefolderpath = ProjectFolderPath + @"\测试用例";
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
                    FileHelper.CreateNewDirectory(ProjectFolderPath + @"\" + projectabbreviation + "缺陷截图");
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
                string TestCaseTemplateFilePath = ConfigHelper.getappSettings("TestCaseTemplateFilePath");
                //按“\”分割，取最后最后一个匹配项的索引位置
                int index = TestCaseTemplateFilePath.LastIndexOf(@"\");
                //取出上方索引位置+1开始至末尾的文件名
                string TestCaseFileName = TestCaseTemplateFilePath.Substring(index + 1);
                //测试用例文件路径
                testcasefilepath = testcasefolderpath + @"\" + projectnum + TestCaseFileName;
                //复制模板文件至项目文件测试用例路径下，并将模板文件名称修改为带项目编号的名称
                if (FileHelper.CopyFileTo(TestCaseTemplateFilePath, testcasefilepath))
                {
                    //封面-项目名称
                    ExcelHelper.ModifyExcelByCell(testcasefilepath, 0, 13, 1, projectname);
                    //版本记录-项目名称
                    ExcelHelper.ModifyExcelByCell(testcasefilepath, 1, 1, 5, projectname);
                    //版本记录-1.文档属性-文档编号
                    ExcelHelper.ModifyExcelByCell(testcasefilepath, 1, 5, 3, projectnum + "_ST_系统测试用例");
                    //版本记录-2.版本历史-日期
                    ExcelHelper.ModifyExcelByCell(testcasefilepath, 1, 11, 1, DateTime.Now.ToString("yyyy/MM/dd"));
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

        //Excel_测试服务器部署信息登记表
        private static bool excel_TestServerDeploymentInformation()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Excel_项目测试进度
        private static bool excel_ProjectTestProgress()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //TXT_版本更新日志
        private static bool txt_VersionUpdateLog()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //TXT_问题
        private static bool txt_Problem()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}