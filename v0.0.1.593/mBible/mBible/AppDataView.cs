using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace mBible
{
    public class AppDataView : INotifyPropertyChanged
    {
        private AppDatabase mBibleDb;
        public AppDataView(string DBConnectionString)
        {
            mBibleDb = new AppDatabase(AppDatabase.DBConnectionString);
        }

        private ObservableCollection<mb_bible> _biblebooks;
        public ObservableCollection<mb_bible> BibleBooks
        {
            get
            {
                return _biblebooks;
            }
            set
            {
                _biblebooks = value;
                NotifyPropertyChanged("BibleBooks");
            }
        }

        public void ListBibleBooks()
        {
            var biblebooks = from mb_bible mybiblelist in
                 mBibleDb.Books.OrderBy(v => v.ID) select mybiblelist;
            BibleBooks = new ObservableCollection<mb_bible>(biblebooks);
        }

        private ObservableCollection<mb_verse> _bookverses;
        public ObservableCollection<mb_verse> BookVerses
        {
            get
            {
                return _bookverses;
            }
            set
            {
                _bookverses = value;
                NotifyPropertyChanged("BookList");
            }
        }

        public void ListBibleVerses()
        {
            var bookverses = from mb_verse mybiblelist in
                 mBibleDb.Verses.OrderBy(v => v.ID) select mybiblelist;
            BookVerses = new ObservableCollection<mb_verse>(bookverses);
        }

        private ObservableCollection<mb_bookmark> _bookmark;
        public ObservableCollection<mb_bookmark> BookMark
        {
            get
            {
                return _bookmark;
            }
            set
            {
                _bookmark = value;
                NotifyPropertyChanged("BookMark");
            }
        }

        public void ListBookMarks()
        {
            var bookmarks = from mb_bookmark mybiblelist in
                 mBibleDb.BookMarks.OrderBy(v => v.ID) select mybiblelist;
            BookMark = new ObservableCollection<mb_bookmark>(bookmarks);
        }

        private ObservableCollection<mb_copy> _bookcopy;
        public ObservableCollection<mb_copy> BookCopy
        {
            get
            {
                return _bookcopy;
            }
            set
            {
                _bookcopy = value;
                NotifyPropertyChanged("BookCopy");
            }
        }

        public void ListBibleCopy()
        {
            var bookcopy = from mb_copy mybiblelist in
                 mBibleDb.Copies.OrderBy(v => v.ID) select mybiblelist;
            BookCopy = new ObservableCollection<mb_copy>(bookcopy);
        }

        private ObservableCollection<mb_copy> _biblesearch;
        public ObservableCollection<mb_copy> BibleSearch
        {
            get
            {
                return _biblesearch;
            }
            set
            {
                _biblesearch = value;
                NotifyPropertyChanged("BibleSearch");
            }
        }

        public void ListBibleSearch()
        {
            var biblesearch = from mb_copy mybiblelist in
                mBibleDb.Searches.OrderBy(v => v.ID) select mybiblelist;
            BibleSearch = new ObservableCollection<mb_copy>(biblesearch);
        }

        public void SaveChangesToDB()
        {
            mBibleDb.SubmitChanges();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
