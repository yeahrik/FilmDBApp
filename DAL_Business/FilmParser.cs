using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace DAL_Business
{
    public class FilmParser
    {
        #region var prop
        private FilmDbContext dbContxt;
        private List<FilmType> listGenres;
        private List<Actor> listActors;

        public FilmDbContext DbContxt { get => dbContxt; set => dbContxt = value; }
        public List<FilmType> ListGenres { get => listGenres; set => listGenres = value; }
        public List<Actor> ListActors { get => listActors; set => listActors = value; }
        #endregion
        public FilmParser()
        {
            DbContxt = null;
            ListGenres = new List<FilmType>();
            ListActors = new List<Actor>();
        }
        public FilmParser(FilmDbContext ctx)
        {
            DbContxt = ctx;
            ListGenres = new List<FilmType>();
            ListActors = new List<Actor>();
        }

        private List<string> getTextLines(int nb)
        {
            int i = 0;
            List<string> textLines = new List<string>();
            StreamReader sr = new StreamReader(@"C:\Users\stasy\Desktop\CSharpDotNet\Labo\DossierFinal\MyFilms\DAL_ConsoleApp\res\movies_v2.txt");

            while (i < nb)
            {
                textLines.Add(sr.ReadLine());
                i++;
            }
            return textLines;
        }


        public void SaveFilmsToDB(int nbl)
        {
            Film film;
            List<String> textLines = getTextLines(nbl);
            foreach (string s in textLines)
            {
                film = new Film();
                //try
                //{
                film = lireFilmLine(s);

                dbContxt.Films.Add(film);
                Console.WriteLine("Film Added : " + film.FilmID + "|" + film.Title + "|" + film.Runtime);
                dbContxt.SaveChanges();
                //}
                //catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                //{
                //    //Console.WriteLine("Impossible d'ajouter le film !");
                //    //Console.WriteLine(e.InnerException);
                //}
            }

        }


        /// TODO : enle
        private Film lireFilmLine(string str)
        {
            Film film = new Film();

            string[] filmTokens;
            Char[] delimiterChars = { '‣' };
            filmTokens = str.Split(delimiterChars);
            delimiterChars[0] = '\u2016';

            film.FilmID = Int32.Parse(filmTokens[0]);

            try
            {
                film.Title = filmTokens[1];
            }
            catch (Exception e)
            {
                Console.WriteLine("(Title) Erreur : " + e);
                film.Title = null;
            }

            try
            {
                film.Runtime = Int32.Parse(filmTokens[7]);
            }
            catch (Exception e)
            {
                Console.WriteLine("(Runtime) Erreur : " + e);
                film.Runtime = -1;
            }

            try
            {
                film.Posterpath = filmTokens[9];
            }
            catch (Exception e)
            {
                Console.WriteLine("(Posterpath) Erreur : " + e);
                film.Posterpath = null;
            }

            string genres;
            try
            {
                genres = filmTokens[12];
                film.Filmtypes = getFilmTypes(genres);
                foreach (FilmType ft in film.Filmtypes)
                {
                    ft.Films.Add(film);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("(genres) Erreur : " + e);
            }

            string acteurs;
            try
            {
                acteurs = filmTokens[14];
                film.Actors = getActors(acteurs);
                foreach (Actor a in film.Actors)
                {
                    a.Films.Add(film);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("(acteurs) Erreur : " + e);
            }

            return film;
        }



        //// TODO : rectify UNTOUCHED below
        private List<Actor> getActors(string actors)
        {
            List<Actor> Actors = new List<Actor>();
            string[] actorString;
            string[] caracActor;
            Actor act, tempActor;
            Char[] delimiterChars = { '‖' };
            actorString = actors.Split(delimiterChars);
            delimiterChars[0] = '\u2016';

            foreach (string s in actorString)
            {
                try
                {
                    act = new Actor();
                    caracActor = s.Split('․');
                    act.ActorID = Int32.Parse(caracActor[0]);
                    act.Name = caracActor[1];

                    tempActor = dbContxt.Actors.Find(act.ActorID);
                    if (tempActor != null)
                        act = tempActor;
                    else
                    {
                        foreach (Actor a in Actors)
                        {
                            if (a.ActorID == act.ActorID) throw new Exception("Id(" + act.ActorID + ") déjà inséré !");
                        }

                        foreach (Actor a in listActors)
                        {
                            if (a.ActorID == act.ActorID)
                            {
                                act = a;
                                break;
                            }
                        }
                    }

                    listActors.Add(act);
                    Actors.Add(act);
                }
                catch (Exception e)
                {
                    Console.WriteLine("getActors Log : " + e.Message);
                }
            }
            return Actors;
        }

        private List<FilmType> getFilmTypes(string genres)
        {
            List<FilmType> Genres = new List<FilmType>();
            string[] genreString;
            string[] caracActor;
            FilmType gen, tempGenre;
            Char[] delimiterChars = { '‖' };
            genreString = genres.Split(delimiterChars);
            delimiterChars[0] = '\u2016';

            foreach (string s in genreString)
            {
                try
                {
                    gen = new FilmType();
                    caracActor = s.Split('․');
                    gen.FilmTypeID = Int32.Parse(caracActor[0]);
                    gen.Name = caracActor[1];

                    tempGenre = dbContxt.FilmTypes.Find(gen.FilmTypeID);
                    if (tempGenre != null)
                        gen = tempGenre;
                    else
                    {
                        foreach (FilmType g in Genres)
                        {
                            if (g.FilmTypeID == gen.FilmTypeID) throw new Exception("Id(" + gen.FilmTypeID + ") déjà inséré !");
                        }

                        foreach (FilmType g in ListGenres)
                        {
                            if (g.FilmTypeID == gen.FilmTypeID)
                            {
                                gen = g;
                                break;
                            }
                        }
                    }

                    ListGenres.Add(gen);
                    Genres.Add(gen);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : " + e.Message);
                }
            }
            return Genres;
        }

    }
}
