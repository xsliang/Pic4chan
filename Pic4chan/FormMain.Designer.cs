namespace Pic4chan
{
    partial class FormMain
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
            this.pcbMS = new System.Windows.Forms.PictureBox();
            this.OK = new System.Windows.Forms.Button();
            this.resultText = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseCultureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animeMangaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oekakiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscNSFWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adultNSFWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcbMS
            // 
            this.pcbMS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbMS.Location = new System.Drawing.Point(452, 58);
            this.pcbMS.Name = "pcbMS";
            this.pcbMS.Size = new System.Drawing.Size(311, 236);
            this.pcbMS.TabIndex = 0;
            this.pcbMS.TabStop = false;
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(12, 29);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "GetThem:)";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // resultText
            // 
            this.resultText.BackColor = System.Drawing.Color.Black;
            this.resultText.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultText.ForeColor = System.Drawing.Color.Lime;
            this.resultText.Location = new System.Drawing.Point(12, 58);
            this.resultText.Multiline = true;
            this.resultText.Name = "resultText";
            this.resultText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultText.Size = new System.Drawing.Size(435, 236);
            this.resultText.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(763, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.japaneseCultureToolStripMenuItem,
            this.interestsToolStripMenuItem,
            this.creativeToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.miscNSFWToolStripMenuItem,
            this.adultNSFWToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(51, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // japaneseCultureToolStripMenuItem
            // 
            this.japaneseCultureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animeMangaToolStripMenuItem});
            this.japaneseCultureToolStripMenuItem.Name = "japaneseCultureToolStripMenuItem";
            this.japaneseCultureToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.japaneseCultureToolStripMenuItem.Text = "Japanese Culture";
            // 
            // animeMangaToolStripMenuItem
            // 
            this.animeMangaToolStripMenuItem.Name = "animeMangaToolStripMenuItem";
            this.animeMangaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.animeMangaToolStripMenuItem.Text = "Anime & Manga";
            this.animeMangaToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // interestsToolStripMenuItem
            // 
            this.interestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoGamesToolStripMenuItem});
            this.interestsToolStripMenuItem.Name = "interestsToolStripMenuItem";
            this.interestsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.interestsToolStripMenuItem.Text = "Interests";
            // 
            // videoGamesToolStripMenuItem
            // 
            this.videoGamesToolStripMenuItem.Name = "videoGamesToolStripMenuItem";
            this.videoGamesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.videoGamesToolStripMenuItem.Text = "Video Games";
            this.videoGamesToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // creativeToolStripMenuItem
            // 
            this.creativeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oekakiToolStripMenuItem});
            this.creativeToolStripMenuItem.Name = "creativeToolStripMenuItem";
            this.creativeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.creativeToolStripMenuItem.Text = "Creative";
            // 
            // oekakiToolStripMenuItem
            // 
            this.oekakiToolStripMenuItem.Name = "oekakiToolStripMenuItem";
            this.oekakiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oekakiToolStripMenuItem.Text = "Oekaki";
            this.oekakiToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.travelToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // travelToolStripMenuItem
            // 
            this.travelToolStripMenuItem.Name = "travelToolStripMenuItem";
            this.travelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.travelToolStripMenuItem.Text = "Travel";
            this.travelToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // miscNSFWToolStripMenuItem
            // 
            this.miscNSFWToolStripMenuItem.Name = "miscNSFWToolStripMenuItem";
            this.miscNSFWToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.miscNSFWToolStripMenuItem.Text = "Misc. (NSFW)";
            // 
            // adultNSFWToolStripMenuItem
            // 
            this.adultNSFWToolStripMenuItem.Name = "adultNSFWToolStripMenuItem";
            this.adultNSFWToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.adultNSFWToolStripMenuItem.Text = "Adult (NSFW)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 308);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.pcbMS);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Pic4chan";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbMS;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox resultText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japaneseCultureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animeMangaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oekakiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem travelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miscNSFWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adultNSFWToolStripMenuItem;
    }
}

