using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Field
    {
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
            ColorMass[blocki, blockj].ReadOnly=true;


        }
      

        public string[,] textboxmass = new string[5, 5];
        public bool check
        {   // Я сделяль
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
                return ch;
            }
        }



    }
}
