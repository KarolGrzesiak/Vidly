using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }




        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            var moviesInDb = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();
            if (customerInDb.AmountOfRentedMovies + moviesInDb.Count > Rental.RentalLimit)
                return BadRequest("Rental limit is " + Rental.RentalLimit + " movies");
            if (customerInDb.IsDeliquentOnPayment)
                return BadRequest("Customer is deliquent on payment");

            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customerInDb,
                    DateRented = DateTime.Now,
                    Movie = movie
                };
                _context.Rentals.Add(rental);
            }

            customerInDb.AmountOfRentedMovies += (byte)moviesInDb.Count;

            _context.SaveChanges();
            return Ok();

        }


    }
}