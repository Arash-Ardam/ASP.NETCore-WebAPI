using AutoMapper;
using dotnetcoreWebAPI.Dtos;
using dotnetcoreWebAPI.models;

namespace dotnetcoreWebAPI.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookReadDto, Book>();
            CreateMap<Book, BookReadDto>();
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookCreateDto>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<Book, BookUpdateDto>();
            CreateMap<BookUpdateDto, BookReadDto>();
        }
    }
}
