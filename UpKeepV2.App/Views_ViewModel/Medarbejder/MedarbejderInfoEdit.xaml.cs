﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UpKeepV2.App.Data;
using UpKeepV2.App.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpKeepV2.App.Views.Medarbejder
{
    public sealed partial class MedarbejderInfoEdit : Page
    {
        private MedarbejderInfo Model = new MedarbejderInfo();
        private bool windowsID = false;
        private bool navn = false;
        private bool emailAdresse = false;
        private bool mobilNummer = false;
        private bool lokalitet_InfoID = false;

        public MedarbejderInfoEdit()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                Model.Medarbejder_InfoID = (int)e.Parameter;
                Data();
            }
        }
        private async Task Data()
        {
            Model = await new MedarbejderInfoDataService().Find(Model.Medarbejder_InfoID);
            this.DataContext = Model;
            LoadingControl.IsActive = false;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MedarbejderInfoDetails), (sender as Button).Tag);
        }

        private async void Gemme(object sender, RoutedEventArgs e)
        {
            LoadingControl.IsActive = true;
            await new MedarbejderInfoDataService().Update(Model);
            this.Frame.Navigate(typeof(MedarbejderInfoDetails), Model.Medarbejder_InfoID);
            LoadingControl.IsActive = false;
        }

        private void WindowsID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WindowsID.Text))
            {
                windowsID = false;
                WindowsIDLabel.Text = WindowsID.Header + " Det kræves";
            }
            else
            {
                windowsID = true;
                WindowsIDLabel.Text = "";
                Model.WindowsID = WindowsID.Text;
            }
            if (windowsID && navn && emailAdresse && mobilNummer && lokalitet_InfoID)
            {
                ButtonGemme.IsEnabled = true;
            }
            else
            {
                ButtonGemme.IsEnabled = false;
            }
        }
        private void Navn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Navn.Text))
            {
                navn = false;
                NavnLabel.Text = Navn.Header + " Det kræves";
            }
            else
            {
                navn = true;
                NavnLabel.Text = "";
                Model.Navn = Navn.Text;

            }
            if (windowsID && navn && emailAdresse && mobilNummer && lokalitet_InfoID)
            {
                ButtonGemme.IsEnabled = true;
            }
            else
            {
                ButtonGemme.IsEnabled = false;
            }
        }

        private void EmailAdresse_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailAdresse.Text))
            {
                emailAdresse = false;
                EmailAdresseLabel.Text = EmailAdresse.Header + " Det kræves";
            }
            else
            {
                emailAdresse = true;
                EmailAdresseLabel.Text = "";
                Model.EmailAdresse = EmailAdresse.Text;

            }
            if (windowsID && navn && emailAdresse && mobilNummer && lokalitet_InfoID)
            {
                ButtonGemme.IsEnabled = true;
            }
            else
            {
                ButtonGemme.IsEnabled = false;
            }
        }

        private void MobilNummer_TextChanged(object sender, TextChangedEventArgs e)
        {
            int v;
            if (string.IsNullOrWhiteSpace(MobilNummer.Text))
            {
                mobilNummer = false;
                MobilNummerLabel.Text = MobilNummer.Header + " Det kræves";
            }
            else if (!int.TryParse(MobilNummer.Text, out v))
            {
                mobilNummer = false;
                MobilNummerLabel.Text = MobilNummer.Header + " Nummer";
            }
            else
            {
                mobilNummer = true;
                MobilNummerLabel.Text = "";
                Model.MobilNummer = v;

            }
            if (windowsID && navn && emailAdresse && mobilNummer && lokalitet_InfoID)
            {
                ButtonGemme.IsEnabled = true;
            }
            else
            {
                ButtonGemme.IsEnabled = false;
            }
        }

        private void Lokalitet_InfoID_TextChanged(object sender, TextChangedEventArgs e)
        {
            int v;
            if (string.IsNullOrWhiteSpace(Lokalitet_InfoID.Text))
            {
                lokalitet_InfoID = false;
                Lokalitet_InfoIDLabel.Text = Lokalitet_InfoID.Header + " Det kræves";
            }
            else if (!int.TryParse(Lokalitet_InfoID.Text, out v))
            {
                lokalitet_InfoID = false;
                Lokalitet_InfoIDLabel.Text = Lokalitet_InfoID.Header + " Nummer";
            }
            else
            {
                lokalitet_InfoID = true;
                Lokalitet_InfoIDLabel.Text = "";
                Model.Lokalitet_InfoID = v;

            }
            if (windowsID && navn && emailAdresse && mobilNummer && lokalitet_InfoID)
            {
                ButtonGemme.IsEnabled = true;
            }
            else
            {
                ButtonGemme.IsEnabled = false;
            }
        }
    }
}
