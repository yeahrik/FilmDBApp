using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        // foreign keys
        private ICollection<Actor> actors;
        private ICollection<FilmType> filmtypes;

        #endregion

        #region constructors
        public Film()
        {
            Title = null;
            ReleaseDate = null;
            VoteAverage = 0;
            Runtime = 0;
            Posterpath = null;
            // many to many with Actors
            this.Actors = new HashSet<Actor>();
            this.Filmtypes = new HashSet<FilmType>();

        }
        public Film(int filmID, string title, DateTime? releaseDate, decimal voteAverage, int runtime, string posterpath)
        {
            FilmID = filmID;
            Title = title;
            ReleaseDate = releaseDate;
            VoteAverage = voteAverage;
            Runtime = runtime;
            Posterpath = posterpath;

            // many to many with Actors
            this.Actors = new HashSet<Actor>();
            this.Filmtypes = new HashSet<FilmType>();

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
        public virtual ICollection<Actor> Actors        { get { return actors = actors ?? new HashSet<Actor>(); } set => actors = value; }
        public virtual ICollection<FilmType> Filmtypes  { get { return filmtypes = filmtypes ?? new HashSet<FilmType>(); } set => filmtypes = value; }

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
