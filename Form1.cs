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
using WindowsFormsApplication1;
using rm.Trie;
using System.Timers;
using System.Diagnostics;

namespace WindowsFormsApplication1
{



    public partial class Form1 : Form
    {


        Field Pole = new Field();
        Trie wordtree = new Trie();
        Trie revwordtree = new Trie();
        List<string> slova = new List<string>();
        List<string> slovarb = new List<string>();
        List<string> help = new List<string>();
        bool Player = false;
        bool gamesbegin = false;
        TextBox[,] ColorMass = new TextBox[5, 5];
        List<Tuple<int, int>> ss = new List<Tuple<int, int>>();
        List<Tuple<int, int>> textboxreadonly = new List<Tuple<int, int>>();
        int itbPrev, jtbPrev, dl, dl1, dl2;
        int timeLeft = 12;

        private void button3_Click(object sender, EventArgs e)
        {
            Player = !Player;
            timer1.Stop();
            timeLeft = 120;
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label6.Text) < Convert.ToInt32(label7.Text))
            {
                MessageBox.Show("Второй игрок победил");
            }
            if (Convert.ToInt32(label6.Text) > Convert.ToInt32(label7.Text))
            {
                MessageBox.Show("Первый игрок победил");
            }
            if (Convert.ToInt32(label6.Text) == Convert.ToInt32(label7.Text))
            {
                MessageBox.Show("Ничья");
            }
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            label6.Text = "";
            label7.Text = "";
            timer1.Stop();
            timer1.Stop();
            timeLeft = 120;
        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            if (label5.Text.Length >= 40)
            {
                ICollection<string> test;
                string test2 = label5.Text;
                test = wordtree.GetWords(test2);
                int lineC = test.Count;
                textBox28.Clear();
                for (int line = 0; line < lineC; line++)
                {
                    textBox28.Text = textBox28.Text + test.ElementAt(line) + "\r\n";
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new Stopwatch();
            sw.Start();
            textBox28.Clear();

            List<string> helpdub = new List<string>();
            List<string> helpdub1 = new List<string>();
            List<string> helpdub2 = new List<string>();
            Pole.ReadMap();
            textboxreadonly.Clear();
            Pole.nexthelp();
            Pole.setslovar(wordtree);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (ColorMass[i, j].Text!="")
                    {
                        textboxreadonly.Add(new Tuple<int, int>(i, j));
                    }

                }

            for (int i = 0; i < textboxreadonly.Count; i++)
                for (int j = 0; j < textboxreadonly.Count; j++)
                {
                    paths p = new paths();
                    help.AddRange(Pole.FindWord(textboxreadonly[i].Item1, textboxreadonly[i].Item2, p, "", false));
              

                }
            Pole.setslovar(revwordtree);
            for (int i = 0; i < textboxreadonly.Count; i++)
                for (int j = 0; j < textboxreadonly.Count; j++)
                {
                    paths p = new paths();

                    foreach (var item in Pole.FindWord(textboxreadonly[i].Item1, textboxreadonly[i].Item2, p, "", false))
                    {
                        help.Add(Reverse(item));
                    }
                    
                }


            helpdub1 = help.Distinct().OrderByDescending(x => x.Length).ToList<string>();
            //foreach (var item in helpdub1)
            //{

            //    foreach (var word in wordtree.GetWords(item))
            //    {
            //        if (word.Length==item.Length+1)
            //        {
            //            helpdub2.Add(word);
            //        }
            //    }
            // }


            List<string> f = new List<string>(helpdub1.Distinct().Except(slova));
            int lineC = f.Count;
            for (int line = 0; line < lineC; line++)
            {

                textBox28.Text = textBox28.Text + f.ElementAt(line) + "\r\n";  //вернуть на f как было.
            }

            help.Clear();
            Pole.Afterhelp();
            sw.Stop();
            label9.Text = (sw.ElapsedMilliseconds / 100.0).ToString();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }



        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)

        {

            if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                Timer.Text = "Осталось времени: " + timeLeft;
            }
            else
            {
                timer1.Stop();
                button3.PerformClick();
                timeLeft = 120;
                timer1.Start();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public Form1()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            dl1 = 0;
            dl2 = 0;
            itbPrev = 50;
            jtbPrev = 50;
            bool textboxfull = true;
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
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
            Pole.words = label8;
            Pole.puti = label9;
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
                revwordtree.AddWord(new string(sv.Reverse().ToArray()));
                wordtree.AddWord(sv);
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
                        textBox11.BackColor = Color.White;
                        textBox12.BackColor = Color.White;
                        textBox13.BackColor = Color.White;
                        textBox14.BackColor = Color.White;
                        textBox15.BackColor = Color.White;
                        gamesbegin = true;
                        Pole.begin();
                        Pole.setslovar(wordtree);
                        slova.Add(st);
                        //    Pole.slova = slovarb;
                        break;// останавливаем цикл
                    }
                    else
                    {
                        temp = temp - 1;
                    }


                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timeLeft = 120;
            timer1.Start();
            label6.Text = "0";
            label7.Text = "0";
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;





        }


        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char i = e.KeyChar;
            if (!((i >= 1072 && i <= 1103) || (i == 8) || (i == 46)))

            {
                e.Handled = true;
            }

        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
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
                    if (Player == false)
                    {

                        dl1 = dl + dl1;
                        textBox26.Text = textBox26.Text + label5.Text + " " + dl + "\r\n";
                        Player = true;
                        label6.Text = dl1 + "";
                        label5.Text = "";
                        itbPrev = 50;
                        jtbPrev = 50;
                        ss.Clear();
                        timer1.Stop();
                        timeLeft = 120;
                        timer1.Start();

                    }
                    else
                    {
                        dl2 = dl + dl2;
                        textBox27.Text = textBox27.Text + label5.Text + " " + dl + "\r\n";
                        Player = false;
                        label7.Text = dl2 + "";
                        label5.Text = "";
                        itbPrev = 50;
                        jtbPrev = 50;
                        ss.Clear();
                        timer1.Stop();
                        timeLeft = 120;
                        timer1.Start();
                    }
                    // Если такое слово/посчитать длину слова, записать в поле игрока 1/2 



                }
                else
                {
                    MessageBox.Show("Такого слова нет ");//djn
                    label5.Text = "";
                    ss.Clear();
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
}
