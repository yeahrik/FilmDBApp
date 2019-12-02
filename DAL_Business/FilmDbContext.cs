using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace DAL_Business
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext() : base("FilmDB")
        {
            // Recréer model DB si changements :
            Database.SetInitializer<FilmDbContext>(new DropCreateDatabaseIfModelChanges<FilmDbContext>());

            // Recréer model à chaque exécution :
            // Database.SetInitializer<FilmDbContext>(new DropCreateDatabaseAlways<FilmDbContext>());
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FilmType> FilmTypes { get; set; }
        public DbSet<CharacterActor> CharacterActors { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}
