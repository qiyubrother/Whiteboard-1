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

namespace WhiteBoardTest
{
    /// <summary>
    /// SimpleCounter.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleCounter : UserControl
    {
        private string parameter1 = null;
        private string parameter2 = null;
        private string parameter3 = null;
        private bool state = false;
        private bool stateEqu = false;
    
        public SimpleCounter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {


            if (state == true)
            {
                textBox1.Text += button1.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button1.Content.ToString();
                }
                else
                {
                    parameter2 += button1.Content.ToString();
                }
            }
            else
            {
                if (stateEqu == true && state == false)
                { textBox1.Text = button1.Content.ToString(); }
                else
                {

                    textBox1.Text += button1.Content.ToString();
                }
                parameter1 += button1.Content.ToString();


            }
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            if (parameter1 != null)
            {


                if (stateEqu == true && state == false)
                {

                    parameter1 = textBox1.Text;

                    parameter2 = null;
                }
                else
                {


                    switch (parameter3)
                    {
                        case "+":
                            if (parameter2 == null)
                            {
                                parameter2 = "0";
                            }
                            parameter1 = (double.Parse(parameter1) + double.Parse(parameter2)).ToString();
                            break;
                        case "-":
                            if (parameter2 == null)
                            {
                                parameter2 = "0";
                            }
                            parameter1 = (double.Parse(parameter1) - double.Parse(parameter2)).ToString();
                            break;
                        case "*":
                            if (parameter2 == null)
                            {
                                parameter2 = "1";
                            }
                            parameter1 = (double.Parse(parameter1) * double.Parse(parameter2)).ToString();
                            break;
                        case "/":
                            if (parameter2 == null)
                            {
                                parameter2 = "1";
                            }
                            parameter1 = (double.Parse(parameter1) / double.Parse(parameter2)).ToString();
                            break;
                    }

                    textBox1.Text = parameter1;
                    parameter2 = null;
                }

                textBox1.Text += "\r\n" + "+" + "\t";
                parameter3 = "+";
                state = true;

            }
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            double FirstNum = 0;
            double SecNum = 0;
            if (state == true && parameter2 == null)
            {
                textBox1.Text = parameter1;
               
               
            }
            else if (state == true && parameter2 != null)
            {
                try
                {
                    FirstNum = double.Parse(parameter1);

                }
                catch
                {
                    textBox1.Text = "Not a Num";
                }
                try
                {
                    SecNum = double.Parse(parameter2);
                }
                catch
                {
                    textBox1.Text = "Not a Num";
                }
                switch (parameter3)
                {
                    case "+":
                        textBox1.Text = (FirstNum + SecNum).ToString();
                        break;
                    case "-":
                        textBox1.Text = (FirstNum - SecNum).ToString();
                        break;
                    case "*":
                        textBox1.Text = (FirstNum * SecNum).ToString();
                        break;
                    case "/":
                        textBox1.Text = (FirstNum / SecNum).ToString();
                        break;
                }

                state = false;
                parameter3 = null;
                stateEqu = true;

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            if (state == true)
            {
                textBox1.Text += button2.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button2.Content.ToString();
                }
                else
                {
                    parameter2 += button2.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button2.Content.ToString(); }
                else
                {
                    textBox1.Text += button2.Content.ToString();
                }
                parameter1 += button2.Content.ToString();



            }
            //if (state == true)
            //{
            //    parameter2 += button2.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button2.Content.ToString();
            //}
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            parameter1 = null;
            parameter2 = null;
            parameter3 = null;
            state = false;
            stateEqu = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

            if (state == true)
            {
                textBox1.Text += button3.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button3.Content.ToString();
                }
                else
                {
                    parameter2 += button3.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button3.Content.ToString(); }
                else
                {

                    textBox1.Text += button3.Content.ToString();
                }
                parameter1 += button3.Content.ToString();



            }
            //if (state == true)
            //{
            //    parameter2 += button3.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button3.Content.ToString();
            //}
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

