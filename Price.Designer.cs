namespace ExportApp
{
    partial class Price
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Price));
            D.Forms.MBorder mBorder1 = new D.Forms.MBorder();
            D.Forms.MBorder mBorder2 = new D.Forms.MBorder();
            D.Forms.MBorder mBorder3 = new D.Forms.MBorder();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            D.Forms.GradientColor gradientColor1 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor2 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor3 = new D.Forms.GradientColor();
            D.Forms.GradientColor gradientColor4 = new D.Forms.GradientColor();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.mComboBox = new D.Forms.MComboBox();
            this.labPrice = new D.Forms.MLabel();
            this.mLabel1 = new D.Forms.MLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.mLabel2 = new D.Forms.MLabel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this._weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._plateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.Location = new System.Drawing.Point(121, 297);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(166, 39);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrice.Location = new System.Drawing.Point(110, 231);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(221, 31);
            this.txtPrice.TabIndex = 26;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mComboBox
            // 
            this.mComboBox.BackColor = System.Drawing.Color.White;
            this.mComboBox.BorderBottomColor = System.Drawing.Color.Transparent;
            this.mComboBox.BorderBottomStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.mComboBox.BorderBottomWidth = 0;
            this.mComboBox.BorderLeftColor = System.Drawing.Color.Transparent;
            this.mComboBox.BorderLeftStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.mComboBox.BorderLeftWidth = 1;
            this.mComboBox.BorderRightColor = System.Drawing.Color.Transparent;
            this.mComboBox.BorderRightStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.mComboBox.BorderRightWidth = 1;
            this.mComboBox.BorderTopColor = System.Drawing.Color.Transparent;
            this.mComboBox.BorderTopStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.mComboBox.BorderTopWidth = 1;
            this.mComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mComboBox.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mComboBox.Location = new System.Drawing.Point(48, 94);
            this.mComboBox.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.mComboBox.Name = "mComboBox";
            this.mComboBox.SelectedIndex = -1;
            this.mComboBox.SelectedItem = null;
            this.mComboBox.SelectedText = "";
            this.mComboBox.Size = new System.Drawing.Size(445, 35);
            this.mComboBox.TabIndex = 48;
            this.mComboBox.Title = "";
            // 
            // labPrice
            // 
            this.labPrice.Align = D.Forms.TextAlignment.MiddleCenter;
            this.labPrice.BackColor = System.Drawing.Color.Transparent;
            this.labPrice.BackgroundColor = System.Drawing.SystemColors.Control;
            mBorder1.Bottom = 0;
            mBorder1.Color = System.Drawing.Color.Empty;
            mBorder1.Left = 0;
            mBorder1.Right = 0;
            mBorder1.Top = 0;
            mBorder1.Type = D.Forms.BorderType.Dash;
            mBorder1.Width = 0;
            this.labPrice.Border = mBorder1;
            this.labPrice.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPrice.Location = new System.Drawing.Point(29, 235);
            this.labPrice.Name = "labPrice";
            this.labPrice.Radius = 0;
            this.labPrice.RadiusMode = D.Forms.RadiusMode.None;
            this.labPrice.Size = new System.Drawing.Size(75, 23);
            this.labPrice.TabIndex = 49;
            this.labPrice.Text = "价格:";
            // 
            // mLabel1
            // 
            this.mLabel1.Align = D.Forms.TextAlignment.MiddleCenter;
            this.mLabel1.BackColor = System.Drawing.Color.Transparent;
            this.mLabel1.BackgroundColor = System.Drawing.SystemColors.Control;
            mBorder2.Bottom = 0;
            mBorder2.Color = System.Drawing.Color.Empty;
            mBorder2.Left = 0;
            mBorder2.Right = 0;
            mBorder2.Top = 0;
            mBorder2.Type = D.Forms.BorderType.Dash;
            mBorder2.Width = 0;
            this.mLabel1.Border = mBorder2;
            this.mLabel1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mLabel1.Location = new System.Drawing.Point(29, 172);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Radius = 0;
            this.mLabel1.RadiusMode = D.Forms.RadiusMode.None;
            this.mLabel1.Size = new System.Drawing.Size(75, 23);
            this.mLabel1.TabIndex = 51;
            this.mLabel1.Text = "材料:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(110, 168);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(221, 31);
            this.txtName.TabIndex = 50;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mLabel2
            // 
            this.mLabel2.Align = D.Forms.TextAlignment.MiddleCenter;
            this.mLabel2.BackColor = System.Drawing.Color.Transparent;
            this.mLabel2.BackgroundColor = System.Drawing.SystemColors.Control;
            mBorder3.Bottom = 0;
            mBorder3.Color = System.Drawing.Color.Empty;
            mBorder3.Left = 0;
            mBorder3.Right = 0;
            mBorder3.Top = 0;
            mBorder3.Type = D.Forms.BorderType.Dash;
            mBorder3.Width = 0;
            this.mLabel2.Border = mBorder3;
            this.mLabel2.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mLabel2.Location = new System.Drawing.Point(324, 61);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Radius = 0;
            this.mLabel2.RadiusMode = D.Forms.RadiusMode.None;
            this.mLabel2.Size = new System.Drawing.Size(75, 23);
            this.mLabel2.TabIndex = 51;
            this.mLabel2.Text = "已有材料:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(208)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(208)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeight = 26;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._weight,
            this._plateNumber});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.Location = new System.Drawing.Point(530, 61);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(208)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(56)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 50;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(334, 368);
            this.dataGridView.TabIndex = 53;
            // 
            // _weight
            // 
            this._weight.DataPropertyName = "name";
            this._weight.HeaderText = "材料";
            this._weight.Name = "_weight";
            this._weight.ReadOnly = true;
            this._weight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this._weight.Width = 234;
            // 
            // _plateNumber
            // 
            this._plateNumber.DataPropertyName = "price";
            this._plateNumber.HeaderText = "价格";
            this._plateNumber.Name = "_plateNumber";
            this._plateNumber.ReadOnly = true;
            this._plateNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
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
            this.Caption.Rectangle = new System.Drawing.Rectangle(1, 1, 868, 40);
            this.Caption.Size = new System.Drawing.Size(868, 40);
            this.Caption.Text = "D Form";
            this.Caption.Visible = true;
            this.Caption.Width = 868;
            this.Caption.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Caption.X = 1;
            this.Caption.Y = 1;
            this.ClientSize = new System.Drawing.Size(868, 433);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.mLabel2);
            this.Controls.Add(this.mLabel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labPrice);
            this.Controls.Add(this.mComboBox);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnAdd);
            this.Name = "Price";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Price";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPrice;
        public D.Forms.MComboBox mComboBox;
        private D.Forms.MLabel labPrice;
        private D.Forms.MLabel mLabel1;
        private System.Windows.Forms.TextBox txtName;
        private D.Forms.MLabel mLabel2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn _plateNumber;
    }
}