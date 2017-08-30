using System;
using System.ComponentModel;

namespace mBible.RealData
{
    public class VerseObject : INotifyPropertyChanged
    {
        private bool _unread;

        public string Title { get; set; }

        public string Verse { get; set; }

        public string ID { get; set; }

        public bool Unread
        {
            get { return _unread; }
            set
            {
                _unread = value;
                NotifyPropertyChanged("Unread");
            }
        }

        public VerseObject(string title, string verse)
        {
            Title = title;
            Verse = verse;
        }

        public VerseObject(string title, string verse, bool unread)
        {
            Title = title;
            Verse = verse;
            Unread = unread;
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
