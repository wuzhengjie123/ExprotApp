using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using D.Forms;

namespace ExportApp
{
    public partial class Form1 : MForm
    {
        private static Microsoft.Office.Interop.Excel.Application app = null;
        private static Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
        private static Microsoft.Office.Interop.Excel._Workbook workbook = null; //加载模板
        private static Microsoft.Office.Interop.Excel.Sheets sheets = null;
        private static Microsoft.Office.Interop.Excel._Worksheet worksheet = null; //第一个工作薄。
        private string savePath = "";
        private string strTempPath = "";
        private string fileName = "导出";
        private Boolean success = false;
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

                DataTable dt = new DataTable();
                dt.Columns.Add("date", typeof(string)); //数据类型为 文本
                dt.Columns.Add("remark", typeof(string)); //数据类型为 文本
                dt.Columns.Add("length", typeof(double)); //数据类型为 double
                dt.Columns.Add("width", typeof(double)); //数据类型为 double
                dt.Columns.Add("goods", typeof(string)); //数据类型为 文本
                dt.Columns.Add("count", typeof(Int64)); //数据类型为 int
                dt.Columns.Add("size", typeof(double)); //数据类型为 文本
                foreach (FileInfo file in folder.GetFiles("*.*"))
                {
                    // String name = file.Name.IndexOf(".");
                    String name = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                    DataRow dr = dt.NewRow();
                    //添加时间列的值
                    dr["date"] = DateTime.Now.ToString("MM.dd"); 
                    

                    //提取中文
                    MatchCollection zw = Regex.Matches(name, @"\D+");
                    /*String remark = "";
                    foreach (Match m in zw)
                    {
                        remark = m.Value;
                        break;
                    }*/
                    //备注

                    //提取数字
                    /*MatchCollection sz = Regex.Matches(name, @"\d+");
                    String szStr = "";
                    foreach (Match m in sz)
                    {
                        szStr += m.Value + "";

                    }*/
                    String[] arr = name.Split(' ');
                    dr["remark"] = name;
                    for (Int64 i = 0; i < arr.Length; i++) {

                        String size = arr[1];
                        String[] sizeArr = size.Split('-');
                        for (Int64 j = 0; j < sizeArr.Length; j++)
                        {
                            double length = double.Parse(sizeArr[0]) / 100;
                            double width = double.Parse(sizeArr[1]) / 100;
                            dr["length"] = length;
                            dr["width"] = width;
                            dr["size"] = length * width;
                        }
                        dr["goods"] = arr[2];

                        MatchCollection sz = Regex.Matches(arr[3], @"\d+");
                        foreach (Match m in sz)
                        {
                            dr["count"] = m.Value;
                            break;
                        }
        
                    }

                    dt.Rows.Add(dr);

                  //  richTextBox1.AppendText(" " + szStr + "\n");

                }


                //1.创建空列
                /* DataColumn dc = new DataColumn();
                 dt.Columns.Add(dc);
                 //1.创建空行
                 DataRow dr = dt.NewRow();
                 dt.Rows.Add(dr);*/
                //2.创建空行
                //  dt.Rows.Add();
                //3.通过行框架创建并赋值
                //dt.Rows.Add("张三", DateTime.Now);//Add里面参数的数据顺序要和dt中的列的顺序对应 
                //4.通过复制dt2表的某一行来创建


