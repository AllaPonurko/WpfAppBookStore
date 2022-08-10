using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfAppBookStore.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Book> GetBooks { get; set; }
        public Genre()
        {
            Name = Name;
            GetBooks = new List<Book>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
