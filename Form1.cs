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
            MessageBox.Show(" 읽어 주세요! \n 처음 설치시 바탕화면에 steamcmd 폴더가 있어야 됩니다! \n 설정중입니다. 열나게 찾고 있습니다.;;");
            MessageBox.Show(" 그리고 설치 장소는 c:\\ 입니다.\n 만약 부족현상시 죄송합니다. 돌아가세요... \n 또는 c:\\ 을 정리하세요(최소 1G 있으면 충분 합니다.)");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\steamcmd"))
                {
                string[] lines = { "@echo off", "steamcmd.exe +login anonymous +force_install_dir C:\\scp +app_update 996560 +quit"+ "pause" };
                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\steamcmd\commd.bat", lines);

                Process ps = new Process();
                ps.StartInfo.FileName = "commd.bat";
                ps.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\steamcmd";
                ps.Start();
                ps.WaitForExit(1000);
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\steamcmd\commd.bat");
            }
            else
            {
                MessageBox.Show("앗 이건 바탕화면에 steamcmd 폴더 가 있어야 됩니다.!");
                MessageBox.Show("자동 다운 받는곳으로 이동 합니다.");
                System.Diagnostics.Process up = new Process();
                up.StartInfo.FileName = "https://developer.valvesoftware.com/wiki/SteamCMD";
                up.Start();
                up.WaitForExit(1000);
               

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(@"C:\scp"))
            { if(Directory.Exists(@"C:\Program Files\Mono\bin"))
                {
                    MessageBox.Show("첫 실행시 7777을 입력 하세요");
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
                string[] lines = { "@echo off", "start \" \" \"%AppData%\\SCP Secret Laboratory\\config\"" };
                File.WriteAllLines(@"C:\scp\control.bat", lines);
                MessageBox.Show("설정에 맞게 하세요\n 예)7777 입력 했으면 7777 에 설정 하시면 됩니다.");
                System.Diagnostics.Process cm = new Process();
                cm.StartInfo.FileName = "control.bat";
                cm.StartInfo.WorkingDirectory = @"C:\scp";
                cm.Start();
                cm.WaitForExit(1000);
                File.Delete(@"C:\scp\control.bat");

            }
            else
            {
                MessageBox.Show("파일이 없습니다. 실행 먼저 하시고 하세요!");
            }
            
            }
        }
    }

