using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        StreamWriter outputFile = new StreamWriter("Log.txt", true);

        string input = "";  //first operand
        string input2 = "";  //second operand

        bool step2 = false;  //becomes true if first operand has been inputted
            
        private void DisplayInput(string num) //displays input
        { 
            if (step2)
            {
                input2 += num;
                outputLabel.Text = input2;
            }
            else
            {
                input += num;
                outputLabel.Text = input;
            }
        }

        private void Button_Click(object sender, EventArgs e) //click events for entire form
        {
            string[] ops = { "/", "*", "-", "+", "+-", "=" };            
            Button button = (Button)sender;
            if (ops.Contains(button.Text))
            {
                OperatorClick(button.Text);
            }
            else if (button.Text == "Save Log")
            {
                outputFile.WriteLine(DateTime.Now.ToString());
                outputFile.Close();
            }
            else
            {
                DisplayInput(button.Text);
            }            
        }

        //variables to use in calculate method 
        public bool addition = false;
        public bool subtraction = false;
        public bool multiplication = false;
        public bool division = false;

        private void OperatorClick(string op)  //uses chosen operator for correct operation with exception handling
        {
            switch (op)
            {
                case "+":
                    if (addition == true)
                    {
                        MessageBox.Show("Please enter a number then press '+' again.");
                    }
                    else
                    {
                        Log("+");
                        addition = true;
                        step2 = true;
                        outputLabel.Text += "+\r\n";
                    }
                    break;

                case "/":
                    if (division)
                    {
                        MessageBox.Show("Please enter a number then press '/' again.");
                        break;
                    }
                    else
                    {
                        Log("/");
                        division = true;
                        step2 = true;
                        outputLabel.Text += "/\r\n";
                        break;
                    }                                        

                case "*":
                    if (multiplication)
                    {
                        MessageBox.Show("Please enter a number then press '*' again.");
                        break;
                    }
                    else
                    {
                        Log("*");
                        multiplication = true;
                        step2 = true;
                        outputLabel.Text += "*\r\n";
                        break;
                    }
                    

                case "-":
                    if (subtraction)
                    {
                        MessageBox.Show("Please enter a number then press '-' again.");
                        break;
                    }
                    else
                    {
                        Log("-");
                        subtraction = true;
                        step2 = true;
                        outputLabel.Text += "-\r\n";
                        break;
                    }
                    

                case "=":
                    Log(null);
                    input = Calculate(input, input2).ToString();
                    input2 = "";
                    outputFile.WriteLine("=");
                    Log(null);
                    outputFile.WriteLine("\r\n");
                    break;

                case "+-":
                    if (step2)
                    {
                        double newNum = double.Parse(input2);
                        input2 = (-newNum).ToString();
                        outputLabel.Text = input2;
                        break;
                    }
                    else
                    {
                        double newNum = double.Parse(input); ;
                        input = (-newNum).ToString();
                        outputLabel.Text = input;
                        break;
                    }
                    
            }
        }

        double total = 0;
       
        private double Calculate(string input, string input2)  //executes when '=' is pressed
        {
            if (addition)
            {
                total = Calc.Add(input, input2);
                addition = false;
            }
            else if (subtraction)
            {
                total = Calc.Subtract(input, input2);
                subtraction = false;
            }
            else if (multiplication)
            {
                total = Calc.Multiply(input, input2);
                multiplication = false;
            }
            else if (division)
            {
                total = Calc.Divide(input, input2);
                division = false;
            }

            outputLabel.Text = total.ToString();
            return total;
        }

        private void Log(string sign)  //uses streamWriter object to log calculations
        {
            if (input2 == "")
            {
                outputFile.WriteLine(input + sign);
            }
            else
            {
                outputFile.WriteLine(input2);
            }
        }
    }    
}