            if (state == true)
            {
                textBox1.Text += button4.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button4.Content.ToString();
                }
                else
                {
                    parameter2 += button4.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button4.Content.ToString(); }
                else
                {

                    textBox1.Text += button4.Content.ToString();
                }
                parameter1 += button4.Content.ToString();



            }
            //if (state == true)
            //{
            //    parameter2 += button4.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button4.Content.ToString();
            //}
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

            if (state == true)
            {
                textBox1.Text += button5.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button5.Content.ToString();
                }
                else
                {
                    parameter2 += button5.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button5.Content.ToString(); }
                else
                {

                    textBox1.Text += button5.Content.ToString();
                }
                parameter1 += button5.Content.ToString();



            }
            //if (state == true)
            //{
            //    parameter2 += button5.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button5.Content.ToString();
            //}
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {

            if (state == true)
            {
                textBox1.Text += button6.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button6.Content.ToString();
                }
                else
                {
                    parameter2 += button6.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button6.Content.ToString(); }
                else
                {

                    textBox1.Text += button6.Content.ToString();
                }
                parameter1 += button6.Content.ToString();



            }
            //if (state == true)
            //{
            //    parameter2 += button6.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button6.Content.ToString();
            //}
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {

            if (state == true)
            {
                textBox1.Text += button7.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button7.Content.ToString();
                }
                else
                {
                    parameter2 += button7.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button7.Content.ToString(); }
                else
                {

                    textBox1.Text += button7.Content.ToString();
                }
                parameter1 += button7.Content.ToString();



            }
            //if (state == true)
            //{
            //    parameter2 += button7.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button7.Content.ToString();
            //}
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            //textBox1.Text += button8.Content.ToString();
            if (state == true)
            {
                textBox1.Text += button8.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button8.Content.ToString();
                }
                else
                {
                    parameter2 += button8.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button8.Content.ToString(); }
                else
                {

                    textBox1.Text += button8.Content.ToString();
                }
                parameter1 += button8.Content.ToString();


            }
            //if (state == true)
            //{
            //    parameter2 += button8.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button8.Content.ToString();
            //}
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {

            if (state == true)
            {
                textBox1.Text += button9.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button9.Content.ToString();
                }
                else
                {
                    parameter2 += button9.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button9.Content.ToString(); }
                else
                {

                    textBox1.Text += button9.Content.ToString();
                }
                parameter1 += button9.Content.ToString();


            }
            //if (state == true)
            //{
            //    parameter2 += button9.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button9.Content.ToString();
            //}
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            if (parameter1 != null)
            {


                if (stateEqu == true && state == false)
                {

                    parameter1 = textBox1.Text;

                    parameter2 = null;
                }
                else
                {
                    switch (parameter3)
                    {
                        case "+":
                            if (parameter2 == null)
                            {
                                parameter2 = "0";
                            }
                            parameter1 = (double.Parse(parameter1) + double.Parse(parameter2)).ToString();
                            break;
                        case "-":
                            if (parameter2 == null)
                            {
                                parameter2 = "0";
                            }
                            parameter1 = (double.Parse(parameter1) - double.Parse(parameter2)).ToString();
                            break;
                        case "*":
                            if (parameter2 == null)
                            {
                                parameter2 = "1";
                            }
                            parameter1 = (double.Parse(parameter1) * double.Parse(parameter2)).ToString();
                            break;
                        case "/":
                            if (parameter2 == null)
                            {
                                parameter2 = "1";
                            }
                            parameter1 = (double.Parse(parameter1) / double.Parse(parameter2)).ToString();
                            break;
                    }
                    //if (parameter2 == null)
                    //{
                    //    parameter2 = "1";
                    //}
                    //int b = int.Parse(parameter1) * int.Parse(parameter2);
                    //parameter1 = b.ToString();
                    textBox1.Text = parameter1;
                    parameter2 = null;
                }

                textBox1.Text += "\r\n" + "*" + "\t";
                parameter3 = "*";
                state = true;

            }
            //if (parameter1 != null)
            //{
            //    if (stateEqu == true)
            //    {
            //        parameter1 = textBox1.Text;
            //        parameter2 = null;
            //    }


            //    textBox1.Text += "\r\n" + "*" + "\r\n";
            //    parameter3 = "*";
            //    state = true;
            //}
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            if (parameter1 != null)
            {


                if (stateEqu == true && state == false)
                {

                    parameter1 = textBox1.Text;

                    parameter2 = null;
                }
                else
                {
                    switch (parameter3)
                    {
                        case "+":
                            if (parameter2 == null)
                            {
                                parameter2 = "0";
                            }
                            parameter1 = (double.Parse(parameter1) + double.Parse(parameter2)).ToString();
                            break;
                        case "-":
                            if (parameter2 == null)
                            {
                                parameter2 = "0";
                            }
                            parameter1 = (double.Parse(parameter1) - double.Parse(parameter2)).ToString();
                            break;
                        case "*":
                            if (parameter2 == null)
                            {
                                parameter2 = "1";
                            }
                            parameter1 = (double.Parse(parameter1) * double.Parse(parameter2)).ToString();
                            break;
                        case "/":
                            if (parameter2 == null)
                            {
                                parameter2 = "1";
                            }
                            parameter1 = (double.Parse(parameter1) / double.Parse(parameter2)).ToString();
                            break;
                    }
                    //if (parameter2 == null)
                    //{
                    //    parameter2 = "0";
                    //}

                    //int b = int.Parse(parameter1) - int.Parse(parameter2);
                    //parameter1 = b.ToString();
                    textBox1.Text = parameter1;
                    parameter2 = null;
                }

                textBox1.Text += "\r\n" + "-" + "\t";
                parameter3 = "-";
                state = true;

            }
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            if (parameter1 != null)
            {


                if (stateEqu == true && state == false)
                {

                    parameter1 = textBox1.Text;

                    parameter2 = null;
                }
                else
                {
                    switch (parameter3)
                    {
                        case "+":
                            if (parameter2 == null)
                            {
                                parameter2 = "0";
                            }
                            parameter1 = (double.Parse(parameter1) + double.Parse(parameter2)).ToString();
                            break;
                        case "-":
                            if (parameter2 == null)
                            {
                                parameter2 = "0";
                            }
                            parameter1 = (double.Parse(parameter1) - double.Parse(parameter2)).ToString();
                            break;
                        case "*":
                            if (parameter2 == null)
                            {
                                parameter2 = "1";
                            }
                            parameter1 = (double.Parse(parameter1) * double.Parse(parameter2)).ToString();
                            break;
                        case "/":
                            if (parameter2 == null)
                            {
                                parameter2 = "1";
                            }
                            parameter1 = (double.Parse(parameter1) / double.Parse(parameter2)).ToString();
                            break;
                    }
                    //if (parameter2 == null)
                    //{
                    //    parameter2 = "1";
                    //}
                    //int b = int.Parse(parameter1) / int.Parse(parameter2);
                    //parameter1 = b.ToString();
                    textBox1.Text = parameter1;
                    parameter2 = null;
                }

                textBox1.Text += "\r\n" + "/" + "\t";
                parameter3 = "/";
                state = true;

            }
            //if (parameter1 != null)
            //{
            //    if (stateEqu == true)
            //    {
            //        parameter1 = textBox1.Text;
            //        parameter2 = null;
            //    }


            //    textBox1.Text += "\r\n" + "/" + "\r\n";
            //    parameter3 = "/";
            //    state = true;
            //}

        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {

            if (state == true)
            {
                textBox1.Text += button16.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button16.Content.ToString();
                }
                else
                {
                    parameter2 += button16.Content.ToString();
                }
            }
            else
            {

                if (stateEqu == true && state == false)
                { textBox1.Text = button16.Content.ToString(); }
                else
                {

                    textBox1.Text += button16.Content.ToString();
                }
                parameter1 += button16.Content.ToString();


            }
            //if (state == true)
            //{
            //    parameter2 += button16.Content.ToString();
            //}
            //else
            //{
            //    parameter1 += button16.Content.ToString();
            //}
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            if (state == true)
            {
                textBox1.Text += button17.Content.ToString();
                if (stateEqu == true)
                {

                    parameter2 += button17.Content.ToString();
                }
                else
                {
                    parameter2 += button17.Content.ToString();
                }
            }
            else
            {
                if (stateEqu == true && state == false)
                {
                    textBox1.Text = button17.Content.ToString();
                }
                else
                {

                    textBox1.Text += button17.Content.ToString();
                }
                parameter1 += button17.Content.ToString();


            }
        }
    }
}
