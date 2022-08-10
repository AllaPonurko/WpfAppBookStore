using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfAppBookStore.Models
{/// <summary>
/// 
/// </summary>
    public class Book
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        ///поле название книги
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// поле автор
        /// </summary>
        [Required]
        public string Author { get; set; }
        /// <summary>
        /// поле цена
        /// </summary>
        [Required]   
        public double Price { get; set; }
        ///// <summary>
        ///// поле жанр
        ///// </summary>
        //[Required]
        //public string Genre { get; set; }
        /// <summary>
        /// поле год издания
        /// </summary>
        public DateTime dateTime { get; set; }
        public Book()
        {
            Title = Title;
            Author = Author;
            Price = Price;
            dateTime = dateTime;
        }
        public override string ToString()
        {
            return Title+" "+Author;
        }

    }
}
