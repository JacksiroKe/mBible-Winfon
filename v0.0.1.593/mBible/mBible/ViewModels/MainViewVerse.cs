using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using mBible.Resources;

namespace mBible
{
    public class MainViewVerse : INotifyPropertyChanged
    {
        public MainViewVerse()
        {
            this.Verses = new ObservableCollection<ItemViewVerse>();
        }

        /// <summary>
        /// A collection for ItemViewVerse objects.
        /// </summary>
        public ObservableCollection<ItemViewVerse> Verses { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewVerse property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewVerse objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}