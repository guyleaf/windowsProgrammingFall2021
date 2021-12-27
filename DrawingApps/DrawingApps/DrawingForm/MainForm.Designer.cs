
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._lineDrawingButton = new System.Windows.Forms.Button();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._undoButton = new System.Windows.Forms.ToolStripButton();
            this._redoButton = new System.Windows.Forms.ToolStripButton();
            this._clearButton = new System.Windows.Forms.Button();
            this._ellipseDrawingButton = new System.Windows.Forms.Button();
            this._rectangleDrawingButton = new System.Windows.Forms.Button();
            this._selectedShapeMessage = new System.Windows.Forms.Label();
            this._canvas = new DrawingForm.Canvas();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this._toolStrip.SuspendLayout();
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
            this._splitContainer.Panel1.Controls.Add(this._lineDrawingButton);
            this._splitContainer.Panel1.Controls.Add(this._toolStrip);
            this._splitContainer.Panel1.Controls.Add(this._clearButton);
            this._splitContainer.Panel1.Controls.Add(this._ellipseDrawingButton);
            this._splitContainer.Panel1.Controls.Add(this._rectangleDrawingButton);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._selectedShapeMessage);
            this._splitContainer.Panel2.Controls.Add(this._canvas);
            this._splitContainer.Size = new System.Drawing.Size(1142, 611);
            this._splitContainer.SplitterDistance = 86;
            this._splitContainer.SplitterWidth = 1;
            this._splitContainer.TabIndex = 0;
            // 
            // _lineDrawingButton
            // 
            this._lineDrawingButton.AccessibleName = "Line";
            this._lineDrawingButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._lineDrawingButton.Location = new System.Drawing.Point(632, 34);
            this._lineDrawingButton.Name = "_lineDrawingButton";
            this._lineDrawingButton.Size = new System.Drawing.Size(105, 37);
            this._lineDrawingButton.TabIndex = 5;
            this._lineDrawingButton.TabStop = false;
            this._lineDrawingButton.Text = "Line";
            this._lineDrawingButton.UseVisualStyleBackColor = true;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._undoButton,
            this._redoButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(1142, 25);
            this._toolStrip.TabIndex = 4;
            // 
            // _undoButton
            // 
            this._undoButton.AccessibleName = "Undo";
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._undoButton.Enabled = false;
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(43, 22);
            this._undoButton.Text = "Undo";
            // 
            // _redoButton
            // 
            this._redoButton.AccessibleName = "Redo";
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._redoButton.Enabled = false;
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(42, 22);
            this._redoButton.Text = "Redo";
            // 
            // _clearButton
            // 
            this._clearButton.AccessibleName = "Clear";
            this._clearButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._clearButton.Location = new System.Drawing.Point(857, 34);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(105, 37);
            this._clearButton.TabIndex = 3;
            this._clearButton.TabStop = false;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            // 
            // _ellipseDrawingButton
            // 
            this._ellipseDrawingButton.AccessibleName = "Ellipse";
            this._ellipseDrawingButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._ellipseDrawingButton.Location = new System.Drawing.Point(403, 34);
            this._ellipseDrawingButton.Name = "_ellipseDrawingButton";
            this._ellipseDrawingButton.Size = new System.Drawing.Size(105, 37);
            this._ellipseDrawingButton.TabIndex = 2;
            this._ellipseDrawingButton.TabStop = false;
            this._ellipseDrawingButton.Text = "Ellipse";
            this._ellipseDrawingButton.UseVisualStyleBackColor = true;
            // 
            // _rectangleDrawingButton
            // 
            this._rectangleDrawingButton.AccessibleName = "Rectangle";
            this._rectangleDrawingButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._rectangleDrawingButton.Location = new System.Drawing.Point(174, 34);
            this._rectangleDrawingButton.Name = "_rectangleDrawingButton";
            this._rectangleDrawingButton.Size = new System.Drawing.Size(105, 37);
            this._rectangleDrawingButton.TabIndex = 1;
            this._rectangleDrawingButton.TabStop = false;
            this._rectangleDrawingButton.Text = "Rectangle";
            this._rectangleDrawingButton.UseVisualStyleBackColor = true;
            // 
            // _selectedShapeMessage
            // 
            this._selectedShapeMessage.AutoSize = true;
            this._selectedShapeMessage.Location = new System.Drawing.Point(902, 486);
            this._selectedShapeMessage.Name = "_selectedShapeMessage";
            this._selectedShapeMessage.Size = new System.Drawing.Size(66, 16);
            this._selectedShapeMessage.TabIndex = 1;
            this._selectedShapeMessage.Text = "Selected : ";
            this._selectedShapeMessage.Visible = false;
            // 
            // _canvas
            // 
            this._canvas.AccessibleName = "Canvas";
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._canvas.MinimumSize = new System.Drawing.Size(1142, 699);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(1142, 699);
            this._canvas.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1142, 611);
            this.Controls.Add(this._splitContainer);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Drawing";
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel1.PerformLayout();
            this._splitContainer.Panel2.ResumeLayout(false);
            this._splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.Button _rectangleDrawingButton;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _ellipseDrawingButton;
        private DrawingForm.Canvas _canvas;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _undoButton;
        private System.Windows.Forms.ToolStripButton _redoButton;
        private System.Windows.Forms.Button _lineDrawingButton;
        private System.Windows.Forms.Label _selectedShapeMessage;
    }
}