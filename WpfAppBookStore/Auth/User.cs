using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WpfAppBookStore.Models;

namespace WpfAppBookStore.Auth
{
    public class User
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public bool IsAdmin { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public override string ToString()
        {
            return Login;
        }
        public ICollection<Book> GetBooks { get; set; }
        public User()
        {
            Login = Login;
            Password = Password;
            GetBooks = new List<Book>();
            IsAdmin = false;
        }
    }
}
