using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DAL;
using System.Threading.Tasks;

namespace DAL_2///////TODO
{
    public class DALManager
    {
        private FilmDbContext dbContxt;
        public DALManager()
        {
            dbContxt = new FilmDbContext();
            if (!dbContxt.Database.Exists())  // Vérifier si la DB existe
            {
                Console.WriteLine("Création et remplissage de la DB... !");
                dbContxt.Database.Create();
                FilmParser dec = new FilmParser(dbContxt);
                dec.SaveFilmsToDB(1000);
            }
        }

        #region EtapeDAL
        public IQueryable<Actor> GetActors()
        {
            return dbContxt.Actors;
        }

        public IQueryable<FilmType> GetGenres()
        {
            return dbContxt.FilmTypes;
        }

        public IQueryable<Film> GetMovies()
        {
            return dbContxt.Films;
        }

        public IQueryable<Comment> GetComments()
        {
            return dbContxt.Comments;
        }

        public void AddComment(String content, int rate, string avatar, DateTime date, int actorID)
        {
            dbContxt.Comments.Add(new Comment(content, rate, avatar, date, actorID));
            dbContxt.SaveChanges();
        }
        #endregion
    }
}
