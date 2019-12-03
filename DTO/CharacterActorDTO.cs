using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
    public class CharacterActor
    {

        #region variables
        //private int characterID;
        //private int actorID;
        //private int filmID;
        private int id;

        #endregion

        #region constructors
        public CharacterActor()
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

        public int Id { get => id; set => id = value; }

        #endregion

        #region methods
        public override string ToString()
        {
            return "(ToString)FilmActorCharacter:" + Id; // + 
                //FilmID + ", " + ActorID + ", " + CharacterID +
            //"\tfilm=" + film +
            //"\tactor=" + actor +
            //"\tcharacter=" + character;
        }
        public void Affiche()
        {
            Console.WriteLine(ToString());
        }
        #endregion
    }
}
