

using EF_LINQ_PROJECT.DBContext;
using EF_LINQ_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EF_LINQ_PROJECT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamingContext streamingContext = new StreamingContext();

            streamingContext.Database.Migrate();


            #region Add producers



            streamingContext.AddRange(
              new Producer { CompanyName = "company1", Country = "egypt" },
              new Producer { CompanyName = "company2", Country = "USA" },
               new Producer { CompanyName = "company1", Country = "England" }

            );

            #endregion
            streamingContext.SaveChanges();



            #region aDD MOVIES



            streamingContext.AddRange(
            new Movie { ProducerId = 1, duaration = 3, rating = 6, Title = "the god father" },
            new Movie { ProducerId = 2, duaration = 3, rating = 8, Title = "the god father2" },
            new Movie { ProducerId = 2, duaration = 3, rating = 8, Title = "the god father3" },
            new Movie { ProducerId = 3, duaration = 2, rating = 7, Title = "shutter island" },
              new Movie { ProducerId = 3, duaration = 2, rating = 4, Title = "Sonic" },
              new Movie { ProducerId = 1, duaration = 2, rating = 3, Title = "Sonic2" },
              new Movie { ProducerId = 2, duaration = 2, rating = 9, Title = "fight club" });
            #endregion

            streamingContext.SaveChanges();



            #region ADD customers
            streamingContext.AddRange(new Customer { FirstName = "ahmed ", LastName = "mahmoud", Address = "cairo ", PhoneNumber = "011165926245" },
            new Customer
            {
                FirstName = "abdelrahman ",
                LastName = "hamdy",
                Address = " Alex",
                PhoneNumber = "0122568126"
            }, new Customer
            {
                FirstName = "mohamed ",
                LastName = "karem",
                Address = " monofia ",
                PhoneNumber = "01022336655"
            }



                );
            streamingContext.SaveChanges();


            #endregion




            #region aDD RENTAL

            streamingContext.AddRange(
                    new CustomerMoive { CustomerId = 1, MovieId = 2 },
                                    new CustomerMoive { CustomerId = 3, MovieId = 2 },
                    new CustomerMoive { CustomerId = 3, MovieId = 1 },
                    new CustomerMoive { CustomerId = 3, MovieId = 5 },
                    new CustomerMoive { CustomerId = 1, MovieId = 5 },
                    new CustomerMoive { CustomerId = 2, MovieId = 4 },
                    new CustomerMoive { CustomerId = 2, MovieId = 6 },
                    new CustomerMoive { CustomerId = 1, MovieId = 7 },
                                        new CustomerMoive { CustomerId = 2, MovieId = 7 }
            , new CustomerMoive { CustomerId = 3, MovieId = 6 }



                     );
            streamingContext.SaveChanges();

            #endregion


            #region aDD_NEW_TABLE
            streamingContext.Database.Migrate();


            streamingContext.AddRange(new Feedback { Descrition = "good", movieid = 2 },
                new Feedback { Descrition = "vg", movieid = 3 },
                new Feedback { Descrition = "so bad ", movieid = 5 },
                new Feedback { Descrition = "good", movieid = 4 }
                );



            streamingContext.SaveChanges();


            #endregion


            //linq 
            #region query 1 


            //1

            var x = streamingContext.CustomerMoives.Include(x => x.Movie).GroupBy(x => x.MovieId)
                .Select(x => new { name = x.First(y => y.MovieId == x.Key).Movie.Title, count = x.Count() })
                .OrderByDescending(x => x.count).Take(3).ToList();


            foreach (var item in x)
            {
                Console.WriteLine(item.name + "     " + " number of rental " + item.count);
                Console.WriteLine("==================");
                ;

            }
            #endregion

            //2

            #region query2

            Console.WriteLine( "====================================" );
            Console.WriteLine("     query2      ");
            Console.WriteLine("====================================");

            var y = streamingContext.Movies.Include(nameof(Movie.Producer)).GroupBy(x => x.ProducerId).Select(x => new { name = x.First(y => y.ProducerId== x.Key).Producer.CompanyName, number_of_movies = x.Count() }).OrderByDescending(x => x.number_of_movies).First();

            Console.WriteLine(y.name + "     " + " number of movies " + y.number_of_movies);
            Console.WriteLine("=====================================");

            #endregion

            //3
            #region query3

            Console.WriteLine("====================================");
            Console.WriteLine("     query3      ");
            Console.WriteLine("====================================");


            var z = streamingContext.CustomerMoives.Include(x => x.Customer).GroupBy(x => x.CustomerId)
             .Select(x => new { Custom = x.First(y => y.CustomerId == x.Key).Customer, count = x.Count() })
             .OrderByDescending(x => x.count).ToList();

            foreach (var item in z)
            {
                Console.WriteLine(item.Custom + "     " + " number of rental " + item.count);
                Console.WriteLine("==================");
                    ;

            }
            #endregion





            #region querey 4



       var q   =  streamingContext.CustomerMoives.Include(nameof(CustomerMoive.Movie)).Include(nameof(CustomerMoive.Customer)).
       Select(x => new { moviename = x.Movie.Title, CustomerName= x.Customer.FirstName + " "+x.Customer.LastName,  rent_date = x.Startdate.ToString("dd/MM/yyyy"), end_date = x.Enddate.ToString("dd/MM/yyyy"), day_remaining = x.ReaminDayes}).ToList();

            foreach (var item in q)
            {
                Console.WriteLine($" movie name = {item.moviename}  : customer ={item.CustomerName} :  rent date = {item.rent_date}  ;  rent date = {item.end_date}  : days_last = {item.day_remaining}  "  );

                Console.WriteLine(  );
                Console.WriteLine(  "-------------------------------------------------");

            }


            #endregion
        }


    }
}