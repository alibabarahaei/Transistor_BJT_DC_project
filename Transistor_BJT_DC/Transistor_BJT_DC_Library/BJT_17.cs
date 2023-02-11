using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_BJT_DC.Transistor_BJT_DC_Library
{


    public class BJT_17 : BJT
    {
        public bool istransistor_PNP = false;

        public double beta;

        public double VTH;
        public double RTH;
        public double RB1;
        public double RB2;
        public double RE;
        public double RC;
        public double RB;
        public double ROUT;
        public double VCC;
        public double hfe;
        public double VEE;

        public double VBE;
        public double temp;
        public double IB;
        public double IC;
        public double IE;
        public double VCE;
        public double ICsat;
        double[] data = new double[2];

        public void solve(double a1, double b1, double c1, double a2, double b2, double c2)
        {

            data[0] = (c1 * b2 - b1 * c2) / (a1 * b2 - b1 * a2);
            data[1] = (a1 * c2 - c1 * a2) / (a1 * b2 - b1 * a2);
        }
        public bool Check_Active_Mode()
        {
            if (istransistor_PNP == false)
            {
                VBE = 0.7;
            }
            else
            {
                VBE = -0.7;
            }
            temp = VCC - VEE;
            VTH = ((RB1) / (RB1 + RB2) * temp) - VCC;
            RTH = (RB1 * RB2) / (RB1 + RB2);
            IB = ((VCC - VTH) - 0.7) / (RTH + (beta + 1) * RE);
            IC = beta * IB;
            VCE = 2 * VCC - IC * (RC + ((beta + 1) / beta) * RE);


            if (istransistor_PNP == false)
            {
                if (VCE > 0.2)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (VCE < -0.2)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }


        }

        public bool Check_Saturation_Mode()
        {
            if (istransistor_PNP == false)
            {
                VBE = 0.8;
                VCE = 0.2;
            }
            else
            {
                VBE = -0.8;
                VCE = -0.2;
            }


            solve(RE + RB, RE, VTH - 0.8 - VEE, RE, RC + RE, VCC - 0.2 - VEE);
            IB = data[0];
            IC = data[1];

            if (istransistor_PNP == false)
            {
                //I removed the condition which the vce >0.2 as we have defined that above

                if (IC / IB < beta && IB > 0 && IC > 0 && IE > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                    //if true the IB should be IBmin 

                }



            }
            else
            {
                if (VCE > 0.2 && ICsat > IC && IB < 0 && IC < 0 && IE < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool Check_CutOff_Mode()
        {
            if (istransistor_PNP == false)
            {
                VBE = 0.7;
            }
            else
            {
                VBE = -0.7;
            }

            VTH = ((RB2) / (RB1 + RB2) * (2 * VCC - VEE)) + VEE;
            IB = ((VCC - VTH) - 0.7) / (RTH + (beta + 1) * RE);
            //VBE = VCC - VTH - IB*(RTH+(beta+1)*RE);
            if (istransistor_PNP == false)
            {
                if (IE < 0 || IB == 0 || VTH < 0.7)
                {

                    return false;

                }
                else

                {
                    return true;
                }
            }
            else
            {
                if (IE > 0 || IB == 0 || VTH > -0.7)
                {

                    return false;

                }
                else

                {
                    return true;
                }
            }

        }

    }
}
}
