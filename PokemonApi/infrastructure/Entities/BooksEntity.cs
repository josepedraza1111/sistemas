namespace PokemonApi.Infrastructure.Entities
{
    public class BooksEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}