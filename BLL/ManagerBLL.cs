using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Business;
using DAL;

namespace BLL
{
    public class ManagerBLL
    {
        #region var prop
        DALManager _DAL_Manager;
        public DALManager DALManager { get => _DAL_Manager; set => _DAL_Manager = value; }
        #endregion

        #region constructors
        public ManagerBLL()
        {
            DALManager = new DALManager();
        }
        #endregion



        #region Fonctions d'encapsulation BLL
        public List<FilmDTO> GetListFilmsByIdActor(int ActorIDch)
        {
            IQueryable<Actor> actors = DALManager.GetActors();

            var query = actors.Where(a => a.ActorID == ActorIDch);


            Actor actor;
            // lance exception si plusieurs résultats, renvoie liste vide
            try
            {
                actor = query.Single<Actor>();
            }
            catch (InvalidOperationException)
            {
                return new List<FilmDTO>();
            }


            // Récupérer films de l'acteur
            ICollection<Film> listFilm = actor.Films;

            List<FilmDTO> listFilmDTO = new List<FilmDTO>();

            // Remplir liste FilmDTO
            foreach (Film film in listFilm)
            {
                listFilmDTO.Add(new FilmDTO(film.FilmID, film.Title, film.ReleaseDate, film.VoteAverage, film.Runtime, film.Posterpath));

            }

            return listFilmDTO;
        }

        //public List<MovieTypeDTO> GetMovieTypeListByMovieId(int idMovie)
        //{

        //    IQueryable<Movie> movies = _dALManager.GetMovies();

        //    var query = movies.Where(m => m.ID == idMovie);


        //    Movie movie;
        //    try
        //    {
        //        movie = query.Single<Movie>();
        //    }
        //    catch (InvalidOperationException e)
        //    {
        //        return new List<MovieTypeDTO>();
        //    }



        //    List<Genre> listgenre = movie.Genres;

        //    List<MovieTypeDTO> listgenreDTO = new List<MovieTypeDTO>();

        //    foreach (Genre genre in listgenre)
        //    {
        //        listgenreDTO.Add(new MovieTypeDTO(genre.ID, genre.Name));
        //    }

        //    return listgenreDTO;
        //}

        public List<FilmDTO> FindListFilmByPartialActorName(String actorName)
        {

            IQueryable<Film> films = DALManager.GetFilms();

            IQueryable<Actor> actors = DALManager.GetActors();

            // chercher acteurs ayant %actorName% comme nom, renvoyer liste de leur films
            var query = actors.Where<Actor>(a => a.Name.Contains(actorName)).Select(a => a.Films);

            // Pour chaque ListeFilms de chaque Actor trouvé
            List<FilmDTO> ListFilmsDTO = new List<FilmDTO>();
            foreach (HashSet<Film> ListeFilmsTrouv in query)
            {
                foreach (Film film in ListeFilmsTrouv)
                {
                    // Transformer en liste de FilmDTO, ajouter films dans cette liste
                    if (!ListFilmsDTO.Exists(f => f.FilmID == film.FilmID))
                        ListFilmsDTO.Add(new FilmDTO(film.FilmID, film.Title, film.ReleaseDate, film.VoteAverage, film.Runtime, film.Posterpath));
                }
            }

            return ListFilmsDTO;
        }

        //public List<LightActorDTO> GetFavoriteActors()
        //{
        //    IQueryable<Actor> actors = _dALManager.GetActors();

        //    IQueryable<Actor> query = actors.Where<Actor>(a => a.Movies.Count > 1);

        //    List<LightActorDTO> listActor = new List<LightActorDTO>();

        //    foreach (Actor actor in query)
        //    {
        //        listActor.Add(new LightActorDTO(actor.Name, actor.Movies.Count));
        //    }

        //    return listActor;
        //}

        //public MovieFullDTO GetMovieFullDetailsByMovieId(int idMovie)
        //{

        //    //import dal
        //    IQueryable<Movie> movies = _dALManager.GetMovies();

        //    //Recup movie

        //    IQueryable<Movie> queryMovie = movies.Where<Movie>(m => m.ID == idMovie);

        //    Movie movie = queryMovie.First<Movie>();

        //    //Recup Acteur

        //    List<ActorDTO> actorsInMovie = new List<ActorDTO>();

        //    foreach (Actor actor in movie.Actors)
        //    {
        //        actorsInMovie.Add(new ActorDTO(actor.ID, actor.Name));
        //    }

        //    //Recup Genre

        //    List<MovieTypeDTO> genresInMovie = new List<MovieTypeDTO>();

        //    foreach (Genre genre in movie.Genres)
        //    {
        //        genresInMovie.Add(new MovieTypeDTO(genre.ID, genre.Name));
        //    }


        //    return new MovieFullDTO(movie.ID, movie.Title, movie.Runtime, movie.PosterPath, genresInMovie, actorsInMovie);
        //}

        //public void InsertCommentOnMovieId(CommentDTO comment)
        //{
        //    _dALManager.AddComment(comment.Content, comment.Rate, comment.IDFilm, comment.Avatar, DateTime.Now);
        //}
#endregion


    }
}
