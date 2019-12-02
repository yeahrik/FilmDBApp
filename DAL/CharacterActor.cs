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
        private int characterID;
        private int actorID;
        private int filmID;

        private Character character;
        private Actor actor;
        private Film film;
        #endregion

        #region constructors
        public CharacterActor()
        {
        }
        //public CharacterActor(Character character, Actor actor, int characterActorID)
        //{
        //    Character = character;
        //    Actor = actor;
        //}
        #endregion

        #region properties        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 1)]
        public int ActorID { get => actorID; set => actorID = value; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 0)]
        public int FilmID { get => filmID; set => filmID = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 2)]
        public int CharacterID { get => characterID; set => characterID = value; }

        public virtual Actor Actor { get => actor; set => actor = value; }
        public virtual Film Film { get => film; set => film = value; }
        public virtual Character Character { get => character; set => character = value; }
        #endregion

        #region methods
        public override string ToString()
        {
            return "(ToString)FilmActorCharacter:" + FilmID + ", " + ActorID + ", " + CharacterID +
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
