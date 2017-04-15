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
        bool gamesbegin = false;
        TextBox[,] ColorMass = new TextBox[5, 5];
        List<Tuple<int, int>> ss = new List<Tuple<int, int>>();
        int itb, jtb, itbPrev, jtbPrev;
        public Form1()
        {
             
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
                        ColorMass[itb, jtb] = c as TextBox;
                    }
                    jtb++;
                    if (jtb == 5)
                    {
                        itb++;
                        jtb = 0;
                        if (itb == 5)
                        {
                            textboxfull = false;
                        }
                    }
                }

            }
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

                        }
                        if ((itbCur + jtbCur == jtbPrev + itbPrev + 1) || (itbCur + jtbCur == jtbPrev + itbPrev - 1))
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
                        if ((itbCur == ss[ss.Count-1].Item1) && (jtbCur == ss[ss.Count-1].Item2) )
                        {
                            
                            tb.BackColor = Color.White;
                            itbPrev = ss[ss.Count-2].Item1;
                            jtbPrev = ss[ss.Count-2].Item2;
                            ss.RemoveAt(ss.Count - 1);
                            label5.Text = label5.Text.Substring(0, label5.Text.Length - 1);
                        }
                        
                    }
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.BackColor = Color.White;
            }
        }
    }
}
