using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            string WordToTranslate = TextBox1.Text;
            string transText;

            HttpWebRequest wrGETURL = (HttpWebRequest)WebRequest.Create("http://translate.google.com.ua/translate_a/t?client=t&text=" + WordToTranslate + "&hl=ru&sl=en&tl=ru&ie=UTF-8&oe=UTF-8&multires=1&prev=btn&ssel=0&tsel=0&sc=1");
            HttpWebResponse vkHttpWebResponse = (HttpWebResponse)wrGETURL.GetResponse();

            StreamReader vkStreamReader = new StreamReader(vkHttpWebResponse.GetResponseStream());
            string response = vkStreamReader.ReadToEnd();

            response = response.Replace('[', '1');
            response = response.Replace('"', '2');

            Regex transTextRegex = new Regex(@"(1112)(\w*)(2)");
            Match transTextMatch = transTextRegex.Match(response);
            transText = transTextMatch.Value;
            transText = transText.Remove(0, 4);
            transText = transText.Remove(transText.Length - 1, 1);

            TextBox2.Text = transText;
            
        }
    }
}
