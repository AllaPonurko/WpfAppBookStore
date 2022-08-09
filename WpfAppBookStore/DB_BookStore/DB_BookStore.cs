using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfAppBookStore.Models;

namespace WpfAppBookStore.DB_BookStore
{
    public class DB_BookStore:DbContext
    {
        public DbSet<Book> books { get; set; }
        public DB_BookStore()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                           Database=Db_BookStore.db;Trusted_Connection=True;");
        }
    }
}
