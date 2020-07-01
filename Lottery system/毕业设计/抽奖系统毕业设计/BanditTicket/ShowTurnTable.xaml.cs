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
using System.Windows.Media.Animation;
using System.Windows.Threading;

using BanditTicket.Properties;
using System.Media;
using System.Data.SQLite;

namespace BanditTicket
{
    /// <summary>
    /// Turntable.xaml 的交互逻辑
    /// </summary>
    /// 
    
    public partial class ShowTurnTable : UserControl
    {
       
        public ShowTurnTable()
        {
            InitializeComponent();

         
            _ListAngle.Add(5111);
            _ListAngle.Add(5284);
            _ListAngle.Add(5155);
            _ListAngle.Add(5329);
            _ListAngle.Add(5198);
            _ListAngle.Add(5422);
            _ListAngle.Add(5242);
            _ListAngle.Add(5374);


            ConnectSelect();
            SetPrizeName();

        }
      
        private List<string> PrizeNameAndNumber=new List<string>();
        private List<float> prizeProbaility=new List<float>();
         ///<summary>
         ///查询数据库
        /// </summary>

        private void ConnectSelect() 
        {
            SQLiteConnection conn = null;
            int i=0;
            string dbPath = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "/winning_information.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            string sql = "select * from aword_Information ";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               // MessageBox.Show(reader["name"].ToString());
                PrizeNameAndNumber.Add( reader["name"].ToString());
                prizeProbaility.Add(float.Parse(reader["probaility"].ToString()));
                i++;
            }

            conn.Close();
        }

        /// <summary>
        /// 外部获取转盘内所有奖项
        /// </summary>
        //public List<string> SetPrizeNameAndNumber
        //{
        //    get { return setPrizeNameAndNumber; }
        //    set { setPrizeNameAndNumber = value; }
        //}

       ///<summary>
       ///生成概率事件
       ///</summary>
        private void ProbailityEvent()
        {
            float minProbaility = prizeProbaility.Min();
            int denominator = XXtoBL(Convert.ToDecimal(minProbaility));
           // int prizeSumCount =Convert.ToInt32(prizeProbaility.Sum() * XXtoBL(Convert.ToDecimal(minProbaility)));
           
           
            int number0 = Convert.ToInt32(prizeProbaility[0] * denominator);
            int number1 = Convert.ToInt32(prizeProbaility[1] * denominator);
            int number2 = Convert.ToInt32(prizeProbaility[2] * denominator);
            int number3 = Convert.ToInt32(prizeProbaility[3] * denominator);
            int number4 = Convert.ToInt32(prizeProbaility[4] * denominator);
            int number5 = Convert.ToInt32(prizeProbaility[5] * denominator);
            int number6 = Convert.ToInt32(prizeProbaility[6] * denominator);
            int number7 = Convert.ToInt32(prizeProbaility[7] * denominator);
            //MessageBox.Show(number0 + "  " + number1 + "  " + number2 + "  " + number3 + "  " + number4 + "  " + number5 + "  " + number6.ToString() + "  " + number7.ToString() + "  ");
            int prizeSumCount = number0 + number1 + number2 + number3 + number4 + number5 + number6 + number7;
          // MessageBox.Show(prizeSumCount.ToString());
            int index = _Random.Next(0, prizeSumCount);
           // MessageBox.Show(index.ToString());
            if (0 <= index && index < number0) 
            {
                _Index = 0;
                
            }
            else if (number0 <= index && index < number0 + number1)
            {
                _Index = 1;
            }
            else if (number0 + number1 <= index && index < number0 + number1 + number2)
            {
                _Index = 2;
            }
            else if (number0 + number1 + number2 <= index && index < number0 + number1 + number2 + number3)
            {
                _Index = 3;
            }
            else if (number0 + number1 + number2 + number3 <= index && index < number0 + number1 + number2 + number3 + number4)
            {
                _Index = 4;
            }
            else if (number0 + number1 + number2 + number3 + number4 <= index && index < number0 + number1 + number2 + number3 + number4 + number5)
            {
                _Index = 5;
            }
            else if (number0 + number1 + number2 + number3 + number4 + number5 <= index && index < number0 + number1 + number2 + number3 + number4 + number5 + number6)
            {
                _Index = 6;
            }
            else if (number0 + number1 + number2 + number3 + number4 + number5 + number6 <= index && index <= prizeSumCount)
            {
                _Index = 7;
            }
            else
            {
                _Index = 6;
            }
           // MessageBox.Show(_Index.ToString());
        }

