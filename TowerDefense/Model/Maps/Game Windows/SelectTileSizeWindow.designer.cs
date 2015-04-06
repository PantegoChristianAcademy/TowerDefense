namespace TowerDefense
{
    partial class SelectTileSizeWindow
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
            this.TileSizeCB = new System.Windows.Forms.ComboBox();
            this.CreateMapBtn = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TileSizeCB
            // 
            this.TileSizeCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TileSizeCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TileSizeCB.Font = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TileSizeCB.FormattingEnabled = true;
            this.TileSizeCB.Location = new System.Drawing.Point(51, 14);
            this.TileSizeCB.Name = "TileSizeCB";
            this.TileSizeCB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TileSizeCB.Size = new System.Drawing.Size(133, 50);
            this.TileSizeCB.TabIndex = 0;
            this.TileSizeCB.Text = "Choose Size";
            // 
            // CreateMapBtn
            // 
            this.CreateMapBtn.Enabled = false;
            this.CreateMapBtn.Location = new System.Drawing.Point(12, 70);
            this.CreateMapBtn.Name = "CreateMapBtn";
            this.CreateMapBtn.Size = new System.Drawing.Size(206, 23);
            this.CreateMapBtn.TabIndex = 1;
            this.CreateMapBtn.Text = "Create Map";
            this.CreateMapBtn.UseVisualStyleBackColor = true;
            this.CreateMapBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CreateMapBtn_MouseClick);
            // 
            // Refresh
            // 
            this.Refresh.Enabled = true;
            this.Refresh.Interval = 10;
            this.Refresh.Tick += new System.EventHandler(this.Refresh_Tick);
            // 
            // SelectTileSizeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 97);
            this.Controls.Add(this.CreateMapBtn);
            this.Controls.Add(this.TileSizeCB);
            this.Name = "SelectTileSizeWindow";
            this.Text = "Select Tile Size";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TileSizeCB;
        private System.Windows.Forms.Button CreateMapBtn;
        private System.Windows.Forms.Timer Refresh;
    }
}