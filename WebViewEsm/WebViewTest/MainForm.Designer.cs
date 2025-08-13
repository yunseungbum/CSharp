namespace WebViewTest
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.EsmButton = new System.Windows.Forms.Button();
            this.BeforeDataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AfterDataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PacketLoginBtn = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InfoBtn = new System.Windows.Forms.Button();
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EsmButton
            // 
            this.EsmButton.Location = new System.Drawing.Point(74, 7);
            this.EsmButton.Name = "EsmButton";
            this.EsmButton.Size = new System.Drawing.Size(161, 23);
            this.EsmButton.TabIndex = 0;
            this.EsmButton.Text = "쇼핑몰 연결";
            this.EsmButton.UseVisualStyleBackColor = true;
            this.EsmButton.Click += new System.EventHandler(this.EsmButton_Click);
            // 
            // BeforeDataRichTextBox
            // 
            this.BeforeDataRichTextBox.Location = new System.Drawing.Point(30, 755);
            this.BeforeDataRichTextBox.Name = "BeforeDataRichTextBox";
            this.BeforeDataRichTextBox.Size = new System.Drawing.Size(296, 259);
            this.BeforeDataRichTextBox.TabIndex = 10;
            this.BeforeDataRichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 737);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "이전 데이터";
            // 
            // AfterDataRichTextBox
            // 
            this.AfterDataRichTextBox.Location = new System.Drawing.Point(379, 755);
            this.AfterDataRichTextBox.Name = "AfterDataRichTextBox";
            this.AfterDataRichTextBox.Size = new System.Drawing.Size(296, 259);
            this.AfterDataRichTextBox.TabIndex = 12;
            this.AfterDataRichTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 737);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "최근 데이터";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(337, 356);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(455, 86);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(337, 356);
            this.richTextBox2.TabIndex = 14;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "쿠키A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "쿠키B";
            // 
            // PacketLoginBtn
            // 
            this.PacketLoginBtn.Location = new System.Drawing.Point(515, 7);
            this.PacketLoginBtn.Name = "PacketLoginBtn";
            this.PacketLoginBtn.Size = new System.Drawing.Size(161, 23);
            this.PacketLoginBtn.TabIndex = 17;
            this.PacketLoginBtn.Text = "패킷 로그인";
            this.PacketLoginBtn.UseVisualStyleBackColor = true;
            this.PacketLoginBtn.Click += new System.EventHandler(this.PacketLoginBtn_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(798, 86);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(312, 356);
            this.richTextBox3.TabIndex = 18;
            this.richTextBox3.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "최근 데이터";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(795, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "이전 데이터";
            // 
            // InfoBtn
            // 
            this.InfoBtn.Location = new System.Drawing.Point(448, 482);
            this.InfoBtn.Name = "InfoBtn";
            this.InfoBtn.Size = new System.Drawing.Size(117, 23);
            this.InfoBtn.TabIndex = 21;
            this.InfoBtn.Text = "주문수집";
            this.InfoBtn.UseVisualStyleBackColor = true;
            this.InfoBtn.Click += new System.EventHandler(this.InfoBtnClick);
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.Location = new System.Drawing.Point(448, 511);
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.Size = new System.Drawing.Size(662, 23);
            this.InfoTextBox.TabIndex = 22;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 813);
            this.Controls.Add(this.InfoTextBox);
            this.Controls.Add(this.InfoBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.PacketLoginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.AfterDataRichTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BeforeDataRichTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EsmButton);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EsmButton;
        private System.Windows.Forms.RichTextBox BeforeDataRichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox AfterDataRichTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PacketLoginBtn;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button InfoBtn;
        private System.Windows.Forms.TextBox InfoTextBox;
    }
}

