using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class Actor
    {

        #region variables
        private int actorID;
        private string name;
        private string surname;

        // foreign keys
        private ICollection<Film> films;
        private ICollection<CharacterActor> characterActors;
        #endregion

        #region constructors
        public Actor()
        {
            // many to many with Films
            this.Films = new HashSet<Film>();
            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActor>();

        }
        public Actor(int actorID, string name, string surname)
        {
            ActorID = actorID;
            Name = name;
            Surname = surname;

            // many to many with Films
            this.Films = new HashSet<Film>();
            // one to many with CharAct
            this.CharacterActors = new HashSet<CharacterActor>();

        }
        public Actor(string text) // Constructeur d’objet Actor
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
        public int ActorID { get => actorID; set => actorID = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public virtual ICollection<Film> Films { get { return films = films ?? new HashSet<Film>(); } set => films = value; }
        public virtual ICollection<CharacterActor> CharacterActors { get { return characterActors = characterActors ?? new HashSet<CharacterActor>(); } set => characterActors = value; }

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