                /* String path = System.AppDomain.CurrentDomain.BaseDirectory;
                  path = System.IO.Directory.GetCurrentDirectory();
                  ExcelOp(path+"\\export.xls");*/
                GenerateAttachment(dt);
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
            excel.DisplayAlerts = false;
            excel.Visible = true;//是否打开该Excel文件
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
               // ClosePro(excelPath, excel, wb);
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
        /// <summary>
        /// 生成附件（使用Microsoft.Office.Interop.Excel组件的方式）
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        public void GenerateAttachment(DataTable DT)
        {
            try
            {
                //需要添加 Microsoft.Office.Interop.Excel引用 
                app = new Microsoft.Office.Interop.Excel.Application();
                if (app == null)//服务器上缺少Excel组件，需要安装Office软件
                {
                    return;
                }
                app.Visible = false;
                app.UserControl = true;
                strTempPath = System.Windows.Forms.Application.StartupPath + "\\export.xls";
                workbooks = app.Workbooks;
                workbook = workbooks.Add(strTempPath); //加载模板
                sheets = workbook.Sheets;
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)sheets.get_Item(1); //第一个工作薄。
                if (worksheet == null)//工作薄中没有工作表
                {
                    return;
                }

                //1、获取数据
                int rowCount = DT.Rows.Count;
                if (rowCount < 1)//没有取到数据
                {
                    MessageBox.Show("没有数据导出，请稍后再试！", "提示");
                    return;
                }
  
               /* progressBar.Visible = true;
                progressBar.Value = 0;
                progressBar.Maximum = rowCount;*/
                //worksheet.Cells[3, 7] = "2222";
                //2、写入数据，Excel索引从1开始
                for (int i = 1; i <= rowCount; i++)
                {
                    int row_ = 4 + i;  //Excel模板上表头占了1行
                    int dt_row = i - 1; //dataTable的行是从0开始的 
                  //  worksheet.Cells[1, 1] = "磅单";
                    worksheet.Cells[row_, 1] = DT.Rows[dt_row]["date"].ToString();
                    worksheet.Cells[row_, 2] = DT.Rows[dt_row]["remark"].ToString();
                    worksheet.Cells[row_, 3] = DT.Rows[dt_row]["goods"].ToString();
                    worksheet.Cells[row_, 4] = DT.Rows[dt_row]["length"].ToString();
                    worksheet.Cells[row_, 5] = DT.Rows[dt_row]["width"].ToString();
                    worksheet.Cells[row_, 6] = DT.Rows[dt_row]["count"].ToString();
                    worksheet.Cells[row_, 7] = DT.Rows[dt_row]["size"].ToString();
                   // progressBar.Value = i;
                    //水平样式
                    /*worksheet.Range[worksheet.Cells[row_, 1], worksheet.Cells[row_, 1]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Range[worksheet.Cells[row_, 2], worksheet.Cells[row_, 2]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Range[worksheet.Cells[row_, 3], worksheet.Cells[row_, 3]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Range[worksheet.Cells[row_, 4], worksheet.Cells[row_, 4]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Range[worksheet.Cells[row_, 5], worksheet.Cells[row_, 5]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Range[worksheet.Cells[row_, 6], worksheet.Cells[row_, 6]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Range[worksheet.Cells[row_, 7], worksheet.Cells[row_, 7]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;*/
                }
                //边框样式
              //  worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[rowCount + 2, 7]].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;//细线
                //调整Excel的样式。
                //Microsoft.Office.Interop.Excel.Range rg = worksheet.Cells.Range["A3", worksheet.Cells[rowCount + 2, 12]];
                //rg.Borders.LineStyle = 1; //单元格加边框
                // worksheet.Columns.AutoFit(); //自动调整列宽

                //隐藏某一行
                //选中部分单元格，把选中的单元格所在的行的Hidden属性设为true
                //worksheet.get_Range(app.Cells[2, 1], app.Cells[2, 32]).EntireRow.Hidden = true;

                //删除某一行
                //worksheet.Range[app.Cells[2, 1], app.Cells[2, 32]].EntireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
                //指定单元格
                //Microsoft.Office.Interop.Excel.Range rtemp = worksheet.Range[app.Cells[1, 1], app.Cells[1, 2]];
                //rtemp.Font.Name = "宋体";
                //rtemp.Font.Size = 20;
                //3、保存生成的Excel文件
                //Missing在System.Reflection命名空间下
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                fileName = DateTime.Now.ToString("yyyy-MM-dd");
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "蓝图广告清单"+fileName + ".xls";
               // string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + currentTime + ".xls"; 
                workbook.SaveAs(savePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                // MessageBox.Show("导出成功", "提示");
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败,"+ex.Message, "提示");
                workbook.Close(false, strTempPath, System.Reflection.Missing.Value);
                success = false;
                WriteLog(ex);
            }
            finally
            {
                /*progressBar.Visible = false;
                progressBar.Value = 0;*/
                 //4、按顺序释放资源
                 NAR(worksheet);
                 NAR(sheets);
                 NAR(workbook);
                 NAR(workbooks);
                 app.Quit();
                 NAR(app);
                if (success) {
                    //打开文件
                    System.Diagnostics.Process.Start(savePath);
                }
                Process[] process = Process.GetProcessesByName("进程名称");
                 foreach (Process p in process)
                 {
                     if (!p.HasExited)  // 如果程序没有关闭，结束程序
                     {
                         p.Kill();
                         p.WaitForExit();
                     }
                 }
            }
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="o"></param>
        public static void NAR(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
            finally
            {
                o = null;
            }
        }
        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        public static void WriteLog(Exception ex, string LogAddress = "")
        {
            //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
            if (LogAddress == "")
            {
                LogAddress = System.Windows.Forms.Application.StartupPath + "\\log\\" +
                    DateTime.Now.Year + "-" +
                    DateTime.Now.Month + "-" +
                    DateTime.Now.Day + "_Log.log";
            }
            //把异常信息输出到文件，因为异常文件由这几部分组成，这样就不用我们自己复制到文档中了
            StreamWriter fs = new StreamWriter(LogAddress, true);
            fs.WriteLine("当前时间：" + DateTime.Now.ToString());
            fs.WriteLine("异常信息：" + ex.Message);
            fs.WriteLine("异常对象：" + ex.Source);
            fs.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
            fs.WriteLine("触发方法：" + ex.TargetSite);
            fs.WriteLine();
            fs.Close();
        }
    }
}
