using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProjectFolder.Helper
{
    class FileHelper
    {
        /// <summary>
        /// 新建文件并写入内容，如果已存在，则覆盖
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="content">文件内容</param>
        public static bool CreateNewFile(string fileName, string content)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(content);
                    sw.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 复制文件，如果目标路径已存在同名文件，则覆盖，否则新建
        /// </summary>
        /// <param name="source">源文件路径</param>
        /// <param name="dest">目标文件路径</param>
        public static bool CopyFileTo(string source, string dest)
        {
            try
            {
                if (File.Exists(source))//必须判断要复制的文件是否存在
                {
                    if (IsFileInUsed(source) == false)
                    {
                        File.Copy(source, dest, true);//三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("所选文件被占用，无法复制");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 移动文件/目录
        /// </summary>
        /// <param name="source">源路径</param>
        /// <param name="dest">目标路径</param>
        public static bool MoveFileTo(string source, string dest)
        {
            try
            {
                if (File.Exists(source))
                {
                    if (IsFileInUsed(source) == false)
                    {
                        File.Move(source, dest);
                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("所选文件被占用，无法移动");
                        return false;
                    }
                }
                else if (Directory.Exists(source))
                {
                    try
                    {
                        Directory.Move(source, dest);
                        return true;
                    }
                    catch
                    {
                        //MessageBox.Show("所选文件夹被占用，无法移动");
                        return false;
                    }
                }
                else
                {
                    //MessageBox.Show("所选文件/文件夹不存在");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断指定文件是否在使用
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>true, false</returns>
        public static bool IsFileInUsed(string fileName)
        {
            try
            {
                bool inUse = true;
                if (File.Exists(fileName))
                {
                    FileStream fs = null;
                    try
                    {
                        fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                        inUse = false;
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e.Message.ToString());
                        return false;
                    }
                    finally
                    {
                        if (fs != null)
                        {
                            fs.Close();
                        }
                    }
                    return inUse;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断指定文件是否存在
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>true, false</returns>
        public static bool IsFileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        /// <summary>
        /// 判断指定目录是否存在
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>true, false</returns>
        public static bool IsDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// 新建目录，如果已存在，则不进行操作
        /// </summary>
        /// <param name="path">目录路径</param>
        public static bool CreateNewDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}