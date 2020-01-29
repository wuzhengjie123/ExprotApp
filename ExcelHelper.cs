using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExportApp
{
    public class ExportHelper
    {
        private static Int64 number = 1;
        private static Boolean success = false;
        public static void RenderDataTableToExcel(DataTable DT)
        {
            String strTempPath = System.Windows.Forms.Application.StartupPath + "\\export.xls";
            FileStream fileIn = new FileStream(strTempPath, FileMode.Open, FileAccess.Read);
            //FileInputStream fileIn = new FileInputStream(strTempPath);
            HSSFWorkbook workbook = new HSSFWorkbook(fileIn);
            HSSFSheet worksheet = (HSSFSheet)workbook.CreateSheet();
            HSSFRow headerRow = (HSSFRow)worksheet.CreateRow(0);
            String fileName = "导出";
            String savePath = "";

            try
            {

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
                //删除多余行数
                if (rowCount < 1000)
                {
                    deleteRows(worksheet, 4 + rowCount, 1065);
                }
                //2、写入数据，Excel索引从1开始
                IRow row = null;
                ICell cell = null;
                for (int i = 1; i < rowCount; i++)
                {
                    int dt_row = i - 1; //dataTable的行是从0开始的 
                    row = worksheet.CreateRow(i + 4);
                    for (int j = 0; j < 9; j++)
                    {
                        cell = row.CreateCell(j);//excel第二行开始写入数据  
                        switch (j) {
                            case 0:
                                cell.SetCellValue(DT.Rows[i]["date"].ToString());
                                break;
                            case 1:
                                cell.SetCellValue(DT.Rows[i]["remark"].ToString());
                                break;
                            case 2:
                                cell.SetCellValue(DT.Rows[i]["goods"].ToString());
                                break;
                            case 3:
                                cell.SetCellValue(DT.Rows[i]["width"].ToString());
                                break;
                            case 4:
                                cell.SetCellValue(DT.Rows[i]["height"].ToString());
                                break;
                            case 5:
                                cell.SetCellValue(DT.Rows[i]["count"].ToString());
                                break;
                            case 6:
                                cell.SetCellValue(DT.Rows[i]["size"].ToString());
                                break;
                            case 7:
                                cell.SetCellValue(DT.Rows[i]["price"].ToString());
                                break;
                            case 8:
                                cell.SetCellValue(DT.Rows[i]["sum"].ToString());
                                break;
                            default:
                                break;
                        }

                    }
                }
                    //设置每行每列的单元格,  

                    System.DateTime currentTime = new System.DateTime();
                    currentTime = System.DateTime.Now;
                    fileName = DateTime.Now.ToString("yyyy-MM-dd");
                    String folderName = DateTime.Now.ToString("yyyy.MM");
                    //如果不存在就创建 dir 文件夹 
                    if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + folderName))
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + folderName);
                    //判断文件的存在
                    savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + folderName + "\\一诺广告清单" + fileName;
                    Boolean exist = false;
                    exist = System.IO.File.Exists(savePath + ".xls");
                    do
                    {
                        String numberStr = "(" + number.ToString() + ")";
                        if (savePath.Contains("("))
                        {
                            savePath = savePath.Substring(0, savePath.IndexOf("(")) + numberStr;
                        }
                        else
                        {
                            savePath = savePath + numberStr;
                        }

                        exist = System.IO.File.Exists(savePath + ".xls");
                        number++;
                    } while (exist);
                    if (!string.IsNullOrEmpty(savePath))
                    {
                        FileStream file = new FileStream(savePath, FileMode.Create);
                        workbook.Write(file);
                        file.Close();
                        // workbook.SaveAs(savePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                        success = true;

                    }
                
             }
            catch (Exception ex) {
                MessageBox.Show("导出失败," + ex.Message, "提示");
                workbook.Close();
                success = false;
                WriteLog(ex);
            }
            finally
            {
                /*progressBar.Visible = false;
                progressBar.Value = 0;*/
                //4、按顺序释放资源
                NAR(worksheet);
                NAR(workbook);
                if (success)
                {
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


            worksheet = null;
            headerRow = null;
            workbook = null;
        }
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(SheetIndex);

            DataTable table = new DataTable();

            HSSFRow headerRow = (HSSFRow)sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = (HSSFRow)sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)

                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }
        //删除多余行
        private static void deleteRows(HSSFSheet sheet, int rowStart, int rowEnd)
        {
            for (int i = rowStart; i <= rowEnd; i++) {
               // sheet.RemoveRow(sheet.GetRow(i));

            }

        }
        //添加多余行
        private static void insertRows(HSSFSheet sheet, int rowStart, int rowEnd)
        {
           // sheet.ShiftRows(rowStart, rowEnd,1);
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
