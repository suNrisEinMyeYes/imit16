using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class NormalRV
    {

        double v, m;
        double a1, a2;
        public NormalRV(double mean, double var)
        {
            m = mean;
            v = var;
        }
        Random rnd = new Random();
        double sum;
        public double getNum()
        {
            a1 = rnd.NextDouble();
            a2 = rnd.NextDouble();
            sum = Math.Sqrt(-2 * Math.Log(a1)) * Math.Cos(2 * Math.PI * a2);
            return sum; 
        }

    }
}
