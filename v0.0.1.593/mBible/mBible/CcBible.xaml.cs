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
    public partial class CcBible : PhoneApplicationPage
    {
                
        private AppSettings settings = new AppSettings();
        public CcBible()
        {
            InitializeComponent();
            DataContext = App.ViewBible;
            
            
            pBible.Visibility = Visibility.Collapsed;
            ApplicationBar.IsVisible = false;

            this.Loaded += new RoutedEventHandler(CcBible_Loaded);
            
        }

        private void CcBible_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            App.ViewBible.ListBibleBooks();
            MainListBox1.ItemsSource = App.ViewBible.BibleBooks.Where(w => w.Testament.Equals(1));
            MainListBox2.ItemsSource = App.ViewBible.BibleBooks.Where(w => w.Testament.Equals(2));
            
            pBible.Visibility = Visibility.Visible;
            ApplicationBar.IsVisible = true;

        }
        
        //Selection changed event handler for listbox
        private void MainListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox1.SelectedIndex == -1)
                return;
            mb_bible myresults = MainListBox1.SelectedItem as mb_bible;
            settings.CurrentTestamentSetting = myresults.Testament;
            settings.CurrentBookSetting = myresults.Book;
            settings.CurrentChaptersSetting = myresults.Chapters;
            settings.CurrentEnglishSetting = myresults.English;
            settings.CurrentAbbrevSetting = myresults.Abbrevs;
            settings.CurrentSwahiliSetting = myresults.Swahili;
            NavigationService.Navigate(new Uri("/CcChapters.xaml", UriKind.Relative));

            MainListBox1.SelectedIndex = -1;
        }

        private void MainListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox2.SelectedIndex == -1)
                return;
            mb_bible myresults = MainListBox2.SelectedItem as mb_bible;
            settings.CurrentTestamentSetting = myresults.Testament;
            settings.CurrentBookSetting = myresults.Book;
            settings.CurrentChaptersSetting = myresults.Chapters;
            settings.CurrentEnglishSetting = myresults.English;
            settings.CurrentAbbrevSetting = myresults.Abbrevs;
            settings.CurrentSwahiliSetting = myresults.Swahili;
            NavigationService.Navigate(new Uri("/CcChapters.xaml", UriKind.Relative));
            MainListBox2.SelectedIndex = -1;
        }

        private void SearchBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //FetchBook fetch = new FetchBook();
            //MainListBox1.ItemsSource = fetch.getBook("1", SearchBox1.Text);
            MainListBox1.ItemsSource = App.ViewBible.BibleBooks.Where(w => (w.Testament.Equals(1) && 
                w.English.ToUpper().Contains(SearchBox1.Text.ToUpper())));
            
        }

        private void SearchBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainListBox1.ItemsSource = App.ViewBible.BibleBooks.Where(w => (w.Testament.Equals(2) &&
                w.English.ToUpper().Contains(SearchBox2.Text.ToUpper())));
            
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
            NavigationService.Navigate(new Uri("/CcSearch.xaml", UriKind.Relative));
        }

        private void AppSettings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EeSettings.xaml", UriKind.Relative));
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