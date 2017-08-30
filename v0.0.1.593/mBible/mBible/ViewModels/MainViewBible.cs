using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using mBible.Resources;

namespace mBible
{
    public class MainViewBible : INotifyPropertyChanged
    {
        public MainViewBible()
        {
            this.Bibles = new ObservableCollection<ItemViewBible>();
        }

        /// <summary>
        /// A collection for ItemViewBible objects.
        /// </summary>
        public ObservableCollection<ItemViewBible> Bibles { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewBible property; this property is used in the view to display its value using a Binding
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
        /// Creates and adds a few ItemViewBible objects into the Items collection.
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