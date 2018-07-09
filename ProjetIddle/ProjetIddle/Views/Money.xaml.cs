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
        double argentTotalInt;

        /* Mouche */
        double valeurMouche = 1;
        int niveauMouche = 1;
        double prixAchatMouche = 5;

        /* Souris */
        double valeurSouris = 1;
        int niveauSouris = 1;
        double prixAchatSouris = 5;

        /* Oiseau */
        double valeurOiseau = 1;
        int niveauOiseau = 1;
        double prixAchatOiseau = 5;

        public Money ()
		{
			InitializeComponent ();
            valueMouche.Text = valeurMouche.ToString()+"€";
            buttonPlusMouche.Text = prixAchatMouche.ToString()+"€";
            valueSouris.Text = valeurMouche.ToString() + "€";
            buttonPlusSouris.Text = prixAchatMouche.ToString() + "€";
            valueOiseau.Text = valeurMouche.ToString() + "€";
            buttonPlusOiseau.Text = prixAchatMouche.ToString() + "€";
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
                valueMouche.Text = valeurMouche.ToString() + "€";
                argentTotal.Text = argentTotalInt.ToString() + "€";
                levelMouche.Text = "Nv." + niveauMouche.ToString();
            }
        }

        private void buttonSouris_Clicked(object sender, EventArgs e)
        {
            var updateRate = 1000 / 30f; // 30Hz
            double step = updateRate / (1 * 3 * 1000f);
            if (progressSouris.Progress == 0)
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(updateRate), () =>
                {

                    if (progressSouris.Progress < 1)
                    {
                        Device.BeginInvokeOnMainThread(() => progressSouris.Progress += step);
                        return true;
                    }
                    else if (progressSouris.Progress == 1)
                    {
                        Device.BeginInvokeOnMainThread(() => progressSouris.Progress = 0);
                        argentTotalInt += valeurMouche;
                        argentTotal.Text = argentTotalInt.ToString() + "€";
                        return false;
                    }

                    return false;
                });
            }
        }

        private void buttonPlusSouris_Clicked(object sender, EventArgs e)
        {
            if (argentTotalInt >= prixAchatSouris)
            {
                argentTotalInt -= prixAchatSouris;
                niveauSouris++;
                valeurSouris *= 2;
                prixAchatSouris *= 1.5;
                buttonPlusSouris.Text = prixAchatSouris.ToString() + "€";
                valueSouris.Text = valeurSouris.ToString() + "€";
                argentTotal.Text = argentTotalInt.ToString() + "€";
                levelSouris.Text = "Nv." + niveauSouris.ToString();
            }
        }

        private void buttonOiseau_Clicked(object sender, EventArgs e)
        {
            var updateRate = 1000 / 30f; // 30Hz
            double step = updateRate / (1 * 3 * 1000f);
            if (progressOiseau.Progress == 0)
            {
                Device.StartTimer(TimeSpan.FromMilliseconds(updateRate), () =>
                {

                    if (progressOiseau.Progress < 1)
                    {
                        Device.BeginInvokeOnMainThread(() => progressOiseau.Progress += step);
                        return true;
                    }
                    else if (progressOiseau.Progress == 1)
                    {
                        Device.BeginInvokeOnMainThread(() => progressOiseau.Progress = 0);
                        argentTotalInt += valeurOiseau;
                        argentTotal.Text = argentTotalInt.ToString() + "€";
                        return false;
                    }

                    return false;
                });
            }
        }

        private void buttonPlusOiseau_Clicked(object sender, EventArgs e)
        {
            if (argentTotalInt >= prixAchatOiseau)
            {
                argentTotalInt -= prixAchatOiseau;
                niveauOiseau++;
                valeurOiseau *= 2;
                prixAchatOiseau *= 1.5;
                buttonPlusOiseau.Text = prixAchatOiseau.ToString() + "€";
                valueOiseau.Text = valeurOiseau.ToString() + "€";
                argentTotal.Text = argentTotalInt.ToString() + "€";
                levelOiseau.Text = "Nv." + niveauOiseau.ToString();
            }
        }
    }
}