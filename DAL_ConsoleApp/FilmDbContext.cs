using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DAL;

namespace DAL_ConsoleApp
{
    class FilmDbContext : DbContext
    {
        public FilmDbContext() : base("FilmDB")
        {
            Database.SetInitializer<FilmDbContext>(new DropCreateDatabaseIfModelChanges<FilmDbContext>());


            //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
