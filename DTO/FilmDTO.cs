using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DTO
{
    [DataContract(Name = "FilmDTO")]
    public class FilmDTO
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
        private ICollection<FilmTypeDTO> filmtypes;
        private ICollection<CharacterActorDTO> characterActors;


        #endregion

        #region constructors
        public FilmDTO()
        {
            Title = null;
            ReleaseDate = null;
            VoteAverage = 0;
            Runtime = 0;
            Posterpath = null;
            // many to many with Actors
            this.Actors = new HashSet<Actor>();
            this.Filmtypes = new HashSet<FilmTypeDTO>();
            this.CharacterActors = new HashSet<CharacterActorDTO>();


        }
        public FilmDTO(int filmID, string title, DateTime? releaseDate, decimal voteAverage, int runtime, string posterpath)
        {
            FilmID = filmID;
            Title = title;
            ReleaseDate = releaseDate;
            VoteAverage = voteAverage;
            Runtime = runtime;
            Posterpath = posterpath;

            // many to many with Actors
            this.Actors = new HashSet<Actor>();
            this.Filmtypes = new HashSet<FilmTypeDTO>();
            this.CharacterActors = new HashSet<CharacterActorDTO>();

        }
        #endregion

        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember(Name = "FilmID")]
        public int FilmID { get => filmID; set => filmID = value; }
        [DataMember(Name = "FilmTitle")]
        public string Title { get => title; set => title = value; }
        [DataMember(Name = "FilmReleaseDate")]
        public DateTime? ReleaseDate { get => releaseDate; set => releaseDate = value; }
        [DataMember(Name = "FilmVoteAverage")]
        public decimal VoteAverage { get => voteAverage; set => voteAverage = value; }
        [DataMember(Name = "FilmRuntime")]
        public int Runtime { get => runtime; set => runtime = value; }
        [DataMember(Name = "FilmPosterpath")]
        public string Posterpath { get => posterpath; set => posterpath = value; }
        
        public virtual ICollection<Actor> Actors        { get { return actors = actors ?? new HashSet<Actor>(); } set => actors = value; }
        
        public virtual ICollection<FilmTypeDTO> Filmtypes  { get { return filmtypes = filmtypes ?? new HashSet<FilmTypeDTO>(); } set => filmtypes = value; }
        
        public virtual ICollection<CharacterActorDTO> CharacterActors { get { return characterActors = characterActors ?? new HashSet<CharacterActorDTO>(); } set => characterActors = value; }

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
