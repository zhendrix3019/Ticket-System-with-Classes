using System;
using System.Collections.Generic;
using System.IO;

namespace MovieTicketSystem
{
    class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Rating { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string file = "movies.txt";
            string choice;

            do
            {
                Console.WriteLine("\n1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] data = line.Split(',');

                            Movie movie = new Movie();
                            movie.Title = data[0];
                            movie.Director = data[1];
                            movie.ReleaseDate = DateTime.Parse(data[2]);
                            movie.Rating = data[3];

                            Console.WriteLine($"Title: {movie.Title}, Director: {movie.Director}, Release Date: {movie.ReleaseDate.ToShortDateString()}, Rating: {movie.Rating}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file);

                    List<Movie> movies = new List<Movie>();

                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine("Enter a new movie (Y/N)?");
                        choice = Console.ReadLine().ToUpper();
                        if (choice != "Y") { break; }

                        Movie movie = new Movie();

                        Console.WriteLine("Enter the title.");
                        movie.Title = Console.ReadLine();

                        Console.WriteLine("Enter the director.");
                        movie.Director = Console.ReadLine();

                        Console.WriteLine("Enter the release date (MM/dd/yyyy).");
                        movie.ReleaseDate = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the rating (G, PG, PG-13, R, NC-17).");
                        movie.Rating = Console.ReadLine();

                        movies.Add(movie);
                    }

                    foreach (Movie movie in movies)
                    {
                        sw.WriteLine($"{movie.Title},{movie.Director},{movie.ReleaseDate.ToString("MM/dd/yyyy")},{movie.Rating}");
                    }

                    sw.Close();
                }
            } while (choice == "1" || choice == "2" || choice == "N");
        }
    }
}
