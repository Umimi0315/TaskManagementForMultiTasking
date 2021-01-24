namespace TaskManagementForMultiTasking
{
    partial class TaskCreateForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "米家"}, "米家.jpg", System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("360摄像头", "360摄像头.png");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskCreateForm));
            this.taskNameLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.IMSILabel = new System.Windows.Forms.Label();
            this.appNameListView = new System.Windows.Forms.ListView();
            this.appImageList = new System.Windows.Forms.ImageList(this.components);
            this.taskNameText = new System.Windows.Forms.TextBox();
            this.IMSIText = new System.Windows.Forms.TextBox();
            this.phoneNumberText = new System.Windows.Forms.TextBox();
            this.taskCreateBtn = new System.Windows.Forms.Button();
            this.taskCancelBtn = new System.Windows.Forms.Button();
            this.apkPathLabel = new System.Windows.Forms.Label();
            this.apkPathTextBox = new System.Windows.Forms.TextBox();
            this.apkPathBtn = new System.Windows.Forms.Button();
            this.apkPathOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.nationCodeLabel = new System.Windows.Forms.Label();
            this.nationCodeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // taskNameLabel
            // 
            this.taskNameLabel.AutoSize = true;
            this.taskNameLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taskNameLabel.Location = new System.Drawing.Point(10, 474);
            this.taskNameLabel.Name = "taskNameLabel";
            this.taskNameLabel.Size = new System.Drawing.Size(49, 14);
            this.taskNameLabel.TabIndex = 0;
            this.taskNameLabel.Text = "任务名";
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phoneNumberLabel.Location = new System.Drawing.Point(417, 474);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(49, 14);
            this.phoneNumberLabel.TabIndex = 1;
            this.phoneNumberLabel.Text = "手机号";
            // 
            // IMSILabel
            // 
            this.IMSILabel.AutoSize = true;
            this.IMSILabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IMSILabel.Location = new System.Drawing.Point(197, 474);
            this.IMSILabel.Name = "IMSILabel";
            this.IMSILabel.Size = new System.Drawing.Size(35, 14);
            this.IMSILabel.TabIndex = 2;
            this.IMSILabel.Text = "IMSI";
            // 
            // appNameListView
            // 
            this.appNameListView.HideSelection = false;
            listViewItem1.Tag = "com.xiaomi.smarthome";
            listViewItem2.Tag = "com.qihoo.camera";
            this.appNameListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.appNameListView.LargeImageList = this.appImageList;
            this.appNameListView.Location = new System.Drawing.Point(0, 1);
            this.appNameListView.Name = "appNameListView";
            this.appNameListView.Size = new System.Drawing.Size(834, 407);
            this.appNameListView.TabIndex = 3;
            this.appNameListView.UseCompatibleStateImageBehavior = false;
            // 
            // appImageList
            // 
            this.appImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("appImageList.ImageStream")));
            this.appImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.appImageList.Images.SetKeyName(0, "米家.jpg");
            this.appImageList.Images.SetKeyName(1, "360摄像头.png");
            // 
            // taskNameText
            // 
            this.taskNameText.Location = new System.Drawing.Point(65, 469);
            this.taskNameText.Name = "taskNameText";
            this.taskNameText.Size = new System.Drawing.Size(126, 21);
            this.taskNameText.TabIndex = 4;
            // 
            // IMSIText
            // 
            this.IMSIText.Location = new System.Drawing.Point(236, 469);
            this.IMSIText.Name = "IMSIText";
            this.IMSIText.Size = new System.Drawing.Size(175, 21);
            this.IMSIText.TabIndex = 5;
            // 
            // phoneNumberText
            // 
            this.phoneNumberText.Location = new System.Drawing.Point(472, 469);
            this.phoneNumberText.Name = "phoneNumberText";
            this.phoneNumberText.Size = new System.Drawing.Size(157, 21);
            this.phoneNumberText.TabIndex = 6;
            // 
            // taskCreateBtn
            // 
            this.taskCreateBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taskCreateBtn.Location = new System.Drawing.Point(170, 510);
            this.taskCreateBtn.Name = "taskCreateBtn";
            this.taskCreateBtn.Size = new System.Drawing.Size(85, 23);
            this.taskCreateBtn.TabIndex = 7;
            this.taskCreateBtn.Text = "创建任务";
            this.taskCreateBtn.UseVisualStyleBackColor = true;
            this.taskCreateBtn.Click += new System.EventHandler(this.taskCreateBtn_Click);
            // 
            // taskCancelBtn
            // 
            this.taskCancelBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taskCancelBtn.Location = new System.Drawing.Point(553, 510);
            this.taskCancelBtn.Name = "taskCancelBtn";
            this.taskCancelBtn.Size = new System.Drawing.Size(83, 23);
            this.taskCancelBtn.TabIndex = 8;
            this.taskCancelBtn.Text = "取消";
            this.taskCancelBtn.UseVisualStyleBackColor = true;
            this.taskCancelBtn.Click += new System.EventHandler(this.taskCancelBtn_Click);
            // 
            // apkPathLabel
            // 
            this.apkPathLabel.AutoSize = true;
            this.apkPathLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.apkPathLabel.Location = new System.Drawing.Point(3, 436);
            this.apkPathLabel.Name = "apkPathLabel";
            this.apkPathLabel.Size = new System.Drawing.Size(56, 14);
            this.apkPathLabel.TabIndex = 9;
            this.apkPathLabel.Text = "APK路径";
            // 
            // apkPathTextBox
            // 
            this.apkPathTextBox.Location = new System.Drawing.Point(65, 432);
            this.apkPathTextBox.Name = "apkPathTextBox";
            this.apkPathTextBox.Size = new System.Drawing.Size(656, 21);
            this.apkPathTextBox.TabIndex = 10;
            // 
            // apkPathBtn
            // 
            this.apkPathBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.apkPathBtn.Location = new System.Drawing.Point(739, 432);
            this.apkPathBtn.Name = "apkPathBtn";
            this.apkPathBtn.Size = new System.Drawing.Size(84, 23);
            this.apkPathBtn.TabIndex = 11;
            this.apkPathBtn.Text = "选择路径";
            this.apkPathBtn.UseVisualStyleBackColor = true;
            this.apkPathBtn.Click += new System.EventHandler(this.apkPathBtn_Click);
            // 
            // apkPathOpenFileDialog
            // 
            this.apkPathOpenFileDialog.FileName = "openFileDialog1";
            // 
            // nationCodeLabel
            // 
            this.nationCodeLabel.AutoSize = true;
            this.nationCodeLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nationCodeLabel.Location = new System.Drawing.Point(646, 474);
            this.nationCodeLabel.Name = "nationCodeLabel";
            this.nationCodeLabel.Size = new System.Drawing.Size(63, 14);
            this.nationCodeLabel.TabIndex = 12;
            this.nationCodeLabel.Text = "国家编码";
            // 
            // nationCodeTextBox
            // 
            this.nationCodeTextBox.Location = new System.Drawing.Point(715, 469);
            this.nationCodeTextBox.Name = "nationCodeTextBox";
            this.nationCodeTextBox.Size = new System.Drawing.Size(108, 21);
            this.nationCodeTextBox.TabIndex = 13;
            // 
            // TaskCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 543);
            this.Controls.Add(this.nationCodeTextBox);
            this.Controls.Add(this.nationCodeLabel);
            this.Controls.Add(this.apkPathBtn);
            this.Controls.Add(this.apkPathTextBox);
            this.Controls.Add(this.apkPathLabel);
            this.Controls.Add(this.taskCancelBtn);
            this.Controls.Add(this.taskCreateBtn);
            this.Controls.Add(this.phoneNumberText);
            this.Controls.Add(this.IMSIText);
            this.Controls.Add(this.taskNameText);
            this.Controls.Add(this.appNameListView);
            this.Controls.Add(this.IMSILabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.taskNameLabel);
            this.Name = "TaskCreateForm";
            this.Text = "taskCreateForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskCreateForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label taskNameLabel;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label IMSILabel;
        private System.Windows.Forms.ListView appNameListView;
        private System.Windows.Forms.ImageList appImageList;
        private System.Windows.Forms.TextBox taskNameText;
        private System.Windows.Forms.TextBox IMSIText;
        private System.Windows.Forms.TextBox phoneNumberText;
        private System.Windows.Forms.Button taskCreateBtn;
        private System.Windows.Forms.Button taskCancelBtn;
        private System.Windows.Forms.Label apkPathLabel;
        private System.Windows.Forms.TextBox apkPathTextBox;
        private System.Windows.Forms.Button apkPathBtn;
        private System.Windows.Forms.OpenFileDialog apkPathOpenFileDialog;
        private System.Windows.Forms.Label nationCodeLabel;
        private System.Windows.Forms.TextBox nationCodeTextBox;
    }
}