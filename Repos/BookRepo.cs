using dotnetcoreWebAPI.infrastructure;
using dotnetcoreWebAPI.models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using dotnetcoreWebAPI.Dtos;
using dotnetcoreWebAPI.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace dotnetcoreWebAPI.Repos
{
    
    public class BookRepo : IBookRepo
    {
        private readonly BookDbContext _context ;
        private readonly IMapper _mapper ;
        public BookRepo(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IBookRepo.ResultType AddBook(BookCreateDto book)
        {
            if (book is not null)
            {
                var BookToDb = _mapper.Map<BookCreateDto,Book>(book);
                _context.Add(BookToDb);
                _context.SaveChanges();
            }

            return IBookRepo.ResultType.Created;
        }

        
        public IBookRepo.ResultType DeleteBook(int id)
        {
            var deletedBook = _context.Books.Remove(_context.Books.SingleOrDefault(e => e.id == id));
            _context.SaveChanges();

            return IBookRepo.ResultType.Deleted;
        }

        public BookReadDto GetBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(e => e.id == id);
            var ClientBook = _mapper.Map<Book, BookReadDto>(book);
            return ClientBook;
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = _context.Books.ToList();

            return books;
        }

        public string PatchCommandUpdateBook(int id, JsonPatchDocument<BookUpdateDto> patchdoc)
        {
            var DbBook = _context.Books.SingleOrDefault(e => e.id==id);
            if (DbBook == null)
            {
                return "Nothing";
            }
            var bookToPatch = _mapper.Map<BookUpdateDto>(DbBook);
            patchdoc.ApplyTo(bookToPatch);

            _mapper.Map(bookToPatch,DbBook);
            _context.Update(DbBook);
            _context.SaveChanges();

            return "PatchUpdated";
        }

        public IBookRepo.ResultType UpdateBook(BookUpdateDto book)
        {
            var BookinDB = _context.Books.SingleOrDefault(e => e.id==book.id);
            BookinDB.title = book.title;
            BookinDB.price = book.price;
            _context.Update(BookinDB);
            _context.SaveChanges();

            return IBookRepo.ResultType.Updated;
        }
    }
}
