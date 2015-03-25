using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


namespace SmartDeviceProject1
{
    public  class HBCC 
    {

        private void DL_calc(object sender, EventArgs e)
        {

            /*
              Z(u, w) = Zo(w)[1 - exp{-b(w)u}]
        where Z(u, w) is the expected number of runs
        to be scored in u overs when w wickets have been lost.
        Zo(w) is the average total score if an unlimited number
        of overs were available and hen w wickets have been lost.
        b(w) is a decay constant that varies with w, the number of wickets lost.
             
             *eg. 293.8* (1-(exp(0.0343 * 9))289.27
             
             */

            //Array of constants
            double[,] dlewisdict1 = { { 293.8, 241.93, 217.21, 173.32, 142.84, 102.94, 81.705, 51.471, 26.708, 17.995 }, { 0.033468, 0.043685, 0.044921, 0.059491, 0.071912, 0.10011, 0.12843, 0.21507, 0.41548, 0.26668 } };

            //Get the number of Wickets lost
            int wicksremain = 10 - (int)InnsWicks2nd.Value;
            int wicksremain2 = 10 - (int)InnsWicks1st.Value;


            double w = dlewisdict1[1, wicksremain] * (double)innOvers2nd.Value;
            double v = dlewisdict1[1, wicksremain] * (double)innOvers1st.Value;


            double d1 = 1 - System.Math.Exp(-v);
            d1 = d1 * dlewisdict1[0, 0];

            double d = 1 - System.Math.Exp(-w);
            d = d * dlewisdict1[0, wicksremain];

            double x = ((d1 / 235) * 100);
            double y = ((d / 235) * 100);

            d = ((double)innScore1st.Value / x) * y;
            d = Math.Round(d);
            Return  d.ToString();
        }
           
    }
}