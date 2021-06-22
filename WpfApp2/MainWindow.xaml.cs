using System;
using System.Collections.Generic;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public double AnswerQuarry(string s)
        {
            int n;
            char[] c = { '+', '-', '/', '*'};
            n = s.IndexOfAny(c);
            if (n == -1)
            {
                return Convert.ToDouble(s);
            }

            char[] c1 = { '+', '-' };
            n = s.IndexOfAny(c1);
            if (n != -1)
            {
                string s1 = s.Substring(0, n);
                string s2 = s.Substring(n + 1);
                if (s.IndexOf('+') != -1)
                {
                    return AnswerQuarry(s1) + AnswerQuarry(s2);
                }
                else
                {
                    return AnswerQuarry(s1) - AnswerQuarry(s2);
                }
            }
            else
            {
                char[] c2 = { '/', '*' };
                n = s.IndexOfAny(c2);
                string s1 = s.Substring(0, n);
                string s2 = s.Substring(n + 1);
                if (s.IndexOf('*') != -1)
                {
                    return AnswerQuarry(s1) * AnswerQuarry(s2);
                }
                else
                {
                    return AnswerQuarry(s1) / AnswerQuarry(s2);
                }
            }

        }
        public bool ContainsComma(string s)
        {
            string res = s;
            res = res.Split('+')[res.Split('+').Length - 1];
            res = res.Split('-')[res.Split('-').Length - 1];
            res = res.Split('/')[res.Split('/').Length - 1];
            res = res.Split('*')[res.Split('*').Length - 1];
            return res.Contains(',');
        }
        public void Enter(char c)
        {
            if (c == 'C')
            {
                Quarry.Text = "";
            }
            else
            {
                if (Quarry.Text != "")
                {
                    if (!(",+-/*".Contains(Quarry.Text[Quarry.Text.Length - 1]) && ",+-/*".Contains(c)))
                    {
                        Quarry.Text += c;
                    }
                }
                else
                {
                    Quarry.Text += c;
                }
            }
            
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Button b = (sender as Button);
            char c = ((string)b.Content)[0];
            Enter(c);
        }

        private void B42_Click(object sender, RoutedEventArgs e)
        {
            Solution.Text = Convert.ToString(AnswerQuarry(Quarry.Text));
        }
    }
}
