using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using mBible.Resources;

namespace mBible
{
    public partial class CcSearch : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public string currtitle;
        public CcSearch()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(CcSearch_Loaded);

        }

        private void CcSearch_Loaded(object sender, RoutedEventArgs e)
        {

           
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Focus();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            SearchBox.Focus();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(SearchBox.Text == "Search"))
            {
                SearchVerses fetch = new SearchVerses();
                MainListBox.ItemsSource = fetch.searchVerses(SearchBox.Text);
            }
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox.SelectedIndex == -1)
                return;
            BibleVerse this_str = MainListBox.SelectedItem as BibleVerse;
            string[] holy_bible = this_str.Title.Split(' ');
            string[] set_verses = this_str.Verse.Split(' ');
            string set_chapter = holy_bible[1].Remove(holy_bible[1].Length - 1, 1);

            FindBook find = new FindBook();
            FinalListBox.ItemsSource = find.getJustOne(holy_bible[0]);
            FinalListBox.SelectedIndex = 0;

            BibleBook myresults = FinalListBox.SelectedItem as BibleBook;
            settings.CurrentTestamentSetting = myresults.Testament;
            settings.CurrentBookSetting = myresults.Book;
            settings.CurrentChaptersSetting = myresults.Chapters;
            settings.CurrentEnglishSetting = myresults.English;
            settings.CurrentAbbrevSetting = myresults.Abbrevs;
            settings.CurrentSwahiliSetting = myresults.Swahili;
            settings.SelectedChapterSetting = Int32.Parse(set_chapter);
            settings.SelectedVerseSetting = Int32.Parse(set_verses[0]);
           
            NavigationService.Navigate(new Uri("/CcRead.xaml", UriKind.Relative));
            MainListBox.SelectedIndex = -1;
        }

    }
}