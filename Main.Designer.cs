﻿namespace ExportApp
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            D.Forms.GradientColor gradientColor1 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor2 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor3 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor4 = new D.Forms.GradientColor();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataTable2 = new System.Data.DataTable();
            this.buttonSet = new System.Windows.Forms.Button();
            this.uploadBtn = new D.Forms.MButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(322, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 53);
            this.button2.TabIndex = 1;
            this.button2.Text = "选择文件夹";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox.ForeColor = System.Drawing.Color.Black;
            this.richTextBox.Location = new System.Drawing.Point(198, 158);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(832, 342);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // dataTable2
            // 
            this.dataTable2.TableName = "Table2";
            // 
            // buttonSet
            // 
            this.buttonSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSet.BackgroundImage")));
            this.buttonSet.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSet.Location = new System.Drawing.Point(652, 75);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(209, 53);
            this.buttonSet.TabIndex = 1;
            this.buttonSet.Text = "设置";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.BackColor = System.Drawing.Color.Transparent;
            this.uploadBtn.BackgroundColor.FromColor = System.Drawing.Color.Transparent;
            this.uploadBtn.BackgroundColor.GradientMode = D.Forms.GradientMode.Vertical;
            this.uploadBtn.BackgroundColor.ToColor = System.Drawing.Color.Transparent;
            this.uploadBtn.BorderColor = System.Drawing.Color.Transparent;
            this.uploadBtn.BorderHoverColor = System.Drawing.Color.Transparent;
            this.uploadBtn.BorderPressColor = System.Drawing.Color.Transparent;
            this.uploadBtn.BorderWidth = 1;
            this.uploadBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uploadBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.uploadBtn.ForeColor = System.Drawing.Color.Transparent;
            this.uploadBtn.HoverBackColor.FromColor = System.Drawing.Color.Transparent;
            this.uploadBtn.HoverBackColor.GradientMode = D.Forms.GradientMode.None;
            this.uploadBtn.HoverBackColor.ToColor = System.Drawing.Color.Transparent;
            this.uploadBtn.Image = global::ExportApp.Properties.Resources.更新__3_;
            this.uploadBtn.ImageSize = new System.Drawing.Size(35, 35);
            this.uploadBtn.Location = new System.Drawing.Point(984, 4);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Radius = 0;
            this.uploadBtn.RadiusMode = D.Forms.RadiusMode.None;
            this.uploadBtn.Size = new System.Drawing.Size(26, 24);
            this.uploadBtn.TabIndex = 4;
            this.uploadBtn.TextImageRelation = D.Forms.ImageTextRelation.Overlay;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            this.uploadBtn.MouseEnter += new System.EventHandler(this.uploadBtn_MouseEnter);
            this.uploadBtn.MouseLeave += new System.EventHandler(this.uploadBtn_MouseLeave);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ExportApp.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gradientColor1.FromColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            gradientColor1.GradientMode = D.Forms.GradientMode.Vertical;
            gradientColor1.ToColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.Caption.BackColor = gradientColor1;
            this.Caption.BackImage = null;
            this.Caption.CenterCaption = false;
            this.Caption.CenterControlBox = false;
            this.Caption.CenterTitle = false;
            this.Caption.CloseButtonImage = ((System.Drawing.Image)(resources.GetObject("resource.CloseButtonImage")));
            gradientColor2.FromColor = System.Drawing.Color.Red;
            gradientColor2.GradientMode = D.Forms.GradientMode.None;
            gradientColor2.ToColor = System.Drawing.Color.Empty;
            this.Caption.ControlActivedColor = gradientColor2;
            gradientColor3.FromColor = System.Drawing.Color.Transparent;
            gradientColor3.GradientMode = D.Forms.GradientMode.None;
            gradientColor3.ToColor = System.Drawing.Color.Empty;
            this.Caption.ControlBackColor = gradientColor3;
            this.Caption.ControlBox = true;
            this.Caption.ControlBoxSize = new System.Drawing.Size(24, 24);
            this.Caption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Caption.ForeColor = System.Drawing.Color.Black;
            gradientColor4.FromColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(198)))), ((int)(((byte)(131)))));
            gradientColor4.GradientMode = D.Forms.GradientMode.None;
            gradientColor4.ToColor = System.Drawing.Color.Empty;
            this.Caption.FullButtonBackColor = gradientColor4;
            this.Caption.Height = 40;
            this.Caption.HelpButton = false;
            this.Caption.HelpButtonImage = ((System.Drawing.Image)(resources.GetObject("resource.HelpButtonImage")));
            this.Caption.ImageList = null;
            this.Caption.Location = new System.Drawing.Point(1, 1);
            this.Caption.Logo = null;
            this.Caption.LogoSize = new System.Drawing.Size(0, 0);
            this.Caption.LogoVisible = true;
            this.Caption.MaximizeBox = false;
            this.Caption.MaximizeBoxImage = ((System.Drawing.Image)(resources.GetObject("resource.MaximizeBoxImage")));
            this.Caption.MinimizeBox = true;
            this.Caption.MinimizeBoxImage = ((System.Drawing.Image)(resources.GetObject("resource.MinimizeBoxImage")));
            this.Caption.NormalBoxImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalBoxImage")));
            this.Caption.Padding = new System.Windows.Forms.Padding(4);
            this.Caption.Rectangle = new System.Drawing.Rectangle(1, 1, 1071, 40);
            this.Caption.Size = new System.Drawing.Size(1071, 40);
            this.Caption.Text = "壹诺广告";
            this.Caption.Visible = true;
            this.Caption.Width = 1071;
            this.Caption.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Caption.X = 1;
            this.Caption.Y = 1;
            this.ClientSize = new System.Drawing.Size(1071, 532);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.button2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "壹诺广告";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataTable dataTable2;
        private System.Windows.Forms.Button buttonSet;
        private D.Forms.MButton uploadBtn;
    }
}

