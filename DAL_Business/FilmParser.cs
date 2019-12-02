using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL_Business
{
    public class FilmParser
    {
        #region var prop
        private FilmDbContext dbContxt;
        private List<FilmType> listGenres;
        private List<Actor> listActors;

        public FilmDbContext DbContxt { get => dbContxt; set => dbContxt = value; }
        public List<FilmType> ListFilmTypes { get => listGenres; set => listGenres = value; }
        public List<Actor> ListActors { get => listActors; set => listActors = value; }
        #endregion
        public FilmParser()
        {
            DbContxt = null;
            ListFilmTypes = new List<FilmType>();
            ListActors = new List<Actor>();
        }
        public FilmParser(FilmDbContext ctx)
        {
            DbContxt = ctx;
            ListFilmTypes = new List<FilmType>();
            ListActors = new List<Actor>();
        }

        // fct : recopie nb lignes du fichier texte, return list<string>
        private List<string> getTextLines(int nb)
        {
            int i = 0;
            List<string> textLines = new List<string>();
            StreamReader sr = new StreamReader(@"C:\Users\stasy\Desktop\movies_v2.txt");

            while (i < nb)
            {
                textLines.Add(sr.ReadLine());
                i++;
            }
            return textLines;
        }

        // fct : sauvegarde nbl lignes lues (une par film) dans la bd
        public void SaveFilmsToDB(int nbl)
        {
            Film film;
            List<String> textLines = getTextLines(nbl);
            foreach (string s in textLines)
            {
                film = new Film();

                film = lireFilmLine(s);
                dbContxt.Films.Add(film);
                Console.WriteLine("Film Ajoute au DbContext : " + film.FilmID + "\t" + film.Title + "\t" + film.Runtime);

                dbContxt.SaveChanges();
            }

        }


        // fct : lit un string (ligne du fich txt) et crée objet DAL Film, return Film
        private Film lireFilmLine(string str)
        {
            Film film = new Film();

            string[] filmTokens;
            Char[] delimiterChars = { '‣' };
            filmTokens = str.Split(delimiterChars);
            delimiterChars[0] = '\u2016';

            film.FilmID = Int32.Parse(filmTokens[0]);

            try {
                film.Title = filmTokens[1];
            }
            catch (Exception e) {
                Console.WriteLine("(Title) Erreur : " + e);
                film.Title = "Unknown";
            }

            try {
                film.Runtime = Int32.Parse(filmTokens[7]);
            }
            catch (Exception e) {
                Console.WriteLine("(Runtime) Erreur : " + e);
                film.Runtime = -1;
            }

            try {
                film.Posterpath = filmTokens[9];
            }
            catch (Exception e) {
                Console.WriteLine("(Posterpath) Erreur : " + e);
                film.Posterpath = "Unknown";
            }

            // cherche liste FilmTypes du film, ajoute film dans liste films de chaque FilmType
            string filmtypes;
            try {
                filmtypes = filmTokens[12];
                film.Filmtypes = getFilmTypes(filmtypes);
                foreach (FilmType ft in film.Filmtypes)
                {
                    ft.Films.Add(film);
                }
            }
            catch (Exception e) {
                Console.WriteLine("(genres) Erreur : " + e);
            }

            // cherche liste Acteurs du film, ajoute film dans liste films de chaque Acteur
            string actors;
            try {
                actors = filmTokens[14];
                film.Actors = getActors(actors);
                foreach (Actor a in film.Actors)
                {
                    a.Films.Add(film);
                }
            }
            catch (Exception e) {
                Console.WriteLine("(acteurs) Erreur : " + e);
            }


            return film;
        }



        // fct : obtenir liste acteurs du film, return liste
        private List<Actor> getActors(string actors)
        {
            List<Actor> Actors = new List<Actor>();
            string[] ActorString;
            string[] ActorTokens;
            Actor NewActor, TempActor;

            Char[] separator = {'‖'};
            ActorString = actors.Split(separator);
            separator[0] = '\u2016';

            // pour chaque acteur du film :
            foreach (string s in ActorString)
            {
                try
                {
                    NewActor = new Actor();
                    ActorTokens = s.Split('․');
                    NewActor.Name = ActorTokens[1];
                    NewActor.ActorID = Int32.Parse(ActorTokens[0]);

                    // tester si acteur existe deja dans la bd 
                    TempActor = dbContxt.Actors.Find(NewActor.ActorID);
                    if (TempActor != null)
                        NewActor = TempActor;
                    else
                    {
                        foreach (Actor a in Actors)
                        {
                            // si même Acteur a déjà été inséré dans la liste du return
                            if (a.ActorID == NewActor.ActorID) throw new Exception("Acteur avec id " + NewActor.ActorID + " a déjà été inséré dans la DB");
                        }

                        foreach (Actor a in listActors)
                        {
                            // si même Acteur a déjà été inséré dans la liste du FilmParser
                            if (a.ActorID == NewActor.ActorID)
                            {
                                NewActor = a;
                                break;
                            }
                        }
                    }
                    
                    listActors.Add(NewActor);
                    Actors.Add(NewActor);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur getActors : " + e.Message);
                }
            }
            return Actors;
        }

        // fct : obtenir liste genres du film, return liste
        private List<FilmType> getFilmTypes(string genres)
        {
            List<FilmType> FilmTypes = new List<FilmType>();
            string[] FilmtypeString;
            string[] FilmtypeTokens;
            FilmType NewFilmtype, TempFilmtype;

            Char[] separator = {'‖'};
            FilmtypeString = genres.Split(separator);
            separator[0] = '\u2016';

            // pour chaque filmtype du film :
            foreach (string s in FilmtypeString)
            {
                try
                {
                    NewFilmtype = new FilmType();
                    FilmtypeTokens = s.Split('․');
                    NewFilmtype.FilmTypeID = Int32.Parse(FilmtypeTokens[0]);
                    NewFilmtype.Name = FilmtypeTokens[1];

                    // tester si filmtype existe deja dans la bd 
                    TempFilmtype = dbContxt.FilmTypes.Find(NewFilmtype.FilmTypeID);
                    if (TempFilmtype != null)
                        NewFilmtype = TempFilmtype;
                    else
                    {
                        foreach (FilmType g in FilmTypes)
                        {
                            // si même FilmType a déjà été inséré dans la liste du return
                            if (g.FilmTypeID == NewFilmtype.FilmTypeID) throw new Exception("Id(" + NewFilmtype.FilmTypeID + ") déjà inséré !");
                        }

                        foreach (FilmType g in ListFilmTypes)
                        {
                            // si même FilmType a déjà été inséré dans la liste du FilmParser
                            if (g.FilmTypeID == NewFilmtype.FilmTypeID)
                            {
                                NewFilmtype = g;
                                break;
                            }
                        }
                    }

                    ListFilmTypes.Add(NewFilmtype);
                    FilmTypes.Add(NewFilmtype);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur getFilmTypes : " + e.Message);
                }
            }
            return FilmTypes;
        }

    }
}
