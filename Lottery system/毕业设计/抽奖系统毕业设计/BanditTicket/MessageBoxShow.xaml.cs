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
using System.Media;
using System.Threading;

namespace BanditTicket
{
    /// <summary>
    /// MessageBoxShow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxShow : Window
    {
        
        public MessageBoxShow( string aword)
        {
            InitializeComponent();
           
            string backgroundFilPath = System.AppDomain.CurrentDomain.BaseDirectory + "xi.jpg";
            ImageBrush back = new ImageBrush();
            back.ImageSource = new BitmapImage(new Uri(backgroundFilPath, UriKind.RelativeOrAbsolute));

            grid.Background = back;
            label1.Content = aword;
        }
        SoundPlayer soundPlayer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            soundPlayer = new SoundPlayer(System.Environment.CurrentDirectory + "\\zj.wav");
            soundPlayer.PlayLooping();
            Thread ts = new Thread(new ThreadStart(PlaySound));
            ts.Start();
        }
        private void PlaySound() {

            Thread.Sleep(2000);
            soundPlayer.Stop();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
       //  BackgroundFormPic bc = new BackgroundFormPic();
        // bc.Show();
        
            this.Close();
            soundPlayer.Stop();

           
        }
    }
}
