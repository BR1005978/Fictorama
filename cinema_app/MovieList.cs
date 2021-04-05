using System;
using System.Collections.Generic;

namespace cinema_app

{
    public class MovieList
    {
        public static List<Movie> movielist = new List<Movie>(){
        new Movie("Pixels", "", "2015", new string[] { "Action", "Comedy", "Animation", "Fantasy", "Science Fiction" }, "Adam Sandler plays Sam Brenner \n Josh gad plays Ludlow Lamonsoff \n Peter Dinklage plays Eddie Plant", "1 H 46 M"),
        new Movie("CHAPIE", "", "2015", new string[] { "Science Fiction", "Action", "Crime", "Thriller" }, "Anri du Toit plays Yolandi \n Watkin Tudor Jones plays Ninja \n Hugh Jackman plays Vincent Moore", "2 H"),
        new Movie("Jurassic World", "", "2015", new string[] { "Science Fiction", "Action", "Thriller", "Fantasy", "Adventure" }, "Chris Pratt plays Owen Grady \n ", "2 H 4 M"),
        new Movie("Tron: Lengacy", "", "2010", new string[] { "Science Fiction, Action, Adventure, Fantasy" }, "Garrett Hedlund plays Sam Flynn \n Jeff Bridges plays Kevin Flynn", "2 H 7 M"),
        new Movie("The Maze Runner", "", "2014", new string[] { "Science Fiction", "Action", "Thriller", "Adventure" }, "Dylan O'Brien plays Thomas \n Thomas Brodie-Sangster plays Newt \n Will Poulter plays Gally", "1 H 54 M"),
        new Movie("X-Men Origins: Wolverine", "The early years of James Logan, featuring his rivalry with his brother Victor Creed, his service in the special forces team Weapon X, and his experimentation into the metal-lined mutant Wolverine.", "2009", new string[] { "science-fiction" }, "actor", "duration"), //test movie
        };

        
        
        //List<Movie> movielist = new List<Movie>();

        //movielist.Add(Wolverine);
        //public static List<Movie> movielist = new List<Movie>();

        // hoe maak je dit ding gewoon een attribute? met die get;set dingen toch?
        //Movie Wolverine = new Movie("X-Men Origins: Wolverine", "The early years of James Logan, featuring his rivalry with his brother Victor Creed, his service in the special forces team Weapon X, and his experimentation into the metal-lined mutant Wolverine.", "2009"); //test movie
        //public Movie movielist = new Movie { Wolverine }; {get; set;};
        /*static Movie Pixels = new Movie("Pixels", "", "", new string[]{"Action", "Comedy", "Animation", "Fantasy", "Science Fiction"}, "Adam Sandler plays Sam Brenner \n Josh gad plays Ludlow Lamonsoff \n Peter Dinklage plays Eddie Plant", "1 H 46 M", "2015");
        static Movie CHAPPIE = new Movie("CHAPIE", "", "", new string[] { "Science Fiction", "Action", "Crime", "Thriller" }, "Anri du Toit plays Yolandi \n Watkin Tudor Jones plays Ninja \n Hugh Jackman plays Vincent Moore", "2 H", "2015");
        static Movie Jurassic_World = new Movie("Jurassic World", "", "", new string[] { "Science Fiction", "Action", "Thriller", "Fantasy", "Adventure" }, "Chris Pratt plays Owen Grady \n ", "2 H 4 M", "2015");
        static Movie Tron = new Movie("Tron: Lengacy", "", "", new string[] { "Science Fiction, Action, Adventure, Fantasy" }, "Garrett Hedlund plays Sam Flynn \n Jeff Bridges plays Kevin Flynn", "2 H 7 M", "2010");
        static Movie The_Maze_Runner = new Movie("The Maze Runner", "", "", new string[] { "Science Fiction", "Action", "Thriller", "Adventure" }, "Dylan O'Brien plays Thomas \n Thomas Brodie-Sangster plays Newt \n Will Poulter plays Gally", "1 H 54 M", "2014");
        */

    }
}

