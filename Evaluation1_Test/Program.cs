using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using DAL;
using DAL_2;

namespace Evaluation1_Test
{
    class Program /// TODO
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Creating database FilmDB...");
            FilmDbContext dbContxt = new FilmDbContext();

            //if (!dbContxt.Database.Exists())  // Vérifier si la DB existe
            //{
                Console.WriteLine("Création/Remplissage de la DB... !");
                //dbContxt.Database.Create();
                FilmParser dec = new FilmParser(dbContxt);
                dec.SaveFilmsToDB(1000);
            //}


            //else
            //    Console.WriteLine("DB existe déjà... !");

            Console.WriteLine("La DB contient : ");

            int nb_Films = dbContxt.Films.Count();
            int nb_Acteurs = dbContxt.Actors.Count();

            Console.WriteLine(nb_Films + " films");
            Console.WriteLine(nb_Acteurs + " acteurs");


            IQueryable<Film> listes = dbContxt.Films.Take(5);

            foreach (Film m in listes)
            {
                m.Affiche();
                Console.WriteLine(" ");
                Console.ReadKey();
            }

            System.Environment.Exit(0);







            //using (var ctx = new FilmDbContext())
            //{
            //    var stud = new Actor() { ActorID = 12385, Name = "Bitches", Surname = "Yeahrik" };
            //    var stud1 = new Actor() { ActorID = 12356, Name = "Yeah", Surname = "Yeahrik" };


            //    // pas de validation de donées au changement de la bd
            //    ctx.Configuration.ValidateOnSaveEnabled = false;
            //    //ctx.Actors.Add(stud);
            //    //ctx.Actors.Add(stud1);


            //    StreamReader f = new StreamReader(@"C:\Users\stasy\Desktop\CSharpDotNet\Labo\DossierFinal\MyFilms\DAL_ConsoleApp\res\fewlinesFilms.txt");

            //    for (int i=0;i<5;i++)
            //    {
            //        Film film = new Film();

            //        if (readAnddecodeline(f) == true) {

            //            Console.WriteLine("Succes lecture et enregistrement!");

            //        }
            //        else {

            //            Console.WriteLine("Probleme de lecture de ligne !");
            //        }

            //    }

            //    //ctx.SaveChanges();
            //}
            //Console.WriteLine("Done!");

        }

        //private static bool readAnddecodeline(StreamReader f)
        //{

        //    string line = f.ReadLine();
        //    if (line == null)
        //        return false;

        //    // Creation d'un objet film
        //    //FilmParser filmtext = new FilmParser();
        //    //Film film = filmtext.DecodeFilmText(line);
        //    Film film = FilmParser.DecodeFilmText(line);

        //    Console.WriteLine("film lu : " + film.ToString());

        //    SaveFilmToDataBase(film);

        //    return true;
        //}


        //// enregistrer
        //private static bool SaveFilmToDataBase(Film film)
        //{
        //    bool res = true;
        //    var ctx = new FilmDbContext();
        //    var NewActors = film.Actors;

        //    // pas de validation de donées au changement de la bd
        //    ctx.Configuration.ValidateOnSaveEnabled = false;
        //    //foreach (Actor actor in NewActors.Where(us => !ctx.Actors.Any(u => u.ActorID == us.ActorID)))
        //    //{
        //    //    //ctx.Actors.Add(actor);
        //    //    ctx.Films.Add(film);

        //    //}
        //    foreach (Actor actor in NewActors)
        //    {
        //        ctx.Entry(actor).State = (AlreadyExists ? EntityState.Modified : EntityState.Added);
        //    }

        //    ctx.SaveChanges();            

        //    return res;
        //}

    }
}
