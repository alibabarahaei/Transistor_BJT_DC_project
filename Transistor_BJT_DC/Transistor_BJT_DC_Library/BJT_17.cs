namespace Transistor_BJT_DC.Transistor_BJT_DC_Library
{


    public class BJT_17
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
            temp = 2 * VCC;
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


            //when this one will be in saturation mode
            temp = 2 * VCC;
            VTH = ((RB1) / (RB1 + RB2) * temp) - VCC;
            RTH = (RB1 * RB2) / (RB1 + RB2);
            IB = ((VCC - VTH) - 0.7) / (RTH + (beta + 1) * RE);
            IC = beta * IB;
            ICsat = (2 * VCC) / (RC + RE);
            VCE = 2 * VCC - IC * (RC + ((beta + 1) / beta) * RE);
            IE = (VTH - (IB * RTH) - (0.7) - VEE) / RE;

            if (istransistor_PNP == false)
            {
                if (VCE < 0.2 && ICsat < IC && IB > 0 && IC > 0 && IE > 0)
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
            VBE = VCC - VTH - IB * (RTH + (beta + 1) * RE);
            if (istransistor_PNP == false)
            {
                if (VBE < 0.7 || IB == 0)
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
                if (VBE > -0.7 || IB == 0)
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
