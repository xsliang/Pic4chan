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
            this.url = new System.Windows.Forms.TextBox();
            this.resultText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMS)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbMS
            // 
            this.pcbMS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbMS.Location = new System.Drawing.Point(764, 41);
            this.pcbMS.Name = "pcbMS";
            this.pcbMS.Size = new System.Drawing.Size(497, 561);
            this.pcbMS.TabIndex = 0;
            this.pcbMS.TabStop = false;
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(268, 10);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(12, 14);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(250, 19);
            this.url.TabIndex = 2;
            this.url.Text = "http://www.4chan.org/ck/";
            // 
            // resultText
            // 
            this.resultText.BackColor = System.Drawing.Color.Black;
            this.resultText.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultText.ForeColor = System.Drawing.Color.Lime;
            this.resultText.Location = new System.Drawing.Point(12, 41);
            this.resultText.Multiline = true;
            this.resultText.Name = "resultText";
            this.resultText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultText.Size = new System.Drawing.Size(726, 561);
            this.resultText.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 986);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.url);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.pcbMS);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pcbMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbMS;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.TextBox resultText;
    }
}

