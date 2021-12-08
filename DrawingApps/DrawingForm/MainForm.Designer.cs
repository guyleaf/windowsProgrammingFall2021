
namespace DrawingForm
{
    partial class MainForm
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
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._clearButton = new System.Windows.Forms.Button();
            this._ellipseDrawingButton = new System.Windows.Forms.Button();
            this._rectangleDrawingButton = new System.Windows.Forms.Button();
            this._canvas = new DrawingForm.Canvas();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer.IsSplitterFixed = true;
            this._splitContainer.Location = new System.Drawing.Point(0, 0);
            this._splitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._splitContainer.Name = "_splitContainer";
            this._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._clearButton);
            this._splitContainer.Panel1.Controls.Add(this._ellipseDrawingButton);
            this._splitContainer.Panel1.Controls.Add(this._rectangleDrawingButton);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._canvas);
            this._splitContainer.Size = new System.Drawing.Size(933, 600);
            this._splitContainer.SplitterDistance = 86;
            this._splitContainer.SplitterWidth = 1;
            this._splitContainer.TabIndex = 0;
            // 
            // _clearButton
            // 
            this._clearButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._clearButton.Location = new System.Drawing.Point(752, 25);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(105, 37);
            this._clearButton.TabIndex = 3;
            this._clearButton.TabStop = false;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            // 
            // _ellipseDrawingButton
            // 
            this._ellipseDrawingButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._ellipseDrawingButton.Location = new System.Drawing.Point(414, 25);
            this._ellipseDrawingButton.Name = "_ellipseDrawingButton";
            this._ellipseDrawingButton.Size = new System.Drawing.Size(105, 37);
            this._ellipseDrawingButton.TabIndex = 2;
            this._ellipseDrawingButton.TabStop = false;
            this._ellipseDrawingButton.Text = "Ellipse";
            this._ellipseDrawingButton.UseVisualStyleBackColor = true;
            // 
            // _rectangleDrawingButton
            // 
            this._rectangleDrawingButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._rectangleDrawingButton.Location = new System.Drawing.Point(69, 25);
            this._rectangleDrawingButton.Name = "_rectangleDrawingButton";
            this._rectangleDrawingButton.Size = new System.Drawing.Size(105, 37);
            this._rectangleDrawingButton.TabIndex = 1;
            this._rectangleDrawingButton.TabStop = false;
            this._rectangleDrawingButton.Text = "Rectangle";
            this._rectangleDrawingButton.UseVisualStyleBackColor = true;
            // 
            // _canvas
            // 
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(933, 513);
            this._canvas.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(933, 600);
            this.Controls.Add(this._splitContainer);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Drawing";
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.Button _rectangleDrawingButton;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _ellipseDrawingButton;
        private DrawingForm.Canvas _canvas;
    }
}