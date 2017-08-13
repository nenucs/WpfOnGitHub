using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfOnGithub
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string url = UrlToCommit.Text;
            string url = "http://www.baidu.com";

            //创建http链接  
            //HttpWebRequest对象实例:该类用于获取和操作HTTP请求 var可改成HttpWebRequest  
            var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url); //Create:创建WebRequest对象  

            //HttpWebResponse对象实例:该类用于获取和操作HTTP应答 var可改成HttpWebResponse  
            var response = (System.Net.HttpWebResponse)request.GetResponse(); //GetResponse:获取答复  

            //构造数据流对象实例  
            Stream stream = response.GetResponseStream();//GetResponseStream:获取应答流  
            StreamReader sr = new StreamReader(stream);  //从字节流中读取字符  

            //从流当前位置读取到末尾并显示在WebBrower控件中  
            string content = sr.ReadToEnd();
            Uri uri = new Uri(url);
            try
            {
                WebBrowser1.Navigate(uri);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
