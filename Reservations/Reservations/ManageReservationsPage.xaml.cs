using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;


using Picker = Xamarin.Forms.Picker;
using Entry = Xamarin.Forms.Entry;
using System.Security.Cryptography.X509Certificates;

using Reservations.Model;

namespace Reservations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageReservationsPage : ContentPage
    {
        List<Reservation> reservations = new List<Reservation>();
        List<Reservation> reservationsApproved = new List<Reservation>();
        List<Reservation> reservationsRejected = new List<Reservation>();



        public ManageReservationsPage()
        {
          
            reservations.Add(new Reservation("02/34/2022", "14:43:34", 1,true, "Meeting Room 1", ApprovalStatus.Rejected, -1));
            reservations.Add(new Reservation("02/34/2022", "08:43:34", 2, true, "Meeting Room 4", ApprovalStatus.Rejected, 1));
            reservations.Add(new Reservation("02/33/2022", "14:43:22", 3, true, "Meeting Room 2", ApprovalStatus.None, -1));
            reservations.Add(new Reservation("02/34/2022", "09:33:34", 5, true, "Meeting Room 3", ApprovalStatus.Approved, -1));
            reservations.Add(new Reservation("02/22/2022", "14:43:34", 4, true, "Meeting Room 6", ApprovalStatus.None, 0));
            reservations.Add(new Reservation("02/01/2022", "14:13:34", 2, true, "Meeting Room 5", ApprovalStatus.None, 2));

            


            Label labelPending = new Label()
            {
                Text = "Reservation Date",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions= LayoutOptions.Center,
            };

            Picker pickerPending = new Picker()
            {
                FontSize= 15,
                TextColor= Color.White,
                ItemsSource= reservations, 
                SelectedIndex= -1,
                HorizontalOptions= LayoutOptions.Center,

            };

   
            Label labelPending2 = new Label()
            {
                Text = "Reservation List",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };

            Entry entryDate = new Entry()
            {
                Placeholder = "",
                TextColor= Color.White,
                WidthRequest= 16,
                HorizontalTextAlignment = TextAlignment.Center,
                IsReadOnly= true

            };

            Label labelStartTime = new Label()
            {
                Text = "Start Time",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };

            Entry entryStartTime = new Entry()
            {
                Placeholder = "",
                TextColor = Color.White,
                WidthRequest = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                IsReadOnly = true

            };

            Label labelDuration = new Label()
            {
                Text = "Duration",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };

            Entry entryDuration = new Entry()
            {
                Placeholder = "",
                TextColor = Color.White,
                WidthRequest = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                IsReadOnly = true

            };

            Label labelVirtual = new Label()
            {
                Text = "Virtual",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };

            Entry entryVirtual = new Entry()
            {
                Placeholder = "",
                TextColor = Color.White,
                WidthRequest = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                IsReadOnly = true

            };

            Label labelLocation = new Label()
            {
                Text = "Location",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };

            Entry entryLocation = new Entry()
            {
                Placeholder = "",
                TextColor = Color.White,
                WidthRequest = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                IsReadOnly = true

            };

            Label labelIsApproved = new Label()
            {
                Text = "Is Reservation Approved",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };

            Entry entryIsApproved = new Entry()
            {
                Placeholder = "",
                TextColor = Color.White,
                WidthRequest = 16,
                HorizontalTextAlignment = TextAlignment.Center,
                IsReadOnly = true

            };

            Button buttonAccept = new Button
            {
                Text = "Accept",
                BackgroundColor = Color.Gray,
                WidthRequest = 150,
                FontSize = 10
            };

            Picker pickerRejectedReason = new Picker()
            {
                FontSize = 10,
                TextColor = Color.White,
                ItemsSource = new string[] { "Room Booked", "This is taken", "Closed", "Cleaning" },
                SelectedIndex = -1,
                HorizontalOptions = LayoutOptions.Center,
            };

            Button buttonReject = new Button
            {
                Text = "Reject",
                BackgroundColor = Color.Gray,
                WidthRequest = 150,
                FontSize = 10
            };

            Label labelApproved = new Label()
            {
                Text = " Approved",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };

            Picker pickerApproved = new Picker()
            {
                FontSize = 10,
                TextColor = Color.White,
                ItemsSource = reservationsApproved,
                SelectedIndex = -1,
                HorizontalOptions = LayoutOptions.Center,
            };

            Label labelRejected = new Label()
            {
                Text = " Rejected",
                TextColor = Color.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
            };

            Picker pickerRejected = new Picker()
            {
                FontSize = 10,
                TextColor = Color.White,
                ItemsSource = reservationsRejected,
                SelectedIndex = -1,
                HorizontalOptions = LayoutOptions.Center,
            };

            buttonAccept.Clicked += async (sender, args) =>
            {

               //This is a SQL Update
                Reservation curr = reservations.ElementAt(pickerPending.SelectedIndex);
                reservations.Remove(curr);


                pickerPending.ItemsSource = null;
                pickerPending.ItemsSource = reservations;
                pickerPending.SelectedIndex = 0;


                entryDate.Text = " ";
                entryLocation.Text = " ";
                entryStartTime.Text = " ";
                entryLocation.Text = "";
                entryVirtual.Text = " ";
                entryIsApproved.Text = " ";

               
                reservationsApproved.Add(curr);
                

                pickerApproved.ItemsSource = null;
                pickerApproved.ItemsSource= reservationsApproved;
                pickerApproved.SelectedIndex = 0;

                /* foreach(Reservation x in reservations)
                 {
                     pickerApproved.Items.Add(x);
                 }*/
                await DisplayAlert(
                    "Reservation Confirmed", $"{curr}", "OK"
                    );

            };

         

            buttonReject.Clicked += async (sender, args) =>
            {
                //This would be a SQL Update
                Reservation curr = reservations.ElementAt(pickerPending.SelectedIndex);
                reservations.Remove(curr);


                pickerPending.ItemsSource = null;
                pickerPending.ItemsSource = reservations;
                pickerPending.SelectedIndex = 0;


                entryDate.Text = " ";
                entryLocation.Text = " ";
                entryStartTime.Text = " ";
                entryLocation.Text = "";
                entryVirtual.Text = " ";
                entryIsApproved.Text = " ";


                reservationsRejected.Add(curr);


                pickerRejected.ItemsSource = null;
                pickerRejected.ItemsSource = reservationsRejected;
                pickerRejected.SelectedIndex = 0;

               
                await DisplayAlert(
                    "Reservation Rejected", $"{curr}", "OK"
                    );

            };

           

            pickerPending.SelectedIndexChanged += async (sender, args) =>
            {
                if (pickerPending.SelectedIndex == -1) return;
                Reservation curr = reservations.ElementAt(pickerPending.SelectedIndex);
                entryDate.Text = curr.Date.ToString();
                entryStartTime.Text = curr.StartTime.ToString();
                entryLocation.Text = curr.Location.ToString();
                entryDuration.Text = curr.Duration.ToString();

                string virt = (curr.Virtual) ? "Virtual" : "Non-Virtual";
                entryVirtual.Text = virt;

                entryIsApproved.Text = curr.IsApproved.ToString();

                pickerRejectedReason.SelectedIndex = curr.Reason; 


            };

            pickerRejectedReason.SelectedIndexChanged += async (sender, args) =>
            {
                if (pickerPending.SelectedIndex == -1) return;
                Reservation curr = reservations.ElementAt(pickerPending.SelectedIndex);
                 
            };

            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    labelPending,
                   pickerPending,
                   labelPending2,
                   entryDate,
                   labelStartTime,
                   entryStartTime,
                   labelVirtual,
                   entryVirtual,
                   labelDuration,
                   entryDuration,
                   labelLocation,
                   entryLocation,
                   labelIsApproved,
                   entryIsApproved,
                   buttonAccept,
                   pickerRejectedReason,
                   buttonReject,
                   labelApproved,
                   pickerApproved,
                   labelRejected,
                   pickerRejected
                  
                 

                },
                HeightRequest = 1500,
                HorizontalOptions = LayoutOptions.Center
            };

           

            BackgroundColor = Color.Black;
            Padding = new Thickness(20);
            Content = stackLayout;



            for(int i = 0; i < reservations.Count; i++)
            {
                FillPickerLists();
            }

           
            pickerPending.ItemsSource = null;
            pickerPending.ItemsSource = reservations;
            pickerPending.SelectedIndex = 0;

            pickerApproved.ItemsSource = null;
            pickerApproved.ItemsSource = reservationsApproved;
            pickerApproved.SelectedIndex = 0;

            pickerRejected.ItemsSource = null;
            pickerRejected.ItemsSource = reservationsRejected;
            pickerRejected.SelectedIndex = 0;
        }

        public void FillPickerLists()
        {
            for (int i = 0; i < reservations.Count; i++)
            {
                Reservation r = reservations[i];
                if (r.IsApproved == ApprovalStatus.Approved)
                {
                    reservationsApproved.Add(r);
                    reservations.Remove(r);
                }
                else if (r.IsApproved == ApprovalStatus.Rejected)
                {
                    reservationsRejected.Add(r);
                    reservations.Remove(r);
                }
            }
        }
    }
}