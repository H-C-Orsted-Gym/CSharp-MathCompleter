using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MathCompleter
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class AndengradsLigning : Window
	{
        private double aVærdi;
        private double bVærdi;
        private double cVærdi;
        private double dVærdi;
        private int try_Loop;
        private double Discriminant;

        public AndengradsLigning()
		{
			InitializeComponent();
		}
        private void Udreng_Click(object sender, RoutedEventArgs e)
        {
            try_Loop = 0;
			Output_AndenGradsLigning.Inlines.Clear();
            while (try_Loop == 0) 
            {
                if (Ligning.Text == "Indtast ligning her Eksempel: 1x^2+2x+3=0")
                {
                    MessageBox.Show("Please type something in the text field");
                    try_Loop++;
                }
                else
                {
                    char[] delimiterChars = { ' ', '=', '^', 'x', 'X', '+' };
                    string Bruh = Ligning.Text;
                    ArrayList ar = new ArrayList();

                    string[] tests = Bruh.Split(delimiterChars);

                    //Mangler stadig et for loop
                    foreach (var test in tests)
                    {
                        if (test == "")
                        {
                            continue;
                        }
                        else
                        {
                            ar.Add(test);
                        }
                    }

                    int c = ar.Count;
                    try
                    {
                        double dVærdiTest = Convert.ToDouble(ar[c - 1]);
                        double cVærditest = Convert.ToDouble(ar[c - 2]);
                        double bVærditest = Convert.ToDouble(ar[2]);
                        double aVærditest = Convert.ToDouble(ar[0]);
                    }
                    catch (Exception)
                    {
                        Output_AndenGradsLigning.Inlines.Add("Ikke valid Input");
                        break;
                    }
                    double dVærdi = Convert.ToDouble(ar[c - 1]);
                    double cVærdi = Convert.ToDouble(ar[c - 2]);
                    double bVærdi = Convert.ToDouble(ar[2]);
                    double aVærdi = Convert.ToDouble(ar[0]);

                    double C = cVærdi - dVærdi;
                    Discriminant = Math.Pow(bVærdi, 2) - 4 * aVærdi * C;
                    Output_AndenGradsLigning.Inlines.Add("Discriminanten: " + Discriminant + "\n");
                    double Løsning1 = -bVærdi + Math.Sqrt(Discriminant);
                    double Løsning2 = -cVærdi - Math.Sqrt(Discriminant);
                    if (Discriminant > 0)
                    {
                        Output_AndenGradsLigning.Inlines.Add("Plus Løsning: " + Løsning1 + "\nMinus Løsning:" + Løsning2);
                    }
                    if (Discriminant < 0)
                    {
                        Output_AndenGradsLigning.Inlines.Add("Ingen Maginær Løsning");
                    }
                    if (Discriminant == 0)
                    {
                        if (Løsning1 != 0)
                        {
                            Output_AndenGradsLigning.Inlines.Add("Den eneste Løsning er plus løsning som er " + Løsning1);
                        }
                        else
                        {
                            Output_AndenGradsLigning.Inlines.Add("Den eneste løsning er minus løsningen som er " + Løsning2);
                        }
                    }
                    try_Loop++;
                }
            }

		}


    }
}
