using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using mBible.RealData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace mBible
{
    /// <summary>
    /// Sample code for LongListMultiSelector
    /// </summary>
    public partial class BbRead : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        class PivotCallbacks
        {
            public Action Init { get; set; }
            public Action OnActivated { get; set; }
            public Action<CancelEventArgs> OnBackKeyPress { get; set; }
        }

        //Dictionary<object, PivotCallbacks> _callbacks;

        /// <summary>
        /// Initializes the dictionary of delegates to call when each pivot is selected
        /// </summary>
        public BbRead()
        {
            InitializeComponent();
            this.Loaded += BbRead_Loaded;

           // Init = CreateVerseApplicationBarItems,
           //  OnActivated = OnVersePivotItemActivated,
           //   OnBackKeyPress = OnVerseBackKeyPressed
            CreateVerseApplicationBarItems();
            OnVersePivotItemActivated();
            //OnVerseBackKeyPressed();
        }

        void BbRead_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        /// <summary>
        /// Resets the application bar
        /// </summary>
        void ClearApplicationBar()
        {
            while (ApplicationBar.Buttons.Count > 0)
            {
                ApplicationBar.Buttons.RemoveAt(0);
            }

            while (ApplicationBar.MenuItems.Count > 0)
            {
                ApplicationBar.MenuItems.RemoveAt(0);
            }
        }

        #region MultiselectListbox item
        ApplicationBarIconButton select;
        ApplicationBarIconButton delete;
        ApplicationBarMenuItem markAsRead;
        ApplicationBarMenuItem markAsUnread;

        /// <summary>
        /// Creates ApplicationBar items for Verse list
        /// </summary>
        private void CreateVerseApplicationBarItems()
        {
            select = new ApplicationBarIconButton();
            select.IconUri = new Uri("/Toolkit.Content/ApplicationBar.Select.png", UriKind.RelativeOrAbsolute);
            select.Text = "select";
            select.Click += OnSelectClick;

            delete = new ApplicationBarIconButton();
            delete.IconUri = new Uri("/Toolkit.Content/ApplicationBar.Delete.png", UriKind.RelativeOrAbsolute);
            delete.Text = "delete";
            delete.Click += OnDeleteClick;

            markAsRead = new ApplicationBarMenuItem();
            markAsRead.Text = "mark as read";
            markAsRead.Click += OnMarkAsReadClick;

            markAsUnread = new ApplicationBarMenuItem();
            markAsUnread.Text = "mark as unread";
            markAsUnread.Click += OnMarkAsUnreadClick;
        }

        /// <summary>
        /// Called when Verse pivot item is activated : makes sure that selection is disabled and updates the application bar
        /// </summary>
        void OnVersePivotItemActivated()
        {
            if (VerseList.IsSelectionEnabled)
            {
                VerseList.IsSelectionEnabled = false; // Will update the application bar too
            }
            else
            {
                SetupVerseApplicationBar();
            }
        }

        /// <summary>
        /// Configure ApplicationBar items for Verse list
        /// </summary>
        private void SetupVerseApplicationBar()
        {
            ClearApplicationBar();

            if (VerseList.IsSelectionEnabled)
            {
                ApplicationBar.Buttons.Add(delete);
                ApplicationBar.MenuItems.Add(markAsRead);
                ApplicationBar.MenuItems.Add(markAsUnread);
                UpdateVerseApplicationBar();
            }
            else
            {
                ApplicationBar.Buttons.Add(select);
            }
            ApplicationBar.IsVisible = true;
        }

        /// <summary>
        /// Updates the Verse Application bar items depending on selection
        /// </summary>
        private void UpdateVerseApplicationBar()
        {
            if (VerseList.IsSelectionEnabled)
            {
                bool hasSelection = ((VerseList.SelectedItems != null) && (VerseList.SelectedItems.Count > 0));
                delete.IsEnabled = hasSelection;
                markAsRead.IsEnabled = hasSelection;
                markAsUnread.IsEnabled = hasSelection;
            }
        }

        /// <summary>
        /// Back Key Pressed = leaves the selection mode
        /// </summary>
        /// <param name="e"></param>
        protected void OnVerseBackKeyPressed(CancelEventArgs e)
        {
            if (VerseList.IsSelectionEnabled)
            {
                VerseList.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Passes the Verse list in selection mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSelectClick(object sender, EventArgs e)
        {
            VerseList.IsSelectionEnabled = true;
        }

        /// <summary>
        /// Deletes selected items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDeleteClick(object sender, EventArgs e)
        {
            IList source = VerseList.ItemsSource as IList;
            while (VerseList.SelectedItems.Count > 0)
            {
                source.Remove((VerseObject)VerseList.SelectedItems[0]);
            }
        }

        /// <summary>
        /// Mark all items as read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMarkAsReadClick(object sender, EventArgs e)
        {
            foreach (VerseObject obj in VerseList.SelectedItems)
            {
                obj.Unread = false;
            }

            VerseList.IsSelectionEnabled = false;
        }

        /// <summary>
        /// Mark all items as unread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMarkAsUnreadClick(object sender, EventArgs e)
        {
            foreach (VerseObject obj in VerseList.SelectedItems)
            {
                obj.Unread = true;
            }

            VerseList.IsSelectionEnabled = false;
        }

        /// <summary>
        /// Adjusts the user interface according to the number of selected Verses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVerseListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateVerseApplicationBar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVerseListIsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetupVerseApplicationBar();
        }



        /// <summary>
        /// Tap on an item : depending on the selection state, either unselect it or consider it as read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemContentTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            VerseObject item = ((FrameworkElement)sender).DataContext as VerseObject;
            if (item != null)
            {
                item.Unread = false;
            }
        }

        #endregion


        #region Databinding
        /// <summary>
        /// Hide the application bar
        /// </summary>
        void SetupBoundBuddiesApplicationBar()
        {
            ApplicationBar.IsVisible = false;
        }


        #endregion
    }
}