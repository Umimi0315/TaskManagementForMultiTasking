namespace TaskManagementForMultiTasking
{
    partial class TaskManageForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.taskInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.taskId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskCreateBtn = new System.Windows.Forms.Button();
            this.refreshTaskBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.taskInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // taskInfoDataGridView
            // 
            this.taskInfoDataGridView.AllowUserToAddRows = false;
            this.taskInfoDataGridView.AllowUserToDeleteRows = false;
            this.taskInfoDataGridView.AllowUserToResizeColumns = false;
            this.taskInfoDataGridView.AllowUserToResizeRows = false;
            this.taskInfoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.taskInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskId,
            this.taskName,
            this.phoneNumber,
            this.IMSI,
            this.nationCode,
            this.appName,
            this.taskCreateTime,
            this.taskStatus,
            this.taskTag,
            this.taskProgress});
            this.taskInfoDataGridView.Location = new System.Drawing.Point(0, -1);
            this.taskInfoDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.taskInfoDataGridView.Name = "taskInfoDataGridView";
            this.taskInfoDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taskInfoDataGridView.RowTemplate.Height = 23;
            this.taskInfoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taskInfoDataGridView.Size = new System.Drawing.Size(1411, 757);
            this.taskInfoDataGridView.TabIndex = 0;
            // 
            // taskId
            // 
            this.taskId.DataPropertyName = "taskId";
            this.taskId.HeaderText = "任务编号";
            this.taskId.Name = "taskId";
            this.taskId.ReadOnly = true;
            // 
            // taskName
            // 
            this.taskName.DataPropertyName = "taskName";
            this.taskName.HeaderText = "任务名";
            this.taskName.Name = "taskName";
            this.taskName.ReadOnly = true;
            // 
            // phoneNumber
            // 
            this.phoneNumber.DataPropertyName = "phoneNumber";
            this.phoneNumber.HeaderText = "手机号";
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            // 
            // IMSI
            // 
            this.IMSI.DataPropertyName = "IMSI";
            this.IMSI.HeaderText = "IMSI";
            this.IMSI.Name = "IMSI";
            this.IMSI.ReadOnly = true;
            // 
            // nationCode
            // 
            this.nationCode.DataPropertyName = "nationCode";
            this.nationCode.HeaderText = "国家编码";
            this.nationCode.Name = "nationCode";
            this.nationCode.ReadOnly = true;
            // 
            // appName
            // 
            this.appName.DataPropertyName = "appName";
            this.appName.HeaderText = "APP名称";
            this.appName.Name = "appName";
            this.appName.ReadOnly = true;
            // 
            // taskCreateTime
            // 
            this.taskCreateTime.DataPropertyName = "taskCreateTime";
            this.taskCreateTime.HeaderText = "创建时间";
            this.taskCreateTime.Name = "taskCreateTime";
            this.taskCreateTime.ReadOnly = true;
            // 
            // taskStatus
            // 
            this.taskStatus.DataPropertyName = "taskStatus";
            this.taskStatus.HeaderText = "任务状态";
            this.taskStatus.Name = "taskStatus";
            this.taskStatus.ReadOnly = true;
            // 
            // taskTag
            // 
            this.taskTag.DataPropertyName = "taskTag";
            this.taskTag.HeaderText = "任务标志";
            this.taskTag.Name = "taskTag";
            this.taskTag.ReadOnly = true;
            // 
            // taskProgress
            // 
            this.taskProgress.DataPropertyName = "taskProgress";
            this.taskProgress.HeaderText = "任务进度";
            this.taskProgress.Name = "taskProgress";
            this.taskProgress.ReadOnly = true;
            // 
            // taskCreateBtn
            // 
            this.taskCreateBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taskCreateBtn.Location = new System.Drawing.Point(267, 781);
            this.taskCreateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.taskCreateBtn.Name = "taskCreateBtn";
            this.taskCreateBtn.Size = new System.Drawing.Size(100, 31);
            this.taskCreateBtn.TabIndex = 1;
            this.taskCreateBtn.Text = "创建任务";
            this.taskCreateBtn.UseVisualStyleBackColor = true;
            this.taskCreateBtn.Click += new System.EventHandler(this.taskCreateBtn_Click);
            // 
            // refreshTaskBtn
            // 
            this.refreshTaskBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refreshTaskBtn.Location = new System.Drawing.Point(973, 783);
            this.refreshTaskBtn.Name = "refreshTaskBtn";
            this.refreshTaskBtn.Size = new System.Drawing.Size(95, 27);
            this.refreshTaskBtn.TabIndex = 2;
            this.refreshTaskBtn.Text = "刷新列表";
            this.refreshTaskBtn.UseVisualStyleBackColor = true;
            this.refreshTaskBtn.Click += new System.EventHandler(this.refreshTaskBtn_Click);
            // 
            // TaskManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 825);
            this.Controls.Add(this.refreshTaskBtn);
            this.Controls.Add(this.taskCreateBtn);
            this.Controls.Add(this.taskInfoDataGridView);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaskManageForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.taskInfoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView taskInfoDataGridView;
        private System.Windows.Forms.Button taskCreateBtn;
        private System.Windows.Forms.Button refreshTaskBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskId;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn appName;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskProgress;
    }
}

