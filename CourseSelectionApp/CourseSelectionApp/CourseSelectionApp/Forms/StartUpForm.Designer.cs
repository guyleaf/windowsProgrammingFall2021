
namespace CourseSelectionApp.Forms
{
    partial class StartUpForm
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
            this._flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._exitButton = new System.Windows.Forms.Button();
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._courseSelectionButton = new System.Windows.Forms.Button();
            this._courseManagementButton = new System.Windows.Forms.Button();
            this._flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _flowLayoutPanel
            // 
            this._flowLayoutPanel.AutoSize = true;
            this._flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._flowLayoutPanel.Controls.Add(this._exitButton);
            this._flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._flowLayoutPanel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._flowLayoutPanel.Location = new System.Drawing.Point(0, 459);
            this._flowLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._flowLayoutPanel.Name = "_flowLayoutPanel";
            this._flowLayoutPanel.Size = new System.Drawing.Size(933, 141);
            this._flowLayoutPanel.TabIndex = 0;
            // 
            // _exitButton
            // 
            this._exitButton.AutoSize = true;
            this._exitButton.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._exitButton.Location = new System.Drawing.Point(580, 4);
            this._exitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(350, 133);
            this._exitButton.TabIndex = 0;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.IsSplitterFixed = true;
            this._splitContainer.Location = new System.Drawing.Point(0, 0);
            this._splitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._splitContainer.Name = "_splitContainer";
            this._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._courseSelectionButton);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._courseManagementButton);
            this._splitContainer.Size = new System.Drawing.Size(933, 459);
            this._splitContainer.SplitterDistance = 229;
            this._splitContainer.SplitterWidth = 5;
            this._splitContainer.TabIndex = 1;
            // 
            // _courseSelectionButton
            // 
            this._courseSelectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseSelectionButton.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._courseSelectionButton.Location = new System.Drawing.Point(0, 0);
            this._courseSelectionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._courseSelectionButton.Name = "_courseSelectionButton";
            this._courseSelectionButton.Size = new System.Drawing.Size(933, 229);
            this._courseSelectionButton.TabIndex = 0;
            this._courseSelectionButton.Text = "Course Selecting System";
            this._courseSelectionButton.UseVisualStyleBackColor = true;
            // 
            // _courseManagementButton
            // 
            this._courseManagementButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseManagementButton.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold);
            this._courseManagementButton.Location = new System.Drawing.Point(0, 0);
            this._courseManagementButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._courseManagementButton.Name = "_courseManagementButton";
            this._courseManagementButton.Size = new System.Drawing.Size(933, 225);
            this._courseManagementButton.TabIndex = 0;
            this._courseManagementButton.Text = "Course Management System";
            this._courseManagementButton.UseVisualStyleBackColor = true;
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 600);
            this.Controls.Add(this._splitContainer);
            this.Controls.Add(this._flowLayoutPanel);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(372, 0);
            this.Name = "StartUpForm";
            this.Text = "起始畫面";
            this._flowLayoutPanel.ResumeLayout(false);
            this._flowLayoutPanel.PerformLayout();
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanel;
        private System.Windows.Forms.Button _exitButton;
        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.Button _courseSelectionButton;
        private System.Windows.Forms.Button _courseManagementButton;
    }
}