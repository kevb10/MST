namespace Ksu.Cis300.Mst
{
    partial class UserInterface
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
            this.uxLoad = new System.Windows.Forms.Button();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxGraphDrawing = new Ksu.Cis300.GraphDrawing.GraphDrawing();
            this.SuspendLayout();
            // 
            // uxLoad
            // 
            this.uxLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxLoad.Location = new System.Drawing.Point(12, 207);
            this.uxLoad.Name = "uxLoad";
            this.uxLoad.Size = new System.Drawing.Size(321, 45);
            this.uxLoad.TabIndex = 0;
            this.uxLoad.Text = "Load a File";
            this.uxLoad.UseVisualStyleBackColor = true;
            this.uxLoad.Click += new System.EventHandler(this.uxLoad_Click);
            // 
            // uxGraphDrawing
            // 
            this.uxGraphDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxGraphDrawing.AutoScroll = true;
            this.uxGraphDrawing.GraphSize = new System.Drawing.Size(150, 150);
            this.uxGraphDrawing.Location = new System.Drawing.Point(12, 13);
            this.uxGraphDrawing.Name = "uxGraphDrawing";
            this.uxGraphDrawing.Size = new System.Drawing.Size(321, 181);
            this.uxGraphDrawing.TabIndex = 1;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(345, 264);
            this.Controls.Add(this.uxGraphDrawing);
            this.Controls.Add(this.uxLoad);
            this.MinimumSize = new System.Drawing.Size(355, 296);
            this.Name = "UserInterface";
            this.Text = "Find MST";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxLoad;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
        private GraphDrawing.GraphDrawing uxGraphDrawing;
    }
}

