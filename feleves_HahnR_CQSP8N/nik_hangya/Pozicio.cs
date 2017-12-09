using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_HahnR_CQSP8N
{
    class Pozicio
    {
        double x;
        double y;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Pozicio(int x, int y)
        {
            this.x = Convert.ToDouble(x);
            this.y = Convert.ToDouble(y);
        }
        public Pozicio(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


    }
}
