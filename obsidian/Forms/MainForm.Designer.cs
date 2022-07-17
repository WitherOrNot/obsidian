namespace obsidian
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
            this.components = new System.ComponentModel.Container();
            this.launchButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.verBox = new obsidian.UKComboBox();
            this.acctBox = new obsidian.UKComboBox();
            this.acctButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(294, 248);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(222, 74);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Launch";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // verBox
            // 
            this.verBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.verBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.verBox.FormattingEnabled = true;
            this.verBox.ItemHeight = 30;
            this.verBox.Location = new System.Drawing.Point(294, 90);
            this.verBox.Name = "verBox";
            this.verBox.Size = new System.Drawing.Size(222, 36);
            this.verBox.TabIndex = 3;
            this.verBox.TextAlign = System.Drawing.StringAlignment.Center;
            this.verBox.TextYOffset = 0;
            // 
            // acctBox
            // 
            this.acctBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.acctBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.acctBox.FormattingEnabled = true;
            this.acctBox.ItemHeight = 30;
            this.acctBox.Location = new System.Drawing.Point(294, 132);
            this.acctBox.Name = "acctBox";
            this.acctBox.Size = new System.Drawing.Size(222, 36);
            this.acctBox.TabIndex = 4;
            this.acctBox.TextAlign = System.Drawing.StringAlignment.Center;
            this.acctBox.TextYOffset = 0;
            // 
            // acctButton
            // 
            this.acctButton.BackgroundImage = global::obsidian.Properties.Resources.user;
            this.acctButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.acctButton.Location = new System.Drawing.Point(522, 132);
            this.acctButton.Name = "acctButton";
            this.acctButton.Size = new System.Drawing.Size(39, 36);
            this.acctButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.acctButton, "Edit accounts...");
            this.acctButton.UseVisualStyleBackColor = true;
            this.acctButton.Click += new System.EventHandler(this.acctButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.acctButton);
            this.Controls.Add(this.acctBox);
            this.Controls.Add(this.verBox);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Obsidian Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private UKComboBox verBox;
        private UKComboBox acctBox;
        private System.Windows.Forms.Button acctButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

