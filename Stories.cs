//Stories are accessed through a command issued to the bot

namespace Stories
{
    class Story
    {
        public string title {get; set;}
        public Page[] pages {get; set;}
        public Story(string title, Page[] pages)
        {
            this.title = title;
            this.pages = pages;
        }
    }

    class Page
    {
        public string contents {get; set;}
        public Page(string contents)
        {
            this.contents = contents;
        }
    }
}