using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfAppBookStore.Models
{
    public class Book
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Genre { get; set; }
        public Book()
        {
            Title = Title;
            Author = Author;
            Price = Price;
            Genre = Genre;
        }
        public override string ToString()
        {
            return Title+" "+Author;
        }

    }
}
