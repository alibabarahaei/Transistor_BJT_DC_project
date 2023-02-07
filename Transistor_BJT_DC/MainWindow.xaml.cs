using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Transistor_BJT_DC.Tools;
using Transistor_BJT_DC.Transistor_BJT_DC_Library;

namespace Transistor_BJT_DC
{


    public partial class MainWindow : Window
    {
        private int B_N = 1;
        private answer defaultanswer = new answer() { VBE = "-", VCE = "-", IB = "-", IC = "-", IE = "-", Mode = "-" };

        public ObservableCollection<answer> answers = new ObservableCollection<answer>();
        public MainWindow()
        {
            answers.Add(defaultanswer);
            InitializeComponent();
            answersDataGrid.ItemsSource = answers;
            VEE_textBox.IsReadOnly = true;
            RB_textBox.IsReadOnly = true;
        }
        private void exit(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void check_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VCC_Icon.Visibility = Visibility.Hidden;
            RB1_Icon.Visibility = Visibility.Hidden;
            RE_Icon.Visibility = Visibility.Hidden;
            RB2_Icon.Visibility = Visibility.Hidden;
            RC_Icon.Visibility = Visibility.Hidden;
            RB_Icon.Visibility = Visibility.Hidden;
            VEE_Icon.Visibility = Visibility.Hidden;
            beta_Icon.Visibility = Visibility.Hidden;

            if (B_N == 1)
            {
                var t = new BJT_13();
                if (VCC_textBox.Text == "")
                {
                    VCC_Icon.Visibility = Visibility.Visible;
                }
                if (RB1_textBox.Text == "")
                {
                    RB1_Icon.Visibility = Visibility.Visible;
                }
                if (beta_textBox.Text == "")
                {
                    beta_Icon.Visibility = Visibility.Visible;
                }
                if (RB2_textBox.Text == "")
                {
                    RB2_Icon.Visibility = Visibility.Visible;
                }
                if (RE_textBox.Text == "")
                {
                    RE_Icon.Visibility = Visibility.Visible;
                }
                if (RC_textBox.Text == "")
                {
                    RC_Icon.Visibility = Visibility.Visible;
                }

                if (VCC_textBox.Text != "" && RB1_textBox.Text != "" && beta_textBox.Text != "" &&
                    RB2_textBox.Text != "" && RE_textBox.Text != "" && RC_textBox.Text != "")
                {

                    t.VCC = Convert.ToDouble(Convertor.converttokilo(VCC_textBox.Text));
                    t.RB1 = Convert.ToDouble(Convertor.converttokilo(RB1_textBox.Text));
                    t.beta = Convert.ToDouble(Convertor.converttokilo(beta_textBox.Text));
                    t.RB2 = Convert.ToDouble(Convertor.converttokilo(RB2_textBox.Text));
                    t.RE = Convert.ToDouble(Convertor.converttokilo(RE_textBox.Text));
                    t.RC = Convert.ToDouble(Convertor.converttokilo(RC_textBox.Text));
                    if (hfe_textBox.Text == "")
                    {
                        t.hfe = Convert.ToDouble(beta_textBox.Text);
                    }
                    else
                    {
                        t.hfe = Convert.ToDouble(hfe_textBox.Text);
                    }
                    answers.Clear();
                    if (t.Check_Active_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Active"
                        });
                    }
                    else if (t.Check_Saturation_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Saturation"
                        });
                    }
                    else if (t.Check_CutOff_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = t.IB.ToString("0.##") + ("mA"),
                            IC = t.IC.ToString("0.##") + ("mA"),
                            IE = t.IE.ToString("0.##") + ("mA"),
                            Mode = "Saturation"
                        });
                    }

                    answersDataGrid.ItemsSource = answers;
                }
            }
            else if (B_N == 2)
            {
                var t = new BJT_10();
                if (VCC_textBox.Text == "")
                {
                    VCC_Icon.Visibility = Visibility.Visible;
                }
                if (RE_textBox.Text == "")
                {
                    RE_Icon.Visibility = Visibility.Visible;
                }
                if (beta_textBox.Text == "")
                {
                    beta_Icon.Visibility = Visibility.Visible;
                }
                if (RB_textBox.Text == "")
                {
                    RB_Icon.Visibility = Visibility.Visible;
                }

                if (RC_textBox.Text == "")
                {
                    RC_Icon.Visibility = Visibility.Visible;
                }
                if (VEE_textBox.Text == "")
                {
                    VEE_Icon.Visibility = Visibility.Visible;
                }
                if (VCC_textBox.Text != "" && RB_textBox.Text != "" && beta_textBox.Text != "" &&
                     RE_textBox.Text != "" && RC_textBox.Text != "" && VEE_textBox.Text != "")
                {
                    t.VCC = Convert.ToDouble(Convertor.converttokilo(VCC_textBox.Text));
                    t.beta = Convert.ToDouble(Convertor.converttokilo(beta_textBox.Text));
                    t.RE = Convert.ToDouble(Convertor.converttokilo(RE_textBox.Text));
                    t.RB = Convert.ToDouble(Convertor.converttokilo(RB_textBox.Text));
                    t.VEE = Convert.ToDouble(Convertor.converttokilo(VEE_textBox.Text));
                    t.RC = Convert.ToDouble(Convertor.converttokilo(RC_textBox.Text));
                    if (hfe_textBox.Text == "")
                    {
                        t.hfe = Convert.ToDouble(beta_textBox.Text);
                    }
                    else
                    {
                        t.hfe = Convert.ToDouble(hfe_textBox.Text);
                    }

                    answers.Clear();
                    if (t.Check_Active_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Active"
                        });
                    }
                    else if (t.Check_Saturation_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Saturation"
                        });
                    }
                    else if (t.Check_CutOff_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = t.IB.ToString("0.##") + ("mA"),
                            IC = t.IC.ToString("0.##") + ("mA"),
                            IE = t.IE.ToString("0.##") + ("mA"),
                            Mode = "Saturation"
                        });
                    }


                    answersDataGrid.ItemsSource = answers;
                }
            }
            else if (B_N == 3)
            {
                var t = new BJT_8();
                if (VCC_textBox.Text == "")
                {
                    VCC_Icon.Visibility = Visibility.Visible;
                }
                if (RE_textBox.Text == "")
                {
                    RE_Icon.Visibility = Visibility.Visible;
                }
                if (beta_textBox.Text == "")
                {
                    beta_Icon.Visibility = Visibility.Visible;
                }
                if (RB_textBox.Text == "")
                {
                    RB_Icon.Visibility = Visibility.Visible;
                }

                if (RC_textBox.Text == "")
                {
                    RC_Icon.Visibility = Visibility.Visible;
                }

                if (VCC_textBox.Text != "" && RB_textBox.Text != "" && beta_textBox.Text != "" &&
                     RE_textBox.Text != "" && RC_textBox.Text != "")
                {
                    t.VCC = Convert.ToDouble(Convertor.converttokilo(VCC_textBox.Text));
                    t.beta = Convert.ToDouble(Convertor.converttokilo(beta_textBox.Text));
                    t.RE = Convert.ToDouble(Convertor.converttokilo(RE_textBox.Text));
                    t.RB = Convert.ToDouble(Convertor.converttokilo(RB_textBox.Text));
                    t.RC = Convert.ToDouble(Convertor.converttokilo(RC_textBox.Text));
                    if (hfe_textBox.Text == "")
                    {
                        t.hfe = Convert.ToDouble(beta_textBox.Text);
                    }
                    else
                    {
                        t.hfe = Convert.ToDouble(hfe_textBox.Text);
                    }

                    answers.Clear();
                    if (t.Check_Active_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Active"
                        });
                    }
                    else if (t.Check_Saturation_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Saturation"
                        });
                    }
                    else if (t.Check_CutOff_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = t.IB.ToString("0.##") + ("mA"),
                            IC = t.IC.ToString("0.##") + ("mA"),
                            IE = t.IE.ToString("0.##") + ("mA"),
                            Mode = "Saturation"
                        });
                    }


                    answersDataGrid.ItemsSource = answers;
                }
            }
            else if (B_N == 4)
            {
                var t = new BJT_5();
                if (VCC_textBox.Text == "")
                {
                    VCC_Icon.Visibility = Visibility.Visible;
                }
                if (RE_textBox.Text == "")
                {
                    RE_Icon.Visibility = Visibility.Visible;
                }
                if (beta_textBox.Text == "")
                {
                    beta_Icon.Visibility = Visibility.Visible;
                }
                if (RB_textBox.Text == "")
                {
                    RB_Icon.Visibility = Visibility.Visible;
                }

                if (RC_textBox.Text == "")
                {
                    RC_Icon.Visibility = Visibility.Visible;
                }

                if (VCC_textBox.Text != "" && RB_textBox.Text != "" && beta_textBox.Text != "" && RE_textBox.Text != "" && RC_textBox.Text != "")
                {
                    t.VCC = Convert.ToDouble(Convertor.converttokilo(VCC_textBox.Text));
                    t.beta = Convert.ToDouble(Convertor.converttokilo(beta_textBox.Text));
                    t.RE = Convert.ToDouble(Convertor.converttokilo(RE_textBox.Text));
                    t.RB = Convert.ToDouble(Convertor.converttokilo(RB_textBox.Text));
                    t.RC = Convert.ToDouble(Convertor.converttokilo(RC_textBox.Text));
                    if (hfe_textBox.Text == "")
                    {
                        t.hfe = Convert.ToDouble(beta_textBox.Text);
                    }
                    else
                    {
                        t.hfe = Convert.ToDouble(hfe_textBox.Text);
                    }

                    answers.Clear();
                    if (t.Check_Active_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Active"
                        });
                    }
                    else if (t.Check_Saturation_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Saturation"
                        });
                    }
                    else if (t.Check_CutOff_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = t.IB.ToString("0.##") + ("mA"),
                            IC = t.IC.ToString("0.##") + ("mA"),
                            IE = t.IE.ToString("0.##") + ("mA"),
                            Mode = "Saturation"
                        });
                    }


                    answersDataGrid.ItemsSource = answers;
                }
            }
            else if (B_N == 5)
            {
                var t = new BJT_8();
                if (VCC_textBox.Text == "")
                {
                    VCC_Icon.Visibility = Visibility.Visible;
                }

                if (beta_textBox.Text == "")
                {
                    beta_Icon.Visibility = Visibility.Visible;
                }
                if (RB_textBox.Text == "")
                {
                    RB_Icon.Visibility = Visibility.Visible;
                }

                if (RC_textBox.Text == "")
                {
                    RC_Icon.Visibility = Visibility.Visible;
                }

                if (VCC_textBox.Text != "" && RB_textBox.Text != "" && beta_textBox.Text != "" &&
                    RC_textBox.Text != "")
                {
                    t.VCC = Convert.ToDouble(Convertor.converttokilo(VCC_textBox.Text));
                    t.beta = Convert.ToDouble(Convertor.converttokilo(beta_textBox.Text));
                    t.RB = Convert.ToDouble(Convertor.converttokilo(RB_textBox.Text));
                    t.RC = Convert.ToDouble(Convertor.converttokilo(RC_textBox.Text));
                    if (hfe_textBox.Text == "")
                    {
                        t.hfe = Convert.ToDouble(beta_textBox.Text);
                    }
                    else
                    {
                        t.hfe = Convert.ToDouble(hfe_textBox.Text);
                    }

                    answers.Clear();
                    if (t.Check_Active_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Active"
                        });
                    }
                    else if (t.Check_Saturation_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Saturation"
                        });
                    }
                    else if (t.Check_CutOff_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = t.IB.ToString("0.##") + ("mA"),
                            IC = t.IC.ToString("0.##") + ("mA"),
                            IE = t.IE.ToString("0.##") + ("mA"),
                            Mode = "Saturation"
                        });
                    }


                    answersDataGrid.ItemsSource = answers;
                }
            }
            else if (B_N == 6)
            {
                var t = new BJT_1();
                if (VCC_textBox.Text == "")
                {
                    VCC_Icon.Visibility = Visibility.Visible;
                }
                if (beta_textBox.Text == "")
                {
                    beta_Icon.Visibility = Visibility.Visible;
                }
                if (RB_textBox.Text == "")
                {
                    RB_Icon.Visibility = Visibility.Visible;
                }
                if (RC_textBox.Text == "")
                {
                    RC_Icon.Visibility = Visibility.Visible;
                }

                if (VCC_textBox.Text != "" && RB_textBox.Text != "" && beta_textBox.Text != "" &&
                    RC_textBox.Text != "")
                {
                    t.VCC = Convert.ToDouble(Convertor.converttokilo(VCC_textBox.Text));
                    t.beta = Convert.ToDouble(Convertor.converttokilo(beta_textBox.Text));
                    t.RE = Convert.ToDouble(Convertor.converttokilo(RE_textBox.Text));
                    t.RB = Convert.ToDouble(Convertor.converttokilo(RB_textBox.Text));
                    t.RC = Convert.ToDouble(Convertor.converttokilo(RC_textBox.Text));
                    if (hfe_textBox.Text == "")
                    {
                        t.hfe = Convert.ToDouble(beta_textBox.Text);
                    }
                    else
                    {
                        t.hfe = Convert.ToDouble(hfe_textBox.Text);
                    }

                    answers.Clear();
                    if (t.Check_Active_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Active"
                        });
                    }
                    else if (t.Check_Saturation_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Saturation"
                        });
                    }
                    else if (t.Check_CutOff_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = t.IB.ToString("0.##") + ("mA"),
                            IC = t.IC.ToString("0.##") + ("mA"),
                            IE = t.IE.ToString("0.##") + ("mA"),
                            Mode = "Saturation"
                        });
                    }

                    answersDataGrid.ItemsSource = answers;
                }
            }
            else if (B_N == 7)
            {
                var t = new BJT_17();
                if (VCC_textBox.Text == "")
                {
                    VCC_Icon.Visibility = Visibility.Visible;
                }
                if (beta_textBox.Text == "")
                {
                    beta_Icon.Visibility = Visibility.Visible;
                }
                if (RB1_textBox.Text == "")
                {
                    RB1_Icon.Visibility = Visibility.Visible;
                }
                if (RC_textBox.Text == "")
                {
                    RC_Icon.Visibility = Visibility.Visible;
                }
                if (RE_textBox.Text == "")
                {
                    RE_Icon.Visibility = Visibility.Visible;
                }
                if (RB2_textBox.Text == "")
                {
                    RB2_Icon.Visibility = Visibility.Visible;
                }
                if (VEE_textBox.Text == "")
                {
                    VEE_Icon.Visibility = Visibility.Visible;
                }
                if (VCC_textBox.Text != "" && RB1_textBox.Text != "" && beta_textBox.Text != "" &&
                    RC_textBox.Text != "" && RE_textBox.Text != "" && RB2_textBox.Text != "" && VEE_textBox.Text != "")
                {
                    t.VCC = Convert.ToDouble(Convertor.converttokilo(VCC_textBox.Text));
                    t.beta = Convert.ToDouble(Convertor.converttokilo(beta_textBox.Text));
                    t.RE = Convert.ToDouble(Convertor.converttokilo(RE_textBox.Text));
                    t.RB1 = Convert.ToDouble(Convertor.converttokilo(RB1_textBox.Text));
                    t.RB2 = Convert.ToDouble(Convertor.converttokilo(RB2_textBox.Text));
                    t.VEE = Convert.ToDouble(Convertor.converttokilo(VEE_textBox.Text));
                    t.RC = Convert.ToDouble(Convertor.converttokilo(RC_textBox.Text));
                    if (hfe_textBox.Text == "")
                    {
                        t.hfe = Convert.ToDouble(beta_textBox.Text);
                    }
                    else
                    {
                        t.hfe = Convert.ToDouble(hfe_textBox.Text);
                    }

                    answers.Clear();
                    if (t.Check_Active_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Active"
                        });
                    }
                    else if (t.Check_Saturation_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = (t.IB * 1000).ToString("0.###") + ("mA"),
                            IC = (t.IC * 1000).ToString("0.###") + ("mA"),
                            IE = (t.IE * 1000).ToString("0.###") + ("mA"),
                            Mode = "Saturation"
                        });
                    }
                    else if (t.Check_CutOff_Mode() == true)
                    {
                        answers.Add(new answer()
                        {
                            VBE = t.VBE.ToString("0.###") + ("V"),
                            VCE = t.VCE.ToString("0.###") + ("V"),
                            IB = t.IB.ToString("0.##") + ("mA"),
                            IC = t.IC.ToString("0.##") + ("mA"),
                            IE = t.IE.ToString("0.##") + ("mA"),
                            Mode = "Saturation"
                        });
                    }

                    answersDataGrid.ItemsSource = answers;
                }
            }






        }

        private void next_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            B_N++;
            answers.Clear();
            answers.Add(defaultanswer);
            answersDataGrid.ItemsSource = answers;
            RB1_textBox.IsReadOnly = false;
            RB2_textBox.IsReadOnly = false;
            VCC_textBox.IsReadOnly = false;
            RE_textBox.IsReadOnly = false;
            RB_textBox.IsReadOnly = false;
            RC_textBox.IsReadOnly = false;
            VEE_textBox.IsReadOnly = false;
            RB1_textBox.Text = "";
            RB2_textBox.Text = "";
            VCC_textBox.Text = "";
            RE_textBox.Text = "";
            RB_textBox.Text = "";
            RC_textBox.Text = "";
            VEE_textBox.Text = "";
            beta_textBox.Text = "";
            hfe_textBox.Text = "";
            VCC_Icon.Visibility = Visibility.Hidden;
            RB1_Icon.Visibility = Visibility.Hidden;
            RE_Icon.Visibility = Visibility.Hidden;
            RB2_Icon.Visibility = Visibility.Hidden;
            RC_Icon.Visibility = Visibility.Hidden;
            RB_Icon.Visibility = Visibility.Hidden;
            VEE_Icon.Visibility = Visibility.Hidden;
            beta_Icon.Visibility = Visibility.Hidden;
            switch (B_N)
            {
                case 2:  //biasing -> 10
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_10.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    B_N_button.Content = "2";
                    break;
                case 3:  //biasing -> 8
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_8.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    VEE_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    B_N_button.Content = "3";
                    break;
                case 4:   //biasing -> 5
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_5.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    VEE_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    B_N_button.Content = "4";
                    break;
                case 5:   //biasing ->2
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_2.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    VEE_textBox.IsReadOnly = true;
                    RE_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    RE_textBox.Text = "--------";
                    B_N_button.Content = "5";
                    break;
                case 6:   //biasing ->1
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_1.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    VEE_textBox.IsReadOnly = true;
                    RE_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    RE_textBox.Text = "--------";
                    B_N_button.Content = "6";
                    break;
                case 7:   //biasing -> 17
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_17.png", UriKind.Relative));
                    B_N_button.Content = "7";
                    break;
                case 8:
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_13.png", UriKind.Relative));
                    B_N = 1;
                    B_N_button.Content = "1";
                    VEE_textBox.IsReadOnly = true;
                    RB_textBox.IsReadOnly = true;
                    RB_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    break;
            }
        }

        private void back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            B_N--;
            answers.Clear();
            answers.Add(defaultanswer);
            answersDataGrid.ItemsSource = answers;
            RB1_textBox.IsReadOnly = false;
            RB2_textBox.IsReadOnly = false;
            VCC_textBox.IsReadOnly = false;
            RE_textBox.IsReadOnly = false;
            RB_textBox.IsReadOnly = false;
            RC_textBox.IsReadOnly = false;
            VEE_textBox.IsReadOnly = false;
            RB1_textBox.Text = "";
            RB2_textBox.Text = "";
            VCC_textBox.Text = "";
            RE_textBox.Text = "";
            RB_textBox.Text = "";
            RC_textBox.Text = "";
            VEE_textBox.Text = "";
            beta_textBox.Text = "";
            hfe_textBox.Text = "";
            VCC_Icon.Visibility = Visibility.Hidden;
            RB1_Icon.Visibility = Visibility.Hidden;
            RE_Icon.Visibility = Visibility.Hidden;
            RB2_Icon.Visibility = Visibility.Hidden;
            RC_Icon.Visibility = Visibility.Hidden;
            RB_Icon.Visibility = Visibility.Hidden;
            VEE_Icon.Visibility = Visibility.Hidden;
            beta_Icon.Visibility = Visibility.Hidden;
            switch (B_N)
            {
                case 2:  //biasing -> 10
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_10.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    B_N_button.Content = "2";
                    break;
                case 3:  //biasing -> 8
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_8.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    VEE_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    B_N_button.Content = "3";
                    break;
                case 4:   //biasing -> 5
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_5.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    VEE_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    B_N_button.Content = "4";
                    break;
                case 5:   //biasing ->2
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_2.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    VEE_textBox.IsReadOnly = true;
                    RE_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    RE_textBox.Text = "--------";
                    B_N_button.Content = "5";
                    break;
                case 6:   //biasing ->1
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_1.png", UriKind.Relative));
                    RB1_textBox.IsReadOnly = true;
                    RB2_textBox.IsReadOnly = true;
                    VEE_textBox.IsReadOnly = true;
                    RE_textBox.IsReadOnly = true;
                    RB1_textBox.Text = "--------";
                    RB2_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    RE_textBox.Text = "--------";
                    B_N_button.Content = "6";
                    break;
                case 0:   //biasing -> 17

                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_17.png", UriKind.Relative));
                    B_N = 7;
                    B_N_button.Content = "7";
                    break;
                case 1:
                    ImageBiasing.Source = new BitmapImage(new Uri(@"/images/BJT_13.png", UriKind.Relative));
                    B_N = 1;
                    B_N_button.Content = "1";
                    VEE_textBox.IsReadOnly = true;
                    RB_textBox.IsReadOnly = true;
                    RB_textBox.Text = "--------";
                    VEE_textBox.Text = "--------";
                    break;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Checkmode_checkbox(object sender, MouseButtonEventArgs e)
        {
            if (mode_checkbox.IsChecked == false)
            {
                mode_text.Text = "PNP";
            }
            else
            {
                mode_text.Text = "NPN";
            }
        }
    }


    public class answer
    {
        public string VBE { get; set; }
        public string VCE { get; set; }
        public string IB { get; set; }
        public string IE { get; set; }
        public string IC { get; set; }
        public string Mode { get; set; }
    }
}
