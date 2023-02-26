using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<movieContext>();

            context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange
                        (
                             new List<Movie>()
                                {
                                        new Movie {
                                        MovieID=1,
                                        Title="Jiu Jitsu",
                                        Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                                        ImageURL="1.jpg",
                                        GenreID=1
                                    },
                                    new Movie {
                                        MovieID=2,
                                        Title="Fatman",
                                        Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                                        ImageURL="2.jpg",
                                        GenreID=1
                                    },
                                    new Movie {
                                        MovieID=3,
                                        Title="The Dalton Gang",
                                        Description="When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
                                        ImageURL="3.jpg",
                                        GenreID=3
                                    },
                                        new Movie {
                                        MovieID=4,
                                        Title="Tenet",
                                        Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                                        ImageURL="4.jpg",
                                        GenreID=3
                                    },
                                    new Movie {
                                        MovieID=5,
                                        Title="The Craft: Legacy",
                                        Description="An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
                                        ImageURL="5.jpg",
                                        GenreID=3
                                    },
                                    new Movie {
                                        MovieID=6,
                                        Title="Hard Kill",
                                        Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
                                        ImageURL="6.jpg",
                                        GenreID=4
                                    }
                                }

                        );
                }
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange
                        (
                            new List<Genre>()
                            {
                                new Genre {GenreID=1,GenreName="Macera"},
                                new Genre {GenreID=2,GenreName="Komedi"},
                                new Genre {GenreID=3,GenreName="Romantik"},
                                new Genre {GenreID=4,GenreName="Savaş"},
                                new Genre {GenreID=5,GenreName="Bilim Kurgu"}
                            }
                        );
                }

                context.SaveChanges();
            }
        }
    }
}
