using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DAL;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL_2
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext() : base("FilmDB")
        {
            Database.SetInitializer<FilmDbContext>(new DropCreateDatabaseIfModelChanges<FilmDbContext>());


        }

        public  DbSet<Film> Films { get; set; }
        public  DbSet<Actor> Actors { get; set; }
        public  DbSet<Character> Characters { get; set; }
        public  DbSet<Comment> Comments { get; set; }
        public  DbSet<CharacterActor> CharacterActor { get; set; }
        public  DbSet<FilmType> FilmTypes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

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
