using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;



//

namespace DAL
{
    class FilmDbContext : DbContext
    {
        public FilmDbContext() : base("SchoolDBConnectionString")///////////////////////////
        {
            //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());



  //          Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public DbSet<Film> Students { get; set; }
        public DbSet<Actor> Standards { get; set; }
    }
}
