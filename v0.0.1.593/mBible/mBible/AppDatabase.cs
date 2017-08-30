using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mBible
{
    public class AppDatabase : DataContext
    {
        public static string DBConnectionString = @"isostore:/MasterBible.sdf";
        public AppDatabase(string connectionString)
            : base(connectionString)
        { }

        public Table<mb_bible> Books
        {
            get
            {
                return this.GetTable<mb_bible>();
            }
        }

        public Table<mb_verse> Verses
        {
            get
            {
                return this.GetTable<mb_verse>();
            }
        }

        public Table<mb_search> Searches
        {
            get
            {
                return this.GetTable<mb_search>();
            }
        }

        public Table<mb_bookmark> BookMarks
        {
            get
            {
                return this.GetTable<mb_bookmark>();
            }
        }

        public Table<mb_copy> Copies
        {
            get
            {
                return this.GetTable<mb_copy>();
            }
        }

    }

    [Table]
    public class mb_bible : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private int _testament;

        [Column]
        public int Testament
        {
            get { return _testament; }
            set
            {
                if (_testament != value)
                {
                    _testament = value;
                    NotifyPropertyChanged("Testament");
                }
            }
        }

        private int _book;

        [Column]
        public int Book
        {
            get { return _book; }
            set
            {
                if (_book != value)
                {
                    _book = value;
                    NotifyPropertyChanged("Book");
                }
            }
        }

        private int _chapters;

        [Column]
        public int Chapters
        {
            get { return _chapters; }
            set
            {
                if (_chapters != value)
                {
                    _chapters = value;
                    NotifyPropertyChanged("Chapters");
                }
            }
        }

        private string _english;

        [Column]
        public string English
        {
            get { return _english; }
            set
            {
                if (_english != value)
                {
                    _english = value;
                    NotifyPropertyChanged("English");
                }
            }
        }
        
        private string _abbrevs;

        [Column]
        public string Abbrevs
        {
            get { return _abbrevs; }
            set
            {
                if (_abbrevs != value)
                {
                    _abbrevs = value;
                    NotifyPropertyChanged("Abbrevs");
                }
            }
        }

        private string _swahili;

        [Column]
        public string Swahili
        {
            get { return _swahili; }
            set
            {
                if (_swahili != value)
                {
                    _swahili = value;
                    NotifyPropertyChanged("Swahili");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyDate)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyDate));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyDate)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyDate));
            }
        }

        #endregion
    }

    [Table]
    public class mb_verse : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _title;

        [Column]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _verse;

        [Column]
        public string Verse
        {
            get { return _verse; }
            set
            {
                if (_verse != value)
                {
                    _verse = value;
                    NotifyPropertyChanged("Verse");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyDate)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyDate));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyDate)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyDate));
            }
        }

        #endregion
    }

    [Table]
    public class mb_search : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _title;

        [Column]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _content;

        [Column]
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    NotifyPropertyChanged("Content");
                }
            }
        }

        private string _time;

        [Column]
        public string Time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    NotifyPropertyChanged("Time");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyDate)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyDate));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyDate)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyDate));
            }
        }

        #endregion

    }

    [Table]
    public class mb_bookmark : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _title;

        [Column]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _content;

        [Column]
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    NotifyPropertyChanged("Content");
                }
            }
        }

        private string _time;

        [Column]
        public string Time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    NotifyPropertyChanged("Time");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyDate)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyDate));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyDate)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyDate));
            }
        }

        #endregion
    }

    [Table]
    public class mb_copy : INotifyPropertyChanged, INotifyPropertyChanging
    {
        
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _text;

        [Column]
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    NotifyPropertyChanged("Text");
                }
            }
        }

        private string _time;

        [Column]
        public string Time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    NotifyPropertyChanged("Time");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyDate)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyDate));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyDate)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyDate));
            }
        }

        #endregion
    }

    public class BibleBook
    {
        public int ID { get; set; }
        public int Testament { get; set; }
        public int Book { get; set; }
        public int Chapters { get; set; }
        public string English { get; set; }
        public string Abbrevs { get; set; }
        public string Swahili { get; set; }
    }

    public class BibleVerse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Verse { get; set; }
    }

    public class BookAdd
    {
        public void AddBook(int testament, int book, int chapters, String english, String abbrevs, String swahili)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                mb_bible newdetail = new mb_bible();
                newdetail.Testament = testament;
                newdetail.Book = book;
                newdetail.Chapters = chapters;
                newdetail.English = english;
                newdetail.Abbrevs = abbrevs;
                newdetail.Swahili = swahili;
                context.Books.InsertOnSubmit(newdetail);
                context.SubmitChanges();
            }
        }
    }

    public class VerseAdd
    {
        public void AddVerse(String title, String verse)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                mb_verse newVerse = new mb_verse();
                newVerse.Title = title;
                newVerse.Verse = verse;
                context.Verses.InsertOnSubmit(newVerse);
                context.SubmitChanges();
            }
        }
    }

    public class FetchBook
    {
        public IList<mb_bible> GetAllBooks(String ttno, String sarch)
        {
            IList<mb_bible> list = null;
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<mb_bible> query = from plist in context.Books
                    where (plist.Testament.Equals(ttno) && plist.English.Contains(sarch)) select plist;
                list = query.ToList();
            }
            return list;
        }
        public List<BibleBook> getBook(String ttno, String sarch)
        {
            IList<mb_bible> details = this.GetAllBooks(ttno, sarch);
            List<BibleBook> alldetails = new List<BibleBook>();
            foreach (mb_bible final_a in details)
            {
                BibleBook final_b = new BibleBook();
                final_b.ID = final_a.ID;
                final_b.Testament = final_a.Testament;
                final_b.Book = final_a.Book;
                final_b.Chapters = final_a.Chapters;
                final_b.English = final_a.English;
                final_b.Abbrevs = final_a.Abbrevs;
                final_b.Swahili = final_a.Swahili;
                alldetails.Add(final_b);
            }
            return alldetails;
        }
    }


    public class FindBook
    {
        public IList<mb_bible> GetSingleOne(String sarch)
        {
            IList<mb_bible> list = null;
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<mb_bible> query = from plist in context.Books
                    where plist.English.Equals(sarch)  select plist;
                list = query.ToList();
            }
            return list;
        }
        public List<BibleBook> getJustOne(String sarch)
        {
            IList<mb_bible> details = this.GetSingleOne(sarch);
            List<BibleBook> alldetails = new List<BibleBook>();
            foreach (mb_bible final_a in details)
            {
                BibleBook final_b = new BibleBook();
                final_b.ID = final_a.ID;
                final_b.Testament = final_a.Testament;
                final_b.Book = final_a.Book;
                final_b.Chapters = final_a.Chapters;
                final_b.English = final_a.English;
                final_b.Abbrevs = final_a.Abbrevs;
                final_b.Swahili = final_a.Swahili;
                alldetails.Add(final_b);
            }
            return alldetails;
        }
    }
    public class FetchVerse
    {
        public IList<mb_verse> GetAllVerses(String bkchap)
        {
            IList<mb_verse> list = null;
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<mb_verse> query = from tlist in context.Verses where tlist.Title.Contains(bkchap) select tlist;
                list = query.ToList();
            }
            return list;
        }
        public List<BibleVerse> getVerses(String bkchap)
        {
            IList<mb_verse> Verses = this.GetAllVerses(bkchap);
            List<BibleVerse> allVerses = new List<BibleVerse>();
            foreach (mb_verse final_a in Verses)
            {
                BibleVerse final_b = new BibleVerse();
                final_b.ID = final_a.ID;
                final_b.Title = final_a.Title;
                final_b.Verse = final_a.Verse;
                allVerses.Add(final_b);
            }
            return allVerses;
        }
    }
    
    public class SearchVerses
    {
        public IList<mb_verse> SearchAllVerses(String sarch)
        {
            IList<mb_verse> list = null;
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<mb_verse> query = from tlist in context.Verses
                    where (tlist.Title.Contains(sarch) || tlist.Verse.Contains(sarch)) select tlist;
                list = query.ToList();
            }
            return list;
        }

        public List<BibleVerse> searchVerses(String sarch)
        {
            IList<mb_verse> Verses = this.SearchAllVerses(sarch);
            List<BibleVerse> allVerses = new List<BibleVerse>();
            foreach (mb_verse final_a in Verses)
            {
                BibleVerse final_b = new BibleVerse();
                final_b.ID = final_a.ID;
                final_b.Title = final_a.Title;
                final_b.Verse = final_a.Verse;
                allVerses.Add(final_b);
            }
            return allVerses;
        }
    }

    public class BooksDelete
    {
        public void DeleteAllBooks() 
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<mb_bible> entityQuery = from c in context.Books select c;
                IList<mb_bible> entityToDelete = entityQuery.ToList();
                context.Books.DeleteAllOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }        
    }

    public class VersesDelete
    {
        public void DeleteAllVerses()
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<mb_verse> entityQuery = from c in context.Verses select c;
                IList<mb_verse> entityToDelete = entityQuery.ToList();
                context.Verses.DeleteAllOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
    }

    /*
    public class BookDelete
    {
        public void DeleteAllBooks() //delete all Books
        {
            using (DatabaseHelper context = new DatabaseHelper(DatabaseHelper.DBConnectionString))
            {
                IQueryable<mb_bible> entityQuery = from c in context.Books select c;
                IList<mb_bible> entityToDelete = entityQuery.ToList();
                context.Books.DeleteAllOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
        public void DeleteBook(String id)//delete Book by id
        {
            using (DatabaseHelper context = new DatabaseHelper(DatabaseHelper.DBConnectionString))
            {
                IQueryable<mb_bible> entityQuery = from plist in context.Books where plist.ID.Equals(id) select c;
                mb_bible entityToDelete = entityQuery.FirstOrDefault();
                context.Books.DeleteOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
    }*/

}