        ///<summary>
        ///将小数化成分数
        /// </summary>

        public int XXtoBL(decimal XX)
        {
            int x1 = 1;
            //判断传入的数小数点后有几位小数
            int XXWS = XX.ToString().IndexOf(".");
            string XXBF = XX.ToString().Substring(XXWS + 1, XX.ToString().Length - XXWS - 1);
            for (int i = 0; i < XXBF.Length; i++)
            {
                x1 = x1 * 10;
            }
            return x1;
        }

        /// <summary>
        /// 保存八个角度
        /// </summary>
        List<int> _ListAngle = new List<int>();
        /// <summary>
        /// 产生随机数
        /// </summary>
        Random _Random = new Random();
        int _Index = 0;
        int _OldAngle = 22;
        SoundPlayer soundPlayer;
        private void btnStartTurntable_Click(object sender, RoutedEventArgs e)
        {
            btnStartTurntable.IsEnabled = false;
            ProbailityEvent();
            Storyboard sb = (Storyboard)this.FindResource("zhuandong");
            sb.Completed -= this.sb_Completed;
            sb.Completed += new EventHandler(sb_Completed);
            ((SplineDoubleKeyFrame)((DoubleAnimationUsingKeyFrames)sb.Children[0]).KeyFrames[0]).Value = _OldAngle;
            ((SplineDoubleKeyFrame)((DoubleAnimationUsingKeyFrames)sb.Children[0]).KeyFrames[3]).Value = _ListAngle[_Index];
            sb.Begin();
            soundPlayer =new SoundPlayer(System.Environment.CurrentDirectory + "\\2.wav");
            soundPlayer.PlayLooping();
           
        }

        void sb_Completed(object sender, EventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);//等待出结果的时间
            dt.Tick += delegate 
            {
                dt.Stop();
                _OldAngle = (_ListAngle[_Index] % 360);
                btnStartTurntable.IsEnabled = true;
                soundPlayer.Stop();
                AwardProcess(GetAward(_ListAngle[_Index]));
            };
            dt.Start();
        }

        public delegate void AwardDelegate(string award);

        /// <summary>
        /// 返回转到的奖项信息
        /// </summary>
        public event AwardDelegate AwardProcess;

        private string GetAward(int angle)
        {
            
            string result="";
            switch (angle)
            {
                case 5111:
                    result = PrizeNameAndNumber[0].ToString();
                    //_ListAngle.RemoveAt(_Index);
                    break;
                case 5155:
                    result = PrizeNameAndNumber[2].ToString();
                    break;
                case 5198:
                    result = PrizeNameAndNumber[4].ToString();
                   // _ListAngle.RemoveAt(_Index);
                    break;
                case 5242:
                    result = PrizeNameAndNumber[6].ToString();
                    break;
                case 5284:
                    result = PrizeNameAndNumber[1].ToString();
                   // _ListAngle.RemoveAt(_Index);
                    break;
                case 5329:
                    result = PrizeNameAndNumber[3].ToString();
                    break;
                case 5374:
                    result = PrizeNameAndNumber[7].ToString();
                   // _ListAngle.RemoveAt(_Index);
                    break;
                case 5422:
                    result = PrizeNameAndNumber[5].ToString();
                    break;
                default:
                    break;
            }

            return result;
        }

        public void SetPrizeName()
        {

            first_prize.Text = PrizeNameAndNumber[0].ToString();
            thanks_join2.Text = PrizeNameAndNumber[2].ToString();
            second_prize.Text = PrizeNameAndNumber[4].ToString();
            thanks_join3.Text = PrizeNameAndNumber[6].ToString();
            third_prize.Text = PrizeNameAndNumber[1].ToString();
            thanks_join4.Text = PrizeNameAndNumber[3].ToString();
            lucky_prize.Text = PrizeNameAndNumber[7].ToString();
            thanks_join1.Text = PrizeNameAndNumber[5].ToString();
        }
    }
    
}
