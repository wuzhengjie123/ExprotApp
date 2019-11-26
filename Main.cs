
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using D.Forms;

namespace ExportApp
{
    public partial class Main : MForm
    {

        private Workbook _workBook = null;
        private Worksheet _workSheet = null;
        Int64 line = 1;
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String savePath = dialog.SelectedPath;
                DirectoryInfo folder = new DirectoryInfo(savePath);
                System.Data.DataTable dt = new System.Data.DataTable("测试");
                dt.Columns.Add("Name", Type.GetType("System.String"));
                dt.Columns.Add("Length", Type.GetType("System.String"));
                dt.Columns.Add("Width", Type.GetType("System.String"));
                dt.Columns.Add("Price", Type.GetType("System.String"));
                DataRow drFirst = dt.NewRow();
                drFirst["Name"] = "物品";
                drFirst["Length"] = "长度";
                drFirst["Width"] = "宽度";
                drFirst["Price"] = "价格";
                dt.Rows.Add(drFirst);
                try
                {
                    foreach (FileInfo file in folder.GetFiles("*.*"))
                    {
                        // String name = file.Name.IndexOf(".");
                        String name = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                        DataRow dr = dt.NewRow();
                        //提取中文
                        MatchCollection zw = Regex.Matches(name, @"\D+");
                        String zwStr = "";
                        foreach (Match m in zw)
                        {
                            zwStr = m.Value;
                           // richTextBox1.AppendText(" " + line + ":" + zwStr);
                            dr["Name"] = zwStr;
                            break;
                        }

                        //提取数字
                        MatchCollection sz = Regex.Matches(name, @"\d+");
                        String szStr = "";
                        foreach (Match m in sz)
                        {
                            szStr += m.Value + "*";

                        }
                        String[] arr = szStr.Split('*');
                        String lenght = arr[0];
                        String width = arr[1];
                        dr["Length"] = lenght;
                        dr["Width"] = width;

                        richTextBox1.AppendText(" " + name + "                  " + DateTime.Now.ToString() + "\n");
                        Int64 totalPrice = Int64.Parse(lenght) * Int64.Parse(width);
                        dr["Price"] = totalPrice;
                        dt.Rows.Add(dr);
                        line += 1;
                    }
                }
                catch(Exception e1) {
                    MessageBox.Show("导入格式有误，请咨询林美玲大神。");
                    MessageBox.Show(e1.Message);
                }

             
                DataSet dataSe = new DataSet();
                dataSe.Tables.Add(dt);
                DataSetToExcel(dataSe, true);
            }
        }

        public bool DataSetToExcel(DataSet dataSet, bool isShowExcle)
        {
            System.Data.DataTable dataTable = dataSet.Tables[0];
            int rowNumber = dataTable.Rows.Count;
            int columnNumber = dataTable.Columns.Count;


            if (rowNumber == 0)
            {
                MessageBox.Show("没有任何数据可以导入到Excel文件！");
                return false;
            }

            //建立Excel对象
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

           // excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcle;//是否打开该Excel文件

            _workBook = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            _workSheet = (Worksheet)_workBook.ActiveSheet;

            Microsoft.Office.Interop.Excel.Range excelRangebyName = _workSheet.get_Range(_workSheet.Cells[1, 1], _workSheet.Cells[rowNumber, 1]);
            excelRangebyName.ColumnWidth = 25;
            //设置字体在单元格内的对其方式
            //设置字体大小
            excelRangebyName.Font.Size = 15;
            excelRangebyName.HorizontalAlignment = XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range excelRange = _workSheet.get_Range(_workSheet.Cells[1, 2], _workSheet.Cells[rowNumber, columnNumber]);
            //设置字体大小
            excelRange.Font.Size = 15;

            //设置字体在单元格内的对其方式
            excelRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //设置单元格的宽度
            excelRange.ColumnWidth = 15;
            //填充数据
            for (int c = 0; c < rowNumber; c++)
            {
                for (int j = 0; j < columnNumber; j++)
                {
                    excel.Cells[c + 1, j + 1] = dataTable.Rows[c].ItemArray[j];
                }
            }
            return true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;

            // Scrolls the contents of the control to the current caret position.
            richTextBox1.ScrollToCaret(); //Caret意思：脱字符号；插入符号; (^)
        }
    }
}
