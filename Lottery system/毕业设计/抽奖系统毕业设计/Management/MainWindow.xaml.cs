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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace Management
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int times = 0;
        private string setBackgroundFilPath = AppDomain.CurrentDomain.BaseDirectory + "5.png";
        public string setBackimage;
        private List<string> setPrizeName = new List<string>();
        private List<int> setPrizeNumber = new List<int>();
        private List<string> setPrizeNameAndNumber = new List<string>();
        private List<float> setProbaility = new List<float>();
        private List<float> setProbailityNumber = new List<float>();  

        private void AddPrizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GetNumberOfPrize() < 8)
            {
                if (8 - GetNumberOfPrize() != 0 && 8 - GetNumberOfPrize() > 0)
                {
                    ++times;
                    System.Windows.Controls.TextBox text = new System.Windows.Controls.TextBox();
                    Thickness thick = new Thickness(29, 179 + 36 * times, 0, 0);
                    text.Margin = thick;
                    text.Width = 108;
                    text.Height = 28;
                    text.Name = "text" + times.ToString();
                    text.VerticalAlignment = VerticalAlignment.Top;
                    text.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    text.TextAlignment = TextAlignment.Center;
                    grid.Children.Add(text);

                    Thickness thick1 = new Thickness(179, 179 + 36 * times, 0, 0);
                    System.Windows.Controls.TextBox text1 = new System.Windows.Controls.TextBox();
                    text1.Margin = thick1;
                    text1.Width = 75;
                    text1.Height = 28;
                    text1.Name = "number" + times.ToString();
                    text1.VerticalAlignment = VerticalAlignment.Top;
                    text1.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    text1.TextAlignment = TextAlignment.Center;
                    grid.Children.Add(text1);

                    Thickness thick3 = new Thickness(280, 179 + 36 * times, 0, 0);
                    System.Windows.Controls.TextBox text2 = new System.Windows.Controls.TextBox();
                    text2.Margin = thick3;
                    text2.Width = 75;
                    text2.Height = 28;
                    text2.Name = "probability" + times.ToString();
                    text2.VerticalAlignment = VerticalAlignment.Top;
                    text2.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    text2.TextAlignment = TextAlignment.Center;
                    grid.Children.Add(text2);

                    //  System.Windows.MessageBox.Show(text2.Name);
                    Thickness thick2 = new Thickness(180, 292 + 26 * times, 0, 0);

                    AddPrizeBtn.Margin = thick2;

                }
                else
                {
                    System.Windows.MessageBox.Show("最多有八个奖项");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("奖项显示数量总和不能大于八");
            }
        }
        /// <summary>
        /// 得到后台中设置的各种奖项的总数，以供判断
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfPrize()
        {
            int prize_count = 0;
            try
            {
                setPrizeNumber.Clear();

                System.Windows.Controls.TextBox tb;

                int textnumber = 1;
                prize_count = Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox4.Text) +
                   Convert.ToInt32(textBox6.Text) + Convert.ToInt32(textBox8.Text);

                setPrizeNumber.Add(Convert.ToInt32(textBox2.Text));
                setPrizeNumber.Add(Convert.ToInt32(textBox4.Text));
                setPrizeNumber.Add(Convert.ToInt32(textBox6.Text));
                setPrizeNumber.Add(Convert.ToInt32(textBox8.Text));

                for (int i = 0; i < grid.Children.Count; i++)
                {
                    tb = grid.Children[i] as System.Windows.Controls.TextBox;

                    if (tb != null && tb.Name == "number" + textnumber && tb.Text != "")
                    {

                        // System.Windows.Forms.MessageBox.Show(tb.Name);
                        setPrizeNumber.Add(Convert.ToInt32(tb.Text));
                        prize_count += Convert.ToInt32(tb.Text);

                        textnumber++;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            return prize_count;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            AwardInf ad = new AwardInf();
            ad.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Regist rg = new Regist();
            rg.Show();
        }

        private void SetBackgroundImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";

            openFileDialog.FileName = string.Empty;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            DialogResult result = openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            setBackimage = openFileDialog.FileName;
            File.Copy(setBackimage, AppDomain.CurrentDomain.BaseDirectory + "5.png", true);
            button2.IsEnabled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";

            openFileDialog.FileName = string.Empty;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            DialogResult result = openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            else
            {
                Watermark wm = new Watermark();
                wm.AddWatermark(setBackimage, openFileDialog.FileName);

            }
        }
        ///<summary>
        /// 存储概率事件
        /// </summary>
        public void GetProbabilityPrize()
        {
            try
            {
                setProbaility.Clear();
                setProbaility.Add(float.Parse(textBox9.Text));
                setProbaility.Add(float.Parse(textBox10.Text));
                setProbaility.Add(float.Parse(textBox11.Text));
                setProbaility.Add(float.Parse(textBox12.Text));
                System.Windows.Controls.TextBox tb;
                int textnumber = 1;
                for (int i = 0; i < grid.Children.Count; i++)
                {
                    tb = grid.Children[i] as System.Windows.Controls.TextBox;

                    if (tb != null && tb.Name == "probability" + textnumber && tb.Text != "")
                    {

                        //  System.Windows.Forms.MessageBox.Show(tb.Name);
                        setProbaility.Add(float.Parse(tb.Text));
                        textnumber++;
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
        ///<summary>
        ///生成后台概率
        ///</summary>
        public void GetProbilityListOfPrize()
        {
            try
            {
                GetNumberOfPrize();
                setProbailityNumber.Clear();
                GetProbabilityPrize();

                for (int i = 0; i < setPrizeNumber.Count; i++)
                {
                    int number = 0;
                    for (int j = 0; j < setPrizeNumber[i]; j++)
                    {

                        if (number < setPrizeNumber[i])
                        {
                            setProbailityNumber.Add(setProbaility[i] / setPrizeNumber[i]);


                        }

                        ++number;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        /// <summary>
        /// 得到后台中设置的奖项名称
        /// </summary>
        public void GetNameOfPrize()
        {
            setPrizeName.Clear();
            setPrizeName.Add(textBox1.Text);
            setPrizeName.Add(textBox3.Text);
            setPrizeName.Add(textBox5.Text);
            setPrizeName.Add(textBox7.Text);

            System.Windows.Controls.TextBox tb;
            int textnumber = 1;
            for (int i = 0; i < grid.Children.Count; i++)
            {
                tb = grid.Children[i] as System.Windows.Controls.TextBox;

                if (tb != null && tb.Name == "text" + textnumber && tb.Text != "")
                {
                    // System.Windows.Forms.MessageBox.Show(tb.Name);
                    setPrizeName.Add(tb.Text);
                    textnumber++;
                }
            }
        }
        /// <summary>
        /// 生成转盘内应有的所有奖项
        /// </summary>
        public void GetNameListOfPrize()
        {
            try
            {
                GetNumberOfPrize();
                GetNameOfPrize();
                setPrizeNameAndNumber.Clear();
                int number = 0;
                for (int i = 0; i < setPrizeNumber.Count; i++)
                {
                    for (int j = 0; j < setPrizeNumber[i]; j++)
                    {
                        setPrizeNameAndNumber.Add(setPrizeName[i]);

                        number++;
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
        ///<summary>
        ///判断概率事件和是否为一
        /// </summary>

        public float SumProbaility()
        {
            float probaility_count = 0;
            try
            {
                if (setProbaility.Count > 0)
                {
                    for (int i = 0; i < setProbaility.Count; i++)
                    {
                        probaility_count += setProbaility[i];
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("请填写奖项概率");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            return probaility_count;

        }
        /// <summary>
        /// 建数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void ConnectSplite(string radio)
        {
            SQLiteConnection conn = null;
            TextRange textRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
            
            string dbPath = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "/winning_information.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            string sql = "CREATE TABLE IF NOT EXISTS aword_Information(name varchar(11), probaility FLOAT,radio varchar(5),content TEXT);";//建表语句  
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  

            string sqlSelect = "select * from aword_Information ";
            SQLiteCommand cmdSelect = new SQLiteCommand(sqlSelect, conn);
            int count=   cmdSelect.ExecuteNonQuery();//如果表不存在，创建数据表  
            if (count >= 0)
            {
                string sqlDelete = "delete  from aword_Information ";
                SQLiteCommand cmdDelete = new SQLiteCommand(sqlDelete, conn);
                cmdDelete.ExecuteNonQuery();//如果表不存在，创建数据表  

                //using (SQLiteTransaction tran = conn.BeginTransaction())//实例化一个事务  
                //{


                    SQLiteCommand cmd = new SQLiteCommand(conn);//实例化SQL命令 
                    //cmd.Transaction = tran;
                    for (int i = 0; i < setPrizeNameAndNumber.Count; i++)
                    {


                        cmd.CommandText = "insert into aword_Information values(@name, @probaility,@radio,@content)";//设置带参SQL语句  
                        cmd.Parameters.AddRange(new[] {//添加参数  
                           new SQLiteParameter("@name", setPrizeNameAndNumber[i]),  
                           new SQLiteParameter("@probaility", setProbailityNumber[i]),
                             new SQLiteParameter("@radio", radio),
                               new SQLiteParameter("@content", textRange.Text)
                           
                       });
                        cmd.ExecuteNonQuery();//执行查询  

                       // tran.Commit();//提交  
                    }
               // }
                    System.Windows.MessageBox.Show("设置成功");
            }
            else 
            {

            }
            conn.Close();
        }
        private void ShowBackGroundBtn_Click(object sender, RoutedEventArgs e)
        {
            GetProbilityListOfPrize();
            GetNameListOfPrize();

            if (setPrizeNameAndNumber.Count != 8)
            {
                System.Windows.Forms.MessageBox.Show("请将信息填写完整");
            }
            else
            {
                if (SumProbaility() == 1)
                {
                    if (radioButton1.IsChecked == false)
                    {
                        //BackgroundFormPic winBackgroundFormPic = new BackgroundFormPic(setBackgroundFilPath, setPrizeNameAndNumber, setProbailityNumber, false);
                        ConnectSplite("false");
                        //winBackgroundFormPic.Show();
                        //this.Close();

                    }
                    else
                    {
                        //BackgroundFormPic winBackgroundFormPic = new BackgroundFormPic(setBackgroundFilPath, setPrizeNameAndNumber, setProbailityNumber, true);
                        ConnectSplite("true");
                        //winBackgroundFormPic.Show();
                        //this.Close();
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("概率之和不为一，请重新分配");
                }

            }
        }
    }
}
