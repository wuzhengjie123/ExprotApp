using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using D.Forms;

namespace ExportApp
{
    public partial class Add : MForm
    {
        public Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SQLiteParameter[] sp =
           {
                new SQLiteParameter("@id",DbType.Int32)
            };
            sp[0].Value = 1;
            //sp.
            //SQLiteHelper.SetConnectionString("D:\\用户目录\\我的文档\\Visual Studio 2015\\Projects\\WindowsFormsApplication2\\WindowsFormsApplication2\\midtrans.db",null,3);
            string cd = System.Environment.CurrentDirectory;
            string pd = Directory.GetParent(Directory.GetParent(cd).FullName).FullName;
            pd += "\\export.db";
            //MessageBox.Show(str2);
            SQLiteHelper.SetConnectionString(pd, null, 3);
            DataTable dt = SQLiteHelper.ExecuteQuery("select * from Bs_Materials where id = @id", sp);
            Int64 aa = dt.Rows.Count;
            //dataGridView1.DataSource = dt;

        }
    }
}
