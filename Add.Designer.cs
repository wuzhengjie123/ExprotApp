namespace ExportApp
{
    partial class Add
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
            D.Forms.MBorder mBorder1 = new D.Forms.MBorder();
            D.Forms.MBorder mBorder2 = new D.Forms.MBorder();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
            D.Forms.GradientColor gradientColor1 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor2 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor3 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor4 = new D.Forms.GradientColor();
            this.mLabel1 = new D.Forms.MLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labPrice = new D.Forms.MLabel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mLabel1
            // 
            this.mLabel1.Align = D.Forms.TextAlignment.MiddleCenter;
            this.mLabel1.BackColor = System.Drawing.Color.Transparent;
            this.mLabel1.BackgroundColor = System.Drawing.SystemColors.Control;
            mBorder1.Bottom = 0;
            mBorder1.Color = System.Drawing.Color.Empty;
            mBorder1.Left = 0;
            mBorder1.Right = 0;
            mBorder1.Top = 0;
            mBorder1.Type = D.Forms.BorderType.Dash;
            mBorder1.Width = 0;
            this.mLabel1.Border = mBorder1;
            this.mLabel1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mLabel1.Location = new System.Drawing.Point(180, 117);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Radius = 0;
            this.mLabel1.RadiusMode = D.Forms.RadiusMode.None;
            this.mLabel1.Size = new System.Drawing.Size(75, 23);
            this.mLabel1.TabIndex = 56;
            this.mLabel1.Text = "材料:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(261, 113);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(221, 31);
            this.txtName.TabIndex = 55;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labPrice
            // 
            this.labPrice.Align = D.Forms.TextAlignment.MiddleCenter;
            this.labPrice.BackColor = System.Drawing.Color.Transparent;
            this.labPrice.BackgroundColor = System.Drawing.SystemColors.Control;
            mBorder2.Bottom = 0;
            mBorder2.Color = System.Drawing.Color.Empty;
            mBorder2.Left = 0;
            mBorder2.Right = 0;
            mBorder2.Top = 0;
            mBorder2.Type = D.Forms.BorderType.Dash;
            mBorder2.Width = 0;
            this.labPrice.Border = mBorder2;
            this.labPrice.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPrice.Location = new System.Drawing.Point(180, 180);
            this.labPrice.Name = "labPrice";
            this.labPrice.Radius = 0;
            this.labPrice.RadiusMode = D.Forms.RadiusMode.None;
            this.labPrice.Size = new System.Drawing.Size(75, 23);
            this.labPrice.TabIndex = 54;
            this.labPrice.Text = "价格:";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrice.Location = new System.Drawing.Point(261, 176);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(221, 31);
            this.txtPrice.TabIndex = 53;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.Location = new System.Drawing.Point(294, 241);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(166, 39);
            this.btnAdd.TabIndex = 52;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            gradientColor1.FromColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            gradientColor1.GradientMode = D.Forms.GradientMode.Vertical;
            gradientColor1.ToColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.Caption.BackColor = gradientColor1;
            this.Caption.BackImage = null;
            this.Caption.CenterCaption = false;
            this.Caption.CenterControlBox = false;
            this.Caption.CenterTitle = false;
            this.Caption.CloseButtonImage = ((System.Drawing.Image)(resources.GetObject("resource.CloseButtonImage")));
            gradientColor2.FromColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
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
            this.Caption.MaximizeBox = true;
            this.Caption.MaximizeBoxImage = ((System.Drawing.Image)(resources.GetObject("resource.MaximizeBoxImage")));
            this.Caption.MinimizeBox = true;
            this.Caption.MinimizeBoxImage = ((System.Drawing.Image)(resources.GetObject("resource.MinimizeBoxImage")));
            this.Caption.NormalBoxImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalBoxImage")));
            this.Caption.Padding = new System.Windows.Forms.Padding(4);
            this.Caption.Rectangle = new System.Drawing.Rectangle(1, 1, 750, 40);
            this.Caption.Size = new System.Drawing.Size(750, 40);
            this.Caption.Text = "D Form";
            this.Caption.Visible = true;
            this.Caption.Width = 750;
            this.Caption.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Caption.X = 1;
            this.Caption.Y = 1;
            this.ClientSize = new System.Drawing.Size(750, 404);
            this.Controls.Add(this.mLabel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnAdd);
            this.Name = "Add";
            this.Text = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private D.Forms.MLabel mLabel1;
        private System.Windows.Forms.TextBox txtName;
        private D.Forms.MLabel labPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAdd;
    }
}