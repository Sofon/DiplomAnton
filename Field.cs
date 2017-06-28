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

        int[,] WayMap;
        //int rev;

        Trie wordtree = new Trie();
        string alp = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";


        public int TC;
        private int blocki, blockj;
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

        //public List<string> FindWord1(int startX, int startY, paths p, string word, bool addchar)
        //{
        //    List<string> pref = new List<string>();
        //    List<string> pref1 = new List<string>();







        //    for (int i = 0; i < 5; i++)
        //    {
        //        for (int j = 0; j < 5; j++)
        //        {
        //            if (!addchar && !(i == startX && j == startY) && (p.Test(i, j) == false) && smeg(startX, startY, i, j) && textboxmass[i, j] == "" && textboxmass[startX, startY] != String.Empty)
        //            {
        //                word = word + textboxmass[startX, startY];
        //                if (wordtree.GetWords(word).Count > 0)
        //                {
        //                    if (wordtree.HasWord(word))
        //                    {
        //                        pref.Add(word);
        //                    }
        //                    foreach (var item in alp)
        //                    {
        //                        if (wordtree.GetWords(word + item).Count > 0)
        //                        {


        //                            string word24 = word + item;

        //                            if (p.len() <= word.Length)
        //                            {
        //                                p.add(startX, startY);
        //                            }
        //                            foreach (var x in Getnextstep(startX, startY))
        //                            {

        //                                addchar = true;

        //                                pref1 = FindWord1(x.Item1, x.Item2, p, word + item, addchar);
        //                                pref.AddRange(pref1);
        //                            }





        //                        }
        //                    }



        //                }

        //            }
        //            if (addchar)
        //            {


        //                if (addchar && textboxmass[i, j] != String.Empty && textboxmass[startX, startY] == "" && !(i == startX && j == startY) && (p.Test(i, j) == false) && smeg(startX, startY, i, j))
        //                {


        //                    word = word + textboxmass[i, j];

        //                    if (wordtree.HasWord(word))
        //                    {
        //                        pref.Add(word);
        //                    }




        //                    if (p.len() <= word.Length)
        //                    {
        //                        p.add(startX, startY);
        //                    }
        //                    pref1 = FindWord1(i, j, p, word, addchar);
        //                    pref.AddRange(pref1);
        //                    return pref;


        //                }
        //                if (addchar && textboxmass[i, j] != String.Empty && textboxmass[startX, startY] != "" && !(i == startX && j == startY) && (p.Test(i, j) == false) && smeg(startX, startY, i, j))
        //                {


        //                    word = word + textboxmass[i, j];

        //                    if (wordtree.HasWord(word))
        //                    {
        //                        pref.Add(word);
        //                    }
        //                    if (p.len() <= word.Length)
        //                    {
        //                        p.add(startX, startY);
        //                    }
        //                    pref1 = FindWord1(i, j, p, word, addchar);
        //                    pref.AddRange(pref1);



        //                }
        //            }


        //        }
        //    }


        //    return pref;
        //}

        public void update()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    textboxmass[i, j] = ColorMass[i, j].Text;
                }
        }
        char itn = '*';
        public List<string> FindWord3(int startX, int startY, paths p, string word, bool addchar)
        {
          
            List<string> pref = new List<string>();
            List<string> pref1 = new List<string>();
            
            p.add(startX, startY);
           
            bool add;
            add = true;
            if (word=="")
            {
                word = "*";
                addchar = true;
                pref.AddRange(FindWord3(startX, startY, p, word, addchar));
                return pref;
            }       


                var s = Getnextstepfree(startX, startY);
                for (int i = 0; i < s.Count; i++)

                {




                    if (textboxmass[s[i].Item1, s[i].Item2] != "" && p.Test(s[i].Item1, s[i].Item2))
                    {
                        word = word + textboxmass[s[i].Item1, s[i].Item2];
                        if (addchar)
                        {
                            foreach (var a in alp)
                            {
                                if (wordtree.HasWord(word.Replace(itn, a)))
                                {
                                    pref.Add(word.Replace(itn, a));
                                }

                            }
                        }
                        pref1 = FindWord3(s[i].Item1, s[i].Item2, p, word, addchar);
                        pref.AddRange(pref1);
                        add = false;
                    }

                    if (!word.Contains(itn) && (p.Test(s[i].Item1, s[i].Item2) && textboxmass[s[i].Item1, s[i].Item2] == "") && add)
                    {




                        addchar = true;
                        foreach (var a in alp)
                        {
                            if (wordtree.HasWord((word + itn).Replace(itn, a)))
                            {
                                pref.Add((word + itn).Replace(itn, a));
                            }

                        }
                        pref1 = FindWord3(s[i].Item1, s[i].Item2, p, (word + itn), addchar);
                        pref.AddRange(pref1);





                    }
                }

                return pref;   

        }

        private List<Tuple<int, int>> Getnextstepfree(int x, int y)
        {
            List<Tuple<int, int>> core = new List<Tuple<int, int>>();


            if (x - 1 >= 0)
            {
                core.Add(new Tuple<int, int>(x - 1, y));
            }

            if (y + 1 <= 4)
            {
                core.Add(new Tuple<int, int>(x, y + 1));
            }

            if (x + 1 <= 4)
            {
                core.Add(new Tuple<int, int>(x + 1, y));
            }

            if (y - 1 >= 0)
            {
                core.Add(new Tuple<int, int>(x, y - 1));
            }


            return core;
        }

        


       



       
        public void setslovar(Trie t)
        {
            wordtree = t;
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

        
    }


}


