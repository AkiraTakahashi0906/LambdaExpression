using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaExpression
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = new string[] {"A","BB","CCC","DDDD","EEEEE" };
            var result = GetValue1(values);
            Console.WriteLine(string.Join(",", result));
        }

        private string[] GetValue1(string [] values)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (val.Length >= 3)
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue2(values,4);
            Console.WriteLine(string.Join(",", result));
        }

        private string[] GetValue2(string[] values,int len)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (val.Length >= len)
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue3(values, Shiki1);
            Console.WriteLine(string.Join(",", result));
        }

        delegate bool LenCheck(string value);

        private bool Shiki1(string value)
        {
            return value.Length == 3;
        }

        private string[] GetValue3(string[] values, LenCheck lenCheck)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (lenCheck(val))
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }

        private bool Shiki2(string value)
        {
            return value.Length >= 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue3(values, Shiki2);
            Console.WriteLine(string.Join(",", result));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue5(values,3, Shiki3);
            Console.WriteLine(string.Join(",", result));
        }

        delegate bool LenCheck5(string value,int len);
        private string[] GetValue5(string[] values, int len, LenCheck5 lenCheck)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (lenCheck(val, len))
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }
        private bool Shiki3(string value ,int len)
        {
            return value.Length == len;
        }

        private bool Shiki4(string value, int len)
        {
            return value.Length >= len;
        }

        //匿名メソッド
        private void button6_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue3(values,
                                               //匿名メソッド
                                              delegate (string s) { return s.Length == 3; }
                                              );
            Console.WriteLine(string.Join(",", result));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue3(values,
                                              //匿名メソッド
                                              delegate (string s) { return s.Length >= 4; }
                                              );
            Console.WriteLine(string.Join(",", result));
        }
    }
}
