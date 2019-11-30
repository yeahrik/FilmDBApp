using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Actor
    {

        #region variables
        private int actorID;
        private string name;
        private string surname;
        #endregion

        #region constructors
        public Actor()
        {
        }
        public Actor(int actorID, string name, string surname)
        {
            ActorID = actorID;
            Name = name;
            Surname = surname;
        }
        #endregion

        #region properties
        public int ActorID { get => actorID; set => actorID = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }

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
