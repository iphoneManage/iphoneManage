using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SshNet;
using Renci.SshNet;
using System.IO;
using Renci.SshNet.Sftp;
using System.Configuration;
using System.IO.Compression;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Net;

namespace iManager
{


    public partial class Form1 : Form
    {

        public Form1()
        {
            string imanagerdirc = @"C:\iManager";
            if (!Directory.Exists(imanagerdirc))
            {
                Directory.CreateDirectory(@"C:\iManager");
                Directory.CreateDirectory(@"C:\iManager\infoFiles");
                Directory.CreateDirectory(@"C:\iManager\ipsw");
                Directory.CreateDirectory(@"C:\iManager\fakeSignatures");
                Directory.CreateDirectory(@"C:\iManager\restoreFiles");
                Directory.CreateDirectory(@"C:\iManager\Tweaks");
                Directory.CreateDirectory(@"C:\iManager\install");
                Directory.CreateDirectory(@"C:\iManager\Data");
            }
            InitializeComponent();
            //System.Diagnostics.Process.Start("iproxystart.bat");
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "iproxystart.bat";
            startInfo.Arguments = "";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            sshClient.Connect();

            Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand("sbreload");
            sshClient.Disconnect();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            sshClient.Connect();

            Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand("uicache -a");
            sshClient.Disconnect();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            sshClient.Connect();

            Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand("killall -9 SpringBoard");
            sshClient.Disconnect();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            sshClient.Connect();
            richTextBox1.Text = "Client Connected";
            Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand(textBox2.Text);
            string current = richTextBox1.Text;
            richTextBox1.Text = current + textBox2.Text;
            sshClient.Disconnect();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            sshClient.Connect();

            Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand("killall -SEGV SpringBoard");
            sshClient.Disconnect();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SshClient preclient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            preclient.Connect();

            Renci.SshNet.SshCommand precmd = preclient.RunCommand("mkdir /var/mobile/iManagerkira/");
            Renci.SshNet.SshCommand precmd2 = preclient.RunCommand("mkdir /var/mobile/iManagerkira/debinstall/");
            preclient.Disconnect();
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string pathTweak = System.IO.Path.GetFullPath(folderBrowser.FileName);
                var TweakName = System.IO.Path.GetFileName(folderBrowser.FileName);
                ScpClient client = new ScpClient("127.0.0.1", 2222, "root", textBox1.Text);
                {
                    client.Connect();

                    using (Stream localFile = File.OpenRead(pathTweak))
                    {

                        client.Upload(localFile, "/var/mobile/iManagerkira/debinstall/tempin.deb");
                    }
                }
                SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
                sshClient.Connect();

                Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand("dpkg -i /var/mobile/iManagerkira/debinstall/tempin.deb");
                Renci.SshNet.SshCommand sshCommand2 = sshClient.RunCommand(@"sbalert -t installed -m ""Tweak has been installed.""");
                Renci.SshNet.SshCommand sshCommandd = sshClient.RunCommand("echo Installed");
                Renci.SshNet.SshCommand sshCommandg = sshClient.RunCommand("rm -rf /var/mobile/iManagerkira/debinstall/tempin.deb");
                sshClient.Disconnect();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SshClient preclient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            preclient.Connect();

            Renci.SshNet.SshCommand precmd = preclient.RunCommand("mkdir /var/mobile/iManagerkira/");
            Renci.SshNet.SshCommand precmd2 = preclient.RunCommand("mkdir /var/mobile/iManagerkira/appinstall/");
            preclient.Disconnect();
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string pathApps = System.IO.Path.GetFullPath(folderBrowser.FileName);
                var appName = System.IO.Path.GetFileName(folderBrowser.FileName);
                ScpClient client = new ScpClient("127.0.0.1", 2222, "root", textBox1.Text);
                {
                    client.Connect();

                    using (Stream localFile = File.OpenRead(pathApps))
                    {

                        client.Upload(localFile, "/var/mobile/iManagerkira/appinstall/tempin.ipa");
                    }
                }
                SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
                sshClient.Connect();

                Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand("appinst /var/mobile/iManagerkira/appinstall/tempin.ipa");
                Renci.SshNet.SshCommand sshCommand2 = sshClient.RunCommand(@"sbalert -t installed -m ""Appplication has been installed.""");
                Renci.SshNet.SshCommand sshCommandd = sshClient.RunCommand("echo Installed");
                Renci.SshNet.SshCommand sshCommandg = sshClient.RunCommand("rm -rf /var/mobile/iManagerkira/appinstall/tempin.ipa");
                sshClient.Disconnect();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SshClient preclient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            preclient.Connect();

            Renci.SshNet.SshCommand precmd = preclient.RunCommand("mkdir /var/mobile/iManagerkira/");
            Renci.SshNet.SshCommand precmd2 = preclient.RunCommand("mkdir /var/mobile/iManagerkira/windowsFiles/");
            preclient.Disconnect();
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string dataPath = System.IO.Path.GetFullPath(folderBrowser.FileName);
                var dataName = System.IO.Path.GetFileName(folderBrowser.FileName);
                ScpClient client = new ScpClient("127.0.0.1", 2222, "root", textBox1.Text);
                {
                    client.Connect();

                    using (Stream localFile = File.OpenRead(dataPath))
                    {

                        client.Upload(localFile, "/var/mobile/iManagerkira/windowsFiles/" + dataName);
                    }
                }
            }
            SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            sshClient.Connect();

            Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand(@"sbalert -t FileShared -m ""iManager saved the file to:/var/mobile/iManagerkira/windowsFiles/""");
            sshClient.Disconnect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SshClient preclient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            preclient.Connect();

