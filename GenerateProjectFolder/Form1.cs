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
         * 整体思路：
         * ———————配置文件———————
         * 1.<文件项> 存 文件路径键值对中的键，分号间隔。如<add key="FileName" value="FileName_01;FileName_02;FileName_03" />
         * 2.<文件路径> 存 文件路径，如<add key="FileName_01" value="D:/vs-program/GitHub/GenerateProjectFolder/GenerateProjectFolder.sln" />
         * 3.<生成目录文件路径> 存 生成的目录、文件保存路径，如<add key="ProjectFolderPath" value="D:/vs-program/GitHub/" />
         * 4.
         * 5.
         * 6.
         * 7.
         */
    }
}