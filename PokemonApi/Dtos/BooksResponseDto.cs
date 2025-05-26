using System.Runtime.Serialization;

namespace PokemonApi.Dtos;
[DataContract(Name = "BooksDto", Namespace = "http://book-api/book-service")]
public class BooksResponseDto
{
     [DataMember(Name = "id", Order = 1)]
    public Guid Id { get; set; } 
     [DataMember(Name = "Title", Order = 2)]
    public string Title { get; set; }
     [DataMember(Name = "author", Order = 3)]

    public string Author { get; set; }
     [DataMember(Name = "publishedDate", Order = 4)]

    public DateTime PublishedDate { get; set; }
}