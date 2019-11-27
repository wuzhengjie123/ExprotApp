using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        BindingList<Goods> goodsList = new BindingList<Goods>();
        StreamWriter wr = null;
        public Price()
        {
            priceForm = this;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) {
                MessageBox.Show("材料不能输入空");
                return;
            }
            Regex reg = new Regex("^(\\-|\\+)?\\d+(\\.\\d+)?$");
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("价格不能输入空");
                return;
            }
            if ( !reg.IsMatch(txtPrice.Text))
            {
                MessageBox.Show("价格为整数或者小数");
                return;
            }
            try
            {
                FileStream fs = new FileStream(Application.StartupPath + @"\price.txt", FileMode.Append);
                wr = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
                if (!map.ContainsKey(txtName.Text))
                {
                    wr.WriteLine("\n" + txtName.Text + "|" + txtPrice.Text);
                    MessageBox.Show(txtName.Text + "   添加成功");
                    mComboBox.Items.Add(txtName.Text + "|" + txtPrice.Text);
                    map.Add(txtName.Text, double.Parse(txtPrice.Text));
                    this.refreshTable(txtName.Text, txtPrice.Text);
                }
                else {
                    MessageBox.Show("存在相同材料，请到安装目录下直接修改price.txt文件。");
                    return;
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally {
                wr.Close();

            }


        }
        //初始化下拉
        public void initComboBox() {
            StreamReader sr = new StreamReader(Application.StartupPath + @"\price.txt", Encoding.GetEncoding("gb2312"));
            String name;
            Double price = 0;
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line != null && !string.IsNullOrEmpty(line)) {
                    name = line.Substring(0, line.IndexOf("|"));
                    //先求出最后出现这个字符的下标
                    int index = line.LastIndexOf("|");
                    //从下一个索引开始截取
                    price = double.Parse(line.Substring(index + 1));

                    mComboBox.Items.Add(line.ToString());
                    map.Add(name, price);
                    //使用List<>泛型集合填充DataGridView  
                    Goods goods = new Goods();
                    goods.name = name;
                    goods.price = price.ToString();
                    goodsList.Add(goods);
                }

               
            }
            this.dataGridView.DataSource = goodsList;
            //this.dataGridView.FirstDisplayedScrollingRowIndex = this.dataGridView.Rows.Count - 1;
        }
        //刷新表格
        public void refreshTable(String name,String price)
        {
            Goods goods = new Goods();
            goods.name = name;
            goods.price = price;
            goodsList.Add(goods);
            this.dataGridView.DataSource = goodsList;
            this.dataGridView.FirstDisplayedScrollingRowIndex = goodsList.Count-1;
        }

        }
}
