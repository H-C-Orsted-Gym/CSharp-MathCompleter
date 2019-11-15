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
        private int try_Loop;
        private double Discriminant;

        public AndengradsLigning()
		{
			InitializeComponent();
		}
        private void Udreng_Click(object sender, RoutedEventArgs e)
        {
			Output_AndenGradsLigning.Inlines.Clear();

			if (Ligning.Text == "Indtast ligning her Eksempel: 1x^2+2x+3=0")
			{
				MessageBox.Show("Please type something in the text field");
			} else
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
				double Ligmed = Convert.ToDouble(ar[c - 1]);
				double Ligmed1 = Convert.ToDouble(ar[c - 2]);
				double A = Convert.ToDouble(ar[2]);
				double B = Convert.ToDouble(ar[0]);
				double C = Ligmed1 - Ligmed;
				double D = Math.Pow(B, 2) - 4 * A * C;
				Output_AndenGradsLigning.Inlines.Add("Discriminanten: " + D + "\n");
				double Løsning1 = -B + Math.Sqrt(D);
				double Løsning2 = -B - Math.Sqrt(D);
				if (D > 0)
				{
					Output_AndenGradsLigning.Inlines.Add("Plus Løsning: " + Løsning1 + "\nMinus Løsning:" + Løsning2);
				}
				if (D < 0)
				{
					Output_AndenGradsLigning.Inlines.Add("Ingen Maginær Løsning");
				}
				if (D == 0)
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
			}

		}


    }
}
