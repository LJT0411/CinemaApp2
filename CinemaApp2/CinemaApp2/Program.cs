using CinemaApp2.Models;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CinemaApp2
{
    class Program
    {
        private static AllData data = new AllData();
        static void Main(string[] args)
        {
            // Insert data 
            data.GenerateUser();
            data.GenerateMovie();
            data.GenerateMovieTime();

            // Get the stored list to this checkMovie and checkTime
            var checkMovie = data.MovieDetails.ToList();
            var checkTime = data.MovieTimeDetails.ToList();
            
            Random SeatA = new Random();
            for (int y = 0; y < checkTime.Count; y++)
            {
                // This linq used to check the hall id and give the row
                var checkHall = data.MovieTimeDetails.Where(c => c.MovieHallID == checkTime[y].MovieHallID).SingleOrDefault();
                int check = 0;
                if (checkHall.MovieHallID == 301 || checkHall.MovieHallID == 304)
                    check = 4;
                if (checkHall.MovieHallID == 302 || checkHall.MovieHallID == 305)
                    check = 5;
                if (checkHall.MovieHallID == 303 || checkHall.MovieHallID == 306)
                    check = 6;

                for (int i = 1; i < check; i++)
                {
                    for (int x = 1; x < 11; x++)
                    {
                        SAvail Avail = (SAvail)SeatA.Next(2);

                        MovieSeatDetails SeatList = new MovieSeatDetails
                        {
                            SeatID = +1,
                            SeatNo = i + "," + x,
                            SeatAvail = Avail,
                            MovieTimeID = checkTime[y].MovieTimeID
                        };
                        data.MovieSeatDetails.Add(SeatList);
                    }
                }
            }

            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Welcome to TGV Cinema Ticket App");
                Console.WriteLine("1. View all movies");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit app\n");

                Console.Write("Enter your option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var CinemaTable = new ConsoleTable("Movie Title", "Release Date", "");
                        // This is foreach used to print the movie output
                        foreach (var MovieTitle in data.MovieDetails)
                        {
                            CinemaTable.AddRow(MovieTitle.MovieTitle, MovieTitle.MovieReleaseTime, DisplayOP(MovieTitle.MovieAvailable));
                        }
                        CinemaTable.Write();
                        Console.WriteLine("Login to buy a movie ticket of your favourite movie.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Username : ");
                        var username = Console.ReadLine();

                        Console.Write("\nPassword : ");
                        var password = Console.ReadLine();

                        // This linq used to check the username valid or not
                        var checkAcc = (from c in data.Users
                                        where c.Username == username
                                        select c).SingleOrDefault();

                        if (checkAcc != null)
                        {
                            if (password != checkAcc.Password)
                            {
                                Console.WriteLine("Invalid username or password");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Thread.Sleep(2000);
                                Console.Clear();
                                menu = false;

                                bool menu2 = true;
                                while (menu2)
                                {
                                    Console.WriteLine("You login as tgv");
                                    Console.WriteLine("1. Select a movie");
                                    Console.WriteLine("2. Logout");

                                    Console.Write("\nEnter your option : ");
                                    var option2 = Console.ReadLine();

                                    switch (option2)
                                    {
                                        case "1":
                                            Console.Clear();
                                            Console.WriteLine("Select a movie");

                                            var CinemaTable2 = new ConsoleTable("ID", "Movie Title", "Release Date", "");
                                            // Print the Now Showing Movie
                                            var checkMovie2 = (from c in data.MovieDetails
                                                               where c.MovieAvailable == MAvail.NowShowing
                                                               select c).ToList();

                                            foreach (var movies in checkMovie2)
                                            {
                                                CinemaTable2.AddRow(movies.MovieID, movies.MovieTitle, movies.MovieReleaseTime, DisplayOP(movies.MovieAvailable));
                                            }
                                            CinemaTable2.Write();

                                            Console.Write("\nEnter movie id : ");
                                            var movieID = Console.ReadLine();

                                            // This linq used to check the movie id valid or not
                                            var CheckMID = (from c in data.MovieDetails
                                                            where c.MovieID.ToString() == movieID
                                                            select c).SingleOrDefault();

                                            if (CheckMID != null)
                                            {
                                                Console.Clear();
                                                menu2 = false;

                                                bool select = true;
                                                while (select)
                                                {
                                                    // This linq used to grab the movie time list by using the checkmid linq
                                                    var ListTime = data.MovieTimeDetails.Where(c => c.MovieID == CheckMID.MovieID).ToList();
                                                    Console.WriteLine("Your movie selection: " + CheckMID.MovieTitle);
                                                    Console.WriteLine("Select date and time");

                                                    var DateTable = new ConsoleTable("ID", "Date Start Time");

                                                    foreach (var DateTimeList in ListTime)
                                                    {
                                                        DateTable.AddRow(DateTimeList.MovieTimeID, DateTimeList.MovieTimeStart);
                                                    }
                                                    DateTable.Write();

                                                    Console.WriteLine();
                                                    Console.Write("Enter Id to choose the movie time : ");
                                                    var movieTime = Console.ReadLine();

                                                    // This linq used to check the movie time id valid or not
                                                    var checkTimeID = (from c in ListTime
                                                                       where c.MovieTimeID.ToString() == movieTime
                                                                       select c).SingleOrDefault();

                                                    if (checkTimeID != null)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Cinema Hall Seatings");
                                                        var Rows = new ConsoleTable("T: Taken", "E: Empty", "F: Faulty", "L: Locked");

                                                        Rows.Options.EnableCount = false;
                                                        Rows.Write();

                                                        // This linq used to grab the seats that belong to the movie time id
                                                        var checkHall = (from c in data.MovieSeatDetails
                                                                         where c.MovieTimeID == checkTimeID.MovieTimeID
                                                                         select c).ToList();

                                                        foreach (var Seat in checkHall)
                                                        {
                                                            Console.Write(Seat.SeatNo + " " + Seat.SeatAvail + "\t");
                                                            if (Seat.SeatNo.EndsWith("1,10"))
                                                                Console.WriteLine("\n");
                                                            if (Seat.SeatNo.EndsWith("2,10"))
                                                                Console.WriteLine("\n");
                                                            if (Seat.SeatNo.EndsWith("3,10"))
                                                                Console.WriteLine("\n");
                                                            if (Seat.SeatNo.EndsWith("4,10"))
                                                                Console.WriteLine("\n");
                                                        }

                                                        Console.Write("\n\nEnter a seat number (row,column). Example 1,2 : ");
                                                        var seatNumber = Console.ReadLine();

                                                        // This linq used to check the seat number that you typed valid or not
                                                        var checkNumber = (from c in checkHall
                                                                           where c.SeatNo == seatNumber
                                                                           select c).SingleOrDefault();

                                                        if (checkNumber != null)
                                                        {
                                                            if (checkNumber.SeatAvail != SAvail.T)
                                                            {
                                                                Console.WriteLine("Confirm Order? Yes/No");
                                                                var confirmation = Console.ReadLine();

                                                                if (confirmation == "Yes" || confirmation == "yes")
                                                                {
                                                                    checkNumber.SeatAvail = SAvail.T;
                                                                    PrintResult("Success Purchase");
                                                                }
                                                                else
                                                                {
                                                                    PrintResult("Canceled Order");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                PrintResult("Sorry. This seat was taken.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PrintResult("Invalid Seat Number.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid Option");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                        select = false;
                                                        menu2 = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid Option");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                            }
                                            break;

                                        case "2":
                                            Console.WriteLine("Thanks for using. Have a nice day!");
                                            Thread.Sleep(2000);
                                            Console.Clear();
                                            menu2 = false;
                                            menu = true;
                                            break;

                                        default:
                                            Console.WriteLine("Invalid Option");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nThanks for using. Have a nice day!\n");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid Option\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }

        public static string DisplayOP(MAvail mvail)
        {
            switch (mvail)
            {
                case MAvail.NowShowing:
                    return "Now Showing";
                case MAvail.ComingSoon:
                    return "Coming Soon";
                default:
                    return "";
            }
        }

        private static string PrintResult(string result)
        {
            Console.WriteLine(result);
            Thread.Sleep(2000);
            Console.Clear();
            return result;
        }
    }
}
