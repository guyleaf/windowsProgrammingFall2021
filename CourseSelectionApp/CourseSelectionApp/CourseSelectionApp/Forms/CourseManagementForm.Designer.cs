
namespace CourseSelectionApp.Forms
{
    partial class CourseManagementForm
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
            this._welcomeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _welcomeLabel
            // 
            this._welcomeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._welcomeLabel.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._welcomeLabel.Location = new System.Drawing.Point(0, 0);
            this._welcomeLabel.Name = "_welcomeLabel";
            this._welcomeLabel.Size = new System.Drawing.Size(933, 600);
            this._welcomeLabel.TabIndex = 0;
            this._welcomeLabel.Text = "Comming Soon";
            this._welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 600);
            this.Controls.Add(this._welcomeLabel);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CourseManagementForm";
            this.Text = "課程管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _welcomeLabel;
    }
}