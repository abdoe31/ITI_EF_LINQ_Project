using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_LINQ_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Options;

namespace EF_LINQ_PROJECT.DBContext
{
    public  class StreamingContext :DbContext
    {


        public DbSet<Customer > Customers { get; set; }
        public DbSet<CustomerMoive> CustomerMoives { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        //new table 
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-34KGDF7\\MSSQLSERVER01; databAse = rental_systm ; trusted_connection= true ; encrypt=false  ");


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Customer

            modelBuilder.Entity<Customer>().HasKey(x => x.Id );
            modelBuilder.Entity<Customer>().Property(x => x.FirstName   ).HasMaxLength(225);
            modelBuilder.Entity<Customer>().Property(x => x.LastName).HasMaxLength(225);

            modelBuilder.Entity<Customer>().Property(x => x.Address).HasMaxLength(225);


            #endregion

            #region movie
            modelBuilder.Entity<Movie>().HasKey(x => x.Id);
            modelBuilder.Entity<Movie>().Property(x => x.Id);
            modelBuilder.Entity<Movie>().Property(x => x.Title).HasMaxLength(225);
            modelBuilder.Entity<Movie>().HasOne(x=>x.Producer).WithMany(x=>x.Movies).HasForeignKey(x=>x.ProducerId);



            #endregion

            #region CustomerMovies

            modelBuilder.Entity<CustomerMoive>().HasKey(nameof(CustomerMoive.MovieId), nameof(CustomerMoive.CustomerId));
            modelBuilder.Entity<CustomerMoive>().Ignore(nameof(CustomerMoive.ReaminDayes));
            modelBuilder.Entity<CustomerMoive>().HasOne(x => x.Customer).WithMany(x => x.Moives).HasForeignKey(x => x.CustomerId);
            modelBuilder.Entity<CustomerMoive>().HasOne(x => x.Movie).WithMany(x => x.customers).HasForeignKey(x => x.MovieId);

            #endregion


            #region producer
            modelBuilder.Entity<Producer>().HasKey(nameof(Producer.Id));
            modelBuilder.Entity<Producer>().Property(x => x.CompanyName).HasMaxLength(225);
                        modelBuilder.Entity<Producer>().Property(x => x.CompanyName).HasMaxLength(225);

            modelBuilder.Entity<Producer>().Property(x => x.Id);



            #endregion


            #region feed back

            modelBuilder.Entity<Feedback>().HasKey(nameof(Feedback.Id));
            modelBuilder.Entity<Feedback>().HasOne(x => x.Movie).WithMany(x => x.Feedbacks).HasForeignKey(x => x.movieid);
            modelBuilder.Entity<Feedback>().Property(nameof(Feedback.Descrition)).HasMaxLength(500);
            #endregion

        }




    }
}
