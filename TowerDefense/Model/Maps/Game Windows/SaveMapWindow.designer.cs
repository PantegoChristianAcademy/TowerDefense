namespace TowerDefense
{
    partial class SaveMapWindow
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
            this.SaveMapBtn = new System.Windows.Forms.Button();
            this.MapNameTB = new System.Windows.Forms.TextBox();
            this.Refresh = new System.Windows.Forms.Timer(this.components);
            this.MapNameCB = new System.Windows.Forms.CheckBox();
            this.ListOfDifficulties = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveMapBtn
            // 
            this.SaveMapBtn.Location = new System.Drawing.Point(78, 103);
            this.SaveMapBtn.Name = "SaveMapBtn";
            this.SaveMapBtn.Size = new System.Drawing.Size(124, 23);
            this.SaveMapBtn.TabIndex = 0;
            this.SaveMapBtn.Text = "Save Map";
            this.SaveMapBtn.UseVisualStyleBackColor = true;
            this.SaveMapBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SaveMapBtn_MouseClick);
            // 
            // MapNameTB
            // 
            this.MapNameTB.Location = new System.Drawing.Point(12, 27);
            this.MapNameTB.Name = "MapNameTB";
            this.MapNameTB.Size = new System.Drawing.Size(260, 20);
            this.MapNameTB.TabIndex = 1;
            // 
            // Refresh
            // 
            this.Refresh.Enabled = true;
            this.Refresh.Interval = 10;
            this.Refresh.Tick += new System.EventHandler(this.Refresh_Tick);
            // 
            // MapNameCB
            // 
            this.MapNameCB.AutoSize = true;
            this.MapNameCB.Location = new System.Drawing.Point(94, 80);
            this.MapNameCB.Name = "MapNameCB";
            this.MapNameCB.Size = new System.Drawing.Size(92, 17);
            this.MapNameCB.TabIndex = 2;
            this.MapNameCB.Text = "Finalize Name";
            this.MapNameCB.UseVisualStyleBackColor = true;
            // 
            // ListOfDifficulties
            // 
            this.ListOfDifficulties.FormattingEnabled = true;
            this.ListOfDifficulties.Location = new System.Drawing.Point(78, 53);
            this.ListOfDifficulties.Name = "ListOfDifficulties";
            this.ListOfDifficulties.Size = new System.Drawing.Size(121, 21);
            this.ListOfDifficulties.TabIndex = 5;
            this.ListOfDifficulties.Text = "Choose Difficulty";
            // 
            // SaveMapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 134);
            this.Controls.Add(this.ListOfDifficulties);
            this.Controls.Add(this.MapNameCB);
            this.Controls.Add(this.MapNameTB);
            this.Controls.Add(this.SaveMapBtn);
            this.Name = "SaveMapWindow";
            this.Text = "SaveMapWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveMapBtn;
        private System.Windows.Forms.TextBox MapNameTB;
        private System.Windows.Forms.Timer Refresh;
        private System.Windows.Forms.CheckBox MapNameCB;
        private System.Windows.Forms.ComboBox ListOfDifficulties;
    }
}