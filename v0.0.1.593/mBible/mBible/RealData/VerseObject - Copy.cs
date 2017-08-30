using System;
using System.ComponentModel;

namespace mBible.RealData
{
    public class VerseObject : INotifyPropertyChanged
    {
        private bool _unselected;

        public string ID { get; set; }
        public string Title { get; set; }
        public string Verse { get; set; }

        public bool Unselected
        {
            get { return _unselected; }
            set
            {
                _unselected = value;
                NotifyPropertyChanged("Unselected");
            }
        }

        public VerseObject(string id, string title, string verse)
        {
            ID = id;
            Title = title;
            Verse = verse;
        }

        public VerseObject(string id, string title, string verse, bool unselected)
        {
            ID = id;
            Title = title;
            Verse = verse;
            Unselected = unselected;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
