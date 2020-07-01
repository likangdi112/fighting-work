using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Management;
using System.Windows.Forms;

namespace BanditTicket
{
    /// <summary>
    /// Regist.xaml 的交互逻辑
    /// </summary>
    public partial class Regist : Window
    {
        public Regist()
        {
            InitializeComponent();
        }
        private static string constant = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }

            return newRandom.ToString();
        }
        //获取cup的序列号。
        public string getCpu()
        {
            string strCpu = null;
            try
            {

                ManagementClass myCpu = new ManagementClass("win32_Processor");
                ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
                foreach (ManagementObject myObject in myCpuConnection)
                {
                    strCpu = myObject.Properties["Processorid"].Value.ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            try
            {
                strCpu = strCpu.Substring(strCpu.Length - 8, 8);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                strCpu = "00000000";
            }
            return strCpu;
        }
        //获取设备硬盘的卷积号
        public string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc =
                 new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk =
                 new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();



        }
        public string CreateCode()
        {
            try
            {

                string temp = getCpu() + GetDiskVolumeSerialNumber() + GetMacAddressByNetworkInformation();//获得24位Cpu和硬盘序列号及mac地址
                string strMNum = temp.Substring(0, 28);//从生成的字符串中取出前28个字符做为机器码
                return strMNum;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return null;
            }
        }
        public static string GetMacAddressByNetworkInformation()
        {
            string key = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\";
            string macAddress = string.Empty;
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                {
                    if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                        && adapter.GetPhysicalAddress().ToString().Length != 0)
                    {
                        string fRegistryKey = key + adapter.Id + "\\Connection";
                        RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                        if (rk != null)
                        {
                            string fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                            int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                            if (fPnpInstanceID.Length > 3 &&
                                fPnpInstanceID.Substring(0, 3) == "PCI")
                            {
                                macAddress = adapter.GetPhysicalAddress().ToString();

                                break;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return macAddress;
        }
        string AsciiName;//存储机器码字
        public string ChangeCode()
        {
            string str = GenerateRandom(15);
            string code = CreateCode();
            //  MessageBox.Show(code.ToString());
            try
            {
                for (int i = 0; i < 45; i++)
                {


                    if (i < 2)
                    {
                        AsciiName += Convert.ToChar(str[i]).ToString();

                    }
                    else if (2 <= i && i <= 10)
                    {
                        AsciiName += code.Substring(i - 2, 1);
                    }
                    else if (10 < i && i <= 11)
                    {
                        AsciiName += Convert.ToChar(10 * i).ToString();
                    }
                    else if (11 < i && i <= 30)
                    {
                        AsciiName += code.Substring(i - 3, 1);
                    }
                    else if (30 < i && i < 45)
                    {
                        AsciiName += Convert.ToChar(str[i - 30]).ToString();
                    }

                }
                return AsciiName;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return null;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = ChangeCode().ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (RegistIt(textBox2.Text.Trim()))
                {
                    System.Windows.Forms.MessageBox.Show("注册成功");
                }
                else
                {
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("注册失败,是否退出系统", "程序", MessageBoxButtons.OKCancel);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }


                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("请输入注册码！");
            }
        }
        public bool RegistIt(string realCode)
        {
            try
            {
                if (realCode != "")
                {

                    Microsoft.Win32.RegistryKey retkey =
                      Microsoft.Win32.Registry.CurrentUser.
                      OpenSubKey("software", true).CreateSubKey("umehd").
                      CreateSubKey("register.ini");
                    retkey.SetValue("register", realCode.TrimEnd());

                    retkey = Microsoft.Win32.Registry.LocalMachine.
                        OpenSubKey("software", true).CreateSubKey("umehd").
                         CreateSubKey("register.ini");
                    retkey.SetValue("register", realCode.TrimEnd());

                    return true;

                }
                else { return false; }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return false;
        }
    }
}
