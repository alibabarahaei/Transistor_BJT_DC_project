using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_BJT_DC.Transistor_BJT_DC_Library
{

    public class BJT_10: BJT
    {
        public bool istransistor_PNP==false;

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
        public double VEE; // Just needed for BJT_10.
        public double VBC;
        public double VCE;
        public double VCC;
        public double VC;
        public double VE;
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
            if(istransistor_PNP==false){VBE = 0.7;}
            else{VBE = -0.7;}

            //default in active mode

            IC = (beta / (beta + 1)) * ((VEE - VBE) / (RE + (RB / (beta + 1))));
            IB = IC / beta;
            IE = (beta + 1) * IB;
            VC = (VCC) - (IC * RC);
            VE = -VBE - (IB * RB);
            VCE = VC - VE;
            if(istransistor_PNP==false){
            if (VCE >= 0.2 && IB > 0 && IC > 0 && IE > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            }
            else{
                if (VCE <= -0.2 && IB < 0 && IC < 0 && IE < 0)
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
            //default in saturation mode
            if(istransistor_PNP==false){           
            VBE = 0.8;
            VCE = 0.2;}
            else{
            VBE =-0.8;
            VCE = -0.2;
            }
            //default in saturation mode

            IB = (VEE - VBE - (IE * RE)) / (RB);
            IC = (beta / (beta + 1)) * ((VEE - VBE) / (RE + (RB / (beta + 1))));
            IE = (VEE - VBE - (IB * RB)) / (RE);
            IBmin = IC / hfe;
            VBC = VBE - VCE;
            if(istransistor_PNP==false){
            if (IB > IBmin && IB > 0 && IC > 0 && IE > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            }
            else{
                if (IB < IBmin && IB < 0 && IC < 0 && IE < 0)
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
            if(istransistor_PNP==false){
                VBE=0.7;
            }
            else
            {
                VBE = -0.7;
            }
            IC = (beta / (beta + 1)) * ((VEE - VBE) / (RE + (RB / (beta + 1))));
            IB = IC / beta;
            VBE = (IB * RB) - (IE * RE) - VEE
            if (istransistor_PNP==false)
            {
            if (VBE < 0.7 || IC == 0) //Not Sure!
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
            if (VBE > -0.7 || IC == 0) //Not Sure!
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
}
