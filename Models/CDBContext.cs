using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Cos.Models.Mails;
using Cos.Models.RichAndArticles;
using Cos.Models.ScrollPictures;
namespace Cos.Models
{
        public class CDBContext:DbContext
        {  
            //  public CDBContext(){}
            // public CDBContext(DbContextOptions<CDBContext> options) : base(options)
            // {
            // }
             protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
                optionsBuilder.UseSqlite("Data Source=Cos.db");
            }
            public DbSet<Message> Me{get;set;}
            public DbSet<Article> Ar{get;set;}
            public DbSet<SimpleArticle> Si{get;set;}
            public DbSet<ScrollPicture> Sc{get;set;}
     }
}
