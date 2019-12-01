using System;
using System.Data.Entity;
using System.IO;
using DAL;

namespace DAL_ConsoleApp
{



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating database FilmDB...");
            using (var ctx = new FilmDbContext())
            {
                var stud = new Actor() { ActorID = 12385, Name = "Bitches", Surname = "Yeahrik" };
                var stud1 = new Actor() { ActorID = 12356, Name = "Yeah", Surname = "Yeahrik" };


                // pas de validation de donées au changement de la bd
                ctx.Configuration.ValidateOnSaveEnabled = false;
                //ctx.Actors.Add(stud);
                //ctx.Actors.Add(stud1);




                if (readAnddecodeline() == true)
                {

                    Console.WriteLine("Yeah!");
                }




                //ctx.SaveChanges();
            }
            Console.WriteLine("Done!");

        }

        private static bool readAnddecodeline()
        {
            StreamReader f = new StreamReader(@"C:\Users\stasy\Desktop\CSharpDotNet\Labo\DossierFinal\MyFilms\DAL_ConsoleApp\res\fewlinesFilms.txt");

            string line = f.ReadLine();
            if (line == null)
                return false;

            // Creation d'un objet film
            //FilmParser filmtext = new FilmParser();
            //Film film = filmtext.DecodeFilmText(line);
            Film film = FilmParser.DecodeFilmText(line);

            Console.WriteLine("film lu : " + film.ToString());

            //SaveFilmToDataBase(film);
            return true;
        }

    }
}
