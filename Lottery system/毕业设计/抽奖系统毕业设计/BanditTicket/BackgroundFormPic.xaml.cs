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
using System.Management;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace BanditTicket
{
    /// <summary>
    /// WindowTurntable.xaml 的交互逻辑
    /// </summary>
    public partial class BackgroundFormPic : Window
    {
        private string setBackgroundFilPath = AppDomain.CurrentDomain.BaseDirectory + "5.png";
        public BackgroundFormPic()
        {
            InitializeComponent();
            SelectAwardInfro();
           
           
            setShowTurnTable();
            if (SelectBoolShowPhone()) 
            {
                record = true;
                label2.Visibility = Visibility.Visible;
                textBox1.Visibility = Visibility.Visible;
                button1.Visibility = Visibility.Visible;
                turn.btnStartTurntable.IsEnabled = false;
              //  MessageBox.Show("gg");
            }
            isRegist = BoolRegist();
            if (isRegist)
            {
                label1.Content = "";
            }
            else
            {
                label1.Content = "软件暂未注册,请注册";
            }
        }

        
        private bool isRegist = false;
        public double width;
       
        private List<string> prizeNameAndNumber = new List<string>();
        private List<float> prizeProbaility = new List<float>();
        ShowTurnTable turn;
        bool record = false;
        private void setShowTurnTable()
        {
            turn = new ShowTurnTable();
            //turn.SetPrizeNameAndNumber = prizeNameAndNumber;
            
            turn.SetPrizeName();

            turn.AwardProcess += new ShowTurnTable.AwardDelegate(Turntable_AwardProcess);
            turn.Width = 612;
            turn.Height = 498;
            grid.Children.Add(turn);
           
            this.WindowState = WindowState.Maximized;
            if (setBackgroundFilPath != null)
            {
                ImageBrush back = new ImageBrush();
                back.ImageSource = new BitmapImage(new Uri(setBackgroundFilPath, UriKind.RelativeOrAbsolute));
                grid.Background = back;
            }        
        }


        private void Turntable_AwardProcess(string award)
        {
           // System.Windows.Forms.MessageBox.Show(award.ToString());
            MessageBoxShow mBS = new MessageBoxShow(award.ToString());
            mBS.Show();
            if (record)
            {
                ConnectSplite(award);
                textBox1.Text = "";
                textBox1.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Visible;
                button1.Visibility = Visibility.Visible;
                turn.btnStartTurntable.IsEnabled = false;
                SelectAwardInfro();
            }
            
        }
        ///<summary>
        ///查询是否显示电话
        /// </summary>
        public bool SelectBoolShowPhone() 
        {
            bool panduan = false;
            SQLiteConnection conn = null;

            string dbPath = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "/winning_information.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            string sql = "select radio ,content from aword_Information limit 0,1";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["radio"].ToString() == "true")
                { panduan= true; }
                textBlock1.Text = reader["content"].ToString();
            }

            conn.Close();
            return panduan;
         
        }
        ///<summary>
        ///查询中奖信息
        /// </summary>
        private void SelectAwardInfro() 
        {
           
            SQLiteConnection conn = null;

            string dbPath = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "/winning_information.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            string sql = "select * from information order by Date desc limit 0,5";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);

            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
            conn.Close(); 
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public void ConnectSplite( string award)
        {
            SQLiteConnection conn = null;

            string dbPath = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "/winning_information.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            string sql = "CREATE TABLE IF NOT EXISTS information(phone varchar(11), prize varchar(20),Date varchar(25));";//建表语句  
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  

            using (SQLiteTransaction tran = conn.BeginTransaction())//实例化一个事务  
            {

                SQLiteCommand cmd = new SQLiteCommand(conn);//实例化SQL命令  
                cmd.Transaction = tran;
                cmd.CommandText = "insert into information values(@phone, @prize,@Date)";//设置带参SQL语句  
                cmd.Parameters.AddRange(new[] {//添加参数  
                           new SQLiteParameter("@phone", textBox1.Text.Trim()),  
                           new SQLiteParameter("@prize", award),
                           new SQLiteParameter("@Date", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))
                           
                       });
                cmd.ExecuteNonQuery();//执行查询  

                tran.Commit();//提交  
            }
            conn.Close();
        }


        public bool BoolRegist()
        {
            string getRNumResultStr = CreateCode().Trim();
            // MessageBox.Show(GetMd5(strAsciiName).ToString());
            string[] keynames; bool flag = false;
            Microsoft.Win32.RegistryKey localRegKey = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey userRegKey = Microsoft.Win32.Registry.CurrentUser;
            try
            {
                keynames = localRegKey.OpenSubKey("software\\umehd\\register.ini\\").GetValueNames();
                foreach (string name in keynames)
                {
                    if (name == "register")
                    {
                        if (localRegKey.OpenSubKey("software\\umehd\\register.ini\\").GetValue("register").ToString() == GetMd5(getRNumResultStr).ToString())
                            flag = true;
                    }
                }
                keynames = userRegKey.OpenSubKey("software\\umehd\\register.ini\\").GetValueNames();
                foreach (string name in keynames)
                {
                    if (name == "register")
                    {
                        if (flag && userRegKey.OpenSubKey("software\\umehd\\register.ini\\").GetValue("register").ToString() == GetMd5(getRNumResultStr).ToString())
                            return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                //localRegKey.Close();
                //userRegKey.Close();
            }
        }
        public string GetMd5(object text)
        {
            string md5result = "";
            string path = text.ToString();

            MD5CryptoServiceProvider MD5Pro = new MD5CryptoServiceProvider();
            Byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(text.ToString());
            Byte[] byteResult = MD5Pro.ComputeHash(buffer);

            md5result = BitConverter.ToString(byteResult).Replace("-", "");
            return md5result;
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
                MessageBox.Show(ex.ToString());
                return null;
            }
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
                MessageBox.Show(ex.ToString());
            }

            try
            {
                strCpu = strCpu.Substring(strCpu.Length - 8, 8);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
            }
            return macAddress;
        }
       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string dianxin = @"^1[3578][01379]\d{8}$"; 
            Regex dReg = new Regex(dianxin);      
            //联通手机号正则      
            string liantong = @"^1[34578][01256]\d{8}$";        
            Regex tReg = new Regex(liantong);       
            //移动手机号正则        
            string yidong = @"^(134[012345678]\d{7}|1[34578][012356789]\d{8})$";       
            Regex yReg = new Regex(yidong);
            if (textBox1.Text != "" && (dReg.IsMatch(textBox1.Text.Trim()) || tReg.IsMatch(textBox1.Text.Trim()) || yReg.IsMatch(textBox1.Text.Trim())))
            {
                label2.Visibility =Visibility.Hidden;
                button1.Visibility = Visibility.Hidden;
                textBox1.Visibility = Visibility.Hidden;

                turn.btnStartTurntable.IsEnabled = true;

            }
            else {
                MessageBox.Show("请先正确的手机号");
            }
        }
    }
}
