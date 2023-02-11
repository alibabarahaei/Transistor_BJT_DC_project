namespace Transistor_BJT_DC.Transistor_BJT_DC_Library
{




    public class BJT_13 : BJT
    {

        public bool istransistor_PNP = false;
        public double beta;
        public double hfe;
        //resistance
        public double RB1;
        public double RB2;
        public double RB;
        public double RE;
        public double RC;
        public double RTH;
        //resistance
        //voltag
        public double VBE;
        public double VBC;
        public double VCE;
        public double VCC;
        public double VC;
        public double VE;
        public double VTH;
        //voltag
        //current
        public double IB;
        public double IBmin;
        public double IC;
        public double IE;



        public bool Check_Active_Mode()
        {
            if (istransistor_PNP == false)
            {
                //default in active mode
                VBE = 0.7;
                //default in active mode
            }
            else
            {
                //default in active mode
                VBE = -0.7;
                //default in active mode
            }




            VTH = (VCC * RB2) / (RB1 + RB2);
            RTH = (RB1 * RB2) / (RB1 + RB2);
            IB = (VTH - VBE) / (RTH + (beta + 1) * RE);
            IC = beta * IB;
            IE = (beta + 1) * IB;
            VCE = (VCC) - (IC * RC) - (IE * RE);
            VC = (VCC) - (IC * RC);
            VE = IE * RE;



            if (istransistor_PNP == false)
            {
                if (VCE >= 0.2 && IB > 0 && IC > 0 && IE > 0)
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
            if (istransistor_PNP == false)
            {
                //default in saturation mode
                VBE = 0.8;
                VCE = 0.2;
                //default in saturation mode
            }
            else
            {
                //default in saturation mode
                VBE = -0.8;
                VCE = -0.2;
                //default in saturation mode
            }
            VTH = (VCC * RB2) / (RB1 + RB2);
            RTH = (RB1 * RB2) / (RB1 + RB2);
            IE = (VTH * RC - VBE * RC + RTH * VCC - VCE * RTH) / (RTH * RC + RE * RTH + RE * RC);
            IC = (VCC - VCE - RE * IE) / RC;
            IB = (VTH - VBE - RE * IE) / RTH;
            IBmin = IC / hfe;
            VBC = VBE - VCE;

            if (istransistor_PNP == false)
            {
                if (IB > IBmin && IB > 0 && IC > 0 && IE > 0)
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
            VTH = (VCC * RB2) / (RB1 + RB2);

            if (istransistor_PNP == false)
            {


                if (VTH < 0.7)
                {
                    IB = 0;
                    IC = 0;
                    IE = 0;

                    return true;
                }
                else
                {
                    return false;
                }



            }
            else
            {

                if (VTH > -0.7)
                {
                    IB = 0;
                    IC = 0;
                    IE = 0;

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

