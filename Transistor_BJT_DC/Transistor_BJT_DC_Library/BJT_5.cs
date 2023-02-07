using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_BJT_DC.Transistor_BJT_DC_Library
{

    public class BJT_5: BJT
    {
        public double beta;
        public double hfe;
        //resistance
        public double RB1;
        public double RB2;
        public double RE;
        public double RC;
        public double RB;
        public double RTH;
        //resistance
        //voltage
        public double VBE;
        public double VBC;
        public double VCE;
        public double VCC;
        public double VC;
        public double VE;
        public double VTH;
        //voltage
        //current
        public double IB;
        public double IBmin;
        public double IC;
        public double IE;

        public bool Check_Active_Mode()
        {
            //default in active mode
            VBE = 0.7;
            //default in active mode

            IB = (VCC - VBE) / (RB + ((beta + 1) * RE));
            IC = beta * IB;
            IE = (beta + 1) * IB;
            VCE = (VCC) - (IC * RC) - (IE * RE); // With No TAGHRIB :)
            VC = (VCC) - (IC * RC);
            VE = IE * RE;

            if (VCE >= 0.2 && IB > 0 && IC > 0 && IE > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Check_Saturation_Mode()
        {
            //default in saturation mode
            VBE = 0.8;
            VCE = 0.2;
            //default in saturation mode

            IB = (VCC - VBE) / (RB + ((beta + 1) * RE));
            IC = (VCC - VCE - (IE * RE)) / (RC);
            IE = (VCC - VBE - (IB * RB)) / (RE);
            IBmin = IC / hfe;
            VBC = VBE - VCE;

            if (IB > IBmin && IB > 0 && IC > 0 && IE > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Check_CutOff_Mode()
        {
            VBE = 0.7;
            if (VBE < 0.7) //Not Sure!
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }



}
