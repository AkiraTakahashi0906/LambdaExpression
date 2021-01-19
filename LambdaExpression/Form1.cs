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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            var result = new List<string>();
            foreach (var val in values)
            {
                if (val.Length >= 3)
                {
                    result.Add(val);
                }
            }

            Console.WriteLine(string.Join(",", result));

            var result2 = GetValue1(values);
            Console.WriteLine(string.Join(",", result2));
        }

        private string[] GetValue1(string[] values)
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

        private string[] GetValue2(string[] values, int len)
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

        private void button2_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue2(values, 4);
            Console.WriteLine(string.Join(",", result));
        }

        //delegate
        private void button3_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue3(values, Shiki1);
            Console.WriteLine(string.Join(",", result));
        }

        delegate bool LenCheck(string value);

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

        private bool Shiki1(string value)
        {
            return value.Length == 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue3(values, Shiki2);
            Console.WriteLine(string.Join(",", result));
        }

        private bool Shiki2(string value)
        {
            return value.Length >= 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue5(values, 3, Shiki4);
            Console.WriteLine(string.Join(",", result));
        }

        delegate bool LenCheck5(string value, int len);

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

        private bool Shiki3(string value, int len)
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

            //delegate bool LenCheck(string value);
            var result = GetValue3(
                values,
                delegate (string value) { return value.Length == 3; }
                );
            Console.WriteLine(string.Join(",", result));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            //delegate bool LenCheck(string value);
            var result = GetValue3(
                values,
                delegate (string value) { return value.Length >= 4; }
                );
            Console.WriteLine(string.Join(",", result));
        }

        //Predicate
        //プレディケート
        //delegate bool LenCheck(string value);

        private void button8_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            //delegate bool LenCheck(string value);
            var result = GetValue8(
                values,
                delegate (string value) { return value.Length == 3; }
                );
            Console.WriteLine(string.Join(",", result));
        }

        private string[] GetValue8(string[] values, Predicate<string> predicate)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (predicate(val))
                {
                    result.Add(val);
                }
            }
            return result.ToArray();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

            //匿名メソッド
            var result = GetValue8(
                values,
                delegate (string value) { return value.Length == 3; }
                );
            Console.WriteLine(string.Join(",", result));

            //ラムダ式1
            var result2 = GetValue8(
                values,
                 (value) =>
                 {
                     return value.Length == 3;
                 }
                );
            //ラムダ式2
            var result3 = GetValue8(
                values,
                 value =>
                 {
                     return value.Length == 3;
                 }
                );

            //ラムダ式3
            var result4 = GetValue8(values, value => value.Length == 3);
            Console.WriteLine(string.Join(",", result4));
        }

        //delegate bool LenCheck5(string value, int len);
        private void button10_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue10(values, 3, 
                                                (value,len)=>value.Length>= len);
            Console.WriteLine(string.Join(",", result));
        }

        private string[] GetValue10(string[] values, int len, Func<string,int,bool> lenCheck)
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

        private void button11_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            var result = GetValue10(values, 3,
                                                (value, len) =>
                                                {
                                                    if (value[0] == 'E')
                                                    {
                                                        return value.Length >= len;
                                                    }
                                                    return false;
                                                });
            Console.WriteLine(string.Join(",", result));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GetData(DoConsole);
            GetData(DoText);
        }

        private void DoConsole(int value)
        {
            Console.WriteLine(value + "%");
        }

        private void DoText(int value)
        {
            this.Text = value + "%";
        }

        private List<string> GetData(Action<int> progressAction)
        {
            var result = new List<string>();
            for (int i =1; i<5; i++)
            {
                result.Add(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                System.Threading.Thread.Sleep(1000);
                progressAction(i*20);
            }
            return result;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            GetData(delegate(int value)
                        {
                            Console.WriteLine(value + "%");
                        });

            GetData(value=>Console.WriteLine(value + "%"));
            GetData(x => Console.WriteLine(x + "%"));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            GetData14(Console14);
        }

        private void Console14()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
        }

        private List<string> GetData14(Action progressAction)
        {
            var result = new List<string>();
            for (int i = 1; i < 5; i++)
            {
                result.Add(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                System.Threading.Thread.Sleep(1000);
                progressAction();
            }
            return result;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            GetData14(delegate ()
                                            {
                                                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                                            });

            GetData14(()=>Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var values = new List<string> { "ABCED", "AAAA", "BBBB", "CCCC", "DDDD" };

            var result = values.Find(x => x.Contains("B"));
            Console.WriteLine(string.Join(",", result));

            var result2 = values.FindAll(x => x.Contains("B"));
            Console.WriteLine(string.Join(",", result2));

            var result3 = values.Exists(x => x.Contains("B"));
            Console.WriteLine(string.Join(",", result3));

            var result4 = values.Where(x => x.Contains("B"));
            Console.WriteLine(string.Join(",", result4));

            //遅延実行
            var result5 = values.Where(x => x.Contains("B"));
            values.Add("EEEEB");
            Console.WriteLine(string.Join(",", result5));

            //即時実行
            var result6 = values.Where(x => x.Contains("B")).ToList();
            values.Add("EEEEB2");
            Console.WriteLine(string.Join(",", result6));

            var result7 = values.Any(x => x.Contains("B"));
            values.Add("EEEEB2");
            Console.WriteLine(string.Join(",", result7));

        }

        private void button17_Click(object sender, EventArgs e)
        {
            var products = new List<Product>();
            products.Add(new Product(1, "p1"));
            products.Add(new Product(2, "p2"));
            products.Add(new Product(3, "p31"));

            var result = products.Find(x => x.Id == 2);
            Console.WriteLine(string.Join(",", result.Name));
        }

        public class Product
        {
            public Product(int id,string name)
            {
                Id = id;
                Name = name;
            }
            public int Id { get; }
            public string Name { get; }
        }
    }
}
