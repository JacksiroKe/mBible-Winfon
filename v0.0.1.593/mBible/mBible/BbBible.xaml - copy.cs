using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel;

using mBible.ViewModels;
using mBible.Resources;

namespace mBible
{
    public partial class BbBible : PhoneApplicationPage
    {
                
        private AppSettings settings = new AppSettings();
        public BbBible()
        {
            InitializeComponent();
            
            this.Loaded += new RoutedEventHandler(BbBible_Loaded);
            
        }

        private void BbBible_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            
            FetchHolyBible fetch = new FetchHolyBible();
            MainListBox1.ItemsSource = fetch.getHolyBible("1", "");
            MainListBox2.ItemsSource = fetch.getHolyBible("2", "");
                        
        }
        
        //Selection changed event handler for listbox
        private void MainListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox1.SelectedIndex == -1)
                return;
            HolyBible myresults = MainListBox1.SelectedItem as HolyBible;
            settings.CurrentTestamentSetting = Int32.Parse(myresults.Testament);
            settings.CurrentBookSetting = Int32.Parse(myresults.Book);
            settings.CurrentChaptersSetting = Int32.Parse(myresults.Chapters);
            settings.CurrentEnglishSetting = myresults.English;
            settings.CurrentAbbrevSetting = myresults.Abbrevs;
            settings.CurrentSwahiliSetting = myresults.Swahili;
            NavigationService.Navigate(new Uri("/BbChapters.xaml", UriKind.Relative));

            MainListBox1.SelectedIndex = -1;
        }

        private void MainListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox2.SelectedIndex == -1)
                return;
            HolyBible myresults = MainListBox2.SelectedItem as HolyBible;
            settings.CurrentTestamentSetting = Int32.Parse(myresults.Testament);
            settings.CurrentBookSetting = Int32.Parse(myresults.Book);
            settings.CurrentChaptersSetting = Int32.Parse(myresults.Chapters);
            settings.CurrentEnglishSetting = myresults.English;
            settings.CurrentAbbrevSetting = myresults.Abbrevs;
            settings.CurrentSwahiliSetting = myresults.Swahili;
            NavigationService.Navigate(new Uri("/BbChapters.xaml", UriKind.Relative));
            MainListBox2.SelectedIndex = -1;
        }

        private void SearchBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            FetchHolyBible fetch = new FetchHolyBible();
            MainListBox1.ItemsSource = fetch.getHolyBible("1", SearchBox1.Text);  
        }

        private void SearchBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            FetchHolyBible fetch = new FetchHolyBible();
            MainListBox2.ItemsSource = fetch.getHolyBible("2", SearchBox2.Text); 
        }

        private void btnSearch1_Click(object sender, RoutedEventArgs e)
        {
            SearchBox1.Focus();
        }

        private void btnClear1_Click(object sender, RoutedEventArgs e)
        {
            SearchBox1.Text = "";
            SearchBox1.Focus();
        }

        private void btnSearch2_Click(object sender, RoutedEventArgs e)
        {
            SearchBox2.Focus();
        }

        private void btnClear2_Click(object sender, RoutedEventArgs e)
        {
            SearchBox2.Text = "";
            SearchBox2.Focus();
        }

        private void SearchBible(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BbSearch.xaml", UriKind.Relative));
        }

        private void AppSettings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CcSettings.xaml", UriKind.Relative));
        }

        /*Event handler for Swahili button given in the mylisybox
        private void Swahili_button_click(object sender, RoutedEventArgs e)
        {
            //Get the data object that represents the current selected item
            Resultclass myobject = (sender as Button).DataContext as Resultclass;

            //Get the selected ListBoxItem container instance of the item whose Swahili button is pressed
            ListBoxItem pressedItem = this.MainListBox1.ItemContainerGenerator.ContainerFromItem(myobject) as ListBoxItem;

            //Checks whether it is not null 
            if (pressedItem != null)
            { 
                //Now you can get the English and Swahili of selected student from the myobject

                //Display the English and Swahili of Selected Student in the textblocks given below the listbox.
                StudentEnglishblock.Text = myobject.English;
                Swahiliblock.Text = myobject.Swahili.ToString(); ;
            }
        }*/

    }
}