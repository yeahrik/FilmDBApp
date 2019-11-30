using System;

namespace DAL
{
    public class Film
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
        public Film()
        {
        }
        public Film(int filmID, string title, DateTime? releaseDate, decimal voteAverage, int runtime, string posterpath)
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
