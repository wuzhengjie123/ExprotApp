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
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportApp
{
    public partial class Form1 : Form
    {
        public Form1()
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
                foreach (FileInfo file in folder.GetFiles("*.*"))
                {
                    // String name = file.Name.IndexOf(".");
                    String name = System.IO.Path.GetFileNameWithoutExtension(file.Name);

                    //提取中文
                    MatchCollection zw = Regex.Matches(name, @"\D+");
                    String zwStr = "";
                    foreach (Match m in zw)
                    {
                        zwStr = m.Value;
                        richTextBox1.AppendText(zwStr);
                        break;
                    }

                    //提取数字
                    MatchCollection sz = Regex.Matches(name, @"\d+");
                    String szStr = "";
                    foreach (Match m in sz)
                    {
                        szStr += m.Value;

                    }
                    richTextBox1.AppendText(" " + szStr + "\n");

                }
                DataTable dt = new DataTable();
                //1.创建空列
                DataColumn dc = new DataColumn();
                dt.Columns.Add(dc);
                //1.创建空行
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                //2.创建空行
                dt.Rows.Add();
                //3.通过行框架创建并赋值
                dt.Rows.Add("张三", DateTime.Now);//Add里面参数的数据顺序要和dt中的列的顺序对应 
                                                //4.通过复制dt2表的某一行来创建
                dt.Rows.Add(dt2.Rows[i].ItemArray);
            }
        }
        /// <summary>
        /// 简单操作Excel文件
        /// </summary>
        /// <param name="excelPath">excel 文件路径</param>
        /// <returns></returns>
        public void ExcelOp(string excelPath)
        {
            string ExcelFilePath = excelPath.Trim();
            //set columns
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("订单号", "A");//
            dic.Add("数量", "B");

            Microsoft.Office.Interop.Excel.Application excel = new Excel.Application();
            Excel.Workbook wb = null;
            excel.Visible = false;//设置调用引用的 Excel文件是否可见
            excel.DisplayAlerts = false;
            wb = excel.Workbooks.Open(ExcelFilePath);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1]; //索引从1开始 //(Excel.Worksheet)wb.Worksheets["SheetName"];
            int rowCount = 0;//有效行，索引从1开始
            try
            {
                rowCount = ws.UsedRange.Rows.Count;//赋值有效行

                string ordernum = string.Empty;
                string count = string.Empty;
                //循环行
                for (int i = 1; i <= rowCount; i++)//
                {
                    if (ws.Rows[i] != null)
                    {
                        ordernum = ws.Cells[i, dic["订单号"]].ToString();//取单元格值
                        count = ws.Cells[i, dic["数量"]].ToString();//ws.Cells[i, 2].Value2.ToString();
                    }
                }
                //循环列
                for (int i = 1; i <= ws.UsedRange.Columns.Count; i++)
                {
                    //ws.Columns[i]
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                ClosePro(excelPath, excel, wb);
            }
        }
        /// <summary>
        /// 关闭Excel进程
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="excel"></param>
        /// <param name="wb"></param>
        public void ClosePro(string excelPath, Excel.Application excel, Excel.Workbook wb)
        {
            Process[] localByNameApp = Process.GetProcessesByName(excelPath);//获取程序名的所有进程
            if (localByNameApp.Length > 0)
            {
                foreach (var app in localByNameApp)
                {
                    if (!app.HasExited)
                    {
                        #region
                        ////设置禁止弹出保存和覆盖的询问提示框   
                        //excel.DisplayAlerts = false;
                        //excel.AlertBeforeOverwriting = false;

                        ////保存工作簿   
                        //excel.Application.Workbooks.Add(true).Save();
                        ////保存excel文件   
                        //excel.Save("D:" + "\\test.xls");
                        ////确保Excel进程关闭   
                        //excel.Quit();
                        //excel = null; 
                        #endregion
                        app.Kill();//关闭进程  
                    }
                }
            }
            if (wb != null)
                wb.Close(true, Type.Missing, Type.Missing);
            excel.Quit();
            // 安全回收进程
            System.GC.GetGeneration(excel);
        }

        public bool DataSetToExcel(DataSet dataSet, bool isShowExcle)
        {
            DataTable dataTable = dataSet.Tables[0];
            int rowNumber = dataTable.Rows.Count;
            int columnNumber = dataTable.Columns.Count;

            if (rowNumber == 0)
            {
                MessageBox.Show("没有任何数据可以导入到Excel文件！");
                return false;
            }

            //建立Excel对象
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcle;//是否打开该Excel文件

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
    }
}
