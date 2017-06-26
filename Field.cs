using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rm.Trie;
using System.Drawing;
using System.Threading;
namespace WindowsFormsApplication1
{
    class Field
    {

        int[,] Map;
        int MapWidht;
        int MapHeight;
        int[,] WayMap;
        int rev;
        int sliper = 0;
        Trie wordtree = new Trie();
        string alp = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";


        public int TC;
        private int blocki, blockj;
        public Label words;
        public Label puti;
        public TextBox[,] ColorMass = new TextBox[5, 5];
        public TextBox[,] Textbox
        {
            get
            {
                return ColorMass;
            }
            set
            {

                ColorMass = value;


            }
        }
        public List<string> slova
        {
            get
            {
                return slova;
            }
            set
            {

                slova = value;


            }
        }
        public void begin()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    textboxmass[i, j] = ColorMass[i, j].Text;
                }
        }

        public void next()
        {

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    textboxmass[i, j] = ColorMass[i, j].Text;
                    ColorMass[i, j].BackColor = System.Drawing.Color.White;
                }
            ColorMass[blocki, blockj].ReadOnly = true;


        }
        public void nexthelp()
        {

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    textboxmass[i, j] = ColorMass[i, j].Text;
                    ColorMass[i, j].BackColor = System.Drawing.Color.White;
                    if (ColorMass[i, j].Text != String.Empty)
                    {
                        ColorMass[i, j].ReadOnly = true;
                    }
                }






        }
        public void update() {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    textboxmass[i, j] = ColorMass[i, j].Text; 
                }
        }

        public void Afterhelp()
        {

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {

                    ColorMass[i, j].ReadOnly = false;

                }

        }

        public void ReadMap()
        {
            rev = 0;
            MapWidht = 5;
            MapHeight = 5;
            Map = new int[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (ColorMass[i, j].ReadOnly == true)
                    {
                        Map[i, j] = 0;
                    }
                    else
                    {
                        Map[i, j] = 1;
                    }

                }

            WayMap = new int[5, 5];
        }

        public List<string> FindWord1(int startX, int startY, paths p, string word, bool addchar)
        {
            List<string> pref = new List<string>();
            List<string> pref1 = new List<string>();
           
            






            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!addchar && !(i == startX && j == startY) && (p.Test(i, j) == false) && smeg(startX, startY, i, j) && textboxmass[i, j] == "" && textboxmass[startX, startY] != String.Empty)
                    {
                        word = word + textboxmass[startX, startY];
                        if (wordtree.GetWords(word).Count > 0)
                        {
                            if (wordtree.HasWord(word))
                            {
                                pref.Add(word);
                            }
                            foreach (var item in alp)
                            {
                                if (wordtree.GetWords(word + item).Count > 0)
                                {
                                   
                                    
                                    string word24 = word + item;

                                    if (p.len() <= word.Length)
                                    {
                                        p.add(startX, startY);
                                    }
                                    foreach (var x in Getnextstep(startX, startY))
                                    {
                                        
                                        addchar = true;
                                        
                                        pref1 = FindWord1(x.Item1, x.Item2, p, word + item, addchar);
                                        pref.AddRange(pref1);
                                    }


                                    


                                }
                            }
                           

                   
                        }

                    }
                    if (addchar)
                    {
                       

                        if (addchar && textboxmass[i, j] != String.Empty && textboxmass[startX, startY] == "" && !(i == startX && j == startY) && (p.Test(i, j) == false ) && smeg(startX, startY, i, j))
                        {

                            
                            word = word + textboxmass[i, j];
                           
                            if (wordtree.HasWord(word))
                            {
                                pref.Add(word);
                            }




                            if (p.len() <= word.Length)
                            {
                                p.add(startX, startY);
                            }
                            pref1 = FindWord1(i, j, p, word, addchar);
                            pref.AddRange(pref1);
                            return pref;


                        }
                        if (addchar && textboxmass[i, j] != String.Empty && textboxmass[startX, startY] != "" && !(i == startX && j == startY) && (p.Test(i, j) == false) && smeg(startX, startY, i, j))
                        {


                            word = word + textboxmass[i, j];

                            if (wordtree.HasWord(word))
                            {
                                pref.Add(word);
                            }
                            if (p.len() <= word.Length)
                            {
                                p.add(startX, startY);
                            }
                            pref1 = FindWord1(i, j, p, word, addchar);
                            pref.AddRange(pref1);



                        }
                    }


                }
            }


            return pref;
        }

        public List<string> FindWord(int startX, int startY, paths p, string word, bool addchar)
        {
            List<string> pref = new List<string>();
            List<string> pref1 = new List<string>();


            

            update();

            pref.AddRange(FindWord1(startX, startY, p, word, addchar));
            //ColorMass[startX, startY].BackColor = Color.Red;
            //words.Text = word;
            //puti.Text = p.ToString();
            //System.Threading.Thread.Sleep(sliper);

            
         
            

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {


                    if (!addchar && textboxmass[i, j] != String.Empty && !(i == startX && j == startY) && (p.Test(i, j) == false) && smeg(startX, startY, i, j))
                    {
                        //ColorMass[i, j].BackColor = Color.Yellow;
                        //ColorMass[i, j].Invalidate();
                        //ColorMass[i, j].Update();
                        //words.Text = word;
                        //words.Invalidate();
                        //words.Update();
                        //puti.Text = p.ToString();
                        //puti.Invalidate();
                        //puti.Update();
                        // System.Threading.Thread.Sleep(sliper);
                        if (Getstep(i, j) == 1)
                        {


                            word = word + textboxmass[i, j];
                            if (wordtree.GetWords(word).Count > 0)
                            {


                                foreach (var item in alp)
                                {
                                    if (wordtree.HasWord(word + item))
                                    {
                                        pref.Add(word + item);    
                                    }

                                }





                                p.add(i, j);
                                pref.AddRange(FindWord(i, j, p, word, addchar));
                     
                                }

                        }







                    }

                }




                //for (int i = 0; i < 5; i++)
                //{
                //    for (int j = 0; j < 5; j++)
                //    {
                //        ColorMass[i, j].BackColor = Color.White;
                //    }
                //}



            }


            return pref;
        }




        private bool smeg(int x, int y, int i, int j)
        {

            if ((y == j && x == i - 1) || (y == j - 1 && x == i) || (x == i + 1 && y == j) || (y == j + 1 && x == i))
            {
                return true;
            }


            return false;




        }
        private bool smegp(int x, int y, int i, int j,paths p)
        {

            if ((y == j && x == i - 1) || (y == j - 1 && x == i) || (x == i + 1 && y == j) || (y == j + 1 && x == i) && !p.Test(i,j))
            {
                return true;
            }


            return false;




        }



        private int Getstep(int x, int y)
        {

            int numstep;
            numstep = 0;
            if ((!(!(x - 1 < 0) && !ColorMass[x - 1, y].ReadOnly) && !(!(y + 1 > 4) && !ColorMass[x, y + 1].ReadOnly) && !(!(x + 1 > 4) && !ColorMass[x + 1, y].ReadOnly) && !(!(y - 1 < 0) && !ColorMass[x, y - 1].ReadOnly)))
            {

                numstep = 0;
            }
            else
            {
                if ((x - 1 >= 0 && !(ColorMass[x - 1, y].ReadOnly)) == false)
                {
                    numstep = 1;
                }
                else
                {
                    if ((y + 1 <= 4 && !(ColorMass[x, y + 1].ReadOnly)) == false)
                    {
                        numstep = 1;
                    }
                    else
                    {
                        if ((x + 1 <= 4 && !(ColorMass[x + 1, y].ReadOnly)) == false)
                        {
                            numstep = 1;
                        }

                        else


                        {
                            if ((y - 1 >= 0 && !(ColorMass[x, y - 1].ReadOnly)) == false)
                            {
                                numstep = 1;
                            }
                        }
                    }
                }
            }
            return numstep;
        }
        public void setslovar(Trie t)
        {
            wordtree = t;
        }

        public List<string> wordHelp
        {   // Я сделяль
            get
            {
                List<string> word = new List<string>();
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (ColorMass[i, j].ReadOnly == false)
                        {



                        }
                    }
                return word;
            }
        }


        public string[,] textboxmass = new string[5, 5];
        public bool check
        {
            get
            {
                bool ch;
                ch = false;
                TC = 0;
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (!(textboxmass[i, j] == ColorMass[i, j].Text))
                        {
                            TC++;
                            blocki = i;
                            blockj = j;
                        }
                    }
                if (TC == 1)
                {
                    ch = true;
                }
                else
                    MessageBox.Show("Вы не ввели ни одной буквы, для пропуска хода воспользуйтесь соответствующей кнопкой");
                return ch;
            }
        }

        private List<Tuple<int, int>> Getnextstep(int x, int y)
        {
            List<Tuple<int, int>> core = new List<Tuple<int, int>>();
            if (((!(!(x - 1 < 0) && !(textboxmass[x-1,y]!=""))) && !(!(y + 1 > 4) && !(textboxmass[x, y+1] != "")) && !(!(x + 1 > 4) && !(textboxmass[x + 1, y] != "")) && !(!(y - 1 < 0) && !(textboxmass[x, y-1] != "")) ) && textboxmass[x, y] == "")
            {


            }
            else
            {
                if ((x - 1 >= 0 && (textboxmass[x-1, y] == "") == true))
                {
                    core.Add(new Tuple<int, int>(x - 1, y));
                }

                    if ((y + 1 <= 4 && (textboxmass[x, y+1] == "") == true))
                    {
                        core.Add(new Tuple<int, int>(x, y + 1));
                    }

                        if ((x + 1 <= 4 && (textboxmass[x+1, y] == "") == true))
                        {
                            core.Add(new Tuple<int, int>(x + 1, y));
                        }

                      

                        
                            if ((y - 1 >= 0 && (textboxmass[x, y - 1] == "") == true))
                            {
                                core.Add(new Tuple<int, int>(x, y - 1));
                            }
                        

                    


                
        
            }
            return core;
        }
    }
}