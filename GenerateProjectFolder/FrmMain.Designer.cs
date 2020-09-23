namespace GenerateProjectFolder
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_GenerateTo = new System.Windows.Forms.Label();
            this.txtbox_GenerateTo = new System.Windows.Forms.TextBox();
            this.lab_ProjectNum = new System.Windows.Forms.Label();
            this.txtbox_ProjectNum = new System.Windows.Forms.TextBox();
            this.lab_ProjectName = new System.Windows.Forms.Label();
            this.txtbox_ProjectName = new System.Windows.Forms.TextBox();
            this.lab_ProjectAbbreviation = new System.Windows.Forms.Label();
            this.txtbox_ProjectAbbreviation = new System.Windows.Forms.TextBox();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.btn_Setting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lab_GenerateTo
            // 
            this.lab_GenerateTo.AutoSize = true;
            this.lab_GenerateTo.Location = new System.Drawing.Point(24, 15);
            this.lab_GenerateTo.Name = "lab_GenerateTo";
            this.lab_GenerateTo.Size = new System.Drawing.Size(53, 12);
            this.lab_GenerateTo.TabIndex = 0;
            this.lab_GenerateTo.Text = "生成至：";
            // 
            // txtbox_GenerateTo
            // 
            this.txtbox_GenerateTo.Location = new System.Drawing.Point(83, 12);
            this.txtbox_GenerateTo.Name = "txtbox_GenerateTo";
            this.txtbox_GenerateTo.Size = new System.Drawing.Size(400, 21);
            this.txtbox_GenerateTo.TabIndex = 1;
            this.txtbox_GenerateTo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtbox_GenerateTo_MouseDoubleClick);
            // 
            // lab_ProjectNum
            // 
            this.lab_ProjectNum.AutoSize = true;
            this.lab_ProjectNum.Location = new System.Drawing.Point(12, 42);
            this.lab_ProjectNum.Name = "lab_ProjectNum";
            this.lab_ProjectNum.Size = new System.Drawing.Size(65, 12);
            this.lab_ProjectNum.TabIndex = 2;
            this.lab_ProjectNum.Text = "项目编号：";
            // 
            // txtbox_ProjectNum
            // 
            this.txtbox_ProjectNum.Location = new System.Drawing.Point(83, 39);
            this.txtbox_ProjectNum.Name = "txtbox_ProjectNum";
            this.txtbox_ProjectNum.Size = new System.Drawing.Size(400, 21);
            this.txtbox_ProjectNum.TabIndex = 3;
            // 
            // lab_ProjectName
            // 
            this.lab_ProjectName.AutoSize = true;
            this.lab_ProjectName.Location = new System.Drawing.Point(12, 69);
            this.lab_ProjectName.Name = "lab_ProjectName";
            this.lab_ProjectName.Size = new System.Drawing.Size(65, 12);
            this.lab_ProjectName.TabIndex = 4;
            this.lab_ProjectName.Text = "项目名称：";
            // 
            // txtbox_ProjectName
            // 
            this.txtbox_ProjectName.Location = new System.Drawing.Point(83, 66);
            this.txtbox_ProjectName.Name = "txtbox_ProjectName";
            this.txtbox_ProjectName.Size = new System.Drawing.Size(400, 21);
            this.txtbox_ProjectName.TabIndex = 5;
            // 
            // lab_ProjectAbbreviation
            // 
            this.lab_ProjectAbbreviation.AutoSize = true;
            this.lab_ProjectAbbreviation.Location = new System.Drawing.Point(12, 96);
            this.lab_ProjectAbbreviation.Name = "lab_ProjectAbbreviation";
            this.lab_ProjectAbbreviation.Size = new System.Drawing.Size(65, 12);
            this.lab_ProjectAbbreviation.TabIndex = 6;
            this.lab_ProjectAbbreviation.Text = "项目简称：";
            // 
            // txtbox_ProjectAbbreviation
            // 
            this.txtbox_ProjectAbbreviation.Location = new System.Drawing.Point(83, 93);
            this.txtbox_ProjectAbbreviation.Name = "txtbox_ProjectAbbreviation";
            this.txtbox_ProjectAbbreviation.Size = new System.Drawing.Size(400, 21);
            this.txtbox_ProjectAbbreviation.TabIndex = 7;
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(169, 120);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(75, 23);
            this.btn_Generate.TabIndex = 8;
            this.btn_Generate.Text = "生成";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // btn_Setting
            // 
            this.btn_Setting.Location = new System.Drawing.Point(250, 120);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(75, 23);
            this.btn_Setting.TabIndex = 9;
            this.btn_Setting.Text = "设置";
            this.btn_Setting.UseVisualStyleBackColor = true;
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 155);
            this.Controls.Add(this.btn_Setting);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.txtbox_ProjectAbbreviation);
            this.Controls.Add(this.lab_ProjectAbbreviation);
            this.Controls.Add(this.txtbox_ProjectName);
            this.Controls.Add(this.lab_ProjectName);
            this.Controls.Add(this.txtbox_ProjectNum);
            this.Controls.Add(this.lab_ProjectNum);
            this.Controls.Add(this.txtbox_GenerateTo);
            this.Controls.Add(this.lab_GenerateTo);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成项目文件夹";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_GenerateTo;
        private System.Windows.Forms.TextBox txtbox_GenerateTo;
        private System.Windows.Forms.Label lab_ProjectNum;
        private System.Windows.Forms.TextBox txtbox_ProjectNum;
        private System.Windows.Forms.Label lab_ProjectName;
        private System.Windows.Forms.TextBox txtbox_ProjectName;
        private System.Windows.Forms.Label lab_ProjectAbbreviation;
        private System.Windows.Forms.TextBox txtbox_ProjectAbbreviation;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.Button btn_Setting;
    }
}