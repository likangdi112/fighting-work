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
using Microsoft.Win32;
using System.IO;
using System.Data.SQLite;

namespace Management
{
    /// <summary>
    /// AwardInf.xaml 的交互逻辑
    /// </summary>
    public partial class AwardInf : Window
    {
        public AwardInf()
        {
            InitializeComponent();
            SQLiteConnection conn = null;

            string dbPath = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "/winning_information.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  

            string sql = "select * from information";
            // SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);

            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
            conn.Close(); 
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog objSFD = new SaveFileDialog() { DefaultExt = "csv", Filter = "CSV Files (*.csv)|*.csv|Excel XML (*.xml)|*.xml|All files (*.*)|*.*", FilterIndex = 1 };
            if (objSFD.ShowDialog() == true)
            {
                string strFormat = objSFD.FileName;
                dataGrid1.SelectAllCells();
                dataGrid1.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dataGrid1);
                dataGrid1.UnselectAllCells();
                string result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);

                File.AppendAllText(strFormat, result, UnicodeEncoding.UTF8);
                Clipboard.Clear();
                MessageBox.Show("导出成功");
            }
        }
    }
}
