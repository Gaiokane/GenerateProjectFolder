namespace GenerateProjectFolder
{
    partial class FrmSetting
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
            this.groupbox_ProjectFolderSetting = new System.Windows.Forms.GroupBox();
            this.btn_DefaultProjectFolder_Save = new System.Windows.Forms.Button();
            this.txtbox_DefaultProjectFolder = new System.Windows.Forms.TextBox();
            this.lab_DefaultProjectFolder = new System.Windows.Forms.Label();
            this.groupbox_TemplateFileSetting = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_TemplateFileSetting_Cancel = new System.Windows.Forms.Button();
            this.btn_TemplateFileSetting_Save = new System.Windows.Forms.Button();
            this.txtbox_TemplateFileSetting_Remark = new System.Windows.Forms.TextBox();
            this.lab_TemplateFileSetting_Remark = new System.Windows.Forms.Label();
            this.txtbox_TemplateFileSetting_Path = new System.Windows.Forms.TextBox();
            this.lab_TemplateFileSetting_Path = new System.Windows.Forms.Label();
            this.txtbox_TemplateFileSetting_Name = new System.Windows.Forms.TextBox();
            this.lab_TemplateFileSetting_Name = new System.Windows.Forms.Label();
            this.txtbox_TemplateFileSetting_Num = new System.Windows.Forms.TextBox();
            this.lab_TemplateFileSetting_Num = new System.Windows.Forms.Label();
            this.btn_TemplateFileSetting_Del = new System.Windows.Forms.Button();
            this.btn_TemplateFileSetting_Edit = new System.Windows.Forms.Button();
            this.btn_TemplateFileSetting_New = new System.Windows.Forms.Button();
            this.btn_TemplateFileSetting_Refresh = new System.Windows.Forms.Button();
            this.dgv_TemplateFileSetting = new System.Windows.Forms.DataGridView();
            this.groupbox_ProjectFolderSetting.SuspendLayout();
            this.groupbox_TemplateFileSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TemplateFileSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // groupbox_ProjectFolderSetting
            // 
            this.groupbox_ProjectFolderSetting.Controls.Add(this.btn_DefaultProjectFolder_Save);
            this.groupbox_ProjectFolderSetting.Controls.Add(this.txtbox_DefaultProjectFolder);
            this.groupbox_ProjectFolderSetting.Controls.Add(this.lab_DefaultProjectFolder);
            this.groupbox_ProjectFolderSetting.Location = new System.Drawing.Point(12, 12);
            this.groupbox_ProjectFolderSetting.Name = "groupbox_ProjectFolderSetting";
            this.groupbox_ProjectFolderSetting.Size = new System.Drawing.Size(776, 47);
            this.groupbox_ProjectFolderSetting.TabIndex = 0;
            this.groupbox_ProjectFolderSetting.TabStop = false;
            this.groupbox_ProjectFolderSetting.Text = "生成路径设置";
            // 
            // btn_DefaultProjectFolder_Save
            // 
            this.btn_DefaultProjectFolder_Save.Location = new System.Drawing.Point(507, 18);
            this.btn_DefaultProjectFolder_Save.Name = "btn_DefaultProjectFolder_Save";
            this.btn_DefaultProjectFolder_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_DefaultProjectFolder_Save.TabIndex = 2;
            this.btn_DefaultProjectFolder_Save.Text = "保存";
            this.btn_DefaultProjectFolder_Save.UseVisualStyleBackColor = true;
            // 
            // txtbox_DefaultProjectFolder
            // 
            this.txtbox_DefaultProjectFolder.Location = new System.Drawing.Point(101, 20);
            this.txtbox_DefaultProjectFolder.Name = "txtbox_DefaultProjectFolder";
            this.txtbox_DefaultProjectFolder.Size = new System.Drawing.Size(400, 21);
            this.txtbox_DefaultProjectFolder.TabIndex = 1;
            // 
            // lab_DefaultProjectFolder
            // 
            this.lab_DefaultProjectFolder.AutoSize = true;
            this.lab_DefaultProjectFolder.Location = new System.Drawing.Point(6, 23);
            this.lab_DefaultProjectFolder.Name = "lab_DefaultProjectFolder";
            this.lab_DefaultProjectFolder.Size = new System.Drawing.Size(89, 12);
            this.lab_DefaultProjectFolder.TabIndex = 0;
            this.lab_DefaultProjectFolder.Text = "默认生成路径：";
            // 
            // groupbox_TemplateFileSetting
            // 
            this.groupbox_TemplateFileSetting.Controls.Add(this.groupBox3);
            this.groupbox_TemplateFileSetting.Controls.Add(this.btn_TemplateFileSetting_Del);
            this.groupbox_TemplateFileSetting.Controls.Add(this.btn_TemplateFileSetting_Edit);
            this.groupbox_TemplateFileSetting.Controls.Add(this.btn_TemplateFileSetting_New);
            this.groupbox_TemplateFileSetting.Controls.Add(this.btn_TemplateFileSetting_Refresh);
            this.groupbox_TemplateFileSetting.Controls.Add(this.dgv_TemplateFileSetting);
            this.groupbox_TemplateFileSetting.Location = new System.Drawing.Point(12, 65);
            this.groupbox_TemplateFileSetting.Name = "groupbox_TemplateFileSetting";
            this.groupbox_TemplateFileSetting.Size = new System.Drawing.Size(776, 373);
            this.groupbox_TemplateFileSetting.TabIndex = 1;
            this.groupbox_TemplateFileSetting.TabStop = false;
            this.groupbox_TemplateFileSetting.Text = "模板文件设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_TemplateFileSetting_Cancel);
            this.groupBox3.Controls.Add(this.btn_TemplateFileSetting_Save);
            this.groupBox3.Controls.Add(this.txtbox_TemplateFileSetting_Remark);
            this.groupBox3.Controls.Add(this.lab_TemplateFileSetting_Remark);
            this.groupBox3.Controls.Add(this.txtbox_TemplateFileSetting_Path);
            this.groupBox3.Controls.Add(this.lab_TemplateFileSetting_Path);
            this.groupBox3.Controls.Add(this.txtbox_TemplateFileSetting_Name);
            this.groupBox3.Controls.Add(this.lab_TemplateFileSetting_Name);
            this.groupBox3.Controls.Add(this.txtbox_TemplateFileSetting_Num);
            this.groupBox3.Controls.Add(this.lab_TemplateFileSetting_Num);
            this.groupBox3.Location = new System.Drawing.Point(6, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 68);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btn_TemplateFileSetting_Cancel
            // 
            this.btn_TemplateFileSetting_Cancel.Location = new System.Drawing.Point(582, 39);
            this.btn_TemplateFileSetting_Cancel.Name = "btn_TemplateFileSetting_Cancel";
            this.btn_TemplateFileSetting_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_TemplateFileSetting_Cancel.TabIndex = 9;
            this.btn_TemplateFileSetting_Cancel.Text = "取消";
            this.btn_TemplateFileSetting_Cancel.UseVisualStyleBackColor = true;
            this.btn_TemplateFileSetting_Cancel.Click += new System.EventHandler(this.btn_TemplateFileSetting_Cancel_Click);
            // 
            // btn_TemplateFileSetting_Save
            // 
            this.btn_TemplateFileSetting_Save.Location = new System.Drawing.Point(501, 39);
            this.btn_TemplateFileSetting_Save.Name = "btn_TemplateFileSetting_Save";
            this.btn_TemplateFileSetting_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_TemplateFileSetting_Save.TabIndex = 8;
            this.btn_TemplateFileSetting_Save.Text = "保存";
            this.btn_TemplateFileSetting_Save.UseVisualStyleBackColor = true;
            // 
            // txtbox_TemplateFileSetting_Remark
            // 
            this.txtbox_TemplateFileSetting_Remark.Location = new System.Drawing.Point(596, 14);
            this.txtbox_TemplateFileSetting_Remark.Name = "txtbox_TemplateFileSetting_Remark";
            this.txtbox_TemplateFileSetting_Remark.Size = new System.Drawing.Size(162, 21);
            this.txtbox_TemplateFileSetting_Remark.TabIndex = 7;
            // 
            // lab_TemplateFileSetting_Remark
            // 
            this.lab_TemplateFileSetting_Remark.AutoSize = true;
            this.lab_TemplateFileSetting_Remark.Location = new System.Drawing.Point(501, 17);
            this.lab_TemplateFileSetting_Remark.Name = "lab_TemplateFileSetting_Remark";
            this.lab_TemplateFileSetting_Remark.Size = new System.Drawing.Size(89, 12);
            this.lab_TemplateFileSetting_Remark.TabIndex = 6;
            this.lab_TemplateFileSetting_Remark.Text = "模板文件备注：";
            // 
            // txtbox_TemplateFileSetting_Path
            // 
            this.txtbox_TemplateFileSetting_Path.Location = new System.Drawing.Point(101, 41);
            this.txtbox_TemplateFileSetting_Path.Name = "txtbox_TemplateFileSetting_Path";
            this.txtbox_TemplateFileSetting_Path.Size = new System.Drawing.Size(394, 21);
            this.txtbox_TemplateFileSetting_Path.TabIndex = 5;
            // 
            // lab_TemplateFileSetting_Path
            // 
            this.lab_TemplateFileSetting_Path.AutoSize = true;
            this.lab_TemplateFileSetting_Path.Location = new System.Drawing.Point(6, 44);
            this.lab_TemplateFileSetting_Path.Name = "lab_TemplateFileSetting_Path";
            this.lab_TemplateFileSetting_Path.Size = new System.Drawing.Size(89, 12);
            this.lab_TemplateFileSetting_Path.TabIndex = 4;
            this.lab_TemplateFileSetting_Path.Text = "模板文件路径：";
            // 
            // txtbox_TemplateFileSetting_Name
            // 
            this.txtbox_TemplateFileSetting_Name.Location = new System.Drawing.Point(348, 14);
            this.txtbox_TemplateFileSetting_Name.Name = "txtbox_TemplateFileSetting_Name";
            this.txtbox_TemplateFileSetting_Name.Size = new System.Drawing.Size(147, 21);
            this.txtbox_TemplateFileSetting_Name.TabIndex = 3;
            // 
            // lab_TemplateFileSetting_Name
            // 
            this.lab_TemplateFileSetting_Name.AutoSize = true;
            this.lab_TemplateFileSetting_Name.Location = new System.Drawing.Point(253, 17);
            this.lab_TemplateFileSetting_Name.Name = "lab_TemplateFileSetting_Name";
            this.lab_TemplateFileSetting_Name.Size = new System.Drawing.Size(89, 12);
            this.lab_TemplateFileSetting_Name.TabIndex = 2;
            this.lab_TemplateFileSetting_Name.Text = "模板文件名称：";
            // 
            // txtbox_TemplateFileSetting_Num
            // 
            this.txtbox_TemplateFileSetting_Num.Location = new System.Drawing.Point(101, 14);
            this.txtbox_TemplateFileSetting_Num.Name = "txtbox_TemplateFileSetting_Num";
            this.txtbox_TemplateFileSetting_Num.Size = new System.Drawing.Size(146, 21);
            this.txtbox_TemplateFileSetting_Num.TabIndex = 1;
            // 
            // lab_TemplateFileSetting_Num
            // 
            this.lab_TemplateFileSetting_Num.AutoSize = true;
            this.lab_TemplateFileSetting_Num.Location = new System.Drawing.Point(6, 17);
            this.lab_TemplateFileSetting_Num.Name = "lab_TemplateFileSetting_Num";
            this.lab_TemplateFileSetting_Num.Size = new System.Drawing.Size(89, 12);
            this.lab_TemplateFileSetting_Num.TabIndex = 0;
            this.lab_TemplateFileSetting_Num.Text = "模板文件编码：";
            // 
            // btn_TemplateFileSetting_Del
            // 
            this.btn_TemplateFileSetting_Del.Location = new System.Drawing.Point(249, 20);
            this.btn_TemplateFileSetting_Del.Name = "btn_TemplateFileSetting_Del";
            this.btn_TemplateFileSetting_Del.Size = new System.Drawing.Size(75, 23);
            this.btn_TemplateFileSetting_Del.TabIndex = 4;
            this.btn_TemplateFileSetting_Del.Text = "删除";
            this.btn_TemplateFileSetting_Del.UseVisualStyleBackColor = true;
            // 
            // btn_TemplateFileSetting_Edit
            // 
            this.btn_TemplateFileSetting_Edit.Location = new System.Drawing.Point(168, 20);
            this.btn_TemplateFileSetting_Edit.Name = "btn_TemplateFileSetting_Edit";
            this.btn_TemplateFileSetting_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_TemplateFileSetting_Edit.TabIndex = 3;
            this.btn_TemplateFileSetting_Edit.Text = "编辑";
            this.btn_TemplateFileSetting_Edit.UseVisualStyleBackColor = true;
            // 
            // btn_TemplateFileSetting_New
            // 
            this.btn_TemplateFileSetting_New.Location = new System.Drawing.Point(87, 20);
            this.btn_TemplateFileSetting_New.Name = "btn_TemplateFileSetting_New";
            this.btn_TemplateFileSetting_New.Size = new System.Drawing.Size(75, 23);
            this.btn_TemplateFileSetting_New.TabIndex = 2;
            this.btn_TemplateFileSetting_New.Text = "新增";
            this.btn_TemplateFileSetting_New.UseVisualStyleBackColor = true;
            // 
            // btn_TemplateFileSetting_Refresh
            // 
            this.btn_TemplateFileSetting_Refresh.Location = new System.Drawing.Point(6, 20);
            this.btn_TemplateFileSetting_Refresh.Name = "btn_TemplateFileSetting_Refresh";
            this.btn_TemplateFileSetting_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_TemplateFileSetting_Refresh.TabIndex = 1;
            this.btn_TemplateFileSetting_Refresh.Text = "刷新";
            this.btn_TemplateFileSetting_Refresh.UseVisualStyleBackColor = true;
            this.btn_TemplateFileSetting_Refresh.Click += new System.EventHandler(this.btn_TemplateFileSetting_Refresh_Click);
            // 
            // dgv_TemplateFileSetting
            // 
            this.dgv_TemplateFileSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TemplateFileSetting.Location = new System.Drawing.Point(6, 49);
            this.dgv_TemplateFileSetting.Name = "dgv_TemplateFileSetting";
            this.dgv_TemplateFileSetting.RowTemplate.Height = 23;
            this.dgv_TemplateFileSetting.Size = new System.Drawing.Size(764, 318);
            this.dgv_TemplateFileSetting.TabIndex = 0;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupbox_TemplateFileSetting);
            this.Controls.Add(this.groupbox_ProjectFolderSetting);
            this.Name = "FrmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.groupbox_ProjectFolderSetting.ResumeLayout(false);
            this.groupbox_ProjectFolderSetting.PerformLayout();
            this.groupbox_TemplateFileSetting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TemplateFileSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox_ProjectFolderSetting;
        private System.Windows.Forms.Label lab_DefaultProjectFolder;
        private System.Windows.Forms.TextBox txtbox_DefaultProjectFolder;
        private System.Windows.Forms.Button btn_DefaultProjectFolder_Save;
        private System.Windows.Forms.GroupBox groupbox_TemplateFileSetting;
        private System.Windows.Forms.DataGridView dgv_TemplateFileSetting;
        private System.Windows.Forms.Button btn_TemplateFileSetting_Refresh;
        private System.Windows.Forms.Button btn_TemplateFileSetting_Del;
        private System.Windows.Forms.Button btn_TemplateFileSetting_Edit;
        private System.Windows.Forms.Button btn_TemplateFileSetting_New;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lab_TemplateFileSetting_Num;
        private System.Windows.Forms.Label lab_TemplateFileSetting_Name;
        private System.Windows.Forms.TextBox txtbox_TemplateFileSetting_Num;
        private System.Windows.Forms.TextBox txtbox_TemplateFileSetting_Name;
        private System.Windows.Forms.Label lab_TemplateFileSetting_Path;
        private System.Windows.Forms.TextBox txtbox_TemplateFileSetting_Path;
        private System.Windows.Forms.Label lab_TemplateFileSetting_Remark;
        private System.Windows.Forms.TextBox txtbox_TemplateFileSetting_Remark;
        private System.Windows.Forms.Button btn_TemplateFileSetting_Save;
        private System.Windows.Forms.Button btn_TemplateFileSetting_Cancel;
    }
}