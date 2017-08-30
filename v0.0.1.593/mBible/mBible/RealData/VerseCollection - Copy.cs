using System.Collections.ObjectModel;

namespace mBible.RealData
{
    public class VerseCollection : ObservableCollection<VerseObject>
    {
        public VerseCollection() : base()
        {
            Add(new VerseObject("1", "Did you have fun on your trip?", "1:34p", false));
            Add(new VerseObject("1", "Did you have fun on your trip?", "1:34p", false));
            Add(new VerseObject("1", "Did you have fun on your trip?", "1:34p", false));
           
        }

        /*
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
            public List<Verses> getVerses(String bkchap)
            {
                IList<mb_verse> Verses = this.GetAllVerses(bkchap);
                List<Verses> allVerses = new List<Verses>();
                foreach (mb_verse final_a in Verses)
                {
                    Verses final_b = new Verses();
                    final_b.ID = final_a.ID.ToString();
                    final_b.Title = final_a.Title;
                    final_b.Verse = final_a.Verse;
                    allVerses.Add(final_b);
                }
                return allVerses;
            }
        } */
    }
}
