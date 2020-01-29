using D.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UpdateApp
{
    public partial class Update : MForm
    {
        public Update()
        {
            InitializeComponent();
        }
        public void UpdateApp()
        {
            //点确定的代码

            var test = new SFTPOperation("192.144.233.135", "22", "root", "953615645@qq.com");
            // 上传文件
            test.GetFileList("/root/ExportApp",progressBar1,barLabel);

            this.Close();
            string strPathExe = Environment.CurrentDirectory + "\\ExportApp.exe";
            Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = strPathExe;
            process.StartInfo.Arguments = null;//-s -t 可以用来关机、开机或重启
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = false;  //true
            process.StartInfo.RedirectStandardOutput = false;  //true
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.CreateNoWindow = false;
            process.Start();//启动
        }
        private void Update_Activated(object sender, EventArgs e)
        {
            UpdateApp();
        }
    }
}
