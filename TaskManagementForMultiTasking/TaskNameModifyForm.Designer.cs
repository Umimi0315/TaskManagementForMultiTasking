namespace TaskManagementForMultiTasking
{
    partial class TaskNameModifyForm
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
            this.newTaskNameLabel = new System.Windows.Forms.Label();
            this.taskNameModifyTextBox = new System.Windows.Forms.TextBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newTaskNameLabel
            // 
            this.newTaskNameLabel.AutoSize = true;
            this.newTaskNameLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newTaskNameLabel.Location = new System.Drawing.Point(12, 30);
            this.newTaskNameLabel.Name = "newTaskNameLabel";
            this.newTaskNameLabel.Size = new System.Drawing.Size(77, 14);
            this.newTaskNameLabel.TabIndex = 0;
            this.newTaskNameLabel.Text = "新的任务名";
            // 
            // taskNameModifyTextBox
            // 
            this.taskNameModifyTextBox.Location = new System.Drawing.Point(95, 29);
            this.taskNameModifyTextBox.Name = "taskNameModifyTextBox";
            this.taskNameModifyTextBox.Size = new System.Drawing.Size(244, 21);
            this.taskNameModifyTextBox.TabIndex = 1;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirmBtn.Location = new System.Drawing.Point(48, 75);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 2;
            this.confirmBtn.Text = "确定";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelBtn.Location = new System.Drawing.Point(253, 76);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // TaskNameModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 111);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.taskNameModifyTextBox);
            this.Controls.Add(this.newTaskNameLabel);
            this.Name = "TaskNameModifyForm";
            this.Text = "TaskNameModifyForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskNameModifyForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newTaskNameLabel;
        private System.Windows.Forms.TextBox taskNameModifyTextBox;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}