namespace TowerDefense
{
    partial class MapSelectorWindow
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
            this.ListOfMaps = new System.Windows.Forms.ListBox();
            this.ListOfDifficulties = new System.Windows.Forms.ComboBox();
            this.TakeActionBtn = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ListOfMaps
            // 
            this.ListOfMaps.Enabled = false;
            this.ListOfMaps.FormattingEnabled = true;
            this.ListOfMaps.Location = new System.Drawing.Point(12, 38);
            this.ListOfMaps.Name = "ListOfMaps";
            this.ListOfMaps.Size = new System.Drawing.Size(260, 147);
            this.ListOfMaps.TabIndex = 0;
            // 
            // ListOfDifficulties
            // 
            this.ListOfDifficulties.FormattingEnabled = true;
            this.ListOfDifficulties.Location = new System.Drawing.Point(88, 11);
            this.ListOfDifficulties.Name = "ListOfDifficulties";
            this.ListOfDifficulties.Size = new System.Drawing.Size(106, 21);
            this.ListOfDifficulties.TabIndex = 1;
            this.ListOfDifficulties.Text = "Choose Difficulty";
            this.ListOfDifficulties.SelectedValueChanged += new System.EventHandler(this.ListOfDifficulties_SelectedValueChanged);
            // 
            // TakeActionBtn
            // 
            this.TakeActionBtn.Enabled = false;
            this.TakeActionBtn.Location = new System.Drawing.Point(12, 191);
            this.TakeActionBtn.Name = "TakeActionBtn";
            this.TakeActionBtn.Size = new System.Drawing.Size(260, 23);
            this.TakeActionBtn.TabIndex = 2;
            this.TakeActionBtn.Text = "Take Action";
            this.TakeActionBtn.UseVisualStyleBackColor = true;
            this.TakeActionBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseMapBtn_MouseClick);
            // 
            // Refresh
            // 
            this.Refresh.Enabled = true;
            this.Refresh.Interval = 10;
            this.Refresh.Tick += new System.EventHandler(this.Refresh_Tick);
            // 
            // MapSelectorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 222);
            this.Controls.Add(this.TakeActionBtn);
            this.Controls.Add(this.ListOfDifficulties);
            this.Controls.Add(this.ListOfMaps);
            this.Name = "MapSelectorWindow";
            this.Text = "Temp Text";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfMaps;
        private System.Windows.Forms.ComboBox ListOfDifficulties;
        private System.Windows.Forms.Button TakeActionBtn;
        private System.Windows.Forms.Timer Refresh;
    }
}