            Renci.SshNet.SshCommand precmd = preclient.RunCommand("mkdir /var/mobile/iManagerkira/");
            Renci.SshNet.SshCommand precmd2 = preclient.RunCommand("mkdir /var/mobile/iManagerkira/cmdlinetools/");
            preclient.Disconnect();
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string pathCMDL = System.IO.Path.GetFullPath(folderBrowser.FileName);
                var cmdlineName = System.IO.Path.GetFileName(folderBrowser.FileName);
                ScpClient client = new ScpClient("127.0.0.1", 2222, "root", textBox1.Text);
                {
                    client.Connect();

                    using (Stream localFile = File.OpenRead(pathCMDL))
                    {

                        client.Upload(localFile, $"/var/mobile/iManagerkira/cmdlinetools/{cmdlineName}");
                    }
                }
                SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
                sshClient.Connect();
                Renci.SshNet.SshCommand sshCommand1 = sshClient.RunCommand($"cp -r /var/mobile/iManagerkira/cmdlinetools/{cmdlineName} /usr/bin/");
                Renci.SshNet.SshCommand sshCommand2 = sshClient.RunCommand(@"sbalert -t installed -m ""You can now run""" + cmdlineName + @"""as Command from anywhere""");
                Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand($"chmod +x /usr/bin/{cmdlineName}");
                sshClient.Disconnect();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            sshClient.Connect();
            Renci.SshNet.SshCommand sshCommand1 = sshClient.RunCommand("uname -m>iManagermodel.txt");
            Renci.SshNet.SshCommand sshCommand2 = sshClient.RunCommand("sw_vers>iManageriosversion.txt");
            sshClient.Disconnect();
            ScpClient client = new ScpClient("127.0.0.1", 2222, "root", textBox1.Text);
            {
                client.Connect();
                DirectoryInfo modelhere = new DirectoryInfo(@"C:\iManager\infoFiles\");
                client.Download("/var/root/iManagermodel.txt", modelhere);
                client.Disconnect();
                
            }
            ScpClient client1 = new ScpClient("127.0.0.1", 2222, "root", textBox1.Text);
            {
                client1.Connect();
                DirectoryInfo versionh = new DirectoryInfo(@"C:\iManager\infoFiles\");
                client1.Download("/var/root/iManageriosversion.txt", versionh);
                client1.Disconnect();
            }
            ScpClient clientw = new ScpClient("127.0.0.1", 2222, "root", textBox1.Text);
            {
                clientw.Connect();
                DirectoryInfo modelhere = new DirectoryInfo(@"C:\iManager\");
                clientw.Download("/var/mobile/Library/SpringBoard/LockBackgroundThumbnail.jpg", modelhere);
                clientw.Disconnect();

            }
            string[] model = File.ReadAllLines(@"C:\iManager\infoFiles\iManagermodel.txt");
            string[] version = File.ReadAllLines(@"C:\iManager\infoFiles\iManageriosversion.txt");
            // 6 7 8 1
            label6.Text = model[0];
            label7.Text = version[0];
            label8.Text = version[1];
            label1.Text = version[2];
            pictureBox2.Image = Image.FromFile(@"C:\iManager\LockBackgroundThumbnail.jpg");

            SshClient sshClient2 = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            sshClient2.Connect();
            Renci.SshNet.SshCommand sshCommandw = sshClient2.RunCommand(@"sbalert -t iManager -m ""iManager connected successfully to this idevice :)""");
            sshClient2.Disconnect();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Downloading Dependencies in the background, do not close the program until a message tells you its done");
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://cydia.akemi.ai/debs/nodelete-net.angelxwind.appsyncunified.deb", @"C:\iManager\Tweaks\appsync.deb");
            webClient.DownloadFile("https://if0x.github.io/io.github.awesomebing1.sbutils_2.1.1_iphoneos-arm.deb", @"C:\iManager\Tweaks\sbutils.deb");
            webClient.DownloadFile("https://cydia.akemi.ai/debs/nodelete-com.linusyang.appinst.deb", @"C:\iManager\Tweaks\appinst.deb");
            MessageBox.Show("Downloaded the dependencies, iManager will now install them. MAKE SURE YOUR IDEVICE has a Cydia Substrate, libhooker or Substitute instsalled as well as OpenSSH");


            SshClient preclient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
            preclient.Connect();
            Renci.SshNet.SshCommand precmd = preclient.RunCommand("mkdir /var/mobile/iManagerkira/");
            Renci.SshNet.SshCommand precmd2 = preclient.RunCommand("mkdir /var/mobile/iManagerkira/dependencies/");
            preclient.Disconnect();
                ScpClient client = new ScpClient("127.0.0.1", 2222, "root", textBox1.Text);
                {
                    client.Connect();

                    using (Stream appsync = File.OpenRead(@"C:\iManager\Tweaks\appsync.deb"))
                    {

                        client.Upload(appsync, "/var/mobile/iManagerkira/dependencies/appsync.deb");
                    }
                using (Stream sbutils = File.OpenRead(@"C:\iManager\Tweaks\sbutils.deb"))
                {

                    client.Upload(sbutils, "/var/mobile/iManagerkira/dependencies/sbutils.deb");
                }
                using (Stream afc2 = File.OpenRead(@"C:\iManager\Tweaks\afc2.deb"))
                {

                    client.Upload(afc2, "/var/mobile/iManagerkira/dependencies/afc2.deb");
                }
                using (Stream appinst = File.OpenRead(@"C:\iManager\Tweaks\appinst.deb"))
                {

                    client.Upload(appinst, "/var/mobile/iManagerkira/dependencies/appinst.deb");
                }

            }
                SshClient sshClient = new SshClient("127.0.0.1", 2222, "root", textBox1.Text);
                sshClient.Connect();

            string dependpath = "/var/mobile/iManagerkira/dependencies/";
            MessageBox.Show("copied tweaks to idevice. iManager will now install them");
                Renci.SshNet.SshCommand sshCommand = sshClient.RunCommand($"dpkg -i {dependpath}sbutils.deb");
                Renci.SshNet.SshCommand sshCommandd = sshClient.RunCommand($"dpkg -i {dependpath}appsync.deb");
                Renci.SshNet.SshCommand sshCommand1 = sshClient.RunCommand($"dpkg -i {dependpath}afc2.deb");
                Renci.SshNet.SshCommand sshCommandd1 = sshClient.RunCommand($"dpkg -i {dependpath}appinst.deb");
                Renci.SshNet.SshCommand sshCommandk = sshClient.RunCommand(@"sbalert -t ""Dependencies Installed"" -m ""You don´t need to reboot your device, iManager will now restart in Jailbroken mode""");
            Renci.SshNet.SshCommand sshCommandg = sshClient.RunCommand("rm -rf /var/mobile/iManagerkira/dependencies/");
            Renci.SshNet.SshCommand sshCommandk1 = sshClient.RunCommand("ldrestart");
            sshClient.Disconnect();

            MessageBox.Show("iManager installed all dependencies. Wait for your device to perform the jailbroken reboot and than you can use it with iManager.");
            }


        }
    }


