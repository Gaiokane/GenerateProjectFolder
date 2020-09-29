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

        //Excel_系统测试用例
        private static bool excel_SystemTestCase()
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