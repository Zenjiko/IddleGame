using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetIddle.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Money : ContentPage
	{
        double valeurMouche = 1;
        int niveauMouche = 1;
        double prixAchatMouche = 5;
        double argentTotalInt;

        public Money ()
		{
			InitializeComponent ();
            valueMouche.Text = valeurMouche.ToString()+"€";
            buttonPlusMouche.Text = prixAchatMouche.ToString()+"€";
		}

        private void buttonMouche_Clicked(object sender, EventArgs e)
        {
            var updateRate = 1000 / 30f; // 30Hz
            double step = updateRate / (1 * 3 * 1000f);
            if (progressMouche.Progress == 0)
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(updateRate), () =>
            {

                if (progressMouche.Progress < 1)
                {
                    Device.BeginInvokeOnMainThread(() => progressMouche.Progress += step);
                    return true;
                }
                else if (progressMouche.Progress == 1)
                {
                    Device.BeginInvokeOnMainThread(() => progressMouche.Progress = 0);
                    argentTotalInt += valeurMouche;
                    argentTotal.Text = argentTotalInt.ToString() + "€";
                    return false;
                }

                return false;
            });
            }
        }

        private void buttonPlusMouche_Clicked(object sender, EventArgs e)
        {
            if(argentTotalInt >= prixAchatMouche)
            {
                argentTotalInt -= prixAchatMouche;
                niveauMouche++;
                valeurMouche *= 2;
                prixAchatMouche *= 1.5;
                buttonPlusMouche.Text = prixAchatMouche.ToString() + "€";
                valueMouche.Text = valeurMouche.ToString()+"€";
                argentTotal.Text = argentTotalInt.ToString()+"€";
                levelMouche.Text = niveauMouche.ToString();
            }
        }
    }
}