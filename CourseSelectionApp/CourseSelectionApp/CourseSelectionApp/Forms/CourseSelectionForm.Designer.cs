
namespace CourseSelectionApp.Forms
{
    partial class CourseSelectionForm
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
            this._courseCheckSelectionResultButton = new System.Windows.Forms.Button();
            this._buttonsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._courseSubmitButton = new System.Windows.Forms.Button();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._buttonsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _courseCheckSelectionResultButton
            // 
            this._courseCheckSelectionResultButton.Location = new System.Drawing.Point(1082, 8);
            this._courseCheckSelectionResultButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._courseCheckSelectionResultButton.Name = "_courseCheckSelectionResultButton";
            this._courseCheckSelectionResultButton.Size = new System.Drawing.Size(245, 109);
            this._courseCheckSelectionResultButton.TabIndex = 2;
            this._courseCheckSelectionResultButton.Text = "查看選課結果";
            this._courseCheckSelectionResultButton.UseVisualStyleBackColor = true;
            // 
            // _buttonsLayoutPanel
            // 
            this._buttonsLayoutPanel.AutoSize = true;
            this._buttonsLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._buttonsLayoutPanel.Controls.Add(this._courseCheckSelectionResultButton);
            this._buttonsLayoutPanel.Controls.Add(this._courseSubmitButton);
            this._buttonsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._buttonsLayoutPanel.Location = new System.Drawing.Point(0, 486);
            this._buttonsLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._buttonsLayoutPanel.Name = "_buttonsLayoutPanel";
            this._buttonsLayoutPanel.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._buttonsLayoutPanel.Size = new System.Drawing.Size(1336, 125);
            this._buttonsLayoutPanel.TabIndex = 3;
            // 
            // _courseSubmitButton
            // 
            this._courseSubmitButton.Location = new System.Drawing.Point(831, 8);
            this._courseSubmitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._courseSubmitButton.Name = "_courseSubmitButton";
            this._courseSubmitButton.Size = new System.Drawing.Size(245, 109);
            this._courseSubmitButton.TabIndex = 3;
            this._courseSubmitButton.Text = "確認送出";
            this._courseSubmitButton.UseVisualStyleBackColor = true;
            // 
            // _tabControl
            // 
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1336, 486);
            this._tabControl.TabIndex = 4;
            // 
            // CourseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1336, 611);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._buttonsLayoutPanel);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CourseSelectionForm";
            this.Text = "選課";
            this._buttonsLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _courseCheckSelectionResultButton;
        private System.Windows.Forms.FlowLayoutPanel _buttonsLayoutPanel;
        private System.Windows.Forms.Button _courseSubmitButton;
        private System.Windows.Forms.TabControl _tabControl;
    }
}