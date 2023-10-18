using System.ComponentModel.DataAnnotations;

namespace dotnetcoreWebAPI.models;

    public class Book
    {
    public int id { get; set; }
    public string? title { get; set; }
    [Required]
    public double price { get; set; }
    }

