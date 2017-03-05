using babynophone.App.Resources;
using babynophone.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace babynophone.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();

            string chooseLabelText = Resource.LabelChooseLabel;

        }
    }
}
