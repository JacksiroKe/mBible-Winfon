using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace mBible.RealData
{
    public class VerseCollection : ObservableCollection<VerseObject>
    {
        private AppSettings settings = new AppSettings();
        public VerseCollection() 
            : base()
        {
            String bkchap;
            bkchap = settings.CurrentEnglishSetting + " " + settings.SelectedChapterSetting;
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            
            /*
            Add(new VerseObject("Genesis 1:", "1 In the beginning God created the heaven and the earth.", false));
            Add(new VerseObject("Genesis 1:", "2 And the earth was without form, and void; and darkness was upon the face of the deep. And the Spirit of God moved upon the face of the waters.", false));
            Add(new VerseObject("Genesis 1:", "3 And God said, Let there be light: and there was light.", false));
            Add(new VerseObject("Genesis 1:", "4 And God saw the light, that it was good: and God divided the light from the darkness.", false));
            Add(new VerseObject("Genesis 1:", "5 And God called the light Day, and the darkness he called Night. And the evening and the morning were the first day.", false));
            Add(new VerseObject("Genesis 1:", "6 And God said, Let there be a firmament in the midst of the waters, and let it divide the waters from the waters.", false));
            Add(new VerseObject("Genesis 1:", "aters which were above the firmament: and it was so.", false));
            */

            ///*            
            var query = from tlist in context.Verses where tlist.Title.Contains(bkchap) select tlist;
            foreach (mb_verse mb_item in query)
            {
                Add(new VerseObject(mb_item.Title, mb_item.Verse, false));
            } //*/

        }
    }

}
