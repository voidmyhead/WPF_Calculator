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

namespace wpfcalcal
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
   

    public partial class MainWindow : Window
    {
        private bool opFlag = false;
        private double lvalue;
        private char btn_operation = '\0';

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Num_Button_Click(object sender, RoutedEventArgs e)//숫자버튼
        {
            if (result_label.Content.ToString() == "0" || opFlag == true)
            {
                result_label.Content = ((Button)sender).Content;
                opFlag = false;
            }
            else if (result_label.Content.ToString() == "-0") //+- 버튼에 의해서 -01 이런 숫자대신 -1이 출력될 수 있도록 하는 조건
            {
                result_label.Content = "-" + ((Button)sender).Content;
                opFlag = false;
            }
            else
            {
                result_label.Content = result_label.Content.ToString() + ((Button)sender).Content;
            }

            if (result_label.Content.ToString() != "0")
            {
                AC.Content = "C";
            }

        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)//AC버튼
        {
            result_label.Content = 0;
            AC.Content = "AC";
        }

        private void Dot_Button_Click(object sender, RoutedEventArgs e)//. 버튼
        {
            if (result_label.Content.ToString().Contains("."))
                return;
            else
                result_label.Content = result_label.Content.ToString() + ".";
        }

        private void OP_Button_Click(object sender, RoutedEventArgs e) //연산자 버튼
        {
            lvalue = Double.Parse(result_label.Content.ToString());

            if (((Button)sender).Content.ToString() == "+")
            {
                btn_operation = '+';
                opFlag = true;
            }
            else if (((Button)sender).Content.ToString() == "-")
            {
                btn_operation = '-';
                opFlag = true;
            }
            else if (((Button)sender).Content.ToString() == "X")
            {
                btn_operation = '*';
                opFlag = true;
            }
            else if (((Button)sender).Content.ToString() == "÷")
            {
                btn_operation = '/';
                opFlag = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //결과 버튼
        {
            Double rvalue = Double.Parse(result_label.Content.ToString());
            switch (btn_operation)
            {
                case '+':
                    {
                        result_label.Content = (lvalue + rvalue).ToString();
                        break;
                    }
                case '-':
                    {
                        result_label.Content = (lvalue - rvalue).ToString();
                        break;
                    }
                case '*':
                    {
                        result_label.Content = (lvalue * rvalue).ToString();
                        break;
                    }
                case '/':
                    {
                        result_label.Content = (lvalue / rvalue).ToString();
                        break;
                    }
            }
        }

        private void CHG_Button_Click(object sender, RoutedEventArgs e)//+- 버튼
        {
            double chg_value = Double.Parse(result_label.Content.ToString());
            bool yn = result_label.Content.ToString().Contains("-");
            if (yn == false)
            {
                result_label.Content = "-" + result_label.Content.ToString();
            }
            else if (yn == true)
            {
                result_label.Content = result_label.Content.ToString().Substring(1);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)// %버튼
        {
            result_label.Content = Double.Parse(result_label.Content.ToString()) * 0.01;
        }
    }
}
