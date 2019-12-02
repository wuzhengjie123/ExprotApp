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
    public partial class Main : MForm
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
        private Int64 index = 5;
        private Int64 number = 1;
        private Price priceForm = new Price();
        public Main()
        {
            InitializeComponent();           
            string cd = System.Environment.CurrentDirectory;
            //string pd = Directory.GetParent(Directory.GetParent(cd).FullName).FullName;
            cd += "\\export.db";
            SQLiteHelper.SetConnectionString(cd, null, 3);
            Price.priceForm.selectDate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            index = 5;
            richTextBox.Clear();
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
                dt.Columns.Add("price", typeof(double)); //数据类型为 double
                dt.Columns.Add("sum", typeof(double)); //数据类型为 double
                foreach (FileInfo file in folder.GetFiles("*.*"))
                {
                    // String name = file.Name.IndexOf(".");
                    String name = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                    DataRow dr = dt.NewRow();
                    //添加时间列的值
                    dr["date"] = DateTime.Now.ToString("MM.dd"); 
                    

                    //提取中文
                    MatchCollection zw = Regex.Matches(name, @"\D+");
                    dr["remark"] = name;
                    name =  new Regex("[\\s]+").Replace(name, " ");
                    String[] arr = name.Split(' ');
                    if (arr.Length < 4) {
                        MessageBox.Show(this,"文件【"+name+"】格式不对！格式为【备注 尺寸-尺寸 材料 数量】");
                        return;
                    }
                    double length = 0;
                    double width = 0;
                    double goodsPrice = 0;
                    for (Int64 i = 0; i < arr.Length; i++) {

                        String size = arr[1];

                        if (i == 1) {
                            if (size.Contains("-") || size.Contains("x") || size.Contains("X"))
                            {
                                String[] sizeArr = new String[3];
                                if (size.Contains("-")) {
                                    sizeArr = size.Split('-');
                                }
                                else if (size.Contains("x"))
                                {
                                    sizeArr = size.Split('x');
                                } else if (size.Contains("X")) {
                                    sizeArr = size.Split('X');
                                }


                                for (Int64 j = 0; j < sizeArr.Length; j++)
                                {
                                    length = double.Parse(sizeArr[0]) / 100;
                                    width = double.Parse(sizeArr[1]) / 100;
                                    dr["length"] = length;
                                    dr["width"] = width;
                                    dr["size"] = length * width;
                                }
                            }
                            else
                            {
                                changBlack("（错误）：备注【");
                                changRed(name);
                                changBlack("】尺寸格式异常！！！" + DateTime.Now.ToString() + "\n");

                                continue;
                            }
                        }


                        //读取材料时
                        if (i == 2) {
                            dr["goods"] = arr[2];
                             goodsPrice = priceForm.getPrice(arr[2]);
                            if (goodsPrice == 0)
                            {
                                changBlack("警告：第【");
                                changRed(index.ToString());
                                changBlack("】行价格异常！！！材料是：【");
                                changRed(arr[2]);
                                changBlack("】" + DateTime.Now.ToString() + "\n");
                                //richTextBox.AppendText("警告：第【" + index + "】行价格异常！！！材料是：【" + arr[2] + "】" + DateTime.Now.ToString() + "\n");
                            }
                            dr["price"] = goodsPrice;

                        }
                        //读取数量
                        if (i==3) {
                            if (check(arr[3]))
                            {
                                MatchCollection sz = Regex.Matches(arr[3], @"\d+");
                                foreach (Match m in sz)
                                {
                                    dr["count"] = m.Value;
                                    break;
                                }
                            }
                            else {
                                if (arr[3].Contains("一"))
                                {
                                    dr["count"] = 1;
                                }
                                else if (arr[3].Contains("二") || arr[3].Contains("两"))
                                {
                                    dr["count"] = 2;
                                }
                                else if (arr[3].Contains("三"))
                                {
                                    dr["count"] = 3;

                                }
                                else if (arr[3].Contains("四"))
                                {
                                    dr["count"] = 4;
                                }
                                else if (arr[3].Contains("五"))
                                {
                                    dr["count"] = 5;
                                }
                                else if (arr[3].Contains("六"))
                                {
                                    dr["count"] = 6;
                                }
                                else if (arr[3].Contains("七"))
                                {
                                    dr["count"] = 7;
                                }
                                else if (arr[3].Contains("八"))
                                {
                                    dr["count"] = 8;
                                }
                                else if (arr[3].Contains("九"))
                                {
                                    dr["count"] = 9;

                                }
                                else if (arr[3].Contains("十"))
                                {
                                    dr["count"] = 10;

                                }
                                else {
                                    changBlack("（错误）：备注【");
                                    changRed(name);
                                    changBlack("】数量格式异常！！！" + DateTime.Now.ToString() + "\n");
                                    //richTextBox.AppendText("（错误）：备注【" + name + "】数量格式异常！！！" + DateTime.Now.ToString() + "\n");
                                    dr["count"] = 0;
                                }

                            }
                            dr["sum"] = goodsPrice * length * width * double.Parse(dr["count"].ToString());

                        }

        
                    }

                    dt.Rows.Add(dr);

                    index++;

                }

                GenerateAttachment(dt);
            }
        }

        public bool check(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 48 && text[i] <= 57)
                {
                    return true;
                }
            }
            return false;
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
                worksheet = (Excel.Worksheet)sheets.get_Item(1); //第一个工作薄。
                if (worksheet == null)//工作薄中没有工作表
                {
                    return;
                }

                //1、获取数据
                int rowCount = DT.Rows.Count;
                if (rowCount < 1)//没有取到数据
                {
                    MessageBox.Show(this,"没有数据导出，请稍后再试！", "提示");
                    return;
                }
                //删除多余行数
                if (rowCount < 1000) {
                    deleteRows(worksheet, 4+rowCount, 1065);
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
                    worksheet.Cells[row_, 4] = DT.Rows[dt_row]["length"];
                    worksheet.Cells[row_, 5] = DT.Rows[dt_row]["width"];
                    worksheet.Cells[row_, 6] = DT.Rows[dt_row]["count"];
                    worksheet.Cells[row_, 7] = DT.Rows[dt_row]["size"];
                    worksheet.Cells[row_, 8] = DT.Rows[dt_row]["price"];
                    worksheet.Cells[row_, 9] = DT.Rows[dt_row]["sum"];
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
                String folderName = DateTime.Now.ToString("yyyy.MM");
                //如果不存在就创建 dir 文件夹 
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+ folderName)) 
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+ folderName);
                //判断文件的存在
                savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+ folderName+"\\一诺广告清单" + fileName ;
                Boolean exist = false;
                exist = System.IO.File.Exists(savePath + ".xls");
                do
                {
                    String numberStr = "(" + number.ToString() + ")";
                    if (savePath.Contains("("))
                    {
                        savePath = savePath.Substring(0, savePath.IndexOf("(")) + numberStr;
                    }
                    else {
                        savePath = savePath + numberStr;
                    }

                    exist = System.IO.File.Exists(savePath + ".xls");
                    number++;
                } while (exist);
                savePath = savePath + ".xls";
                if (!string.IsNullOrEmpty(savePath))
                {
                    workbook.SaveAs(savePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    success = true;

                }
               //  string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + currentTime + ".xls"; 

                // MessageBox.Show("导出成功", "提示");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"导出失败,"+ex.Message, "提示");
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
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            //将光标位置设置到当前内容的末尾
            richTextBox.SelectionStart = richTextBox.Text.Length;
            //滚动到光标位置
            richTextBox.ScrollToCaret();
        }
        //设置按钮
        private void buttonSet_Click(object sender, EventArgs e)
        {
            priceForm.ShowDialog();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            label.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label.Visible = false;
        }
        //红色
        private void changRed(string text) {
            this.richTextBox.SelectionColor = System.Drawing.Color.Red;
            this.richTextBox.AppendText(text);
        }
        //黑色
        private void changBlack(string text)
        {
            this.richTextBox.SelectionColor = System.Drawing.Color.Black;
            this.richTextBox.AppendText(text);
        }
        //删除多余行
        private void deleteRows(Excel._Worksheet sheet, int rowStart , int rowEnd)
        {
            String fw = rowStart + ":" + rowEnd;
            Excel.Range range = (Excel.Range)sheet.Rows[fw, Missing.Value];
            //删除整行 1~10行
            range.Delete(Excel.XlDirection.xlDown);
        }
        //添加多余行
        private void insertRows(Excel._Worksheet sheet, int rowStart, int rowEnd)
        {
            String fw = rowStart + ":" + rowEnd;
            Excel.Range range = (Excel.Range)sheet.Rows[fw, Missing.Value];
            //添加整行 1~10行
            range.Insert(Excel.XlDirection.xlDown);
        }
    }
}
