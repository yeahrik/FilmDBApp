using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace Eval1_Tests_BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerBLL MyManagerBLL = new ManagerBLL();
            String input;


            Console.Out.WriteLine("----- TEST BLL -----");

            Console.Out.WriteLine("----- GetListFilmsByIdActor -----");
            Console.Out.WriteLine("----- Veullez entrer un ActorID : -----");
            input = Console.In.ReadLine();
            Console.Out.WriteLine("----- Results -----");
            List<FilmDTO> ListFilmDTO = MyManagerBLL.GetListFilmsByIdActor(Int32.Parse(input));
            foreach (FilmDTO actor in ListFilmDTO)
            {
                Console.Out.WriteLine(actor.ToString());
            }
            Console.Out.WriteLine("----- EndResults -----");



            Console.Out.WriteLine("----- FindMovieListByPartialActorName -----");
            Console.Out.WriteLine("----- Veuillez saisir un nom (ou une partie du nom) d'acteur : -----");

            input = Console.In.ReadLine();
            Console.Out.WriteLine("----- Results -----");

            List<FilmDTO> movieDTOs = MyManagerBLL.FindListFilmByPartialActorName(input);
            foreach (FilmDTO movie in movieDTOs)
            {
                Console.Out.WriteLine(movie.ToString());
            }

            Console.Out.WriteLine("----- EndResults -----");



            Console.ReadKey();

        }
    }
}
