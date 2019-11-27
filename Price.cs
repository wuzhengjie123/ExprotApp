using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using D.Forms;

namespace ExportApp
{
    public partial class Price : MForm
    {

        public static Price priceForm = new Price();
        public Dictionary<String, double> map = new Dictionary<String, double>();
        public Price()
        {
            priceForm = this;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("材料不能输入空");
                return;
            }
            Regex reg = new Regex("^(\\-|\\+)?\\d+(\\.\\d+)?$");
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("价格不能输入空");
                return;
            }
            if (!reg.IsMatch(txtPrice.Text))
            {
                MessageBox.Show("价格为整数或者小数");
                return;
            }
            SQLiteParameter[] nameSp = {
                new SQLiteParameter("@name",DbType.String)
            };
            //查询材料是否重复
            nameSp[0].Value = txtName.Text;

            Int64 sameName = (Int64)SQLiteHelper.ExecuteScalar("select count(id) from Bs_Materials where name = @name", nameSp);
            if (sameName > 0)
            {

                DialogResult dr = MessageBox.Show("是否替换已有材料？", "确认框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //点确定的代码
                    SQLiteParameter[] updateSp = {
                         new SQLiteParameter("@price",DbType.Double),
                         new SQLiteParameter("@name",DbType.String)

                    };
                    updateSp[0].Value = txtPrice.Text;
                    updateSp[1].Value = txtName.Text;
                    Int64 updateCount = SQLiteHelper.ExecuteNonQuery("update Bs_Materials set price = @price where name = @name", updateSp);
                    if (updateCount > 0)
                    {
                        MessageBox.Show("更新成功！");
                    }
                    else
                    {
                        MessageBox.Show("更新失败！");
                    }
                }
                else
                {
                    //点取消的代码 
                    return;
                }
            }
            else
            {
                SQLiteParameter[] sp ={
                new SQLiteParameter("@id",DbType.Int32),
                new SQLiteParameter("@name",DbType.String),
                new SQLiteParameter("@price",DbType.Double)
                  };
                Int64 id = (Int64)SQLiteHelper.ExecuteScalar("select max(id) from Bs_Materials");
                sp[0].Value = id + 1;
                sp[1].Value = txtName.Text;
                sp[2].Value = double.Parse(txtPrice.Text);
                Int64 count = SQLiteHelper.ExecuteNonQuery("insert into Bs_Materials(id,name,price) values(@id,@name,@price)", sp);
                if (count > 0)
                {
                    MessageBox.Show("添加成功！");
                    txtName.Text = "";
                    txtPrice.Text = "";
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            selectDate();
        }
        //查询全部
        public void selectDate() {
           dataGridView.DataSource =  SQLiteHelper.ExecuteQuery("select * from Bs_Materials");
            if (dataGridView.Rows.Count > 1) {
                this.dataGridView.FirstDisplayedScrollingRowIndex = this.dataGridView.Rows.Count - 1;
            }

        }
        //查询材料价格
        public double getPrice(String name) {
            SQLiteParameter[] pricesSp ={
                new SQLiteParameter("@name",DbType.String),
                  };
            pricesSp[0].Value = name;
            Object obj = SQLiteHelper.ExecuteScalar("select price from Bs_Materials where name = @name", pricesSp);
            if (obj == null) {
                //  MessageBox.Show("材料【" + name + "】还未录入！请到设置中添加该材料以及价格！");
                return 0;
            }
            double price = (double)obj;
            return price;
        }

    }
}
