using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using SQLite;
using Reservations.Model;

namespace Reservations
{

    public partial class App : Application
    {

    static ReservationRepository repository;

    public static ReservationRepository Repository
    {
        get
        {
            if(repository == null)
            {
                repository = new ReservationRepository();
            }return repository;
        }
    }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ReservationsContentPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
