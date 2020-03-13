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
            MovieDetails.Add(new MovieDetails() { MovieID = 101, MovieTitle = "The Justice League", MovieReleaseTime = new DateTime(2020, 03, 01), MovieAvailable = MAvail.NowShowing });
            MovieDetails.Add(new MovieDetails() { MovieID = 102, MovieTitle = "The Matrix", MovieReleaseTime = new DateTime(2020, 03, 02), MovieAvailable = MAvail.NowShowing });
            MovieDetails.Add(new MovieDetails() { MovieID = 103, MovieTitle = "The Avengers", MovieReleaseTime = new DateTime(2020, 03, 06), MovieAvailable = MAvail.ComingSoon });
            MovieDetails.Add(new MovieDetails() { MovieID = 104, MovieTitle = "Lord of The Rings", MovieReleaseTime = new DateTime(2020, 03, 10), MovieAvailable = MAvail.ComingSoon });
        }

        public void GenerateMovieTime()
        {
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 201, MovieTimeStart = new DateTime(2020, 02, 27, 10, 0, 0), MovieID = 101 , MovieHallID = 301 });
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 202, MovieTimeStart = new DateTime(2020, 02, 27, 14, 30, 0), MovieID = 101 , MovieHallID = 302 });
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 203, MovieTimeStart = new DateTime(2020, 02, 27, 18, 10, 0), MovieID = 101 , MovieHallID = 303 });

            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 204, MovieTimeStart = new DateTime(2020, 02, 27, 10, 0, 0), MovieID = 102 , MovieHallID = 304 });
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 205, MovieTimeStart = new DateTime(2020, 02, 27, 14, 30, 0), MovieID = 102 , MovieHallID = 305 });
            MovieTimeDetails.Add(new MovieTimeDetails() { MovieTimeID = 206, MovieTimeStart = new DateTime(2020, 02, 27, 18, 10, 0), MovieID = 102 , MovieHallID = 306 });
        }
    }
}
