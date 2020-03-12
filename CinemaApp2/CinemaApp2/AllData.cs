using CinemaApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp2
{
    public class AllData
    {
        public ICollection<Users> Users { get; set; }
        public ICollection<MovieDetails> MovieDetails { get; set; }
        public ICollection<MovieTimeDetails> MovieTimeDetails { get; set; }
        public ICollection<MovieSeatDetails> MovieSeatDetails { get; set; }

        public AllData()
        {
            Users = new List<Users>();
            MovieDetails = new List<MovieDetails>();
            MovieTimeDetails = new List<MovieTimeDetails>();
            MovieSeatDetails = new List<MovieSeatDetails>();
        }

        public void GenerateUser()
        {
            Users.Add(new Users() { UserID = 1, Username = "tgv" , Password = "tgv"});
            Users.Add(new Users() { UserID = 2, Username = "gsc" , Password = "gsc"});
        }

        public void GenerateMovie()
        {
            MovieDetails.Add(new MovieDetails() { MovieID = 101, MovieTitle = "The Justice League", MovieReleaseTime = "Sunday, 01 March 2020", MovieAvailable = MAvail.NowShowing });
            MovieDetails.Add(new MovieDetails() { MovieID = 102, MovieTitle = "The Matrix", MovieReleaseTime = "Monday, 02 March 2020", MovieAvailable = MAvail.NowShowing });
            MovieDetails.Add(new MovieDetails() { MovieID = 103, MovieTitle = "The Avengers", MovieReleaseTime = "Friday, 06 March 2020", MovieAvailable = MAvail.ComingSoon });
            MovieDetails.Add(new MovieDetails() { MovieID = 104, MovieTitle = "Lord of The Rings", MovieReleaseTime = "Tuesday, 10 March 2020", MovieAvailable = MAvail.ComingSoon });
        }

        public void GenerateMovieTime()
        {
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 201, MovieTimeStart = "27/2/2020 10:00:00 AM", MovieID = 101 });
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 202, MovieTimeStart = "27/2/2020 2:30:00 PM" , MovieID = 101 });
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 203, MovieTimeStart = "27/2/2020 6:10:00 PM" , MovieID = 101 });

            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 204, MovieTimeStart = "27/2/2020 10:00:00 AM", MovieID = 102 });
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 205, MovieTimeStart = "27/2/2020 2:30:00 PM", MovieID = 102 });
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 206, MovieTimeStart = "27/2/2020 6:10:00 PM" , MovieID = 102 });
        }
    }
}
