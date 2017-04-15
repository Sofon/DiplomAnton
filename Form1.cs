using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication1
{



    public partial class Form1 : Form
    {
        Field Pole= new Field();
        List<string> slova = new List<string>();
        List<string> slovarb = new List<string>();
        bool Player = false;
        bool gamesbegin = false;
        TextBox[,] ColorMass = new TextBox[5, 5];
        List<Tuple<int, int>> ss = new List<Tuple<int, int>>();
        int itb, jtb, itbPrev, jtbPrev,dl,dl1,dl2;
        public Form1()
        {
            dl1 = 0;
            dl2 = 0;
            itb = 0;
            jtb = 0;
            itbPrev = 50;
            jtbPrev = 50;
            bool textboxfull = true;
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    c.BackColor = Color.White;
                    if (textboxfull)
                    {
                        if (!(c.Text == ""))
                        {
                            int index = Int32.Parse(c.Text) / 5;
                            int index2 = Int32.Parse(c.Text) % 5;
                            ColorMass[index, index2] = c as TextBox;
                     
                            c.Text = "";
                        }

                    }

                }

            }
            Pole.ColorMass = ColorMass;
           
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = string.Empty;
            }
            StreamReader slovar = new StreamReader("ru.txt", Encoding.Default);
            while (!slovar.EndOfStream)
            {
                string sv = slovar.ReadLine();
                slovarb.Add(sv);
            }
            slovar.Close();
            Random rand = new Random();
            int temp;

            temp = rand.Next(2845); //число 5ти буквенных слов в словаре
            StreamReader str = new StreamReader("ru.txt", Encoding.Default);
            while (!str.EndOfStream)
            {
                string st = str.ReadLine();
                if (st.Length == 5)
                {
                    if (temp == 0)
                    {
                        textBox11.Text = st.Substring(0, 1);
                        textBox12.Text = st.Substring(1, 1);
                        textBox13.Text = st.Substring(2, 1);
                        textBox14.Text = st.Substring(3, 1);
                        textBox15.Text = st.Substring(4, 1);
                        textBox11.ReadOnly = true;
                        textBox12.ReadOnly = true;
                        textBox13.ReadOnly = true;
                        textBox14.ReadOnly = true;
                        textBox15.ReadOnly = true;
                        textBox11.BackColor = Color.White;
                        textBox12.BackColor = Color.White;
                        textBox13.BackColor = Color.White;
                        textBox14.BackColor = Color.White;
                        textBox15.BackColor = Color.White;
                        gamesbegin = true;
                        Pole.begin();
                        break;// останавливаем цикл
                    }
                    else
                    {
                        temp = temp - 1;
                    }
                    
                }
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char i = e.KeyChar;
            if (!((i >= 1072 && i <= 1103) || (i == 8) || (i == 46)))

            {
                e.Handled = true;
            }

        }

        private void textBox11_DoubleClick(object sender, EventArgs e)
        {
            int itbCur, jtbCur;
            if (gamesbegin)
            {
                itbCur = 0;
                jtbCur = 0;

                TextBox tb = sender as TextBox;
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        if (tb == ColorMass[i, j])
                        {
                            itbCur = i;
                            jtbCur = j;
                        }
                if (!(tb.Text == ""))
                {

                    if (tb.BackColor == Color.White)
                    {
                        if (itbPrev + jtbPrev == 100)
                        {
                            itbPrev = itbCur;
                            jtbPrev = jtbCur;
                            ss.Add(new Tuple<int, int>(itbCur, jtbCur));
                            tb.BackColor = Color.Yellow;
                            label5.Text = label5.Text + tb.Text;
                        }
                        if (((itbCur == itbPrev) && (jtbCur == jtbPrev + 1)) || ((itbCur == itbPrev) && (jtbCur == jtbPrev - 1)) || ((itbCur == itbPrev + 1) && (jtbCur == jtbPrev)) || ((itbCur == itbPrev - 1) && (jtbCur == jtbPrev)))
                        {
                            itbPrev = itbCur;
                            jtbPrev = jtbCur;
                            ss.Add(new Tuple<int, int>(itbCur, jtbCur));
                            tb.BackColor = Color.Yellow;
                            label5.Text = label5.Text + tb.Text;
                        }
                    }

                    else
                    {
                        if (ss.Count == 1 || ss.Count == 0)
                        {
                            ss.Clear();
                            itbPrev = 50;
                            jtbPrev = 50;
                            tb.BackColor = Color.White;
                            label5.Text = label5.Text.Substring(0, label5.Text.Length - 1);
                            
                        }
                        else
                        {
                            if ((itbCur == ss[ss.Count - 1].Item1) && (jtbCur == ss[ss.Count - 1].Item2))
                            {


                                tb.BackColor = Color.White;
                                itbPrev = ss[ss.Count - 2].Item1;
                                jtbPrev = ss[ss.Count - 2].Item2;
                                ss.RemoveAt(ss.Count - 1);
                                label5.Text = label5.Text.Substring(0, label5.Text.Length - 1);

                            }
                        }


                    }
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Pole.check)
            {
              
                        if (slovarb.Contains(label5.Text) && !(slova.Contains(label5.Text)))
                        {
                            dl = label5.Text.Length;
                            slova.Add(label5.Text);
                            Pole.next();
                            if (Player== false)
                            {

                                dl1 = dl + dl1;
                                textBox26.Text = textBox26.Text+ label5.Text +" "+ dl + "\r\n";
                                Player = true;
                                label6.Text = dl1 + "";
                        label5.Text = "";
                        itbPrev = 50;
                        jtbPrev = 50;
                        ss.Clear();

                    }
                            else
                            {
                                dl2 = dl + dl2;
                                textBox27.Text = textBox27.Text+ label5.Text +" "+ dl + "\r\n";
                                Player = false;
                                label7.Text = dl2 + "";
                        label5.Text = "";
                        itbPrev = 50;
                        jtbPrev = 50;
                        ss.Clear();
                    }
                            // Если такое слово/посчитать длину слова, записать в поле игрока 1/2 
                     

                     
                    }
                        else
                {
                    MessageBox.Show("Такого слова нету ");
                    label5.Text = "";
                    ss.Clear();
                }
                   
                }


                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                        c.BackColor = Color.White;
                itbPrev = 50;
                jtbPrev = 50;
            }

            }
        }
    }


