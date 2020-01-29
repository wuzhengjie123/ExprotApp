namespace UpdateApp
{
    partial class Update
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
            D.Forms.GradientColor gradientColor1 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor2 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor3 = new D.Forms.GradientColor();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update));
            D.Forms.GradientColor gradientColor4 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor5 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor6 = new D.Forms.GradientColor();
            this.progressBar1 = new D.Forms.Controls.MProgressBar();
            this.barLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(99, 68);
            this.progressBar1.MinimumSize = new System.Drawing.Size(100, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ShowText = true;
            this.progressBar1.Size = new System.Drawing.Size(498, 30);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Total = 100;
            gradientColor1.FromColor = System.Drawing.Color.White;
            gradientColor1.GradientMode = D.Forms.GradientMode.Vertical;
            gradientColor1.ToColor = System.Drawing.Color.White;
            this.progressBar1.TotalColor = gradientColor1;
            this.progressBar1.Value = 0;
            gradientColor2.FromColor = System.Drawing.Color.White;
            gradientColor2.GradientMode = D.Forms.GradientMode.Vertical;
            gradientColor2.ToColor = System.Drawing.Color.Red;
            this.progressBar1.ValueColor = gradientColor2;
            // 
            // barLabel
            // 
            this.barLabel.BackColor = System.Drawing.Color.Transparent;
            this.barLabel.ForeColor = System.Drawing.Color.Red;
            this.barLabel.Location = new System.Drawing.Point(269, 128);
            this.barLabel.Name = "barLabel";
            this.barLabel.Size = new System.Drawing.Size(130, 17);
            this.barLabel.TabIndex = 10;
            this.barLabel.Text = "正在更新，请稍等...";
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UpdateApp.Properties.Resources.back;
            gradientColor3.FromColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            gradientColor3.GradientMode = D.Forms.GradientMode.Vertical;
            gradientColor3.ToColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.Caption.BackColor = gradientColor3;
            this.Caption.BackImage = null;
            this.Caption.CenterCaption = false;
            this.Caption.CenterControlBox = false;
            this.Caption.CenterTitle = false;
            this.Caption.CloseButtonImage = ((System.Drawing.Image)(resources.GetObject("resource.CloseButtonImage")));
            gradientColor4.FromColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            gradientColor4.GradientMode = D.Forms.GradientMode.None;
            gradientColor4.ToColor = System.Drawing.Color.Empty;
            this.Caption.ControlActivedColor = gradientColor4;
            gradientColor5.FromColor = System.Drawing.Color.Transparent;
            gradientColor5.GradientMode = D.Forms.GradientMode.None;
            gradientColor5.ToColor = System.Drawing.Color.Empty;
            this.Caption.ControlBackColor = gradientColor5;
            this.Caption.ControlBox = true;
            this.Caption.ControlBoxSize = new System.Drawing.Size(24, 24);
            this.Caption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Caption.ForeColor = System.Drawing.Color.Black;
            gradientColor6.FromColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(198)))), ((int)(((byte)(131)))));
            gradientColor6.GradientMode = D.Forms.GradientMode.None;
            gradientColor6.ToColor = System.Drawing.Color.Empty;
            this.Caption.FullButtonBackColor = gradientColor6;
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
            this.Caption.MinimizeBox = false;
            this.Caption.MinimizeBoxImage = ((System.Drawing.Image)(resources.GetObject("resource.MinimizeBoxImage")));
            this.Caption.NormalBoxImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalBoxImage")));
            this.Caption.Padding = new System.Windows.Forms.Padding(4);
            this.Caption.Rectangle = new System.Drawing.Rectangle(1, 1, 659, 40);
            this.Caption.Size = new System.Drawing.Size(659, 40);
            this.Caption.Text = "更新";
            this.Caption.Visible = true;
            this.Caption.Width = 659;
            this.Caption.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Caption.X = 1;
            this.Caption.Y = 1;
            this.ClientSize = new System.Drawing.Size(659, 201);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.barLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新";
            this.Activated += new System.EventHandler(this.Update_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        public D.Forms.Controls.MProgressBar progressBar1;
        public System.Windows.Forms.Label barLabel;
    }
}

