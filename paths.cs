using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class paths
    {
        public List<int> x = new List<int>();
        public List<int> y = new List<int>();
    
        public void lastdel() {
            if (x.Count == 0)
            {

            }
            else
            {
                x.Remove(x.Last());
                y.Remove(y.Last());
            }
        }
        public void add(int xx, int yy)
        {
            
                x.Add(xx);
                y.Add(yy);
           
         
            
        }
        public bool Test(int xx, int yy)
            {
          
                bool un = false;
            if (x.Contains(xx))
            {
                if (y.Contains(yy))
                {
                    un = true;
                }
            }


            return un;
            }

        public string ToString() {
            string s;
            s = "";
            for (int i = 0; i < x.Count; i++)
            {
                s = s + "x:" + x[i];
                s = s + "y:" + y[i]+";";
            }
            return s;
        }
    }
}
