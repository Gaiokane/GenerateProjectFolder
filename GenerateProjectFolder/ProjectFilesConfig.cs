using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProjectFolder
{
    class ProjectFilesConfig
    {
        //调用以下所有方法
        public static bool init()
        {
            try
            {
                //文件夹_部署包
                folder_DeploymentPackage();
                //文件夹_测试用例
                folder_TestCase();
                //文件夹_缺陷截图
                folder_DefectScreenshot();
                //文件夹_文档备份
                folder_DocumentBackup();
                //文件夹_最终文档
                folder_FinalDocument();
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

        //文件夹_部署包
        private static bool folder_DeploymentPackage()
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

        //文件夹_测试用例
        private static bool folder_TestCase()
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

        //文件夹_缺陷截图
        private static bool folder_DefectScreenshot()
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

        //文件夹_文档备份
        private static bool folder_DocumentBackup()
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

        //文件夹_最终文档
        private static bool folder_FinalDocument()
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