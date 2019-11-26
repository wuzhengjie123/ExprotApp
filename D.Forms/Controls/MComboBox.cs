using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;

namespace D.Forms
{
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("Items")]
    public partial class MComboBox : MBorderControl
    {
        public MComboBox()
        {
            InitializeComponent();
        }

        [Browsable(true), Description("SelectedIndexChanged"), Category("D")]
        public event EventHandler SelectedIndexChanged;
        [Browsable(true), Description("SelectedValueChanged"), Category("D")]
        public event EventHandler SelectedValueChanged;

        [Browsable(true), Description("DropDownStyle"), Category("D")]
        public ComboBoxStyle DropDownStyle { get { return comboBox1.DropDownStyle; } set { comboBox1.DropDownStyle = value; } }
        [Browsable(true), Description("SelectedIndex"), Category("D")]
        public int SelectedIndex { get { return comboBox1.SelectedIndex; } set { comboBox1.SelectedIndex = value; } }
        [Browsable(true), Description("SelectedItem"), Category("D")]
        public object SelectedItem { get { return comboBox1.SelectedItem; } set { comboBox1.SelectedItem = value; } }
        [Browsable(true), Description("Text"), Category("D")]
        public override string Text { get { return comboBox1.Text; } set { comboBox1.Text = value; } }
        [Browsable(true), Description("SelectedText"), Category("D")]
        public string SelectedText { get { return comboBox1.SelectedText; } set { comboBox1.SelectedText = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        [Browsable(true), Description("Items"), Category("D")]
        public ComboBox.ObjectCollection Items { get { return comboBox1.Items; } }

        [Browsable(true), Description("Text"), Category("D")]
        public string Title
        {
            get { return lblTitle.Text; }
            set
            {
                lblTitle.Text = value;
                this.comboBox1.Location = new Point(this.lblTitle.Width + 9, (this.Height - this.comboBox1.Height) / 2);
                this.comboBox1.Width = this.Width - this.comboBox1.Location.X - 2;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIndexChanged?.Invoke(sender, e);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.SelectedValueChanged?.Invoke(sender, e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.comboBox1.Location = new Point(this.lblTitle.Width + 9, (this.Height - this.comboBox1.Height) / 2);
            this.comboBox1.Width = this.Width - this.comboBox1.Location.X - 2;
            this.lblTitle.Location = new Point(3, (this.Height - this.lblTitle.Height) / 2);
        }
    }
}
