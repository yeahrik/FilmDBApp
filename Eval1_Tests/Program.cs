using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL_Business;


namespace Eval1_Tests
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating dbContext...");
            FilmDbContext dbContxt = new FilmDbContext();

            Console.WriteLine("Creating FilmParser... ");
            FilmParser dec = new FilmParser(dbContxt);

            Console.WriteLine("Parsing movies... ");
            dec.SaveFilmsToDB(1);
            Console.WriteLine("Parsing movies finished ");

            Console.WriteLine("\nLa DB contient : ");
            int nb_Films = dbContxt.Films.Count();
            int nb_Acteurs = dbContxt.Actors.Count();
            Console.WriteLine(nb_Films + " films");
            Console.WriteLine(nb_Acteurs + " acteurs");




            // Lire les 5 premiers films
            IQueryable<Film> listes = dbContxt.Films.Take(5);
            foreach (Film m in listes)
            {
                m.Affiche();
                Console.WriteLine(" ");
            }

            Console.ReadKey();
            //System.Environment.Exit(0);

        }

    }
}
