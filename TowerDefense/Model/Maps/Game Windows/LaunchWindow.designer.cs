namespace TowerDefense
{
    partial class LaunchWindow
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
            this.Refresh = new System.Windows.Forms.Timer(this.components);
            this.CreateMapButton = new System.Windows.Forms.Button();
            this.LoadMapButton = new System.Windows.Forms.Button();
            this.DeleteMapBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Refresh
            // 
            this.Refresh.Enabled = true;
            this.Refresh.Interval = 10;
            this.Refresh.Tick += new System.EventHandler(this.Refresh_Tick);
            // 
            // CreateMapButton
            // 
            this.CreateMapButton.BackColor = System.Drawing.Color.Green;
            this.CreateMapButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateMapButton.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateMapButton.Location = new System.Drawing.Point(12, 12);
            this.CreateMapButton.Name = "CreateMapButton";
            this.CreateMapButton.Size = new System.Drawing.Size(250, 150);
            this.CreateMapButton.TabIndex = 0;
            this.CreateMapButton.Text = "Make Your Own Map";
            this.CreateMapButton.UseVisualStyleBackColor = false;
            this.CreateMapButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CreateMapButton_MouseClick);
            // 
            // LoadMapButton
            // 
            this.LoadMapButton.BackColor = System.Drawing.Color.Blue;
            this.LoadMapButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadMapButton.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadMapButton.Location = new System.Drawing.Point(268, 12);
            this.LoadMapButton.Name = "LoadMapButton";
            this.LoadMapButton.Size = new System.Drawing.Size(250, 150);
            this.LoadMapButton.TabIndex = 1;
            this.LoadMapButton.Text = "Load A Map";
            this.LoadMapButton.UseVisualStyleBackColor = false;
            this.LoadMapButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LoadMapButton_MouseClick);
            // 
            // DeleteMapBtn
            // 
            this.DeleteMapBtn.BackColor = System.Drawing.Color.Red;
            this.DeleteMapBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteMapBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteMapBtn.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteMapBtn.Location = new System.Drawing.Point(12, 168);
            this.DeleteMapBtn.Name = "DeleteMapBtn";
            this.DeleteMapBtn.Size = new System.Drawing.Size(443, 49);
            this.DeleteMapBtn.TabIndex = 2;
            this.DeleteMapBtn.Text = "Destroy Your Own Map";
            this.DeleteMapBtn.UseVisualStyleBackColor = false;
            this.DeleteMapBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteMapBtn_MouseClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Uighur", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(461, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // LaunchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(529, 226);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DeleteMapBtn);
            this.Controls.Add(this.LoadMapButton);
            this.Controls.Add(this.CreateMapButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "LaunchWindow";
            this.Text = "Tower Defense Launcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Refresh;
        private System.Windows.Forms.Button CreateMapButton;
        private System.Windows.Forms.Button LoadMapButton;
        private System.Windows.Forms.Button DeleteMapBtn;
        private System.Windows.Forms.Button button1;
    }
}

