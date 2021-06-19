using FR_XamarinResults.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FR_XamarinResults
{
    public partial class MainPage : ContentPage
    {
        public ConnectionViewModel connectionViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            this.connectionViewModel = new ConnectionViewModel();
            this.resultat.ItemsSource = this.connectionViewModel.resultats;
        }
    }
}
