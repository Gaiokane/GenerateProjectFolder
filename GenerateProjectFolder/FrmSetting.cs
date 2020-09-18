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
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Height = 244;
            dataGridView1.Location = new System.Drawing.Point(6, 123);
            groupBox3.Visible = true;
        }
    }
}