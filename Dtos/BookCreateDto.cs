using System.ComponentModel.DataAnnotations;

namespace dotnetcoreWebAPI.Dtos
{
    public class BookCreateDto
    {
        public string? title { get; set; }
        [Required]
        public double price { get; set; }
    }
}
