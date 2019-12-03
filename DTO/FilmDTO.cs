using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class FilmDTO
    {
        #region variables
        private int filmID;
        private string title;
        private DateTime? releaseDate;
        private decimal voteAverage;
        private int runtime;
        private string posterpath;
        #endregion

        #region constructors
        public FilmDTO()
        {
            Title = null;
            ReleaseDate = null;
            VoteAverage = 0;
            Runtime = 0;
            Posterpath = null;



        }
        public FilmDTO(int filmID, string title, DateTime? releaseDate, decimal voteAverage, int runtime, string posterpath)
        {
            FilmID = filmID;
            Title = title;
            ReleaseDate = releaseDate;
            VoteAverage = voteAverage;
            Runtime = runtime;
            Posterpath = posterpath;


        }
        #endregion

        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilmID { get => filmID; set => filmID = value; }
        public string Title { get => title; set => title = value; }
        public DateTime? ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public decimal VoteAverage { get => voteAverage; set => voteAverage = value; }
        public int Runtime { get => runtime; set => runtime = value; }
        public string Posterpath { get => posterpath; set => posterpath = value; }


        #endregion

        #region methods
        public override string ToString()
        {
            return "(ToString)Film:" +
                "\tFilmId=" + FilmID +
                "\tTitle=" + Title +
                "\tReleaseDate=" + ReleaseDate +
                "\tVoteAverage=" + VoteAverage +
                "\tRuntime=" + Runtime +
                "\tPosterpath=" + Posterpath;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
