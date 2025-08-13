namespace WebView2Browser
{
    partial class WebView2Form
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
            this.MainWebView2Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MainWebView2Panel
            // 
            this.MainWebView2Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainWebView2Panel.Location = new System.Drawing.Point(0, 0);
            this.MainWebView2Panel.Name = "MainWebView2Panel";
            this.MainWebView2Panel.Size = new System.Drawing.Size(800, 450);
            this.MainWebView2Panel.TabIndex = 0;
            // 
            // WebView2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainWebView2Panel);
            this.Name = "WebView2Form";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.WebView2Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainWebView2Panel;
    }
}