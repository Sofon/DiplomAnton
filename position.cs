using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class position
    {
        public int x;
        public int y;
        public position()
        {
          x = 0;
          y = 0;
         
        }
        public bool test()
        {
            bool t = true;
            if (x > 5 && y > 5)
            {
                t = false;
            }

            return t;
        }
    }
}
