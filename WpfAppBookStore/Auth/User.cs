using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfAppBookStore.Auth
{
    public class User
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public override string ToString()
        {
            return Login;
        }
        public User()
        {
            Login = Login;
            Password = Password;
        }
    }
}
