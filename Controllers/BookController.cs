using dotnetcoreWebAPI.Dtos;
using dotnetcoreWebAPI.models;
using dotnetcoreWebAPI.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcoreWebAPI.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var response = _bookRepo.GetBooks();
            return response.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var response = _bookRepo.GetBookById(id);
            return null == response ? NotFound(IBookRepo.ResultType.NotFound) : response;
        }

        [HttpPost]
        public ActionResult<IBookRepo.ResultType> AddBook(Dtos.BookCreateDto book)
        {
            if (book is null)
            {
                return BadRequest();
            }
            var response = _bookRepo.AddBook(book);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult<IBookRepo.ResultType> UpdateBook(Dtos.BookUpdateDto book)
        {
            if (book is null)
            {
                return BadRequest();
            }
            var response = _bookRepo.UpdateBook(book);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public ActionResult<string> PatchCommandUpdateBook(int id , JsonPatchDocument<BookUpdateDto> patchdoc)
        {
            if (patchdoc is null)
            {
                return BadRequest();
            }
            var response = _bookRepo.PatchCommandUpdateBook(id, patchdoc);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<IBookRepo.ResultType> DeleteBook(int id)
        {
           var response = _bookRepo.DeleteBook(id);

            return Ok(response);
        }
    }
}
