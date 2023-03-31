using Reservations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reservations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationsContentPage : ContentPage

    {
        List<string> rooms = new List<string>();

        double hours = 1;

        public string ConvertVirtually(Switch switchVirtually)
        {
            return switchVirtually.IsToggled ? "virutal" :"nonvirtual";
        }

        public string ConvertTimePicker(TimePicker timePicker)
        {
            
            return timePicker.Time.ToString("t");
        }

        public string ConvertDatePicker(DatePicker datePicker)
        {
            return datePicker.Date.ToShortDateString();
        }

        
        public ReservationsContentPage()
        {
            rooms.Add("Conference Room 1");
            rooms.Add("Conference Room 2");
            rooms.Add("Conference Room 3");
           

            Label labelDate = new Label
            {
                Text = "Date",
                TextColor = Color.White,
                FontSize = 20,
                HorizontalOptions= LayoutOptions.Center
            };

            DatePicker datePicker = new DatePicker
            {
                TextColor = Color.White,
                MinimumDate = new DateTime(2023, 2, 1),
                MaximumDate = new DateTime(2100, 12, 31),
                Date = DateTime.Today
            };

            Label labelStartTime = new Label
            {
                Text = "Start Time",
                TextColor = Color.White,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            TimePicker timePicker = new TimePicker
            {
                TextColor = Color.White,
                Time = new TimeSpan(18, 15, 26)
            };


            Label labelDuration = new Label
            {
                Text = "Duration",
                TextColor = Color.White,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider sliderDuration = new Slider
            {
                ThumbColor= Color.White,
                BackgroundColor= Color.DimGray,
                Minimum = 0,
                Maximum = 5,
                FlowDirection= FlowDirection.RightToLeft,
            VerticalOptions = LayoutOptions.Center
        };

        Label labelVirtual = new Label
        {
            Text = "Virtual",
            TextColor = Color.White,
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center
        };

        Switch switchVirtually = new Switch
        {
            IsToggled = false,
            BackgroundColor = Color.DimGray,
            OnColor = Color.CornflowerBlue,
            ThumbColor = Color.Blue
        };

        Label labelLocation = new Label
            {
                Text = "Location",
                TextColor = Color.White,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            Picker pickerLocation = new Picker
            {
                FontSize = 20,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                ItemsSource = rooms,
                SelectedIndex = 0

            };
            Button buttonCreate = new Button
            {
                Text = "Reserve",
                BackgroundColor = Color.Gray,
                WidthRequest = 150,
                FontSize = 20
            };

            buttonCreate.Clicked += async (sender, args) =>
            {
                string date = ConvertDatePicker(datePicker);
                string time = ConvertTimePicker(timePicker);
                int dur = (int)sliderDuration.Value;
                string virt = ConvertVirtually(switchVirtually);
                string loc = pickerLocation.SelectedItem.ToString();
                ApprovalStatus status = ApprovalStatus.None;
              

                await DisplayAlert("Reservation",$"Your reservation for a {virt} meeting in room {loc} starting at {time} on {date} for {dur} hours has been created.","OK"
                    );
            };

            Button buttonManage = new Button
            {
                Text = "Manage",
                BackgroundColor = Color.Gray,
                WidthRequest = 150,
                FontSize = 20
            };

            buttonManage.Clicked += async (sender, args) =>
            {
              await  Navigation.PushAsync(new ManageReservationsPage());
            };

            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    labelDate,
                    datePicker,
                    labelStartTime,
                    timePicker,
                    labelDuration,
                    sliderDuration,
                    labelVirtual,                 
                    switchVirtually,
                     labelLocation,
                    pickerLocation,
                    buttonCreate,
                    buttonManage

                },
                HeightRequest = 1500,
                HorizontalOptions= LayoutOptions.Center
            };

            BackgroundColor = Color.Black;
            Padding = new Thickness(20);
            Content = stackLayout;
        }

       
    }
}