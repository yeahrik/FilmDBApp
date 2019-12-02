using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DTO
{
    [DataContract(Name = "ActorDTO")]
    public class ActorDTO
    {

        #region variables
        private int actorID;
        private string name;
        private string surname;

        // foreign keys
        private ICollection<FilmDTO> films;
        private ICollection<CharacterActorDTO> characterActors;
        #endregion

        #region constructors
        public ActorDTO()
        {
            // many to many with Films
            this.Films = new HashSet<FilmDTO>();
            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActorDTO>();

        }
        public ActorDTO(int actorID, string name, string surname)
        {
            ActorID = actorID;
            Name = name;
            Surname = surname;

            // many to many with Films
            this.Films = new HashSet<FilmDTO>();
            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActorDTO>();

        }
        public ActorDTO(string text) // Constructeur d’objet Actor
        {
            string[] acteurdetail, characterdetail;
            string tmp;
            Char[] delimiterChars = { '\u2024' };
            acteurdetail = text.Split(delimiterChars);
            ActorID = Int32.Parse(acteurdetail[0]);
            Name = acteurdetail[1];
            delimiterChars[0] = '/';
            tmp = acteurdetail[2];
            characterdetail = tmp.Split(delimiterChars);
            Surname = characterdetail[0];
        }

        #endregion

        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember(Name = "ActorID")]
        public int ActorID { get => actorID; set => actorID = value; }
        [DataMember(Name = "ActorName")]
        public string Name { get => name; set => name = value; }
        [DataMember(Name = "ActorSurname")]
        public string Surname { get => surname; set => surname = value; }
        public virtual ICollection<FilmDTO> Films { get { return films = films ?? new HashSet<FilmDTO>(); } set => films = value; }
        public virtual ICollection<CharacterActorDTO> CharacterActors { get { return characterActors = characterActors ?? new HashSet<CharacterActorDTO>(); } set => characterActors = value; }

        #endregion

        #region methods
        public override string ToString()
        {
            return "(ToString)Actor:" +
                "\tActorID=" + ActorID +
                "\tName=" + Name +
                "\tSurname=" + Surname;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
