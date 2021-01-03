using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;



namespace SCP_SL서버_관리기
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = { "@echo off", "steamcmd.exe +login anonymous +force_install_dir C:\\scp +app_update 996560 +quit" };
            File.WriteAllLines(@"C:\Users\user\Downloads\steamcmd\commd.bat", lines);

            Process ps = new Process();
            ps.StartInfo.FileName = "commd.bat";
            ps.StartInfo.WorkingDirectory = @"C:\Users\user\Downloads\steamcmd";
            ps.Start();
            ps.WaitForExit(1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(@"C:\scp"))
            { if(Directory.Exists(@"C:\Program Files\Mono\bin"))
                {
                    Process ur = new Process();
                    ur.StartInfo.FileName = "LocalAdmin.exe";
                    ur.StartInfo.WorkingDirectory = @"C:\scp";
                    ur.Start();
                    ur.WaitForExit(1000);
                }
            else
                {
                    MessageBox.Show("mono가 설치되어야 실행이 됩니다.\n 아니면 마이크 깨짐 현상 나타날 수 있습니다.!");
                    MessageBox.Show("자동으로 mono 설치로 넘어 갑니다.");
                    Process cu = new Process();
                    cu.StartInfo.FileName = "mono.msi";
                    cu.StartInfo.WorkingDirectory = @"C:\scp";
                    cu.Start();
                    cu.WaitForExit(1000);
                }
            }
            else
            {
                MessageBox.Show("설치를 먼저 실행 하세요 파일이 없습니다.!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Directory.Exists((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\SCP Secret Laboratory\config"))
            {
                MessageBox.Show("설정에 맞게 하세요\n 예)7777 입력 했으면 7777 에 설정 하시면 됩니다.");

            }
            else
            {
                MessageBox.Show("파일이 없습니다. 실행 먼저 하시고 하세요!");
            }
            
            }
        }
    }

