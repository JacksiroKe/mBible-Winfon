using System.Collections.ObjectModel;

namespace mBible.RealData
{
    public class VersereadObject : ObservableCollection<VerseListObject>
    {
        public VersereadObject()
            : base()
        {
            VerseListObject one = new VerseListObject("3 messages, 0 unread");
            one.Add(new VerseObject("Where are we going for lunch today?", "Sure! We haven't seen him in a while. I'm sure there are lots of things to catch up on."));
            one.Add(new VerseObject("Where are we going for lunch today?", "I down for it. Should we invite Dave to go grab lunch with us today?"));
            one.Add(new VerseObject("Where are we going for lunch today?", "I vote for the Thai restaurant across the street. I always forget the name."));

            VerseListObject two = new VerseListObject("3 messages, 0 unread");
            two.Add(new VerseObject("Did you have fun on your trip?", "It'so awesome that you got the chance to go ..."));

            VerseListObject three = new VerseListObject("4 messages, 1 unread");
            three.Add(new VerseObject("hawaii pictures are up!", "This is awesome. It's great to see that you guys had a good time."));
            three.Add(new VerseObject("hawaii pictures are up!", "Oh man, that picture of you with the fish is amazing."));
            three.Add(new VerseObject("hawaii pictures are up!", "Impressive stuff. I love it out there, and can't wait to get back."));
            three.Add(new VerseObject("hawaii pictures are up!", "Check them out. You'll have to tag yourselves in there 'cause I'm lazy. ;)"));

            Add(one);
            Add(two);
            Add(three);
        }
    }
}
