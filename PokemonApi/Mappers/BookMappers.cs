using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers
{
    public static class BookMappers
    {
        public static Book ToModel(this BooksEntity entity)
        {
            if (entity is null)
            {
                return null;
            }
            return new Book
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                PublishedDate = entity.PublishedDate
            };
        }

        public static BooksResponseDto ToDto(this Book book)
        {
            return new BooksResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate
            };
        }

        public static BooksEntity ToEntity(this Book book)
        {
            return new BooksEntity
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate
            };
        }
    }
}