﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The RM",
                        ReleaseDate = DateTime.Parse("1999-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "PG",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "The Other Side of Heaven ",
                        ReleaseDate = DateTime.Parse("2000-3-13"),
                        Genre = "Comedy",
                        Rating = "PG-13",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2002-2-23"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 9.99M
                    }

                  
                );
                context.SaveChanges();
            }
        }
    }
}