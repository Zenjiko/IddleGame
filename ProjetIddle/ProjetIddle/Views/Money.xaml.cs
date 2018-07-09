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
        int valueMouche = 1;
        int tmp;
        public Money ()
		{
			InitializeComponent ();
		}

        private void buttonMouche_Clicked(object sender, EventArgs e)
        {
            var updateRate = 1000 / 30f; // 30Hz
            double step = updateRate / (1 * 3 * 1000f);
            Device.StartTimer(TimeSpan.FromMilliseconds(updateRate), () =>
            {
                if (progressMouche.Progress < 1)
                {
                    Device.BeginInvokeOnMainThread(() => progressMouche.Progress += step);
                    return true;
                } else if (progressMouche.Progress == 1)
                {
                    Device.BeginInvokeOnMainThread(() => progressMouche.Progress = 0);
                    tmp += valueMouche;
                    argentTotal.Text = tmp.ToString();
                    return false;
                }

                return false;
            });
        }
    }
}