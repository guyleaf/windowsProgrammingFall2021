
namespace CourseSelectionApp.Forms
{
    partial class CourseSelectionResultForm
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
            this._courseSelectionResultGridComponent = new CourseSelectionApp.UserControls.CourseSelectionResultGridComponent();
            this.SuspendLayout();
            // 
            // _courseSelectionResultGridComponent
            // 
            this._courseSelectionResultGridComponent.AutoSize = true;
            this._courseSelectionResultGridComponent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._courseSelectionResultGridComponent.DataGridViewDataSource = null;
            this._courseSelectionResultGridComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseSelectionResultGridComponent.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._courseSelectionResultGridComponent.Location = new System.Drawing.Point(0, 0);
            this._courseSelectionResultGridComponent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._courseSelectionResultGridComponent.Name = "_courseSelectionResultGridComponent";
            this._courseSelectionResultGridComponent.Size = new System.Drawing.Size(1338, 622);
            this._courseSelectionResultGridComponent.TabIndex = 0;
            // 
            // CourseSelectionResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 622);
            this.Controls.Add(this._courseSelectionResultGridComponent);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CourseSelectionResultForm";
            this.RightToLeftLayout = true;
            this.Text = "選課結果";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.CourseSelectionResultGridComponent _courseSelectionResultGridComponent;
    }
}