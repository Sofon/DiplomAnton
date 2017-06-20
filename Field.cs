using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rm.Trie;
namespace WindowsFormsApplication1
{
    class Field
    {

        int[,] Map;
        int MapWidht;
        int MapHeight;
        int[,] WayMap;
        public int step;
        int rev;
        Trie wordtree = new Trie();
        string alp = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";


        char[] Bukvi = Enumerable.Range(0, 32).Select((x, i) => (char)('а' + i)).ToArray();
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
        public List<string> FindWave(int startX, int startY, int targetX, int targetY, Trie wordtree)
        {
            bool add = true;
            string word;
            bool wordcheck;
            ICollection<string> buff;
            List<string> bufflist = new List<string>();
            List<string> rusult = new List<string>();
            List<string> help = new List<string>();
            int[,] cMap = new int[MapHeight, MapWidht];
            int x, y = 0;
            for (x = 0; x < MapHeight; x++)
                for (y = 0; y < MapWidht; y++)
                {
                    if (Map[x, y] == 1)
                    {
                        cMap[x, y] = -2;//индикатор стены
                    }
                    else
                    {
                        cMap[x, y] = -1;//индикатор еще не ступали сюда
                    }

                }
            cMap[targetX, targetY] = 0;//Начинаем с конца
            word = "";
            step = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (getstep(i, j))
                    {
                        default:
                            break;
                    }
                }
            }



            return help;
        }

        public List<string> FindWord(int startX, int startY, paths p, string word,bool addchar)
        {
            List<string> pref = new List<string>();
            List<string> pref1 = new List<string>();
            if (!(textboxmass[startX, startY] == ""))
            {
                rev++;




                int[,] cMap = new int[MapHeight, MapWidht];


                cMap[startX, startY] = 1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                      

                        if (textboxmass[i, j] != String.Empty && !(i == startX && j == startY) && (p.Test(i, j) == false) && smeg(startX, startY, i, j))
                        {
                            switch (getstep(i, j))
                            {
                                case 1:

                                    {


                                        word = word + textboxmass[i, j];
                                        foreach (var item in alp)
                                        {
                                            
                                            if (wordtree.HasWord(word + item))
                                            {   
                                                pref.Add(word + item);
                                            }
                                            if (wordtree.GetWords(word + alp).Count > 0 && !addchar)
                                            {
                                                addchar = true;
                                                word = word + alp;
                                                pref1 = FindWord(i, j, p, word, addchar);
                                            }
                                        }
                                        p.add(i, j);
                                        pref1 = FindWord(i, j, p, word,addchar);
                                        pref.AddRange(pref1);
                                        return pref;
                                    }
                                    break;
                             
                                case 0:
                                    return pref;
                            }
                        }
                    }

                }


            }
            return pref;

        }

        private bool smeg(int x, int y, int i, int j)
        {
            bool smeg;
            smeg = false;
            if ((y == j && x == i - 1) || (y == j - 1 && x == i) || (x == i + 1 && y == j) || (y == j + 1 && x == i))
            {
                return true;
            }


            return false;




        }

        private int getstep(int x, int y)
        {

            int numstep;
            numstep = 0;
            if ((!(!(x - 1 < 0) && !ColorMass[x - 1, y].ReadOnly) && !(!(y + 1 > 4) && !ColorMass[x, y + 1].ReadOnly)&& !(!(x + 1 > 4) && !ColorMass[x + 1, y].ReadOnly) && !( !(y - 1 < 0) && !ColorMass[x, y-1].ReadOnly)))
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



    }
}