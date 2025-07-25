﻿namespace FileExplorer
{
    partial class FileExplorer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileExplorer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.FrontButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.ListView = new System.Windows.Forms.ListView();
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReMakeDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RightPanel = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FilePath);
            this.panel1.Controls.Add(this.FrontButton);
            this.panel1.Controls.Add(this.BackButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 38);
            this.panel1.TabIndex = 1;
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(55, 11);
            this.FilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(693, 23);
            this.FilePath.TabIndex = 4;
            // 
            // FrontButton
            // 
            this.FrontButton.Location = new System.Drawing.Point(29, 4);
            this.FrontButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FrontButton.Name = "FrontButton";
            this.FrontButton.Size = new System.Drawing.Size(20, 29);
            this.FrontButton.TabIndex = 3;
            this.FrontButton.Text = ">";
            this.FrontButton.UseVisualStyleBackColor = true;
            this.FrontButton.Click += new System.EventHandler(this.BeforeButtonClick);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(3, 4);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(20, 29);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "<";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(-3, 31);
            this.TreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(200, 492);
            this.TreeView.TabIndex = 4;
            this.TreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewBeforeExpand);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewAfterSelect);
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.ComboBox);
            this.LeftPanel.Controls.Add(this.TreeView);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 38);
            this.LeftPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 524);
            this.LeftPanel.TabIndex = 2;
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName,
            this.State,
            this.ReMakeDate,
            this.Category,
            this.Size});
            this.ListView.HideSelection = false;
            this.ListView.LargeImageList = this.imageList1;
            this.ListView.Location = new System.Drawing.Point(-3, 31);
            this.ListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(600, 493);
            this.ListView.TabIndex = 5;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.DoubleClick += new System.EventHandler(this.ListViewDoubleClick);
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "이름";
            this.ColumnName.Width = 150;
            // 
            // State
            // 
            this.State.Text = "상태";
            // 
            // ReMakeDate
            // 
            this.ReMakeDate.Text = "수정날짜";
            this.ReMakeDate.Width = 100;
            // 
            // Category
            // 
            this.Category.Text = "유형";
            // 
            // Size
            // 
            this.Size.Text = "크기";
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.ListView);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(200, 38);
            this.RightPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(600, 524);
            this.RightPanel.TabIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folderopened_yellow.ico");
            this.imageList1.Images.SetKeyName(1, "Hopstarter-Sleek-Xp-Basic-Document-Blank.ico");
            // 
            // ComboBox
            // 
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Items.AddRange(new object[] {
            "Details",
            "SmallIcon",
            "LargeIcon",
            "List",
            "Tile"});
            this.ComboBox.Location = new System.Drawing.Point(0, 0);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(121, 23);
            this.ComboBox.TabIndex = 7;
            this.ComboBox.Text = "Details";
            this.ComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // FileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FileExplorer";
            this.ShowIcon = false;
            this.Text = "파일 탐색기";
            this.Load += new System.EventHandler(this.FileExplorerLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Button FrontButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader ReMakeDate;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox ComboBox;
    }
}

