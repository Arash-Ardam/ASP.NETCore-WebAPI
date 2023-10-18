using Microsoft.AspNetCore.JsonPatch;

namespace dotnetcoreWebAPI.Repos
{
    public interface IBookRepo
    {
        public enum ResultType
        {
            Created,
            NotFound,
            Updated, 
            Deleted
        }
        IEnumerable<models.Book> GetBooks();
        Dtos.BookReadDto GetBookById(int id);
        ResultType AddBook(Dtos.BookCreateDto book);
        ResultType UpdateBook(Dtos.BookUpdateDto book);
        ResultType DeleteBook(int id);
        string PatchCommandUpdateBook(int id, JsonPatchDocument<Dtos.BookUpdateDto> patchdoc);
    }
}
