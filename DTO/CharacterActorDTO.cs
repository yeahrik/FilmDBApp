using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace DTO
{
    [DataContract(Name = "CharacterActorDTO")]
    public class CharacterActorDTO
    {

        #region variables
        //private int characterID;
        //private int actorID;
        //private int filmID;
        private int id;


        private CharacterDTO character;
        private Actor actor;
        private FilmDTO film;
        #endregion

        #region constructors
        public CharacterActorDTO()
        {
        }
        #endregion

        #region properties        
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Key, Column("CharacterActorID", Order = 0), ForeignKey("Actors")]
        //public int ActorID { get => actorID; set => actorID = value; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Key, Column("CharacterActorID", Order = 1), ForeignKey("Films")]
        //public int FilmID { get => filmID; set => filmID = value; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Key, Column("CharacterActorID", Order = 2), ForeignKey("Characters")]
        //public int CharacterID { get => characterID; set => characterID = value; }
        [DataMember(Name = "CharacterActorID")]
        public int Id { get => id; set => id = value; }
        public virtual Actor Actor { get => actor; set => actor = value; }
        public virtual FilmDTO Film { get => film; set => film = value; }
        public virtual CharacterDTO Character { get => character; set => character = value; }
        #endregion

        #region methods
        public override string ToString()
        {
            return "(ToString)FilmActorCharacter:" + Id + 
                //FilmID + ", " + ActorID + ", " + CharacterID +
            "\tfilm=" + film +
            "\tactor=" + actor +
            "\tcharacter=" + character;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
