using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfAppBookStore.Auth;
using WpfAppBookStore.Models;

namespace WpfAppBookStore.DbBookStore
{
    public class DB_BookStore:DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<User> users { get; set; }
        public DB_BookStore()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                           Database=BookStore.db;Trusted_Connection=True;");
        }
    }
}
