using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DTO;

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
            if (!string.IsNullOrEmpty(input))
            {
                Console.Out.WriteLine("----- Results -----");
                List<FilmDTO> ListFilmDTO = MyManagerBLL.GetListFilmsByIdActor(Int32.Parse(input));
                foreach (FilmDTO actor in ListFilmDTO)
                {
                    Console.Out.WriteLine(actor.ToString());
                }
                Console.Out.WriteLine("----- EndResults -----");
            }
            else
            {
                Console.Out.WriteLine("Erreur de input : input vide");
            }

            //Console.Out.WriteLine("----- GetMovieTypeListByMovieId -----");
            //input = Console.In.ReadLine();
            //Console.Out.WriteLine("----- Results -----");

            //List<MovieTypeDTO> movieTypeDTOs = MyManagerBLL.GetMovieTypeListByMovieId(Int32.Parse(input));
            //foreach (MovieTypeDTO movieType in movieTypeDTOs)
            //{
            //    Console.Out.WriteLine(movieType.ToString());
            //}

            //Console.Out.WriteLine("----- EndResults -----");

            Console.Out.WriteLine("----- FindMovieListByPartialActorName -----");
            Console.Out.WriteLine("----- Veuillez saisir un nom (ou une partie du nom) d'acteur : -----");
            input = Console.In.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                Console.Out.WriteLine("----- Results -----");
                List<FilmDTO> movieDTOs = MyManagerBLL.FindListFilmByPartialActorName(input);
                foreach (FilmDTO movie in movieDTOs)
                {
                    Console.Out.WriteLine(movie.ToString());
                }
                Console.Out.WriteLine("----- EndResults -----");
            }
            else
            {
                Console.Out.WriteLine("Erreur de input : input vide");
            }


            Console.Out.WriteLine("----- GetFavoriteFilms -----");
            Console.Out.WriteLine("----- Results -----");
            List<LightFilmDTO> ListLightFilmDTO = MyManagerBLL.GetFavoriteFilms();
            foreach (LightFilmDTO lightFilm in ListLightFilmDTO)
            {
                Console.Out.WriteLine(lightFilm.ToString());
            }
            Console.Out.WriteLine("----- EndResults -----");






            Console.Out.WriteLine("----- GetFullActorDetailsByIdActor -----");
            Console.Out.WriteLine("----- Veuillez entrer un ActorID -----");
            input = Console.In.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                Console.Out.WriteLine("----- Results -----");

                FullActorDTO fullActorDTO = MyManagerBLL.GetFullActorDetailsByIdActor(Int32.Parse(input));
                Console.Out.Write(fullActorDTO.ToString());
                Console.Out.WriteLine("\n----- EndResults -----");

                
            }
            else
            {
                Console.Out.WriteLine("Erreur de input : input vide");
            }




            Console.Out.WriteLine("----- InsertCommentOnActorId -----");
            Console.Out.Write("Content : ");
            String content = Console.In.ReadLine();
            Console.Out.Write("Rate : ");
            int rate = Int32.Parse(Console.In.ReadLine());
            Console.Out.Write("Avatar : ");
            String avatar = Console.In.ReadLine();
            Console.Out.Write("ActorID : ");
            int actorID = Int32.Parse(Console.In.ReadLine());
            if (!string.IsNullOrEmpty(content) && !string.IsNullOrEmpty(avatar) && actorID != 0)
            {
                try
                {
                    CommentDTO commentDTO = new CommentDTO(content, rate, avatar, DateTime.Now, actorID);
                    Console.Out.WriteLine("----- SendingComment -----");

                    MyManagerBLL.InsertCommentOnMovieId(commentDTO);

                    Console.Out.WriteLine("----- Comment Sent ! -----");
                    Console.Out.WriteLine("----- Comments in ddContext : -----");
                    List<Comment> ListComments = new List<Comment>(MyManagerBLL.DALManager.GetComments());
                    foreach (Comment c in ListComments)
                    {
                        Console.Out.WriteLine(c.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.ToString());
                    Console.ReadKey();
                    return;

                }


            }
            Console.ReadKey();

        }
    }
}
