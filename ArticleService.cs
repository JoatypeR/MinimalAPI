namespace MinimalAPI
{
    public class ArticleService
    {
        private List<Article> list = new List<Article>
        {
            new Article(1, "Marteau"),
            new Article(2, "Scie")
        };

        public List<Article> GetAll() => list;

        public void Add(string Title)
        {
            list.Add(new Article(list.Max(a => a.Id) + 1, Title));
        }
    }
}
