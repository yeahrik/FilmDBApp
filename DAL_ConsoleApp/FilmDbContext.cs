using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DAL;
using System.Data.Entity.ModelConfiguration.Conventions;

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
        public DbSet<CharacterActor> CharacterActor { get; set; }
        public DbSet<FilmType> FilmType { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Film>()
            //    .HasMany<Actor>(s => s.Actors)
            //    .WithMany(c => c.Films)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("FilmRefId");
            //        cs.MapRightKey("ActorRefId");
            //        cs.ToTable("FilmActor");
            //    });
        }

    }
}
