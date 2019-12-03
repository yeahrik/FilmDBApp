using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Business;
using DTO;

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
            // lance exception si plusieurs résultats 
            try
            {
                actor = query.Single<Actor>();
            }
            catch (InvalidOperationException)
            {
                return new List<FilmDTO>();
            }



            ICollection<Film> listFilm = actor.Films;
            List<FilmDTO> listFilmDTO = new List<FilmDTO>();
            // Construire list FilmDTO
            foreach (Film film in listFilm)
            {
                listFilmDTO.Add(new FilmDTO(film.FilmID, film.Title, film.ReleaseDate, film.VoteAverage, film.Runtime, film.Posterpath));

            }

            return listFilmDTO;
        }

  

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


        

        public List<LightFilmDTO> GetFavoriteFilms()
        {
            IQueryable<Film> films = DALManager.GetFilms();

            //IQueryable<Film> query = films.Where<Actor>(a => a.Movies.Count > 1);

            // Chercher 10 films avec VoteAverage le plus grand
            IQueryable<Film> query = films.OrderByDescending(i => i.VoteAverage).Take(10);


            List<LightFilmDTO> ListFilmDTO = new List<LightFilmDTO>();

            foreach (Film f in query)
            {
                
                ListFilmDTO.Add(new LightFilmDTO(f.Title, f.VoteAverage));

            }

            return ListFilmDTO;
        }


        public FullActorDTO GetFullActorDetailsByIdActor(int actorID)
        {

            
            IQueryable<Actor> movies = DALManager.GetActors();

            // Récupérer acteur de cet id
            IQueryable<Actor> query_actor = movies.Where<Actor>(a => a.ActorID == actorID);
            Actor actor = query_actor.First<Actor>();

            // Récupérer films qu'il a joué
            List<FilmDTO> ListFilmsDTO = new List<FilmDTO>();

            foreach (Film film in actor.Films)
            {
                ListFilmsDTO.Add(new FilmDTO(film.FilmID, film.Title, film.ReleaseDate, film.VoteAverage, film.Runtime, film.Posterpath));
            }

            // Récupérer characteractors
            List<CharacterActorDTO> ListCharacterActorDTO = new List<CharacterActorDTO>();

            foreach (CharacterActor ca in actor.CharacterActors)
            {
                ListCharacterActorDTO.Add(new CharacterActorDTO(ca.Id));
            }


            return new FullActorDTO(actor.ActorID, actor.Name, actor.Surname, ListFilmsDTO, ListCharacterActorDTO);
        }

       

        public void InsertCommentOnMovieId(CommentDTO comment)
        {
            DALManager.AddComment(comment.Content, comment.Rate, comment.Avatar, DateTime.Now, comment.IdActor);
        }
        #endregion


        // finir
        //public List<CharacterDTO> GetListCharacterByIdActorAndIdFilm(int ActorIDch)
        //{
        //    IQueryable<Actor> actors = DALManager.GetActors();

        //    var query = actors.Where(a => a.ActorID == ActorIDch);


        //    Actor actor;
        //    // lance exception si plusieurs résultats 
        //    try
        //    {
        //        actor = query.Single<Actor>();
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        return new List<FilmDTO>();
        //    }



        //    ICollection<Film> listFilm = actor.Films;
        //    List<FilmDTO> listFilmDTO = new List<FilmDTO>();
        //    // Construire list FilmDTO
        //    foreach (Film film in listFilm)
        //    {
        //        listFilmDTO.Add(new FilmDTO(film.FilmID, film.Title, film.ReleaseDate, film.VoteAverage, film.Runtime, film.Posterpath));

        //    }

        //    return listFilmDTO;
        //}


    }
}
